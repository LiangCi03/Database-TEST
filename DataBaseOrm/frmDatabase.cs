using CommonUI.Communication;
using CommonUI.Config;
using CommonUI.CustomControl;
using CommonUI.DataOperate;
using DataBaseOrm.Screw;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static DataBaseOrm.GlobalsVar;


namespace DataBaseOrm
{
    public partial class frmDatabase : Form
    {
        private string _heartbeatAddress = "DB18.78";
        private string _enableReadAddress = "DB18.80";
        private string _codeStatusAddress = "DB18.82";
        private int _lastCodeStatusValue = 0;
        private bool _plcConnected = false;
        private const int BARCODE_READ_LENGTH = 256;
        private DateTime _lastBarcodeReadTime = DateTime.MinValue;
        private const int BARCODE_READ_INTERVAL_MS = 500;
        private bool _heartbeatState = false;
        private DateTime _lastHeartbeatTime = DateTime.MinValue;
        private const int HEARTBEAT_INTERVAL_MS = 1000;
        private bool _autoReconnect = true;

        /// <summary>
        /// 当前加载的条码列配置（JSON格式）
        /// </summary>
        private BarcodeConfig _barcodeConfig;

        // 多产品配置
        private MultiProductConfig _multiProductConfig = new MultiProductConfig();
        private int _selectedProductIndex = 0;
        private bool _isLoadingProduct = false; // 切换产品时阻止误保存
        // cmbProductSelector 已移入设计器
        // txtOkTableName, txtNgTableName 已移入设计器

        // 第二行面板（推卡夹）—— 引用设计器静态创建的控件
        private DataGridView[] _row2Grids;
        private Label[] _row2Titles;

        /// <summary>
        /// 存储从PLC读取到的所有值，key格式为 "{组名}_{列名}"（如 "主码_压力最大"）
        /// </summary>
        private Dictionary<string, string> _barcodeValues = new Dictionary<string, string>();

        /// <summary>
        /// 保护 _barcodeValues 的跨线程访问锁
        /// </summary>
        private readonly object _barcodeValuesLock = new object();

        /// <summary>
        /// 按产品索引存储的条码值（用于主界面切换查看）
        /// </summary>
        private readonly Dictionary<int, Dictionary<string, string>> _allBarcodeValues = new Dictionary<int, Dictionary<string, string>>();

        /// <summary>
        /// 心跳闪烁状态
        /// </summary>
        private bool _heartbeatToggle = false;

        /// <summary>
        /// 连接健康检查计数器
        /// </summary>
        private int _healthCheckCounter = 0;

        public frmDatabase()
        {
            InitializeComponent();
            this.Icon = new System.Drawing.Icon("database.ico");
        }

        MySqlSugarHelper _mySqlSugarHelper;
        //服务器1
        public CommonUI.Config.EthernetConfig _ethernetConfig;
        //服务器2
        public CommonUI.Config.EthernetConfig _ethernetConfig2;
        //服务器3
        public CommonUI.Config.EthernetConfig _ethernetConfig3;

        #region 动态主界面条码字段显示

        /// <summary>
        /// 各组父面板映射
        /// </summary>
        private static readonly Dictionary<string, Panel> GroupParentPanels = new Dictionary<string, Panel>
        {
            { "主码", null },
            { "副码1", null },
            { "副码2", null },
            { "副码3", null },
            { "副码4", null }
        };

        /// <summary>
        /// 初始化主界面各码组的动态显示：
        /// DataGridView 已在 Designer.cs 中静态创建，这里仅配置列和样式
        /// </summary>
        private void InitializeDynamicCodePanels()
        {
            GroupParentPanels["主码"] = pnlMainCode;
            GroupParentPanels["副码1"] = pnlSub1;
            GroupParentPanels["副码2"] = pnlSub2;
            GroupParentPanels["副码3"] = pnlSub3;
            GroupParentPanels["副码4"] = pnlSub4;

            // 隐藏旧的大号值Label（已被 DataGridView 替代）
            var oldValueLabels = new[] { lblMainCodeValue, lblSubCode1Value, lblSubCode2Value, lblSubCode3Value, lblSubCode4Value };
            foreach (var lbl in oldValueLabels)
            {
                if (lbl != null) { lbl.Visible = false; lbl.Dock = DockStyle.None; lbl.Size = new Size(0, 0); }
            }

            // 为第一行5个 DataGridView 设置通用样式和列
            var grids = new[] { dgvMainCode, dgvSubCode1, dgvSubCode2, dgvSubCode3, dgvSubCode4 };
            foreach (var grid in grids)
            {
                SetupDataGridView(grid);
            }

            // === 第二行面板（推卡夹产品）—— 控件已在设计器中静态创建 ===
            var row2Grids = new[] { dgvRow2Main, dgvRow2Sub1, dgvRow2Sub2, dgvRow2Sub3, dgvRow2Sub4 };
            var row2Titles = new[] { lblRow2MainTitle, lblRow2Sub1Title, lblRow2Sub2Title, lblRow2Sub3Title, lblRow2Sub4Title };
            foreach (var grid in row2Grids)
            {
                SetupDataGridView(grid);
            }
            _row2Grids = row2Grids;
            _row2Titles = row2Titles;

            // 隐藏旧的状态标签（设计器中已替换为 tblSummary 双栏布局）
            if (lblMainStatusValue != null) lblMainStatusValue.Visible = false;
            if (lblSubSummaryValue != null) lblSubSummaryValue.Visible = false;

            // 为双产品状态栏添加垂直分隔线
            if (tblSummary != null)
            {
                tblSummary.CellPaint += (s, e) =>
                {
                    if (e.Column == 0 && e.Row == 0)
                    {
                        int midX = tblSummary.Width / 2;
                        using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                        {
                            e.Graphics.DrawLine(pen, midX, 6, midX, tblSummary.Height - 6);
                        }
                    }
                };
            }
        }

        private void SetupDataGridView(DataGridView grid)
        {
            if (grid == null) return;

            // 固定行高，不换行，水平滚动查看长文本
            grid.RowTemplate.Height = 28;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.FromArgb(30, 55, 90),
                SelectionForeColor = Color.FromArgb(30, 55, 90),
                SelectionBackColor = Color.FromArgb(230, 240, 255),
                WrapMode = DataGridViewTriState.False,
                Padding = new Padding(4, 2, 4, 2)
            };

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.FromArgb(240, 242, 245),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            // 列宽自适应内容，长文本出现水平滚动条
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.ScrollBars = ScrollBars.Both;

            if (grid.Columns.Count == 0)
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "FieldName", HeaderText = "字段",
                    FillWeight = 40, MinimumWidth = 60
                });
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "FieldValue", HeaderText = "值",
                    FillWeight = 60, MinimumWidth = 80
                });
            }
        }

        /// <summary>
        /// 刷新单个码组的表格显示（单产品模式）
        /// </summary>
        private void RefreshGroupGridView(string groupName)
        {
            DataGridView grid = GetGridByGroupName(groupName);
            if (grid == null) return;
            if (_barcodeConfig == null) return;
            if (grid.Columns.Count < 2) return;
            if (!grid.Columns.Contains("FieldName") || !grid.Columns.Contains("FieldValue")) return;

            var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null || group.Columns.Count == 0)
            {
                grid.Rows.Clear();
                return;
            }

            string productLabel = grid.Tag as string ?? "";
            int expectedRows = (string.IsNullOrEmpty(productLabel) ? 0 : 1) + group.Columns.Count;

            // 只在行数变化时才重建（保留滚动位置）
            if (grid.Rows.Count != expectedRows)
            {
                grid.Rows.Clear();
                if (!string.IsNullOrEmpty(productLabel))
                {
                    int titleIdx = grid.Rows.Add();
                    grid.Rows[titleIdx].Cells["FieldName"].Value = "▸ " + productLabel;
                    grid.Rows[titleIdx].Cells["FieldValue"].Value = "";
                    grid.Rows[titleIdx].Cells["FieldName"].Style.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
                    grid.Rows[titleIdx].Cells["FieldName"].Style.ForeColor = Color.FromArgb(0, 114, 198);
                    grid.Rows[titleIdx].DefaultCellStyle.BackColor = Color.FromArgb(240, 245, 252);
                }

                foreach (var col in group.Columns)
                {
                    if (col == null) continue;
                    string displayName = string.IsNullOrWhiteSpace(col.DisplayName) ? col.DbColumnName : col.DisplayName;
                    string key = BuildBarcodeValueKey(groupName, col.DbColumnName);
                    string val = "";
                    lock (_barcodeValuesLock) { val = _barcodeValues.TryGetValue(key, out string v) && v != null ? v : ""; }

                    int rowIdx = grid.Rows.Add();
                    grid.Rows[rowIdx].Cells["FieldName"].Value = "  " + displayName;
                    grid.Rows[rowIdx].Cells["FieldValue"].Value = string.IsNullOrEmpty(val) ? "等待PLC数据..." : val;
                    grid.Rows[rowIdx].Cells["FieldValue"].Style.ForeColor = string.IsNullOrEmpty(val)
                        ? Color.FromArgb(180, 180, 180) : Color.FromArgb(0, 114, 198);
                }
                return;
            }

            // 行数不变，只更新值
            int rowOffset = string.IsNullOrEmpty(productLabel) ? 0 : 1;
            for (int i = 0; i < group.Columns.Count; i++)
            {
                var col = group.Columns[i];
                if (col == null) continue;
                string key = BuildBarcodeValueKey(groupName, col.DbColumnName);
                string val = "";
                lock (_barcodeValuesLock) { val = _barcodeValues.TryGetValue(key, out string v) && v != null ? v : ""; }

                int rowIdx = rowOffset + i;
                if (rowIdx < grid.Rows.Count)
                {
                    grid.Rows[rowIdx].Cells["FieldValue"].Value = string.IsNullOrEmpty(val) ? "等待PLC数据..." : val;
                    grid.Rows[rowIdx].Cells["FieldValue"].Style.ForeColor = string.IsNullOrEmpty(val)
                        ? Color.FromArgb(180, 180, 180) : Color.FromArgb(0, 114, 198);
                }
            }

            // 副码设置红绿背景色
            ApplyRowBackgroundByResult(groupName, group, grid, rowOffset);
        }
        /// <summary>
        /// 根据组名获取对应的 DataGridView
        /// </summary>
        private DataGridView GetGridByGroupName(string groupName)
        {
            switch (groupName)
            {
                case "主码": return dgvMainCode;
                case "副码1": return dgvSubCode1;
                case "副码2": return dgvSubCode2;
                case "副码3": return dgvSubCode3;
                case "副码4": return dgvSubCode4;
                default: return null;
            }
        }

        /// <summary>
        /// 根据结果字段为副码行设置背景色（绿=OK，红=NG）
        /// </summary>
        private void ApplyRowBackgroundByResult(string groupName, CodeGroupConfig group, DataGridView grid, int rowOffset)
        {
            // 主码不需要背景色
            if (groupName == "主码") return;

            var resultCol = group.Columns?.FirstOrDefault(c =>
                c?.DbColumnName != null &&
                (c.DbColumnName.Contains("结果") || c.DbColumnName.Contains("OK") || c.DbColumnName.Contains("NG")));
            if (resultCol == null) return;

            string key = BuildBarcodeValueKey(groupName, resultCol.DbColumnName);
            string resultVal = "";
            lock (_barcodeValuesLock) { resultVal = _barcodeValues.TryGetValue(key, out string v) && v != null ? v : ""; }

            if (string.IsNullOrEmpty(resultVal)) return;

            bool isOk = resultVal == "1" || resultVal.Equals("OK", StringComparison.OrdinalIgnoreCase);
            Color rowBack = isOk ? Color.FromArgb(230, 255, 230) : Color.FromArgb(255, 230, 230);
            Color rowFore = isOk ? Color.FromArgb(0, 120, 0) : Color.FromArgb(180, 30, 30);

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (i == 0 && rowOffset > 0) continue; // 跳过标题行
                grid.Rows[i].DefaultCellStyle.BackColor = rowBack;
                if (grid.Rows[i].Cells["FieldValue"].Value != null &&
                    grid.Rows[i].Cells["FieldValue"].Value.ToString() != "等待PLC数据...")
                {
                    grid.Rows[i].Cells["FieldValue"].Style.ForeColor = rowFore;
                }
            }
        }

        /// <summary>
        /// 刷新所有5个码组的表格显示（两个产品分上下两行）
        /// </summary>
        private void RefreshAllGroupGrids()
        {
            if (_multiProductConfig?.Products == null) return;
            var products = _multiProductConfig.Products;

            // 第一行：压装产品（索引0）
            if (products.Count > 0)
            {
                _barcodeConfig = products[0].BarcodeConfig;
                LoadProductValues(0);
                dgvMainCode.Tag = products[0].ProductName;
                dgvSubCode1.Tag = products[0].ProductName;
                dgvSubCode2.Tag = products[0].ProductName;
                dgvSubCode3.Tag = products[0].ProductName;
                dgvSubCode4.Tag = products[0].ProductName;
                RefreshGroupGridView("主码");
                RefreshGroupGridView("副码1");
                RefreshGroupGridView("副码2");
                RefreshGroupGridView("副码3");
                RefreshGroupGridView("副码4");
            }

            // 第二行：推卡夹产品（索引1）
            if (products.Count > 1 && _row2Grids != null)
            {
                _barcodeConfig = products[1].BarcodeConfig;
                LoadProductValues(1);
                _row2Grids[0].Tag = products[1].ProductName;
                _row2Grids[1].Tag = products[1].ProductName;
                _row2Grids[2].Tag = products[1].ProductName;
                _row2Grids[3].Tag = products[1].ProductName;
                _row2Grids[4].Tag = products[1].ProductName;
                RefreshRow2GridView("主码", 0);
                RefreshRow2GridView("副码1", 1);
                RefreshRow2GridView("副码2", 2);
                RefreshRow2GridView("副码3", 3);
                RefreshRow2GridView("副码4", 4);
            }

            // 恢复当前产品配置
            if (products.Count > 0)
                _barcodeConfig = products[_selectedProductIndex].BarcodeConfig;
            LoadProductValues(_selectedProductIndex);
        }

        /// <summary>
        /// 加载指定产品索引的数据到 _barcodeValues
        /// </summary>
        private void LoadProductValues(int productIndex)
        {
            lock (_barcodeValuesLock)
            {
                _barcodeValues.Clear();
                if (_allBarcodeValues.TryGetValue(productIndex, out var values))
                {
                    foreach (var kvp in values)
                        _barcodeValues[kvp.Key] = kvp.Value;
                }
            }
        }

        /// <summary>
        /// 刷新第二行指定组的表格
        /// </summary>
        private void RefreshRow2GridView(string groupName, int gridIndex)
        {
            if (_row2Grids == null || gridIndex >= _row2Grids.Length) return;
            var grid = _row2Grids[gridIndex];
            if (grid == null || _barcodeConfig == null) return;

            if (grid.Columns.Count < 2) return;
            if (!grid.Columns.Contains("FieldName") || !grid.Columns.Contains("FieldValue")) return;

            var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null || group.Columns.Count == 0)
            {
                grid.Rows.Clear();
                return;
            }

            string productLabel = grid.Tag as string ?? "";
            int expectedRows = (string.IsNullOrEmpty(productLabel) ? 0 : 1) + group.Columns.Count;

            // 只在行数变化时才重建
            if (grid.Rows.Count != expectedRows)
            {
                grid.Rows.Clear();
                if (!string.IsNullOrEmpty(productLabel))
                {
                    int titleIdx = grid.Rows.Add();
                    grid.Rows[titleIdx].Cells["FieldName"].Value = "▸ " + productLabel;
                    grid.Rows[titleIdx].Cells["FieldValue"].Value = "";
                    grid.Rows[titleIdx].Cells["FieldName"].Style.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
                    grid.Rows[titleIdx].Cells["FieldName"].Style.ForeColor = Color.FromArgb(0, 114, 198);
                    grid.Rows[titleIdx].DefaultCellStyle.BackColor = Color.FromArgb(240, 245, 252);
                }

                foreach (var col in group.Columns)
                {
                    if (col == null) continue;
                    string displayName = string.IsNullOrWhiteSpace(col.DisplayName) ? col.DbColumnName : col.DisplayName;
                    string key = BuildBarcodeValueKey(groupName, col.DbColumnName);
                    string val = "";
                    lock (_barcodeValuesLock) { val = _barcodeValues.TryGetValue(key, out string v) && v != null ? v : ""; }

                    int rowIdx = grid.Rows.Add();
                    grid.Rows[rowIdx].Cells["FieldName"].Value = "  " + displayName;
                    grid.Rows[rowIdx].Cells["FieldValue"].Value = string.IsNullOrEmpty(val) ? "等待PLC数据..." : val;
                    grid.Rows[rowIdx].Cells["FieldValue"].Style.ForeColor = string.IsNullOrEmpty(val)
                        ? Color.FromArgb(180, 180, 180) : Color.FromArgb(0, 114, 198);
                }
                return;
            }

            // 行数不变，只更新值
            int rowOffset = string.IsNullOrEmpty(productLabel) ? 0 : 1;
            for (int i = 0; i < group.Columns.Count; i++)
            {
                var col = group.Columns[i];
                if (col == null) continue;
                string key = BuildBarcodeValueKey(groupName, col.DbColumnName);
                string val = "";
                lock (_barcodeValuesLock) { val = _barcodeValues.TryGetValue(key, out string v) && v != null ? v : ""; }

                int rowIdx = rowOffset + i;
                if (rowIdx < grid.Rows.Count)
                {
                    grid.Rows[rowIdx].Cells["FieldValue"].Value = string.IsNullOrEmpty(val) ? "等待PLC数据..." : val;
                    grid.Rows[rowIdx].Cells["FieldValue"].Style.ForeColor = string.IsNullOrEmpty(val)
                        ? Color.FromArgb(180, 180, 180) : Color.FromArgb(0, 114, 198);
                }
            }

            // 副码设置红绿背景色
            ApplyRowBackgroundByResult(groupName, group, grid, rowOffset);
        }

        #endregion

        #region PLC读写测试页

        // 模拟PLC数据存储（key=地址如"DB100.80", value=INT16值）
        private Dictionary<string, int> _simulatedPlcData = new Dictionary<string, int>();
        // chkSimMode 已移入设计器

        private void InitPlcTestTab()
        {
            // 控件已在设计器中创建（lblPlcTestTitle + chkSimMode），此处仅绑定动态事件
            var pnlTop = pnlPlcTop;

            // 模拟模式复选框事件
            chkSimMode.CheckedChanged += (s, ev) =>
            {
                bool sim = chkSimMode.Checked;
                btnPlcRead.Text = sim ? "📥 读取(模拟)" : "📥 读取";
                btnPlcWrite.Text = sim ? "📤 写入(模拟)" : "📤 写入";
                if (lblPlcTestTitle != null)
                {
                    lblPlcTestTitle.Text = sim ? "PLC 读写测试 【模拟模式 - 数据仅存内存】" : "PLC 读写测试（支持模拟模式）";
                    lblPlcTestTitle.ForeColor = sim ? Color.FromArgb(231, 76, 60) : Color.FromArgb(30, 55, 90);
                }
            };

            cmbTestDataType.Items.AddRange(new[] { "INT16", "INT32", "STRING", "REAL", "BYTE" });
            cmbTestDataType.SelectedIndex = 0;
        }

        #region PLC测试页 / DB调试页 按钮事件（供设计器绑定）

        private void BtnSimInit_Click(object sender, EventArgs e)
        {
            _simulatedPlcData["DB18.78"] = 0;
            _simulatedPlcData["DB18.80"] = 1;
            _simulatedPlcData["DB18.82"] = 1;
            _simulatedPlcData["DB18.0"] = 0;
            _simulatedPlcData["DB18.100"] = 0;
            _simulatedPlcData["DB18.200"] = 0;
            _simulatedPlcData["DB18.300"] = 0;
            _simulatedPlcData["DB18.400"] = 0;
            AppendPlcTestLog("🔧 模拟数据已初始化（心跳=0, 允许读取=1, 码状态=1）");
        }

        private void BtnDbRefresh_Click(object sender, EventArgs e)
        {
            if (tlpDbInputs == null) return;
            tlpDbInputs.Controls.Clear();
            tlpDbInputs.RowCount = 0;
            AddDbInputHeader(tlpDbInputs, "所属组", "字段名", "数据库列名", "值（手动填写）", "");
            BuildDbInputRows(tlpDbInputs);
            AppendDbDebugLog("🔄 字段列表已刷新");
        }

        private void BtnDbTestConn_Click(object sender, EventArgs e)
        {
            var btn = btnDbTestConn;
            try
            {
                btn.Enabled = false;
                btn.Text = "⏳ 测试中...";
                _mySqlSugarHelper.Open();
                string testMainCol = MySqlSugarHelper.GetMainCodeColumnName(_barcodeConfig);
                var dt = _mySqlSugarHelper.QueryNgByMainCode("__test__", testMainCol);
                _mySqlSugarHelper.Close();
                AppendDbDebugLog("✅ 数据库连接正常（carkettledb @ localhost）");
                btn.BackColor = Color.FromArgb(0, 153, 102);
                btn.Text = "✅ 连接正常";
            }
            catch (Exception ex)
            {
                AppendDbDebugLog("❌ 数据库连接失败：" + ex.Message);
                btn.BackColor = Color.FromArgb(231, 76, 60);
                btn.Text = "❌ 连接失败";
            }
            finally
            {
                btn.Enabled = true;
                var t = new System.Windows.Forms.Timer { Interval = 3000 };
                t.Tick += (s2, ev2) => { btn.Text = "🔗 测试连接"; btn.BackColor = Color.FromArgb(142, 68, 173); t.Stop(); t.Dispose(); };
                t.Start();
            }
        }

        private void BtnDbFill_Click(object sender, EventArgs e)
        {
            if (tlpDbInputs == null) return;
            string mode = rdoDbFull.Checked ? "full" : (rdoDbOk.Checked ? "ok" : "ng");
            int testIdx = 1;
            foreach (Control ctrl in tlpDbInputs.Controls)
            {
                if (ctrl is TextBox txt && txt.Tag is string tag)
                {
                    string[] parts = tag.Contains("|") ? tag.Split('|') : new[] { "", tag };
                    string colName = parts.Length >= 2 ? parts[1] : tag;
                    string groupName = parts.Length >= 2 ? parts[0] : "";

                    // 查找数据类型
                    string dataType = "STRING";
                    if (parts.Length == 2 && _barcodeConfig != null)
                    {
                        var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == parts[0]);
                        var col = group?.Columns?.FirstOrDefault(c => c.DbColumnName == parts[1]);
                        if (col != null) dataType = col.DataType?.ToUpperInvariant() ?? "STRING";
                    }

                    bool isNumeric = dataType == "INT16" || dataType == "INT32" || dataType == "REAL" || dataType == "BYTE";
                    bool isString = dataType == "STRING";
                    bool isResult = colName.Contains("结果") || colName.Contains("状态") || colName.Contains("是否");
                    bool isBarcode = colName.Contains("主码") || colName.Contains("副码");

                    if (mode == "full")
                    {
                        if (isResult)
                            txt.Text = (testIdx % 2 == 0 ? "0" : "1");
                        else if (colName.Contains("位移") || colName.Contains("力"))
                            txt.Text = (10.5 + testIdx * 0.3).ToString("F1");
                        else if (isNumeric)
                            txt.Text = (testIdx % 3).ToString();
                        else if (isBarcode)
                            txt.Text = "BC" + DateTime.Now.ToString("MMddHHmm") + testIdx.ToString("D2");
                        else
                            txt.Text = "TEST" + testIdx;
                    }
                    else if (mode == "ok")
                    {
                        if (isResult)
                            txt.Text = "1";
                        else if (colName.Contains("位移") || colName.Contains("力"))
                            txt.Text = "12.5";
                        else if (isNumeric)
                            txt.Text = "1";
                        else if (isBarcode)
                            txt.Text = "SN" + DateTime.Now.ToString("yyMMdd") + "OK" + testIdx.ToString("D3");
                        else
                            txt.Text = "OK_DATA_" + testIdx;
                    }
                    else
                    {
                        if (isResult)
                            txt.Text = "0";
                        else if (colName.Contains("位移") || colName.Contains("力"))
                            txt.Text = "8.2";
                        else if (isNumeric)
                            txt.Text = "0";
                        else if (isBarcode)
                            txt.Text = "SN" + DateTime.Now.ToString("yyMMdd") + "NG" + testIdx.ToString("D3");
                        else
                            txt.Text = "NG_DATA_" + testIdx;
                    }
                    testIdx++;
                }
            }
            AppendDbDebugLog("📥 已填充测试数据（模式：" + mode + "），共 " + (testIdx - 1) + " 个字段");
        }

        private void BtnDbWritePlc_Click(object sender, EventArgs e)
        {
            if (!_plcConnected) { AppendDbDebugLog("❌ PLC未连接，无法写入"); return; }
            if (tlpDbInputs == null || _barcodeConfig == null) return;
            int count = 0;
            foreach (Control ctrl in tlpDbInputs.Controls)
            {
                if (ctrl is TextBox txt && txt.Tag is string tag && !string.IsNullOrWhiteSpace(txt.Text))
                {
                    string[] parts = tag.Split('|');
                    if (parts.Length != 2) continue;
                    var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == parts[0]);
                    var col = group?.Columns?.FirstOrDefault(c => c.DbColumnName == parts[1]);
                    if (col == null || string.IsNullOrWhiteSpace(col.Address)) continue;
                    try { WritePlcValue(col.Address, col.DataType, txt.Text.Trim()); count++; }
                    catch (Exception ex) { AppendDbDebugLog("❌ 写入 " + col.Address + " 失败：" + ex.Message); }
                }
            }
            AppendDbDebugLog("📤 已写入 " + count + " 个值到PLC");
        }

        private void BtnDbReadOk_Click(object sender, EventArgs e)
        {
            if (!_plcConnected) { AppendDbDebugLog("❌ PLC未连接，无法执行"); return; }
            var product = _multiProductConfig?.Products?.ElementAtOrDefault(_selectedProductIndex);
            if (product == null) { AppendDbDebugLog("❌ 未找到当前产品配置"); return; }
            try
            {
                string statusAddr = product.CodeStatusAddress;
                if (!string.IsNullOrWhiteSpace(statusAddr))
                {
                    string addrType = ParseAddressType(statusAddr);
                    uint addrOffset = ParseAddressOffset(statusAddr);
                    _siemensS7.WriterRegisterInt16(addrType, addrOffset, 1);
                    AppendDbDebugLog($"📤 已写 {statusAddr} = 1（OK）");
                }
                _barcodeConfig = product.BarcodeConfig;
                ReadAllBarcodeContents();
                lock (_barcodeValuesLock) { _allBarcodeValues[_selectedProductIndex] = new Dictionary<string, string>(_barcodeValues); }
                CheckAndWriteBarcodeStatusForProduct(product);
                WriteEnableReadCompleteForProduct(product);
                LoadProductValues(_selectedProductIndex);
                this.BeginInvoke(new Action(() => RefreshAllGroupGrids()));
                AppendDbDebugLog($"✅ [{product.ProductName}] OK读取流程完成");
            }
            catch (Exception ex) { AppendDbDebugLog("❌ OK读取失败：" + ex.Message); }
        }

        private void BtnDbReadNg_Click(object sender, EventArgs e)
        {
            if (!_plcConnected) { AppendDbDebugLog("❌ PLC未连接，无法执行"); return; }
            var product = _multiProductConfig?.Products?.ElementAtOrDefault(_selectedProductIndex);
            if (product == null) { AppendDbDebugLog("❌ 未找到当前产品配置"); return; }
            try
            {
                string statusAddr = product.CodeStatusAddress;
                if (!string.IsNullOrWhiteSpace(statusAddr))
                {
                    string addrType = ParseAddressType(statusAddr);
                    uint addrOffset = ParseAddressOffset(statusAddr);
                    _siemensS7.WriterRegisterInt16(addrType, addrOffset, 2);
                    AppendDbDebugLog($"📤 已写 {statusAddr} = 2（NG）");
                }
                _barcodeConfig = product.BarcodeConfig;
                ReadAllBarcodeContents();
                lock (_barcodeValuesLock) { _allBarcodeValues[_selectedProductIndex] = new Dictionary<string, string>(_barcodeValues); }
                CheckAndWriteBarcodeStatusForProduct(product);
                WriteEnableReadCompleteForProduct(product);
                LoadProductValues(_selectedProductIndex);
                this.BeginInvoke(new Action(() => RefreshAllGroupGrids()));
                AppendDbDebugLog($"✅ [{product.ProductName}] NG读取流程完成");
            }
            catch (Exception ex) { AppendDbDebugLog("❌ NG读取失败：" + ex.Message); }
        }

        #endregion

        private Button CreateActionButton(string text, Color backColor, EventHandler clickHandler)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 38),
                Margin = new Padding(0, 0, 10, 0),
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += clickHandler;
            return btn;
        }

        private void AppendPlcTestLog(string msg)
        {
            if (txtPlcTestLog == null) return;
            if (txtPlcTestLog.InvokeRequired)
            {
                txtPlcTestLog.Invoke(new Action<string>(AppendPlcTestLog), msg);
                return;
            }
            string line = $"[{DateTime.Now:HH:mm:ss}] {msg}";
            txtPlcTestLog.AppendText(line + Environment.NewLine);
            txtPlcTestLog.ScrollToCaret();
        }

        private void btnPlcRead_Click(object sender, EventArgs e)
        {
            string address = txtTestAddress?.Text?.Trim();
            string dataType = cmbTestDataType?.SelectedItem?.ToString() ?? "INT16";

            if (string.IsNullOrWhiteSpace(address))
            {
                AppendPlcTestLog("❌ 请输入PLC地址");
                return;
            }

            // 模拟模式
            if (chkSimMode != null && chkSimMode.Checked)
            {
                try
                {
                    string simResult;
                    if (_simulatedPlcData.TryGetValue(address, out int simVal))
                        simResult = simVal.ToString();
                    else
                        simResult = "(未初始化，返回0)";

                    AppendPlcTestLog($"📥 [模拟] 读取 [{address}] ({dataType}) = {simResult}");
                }
                catch (Exception ex)
                {
                    AppendPlcTestLog($"❌ [模拟] 读取失败：{ex.Message}");
                }
                return;
            }

            // 真实PLC模式
            if (!_plcConnected)
            {
                AppendPlcTestLog("❌ PLC未连接，请先连接PLC或切换到模拟模式");
                return;
            }

            try
            {
                string result;
                switch (dataType.ToUpperInvariant())
                {
                    case "INT16":
                        string addrType = ParseAddressType(address);
                        uint addrOffset = ParseAddressOffset(address);
                        int intVal = _siemensS7.ReadRegisterInt16(addrType, addrOffset);
                        result = intVal.ToString();
                        break;
                    case "INT32":
                        string addrType32 = ParseAddressType(address);
                        uint addrOffset32 = ParseAddressOffset(address);
                        int int32Val = _siemensS7.ReadRegisterInt32(addrType32, addrOffset32);
                        result = int32Val.ToString();
                        break;
                    case "REAL":
                        string realAddrType = ParseAddressType(address);
                        uint realAddrOffset = ParseAddressOffset(address);
                        float floatVal = _siemensS7.ReadRegisterfloat(realAddrType, realAddrOffset);
                        result = floatVal.ToString("F3");
                        break;
                    case "BYTE":
                        byte byteVal = _siemensS7.Readbyte(address);
                        result = byteVal.ToString();
                        break;
                    case "STRING":
                        result = ReadStringFromPlc(address);
                        result = string.IsNullOrEmpty(result) ? "(空)" : result;
                        break;
                    default:
                        result = "未知类型";
                        break;
                }
                AppendPlcTestLog($"📥 读取 [{address}] ({dataType}) = {result}");
            }
            catch (Exception ex)
            {
                AppendPlcTestLog($"❌ 读取失败：{ex.Message}");
            }
        }

        private void btnPlcWrite_Click(object sender, EventArgs e)
        {
            string address = txtTestAddress?.Text?.Trim();
            string dataType = cmbTestDataType?.SelectedItem?.ToString() ?? "INT16";
            string valueText = txtTestValue?.Text?.Trim();

            if (string.IsNullOrWhiteSpace(address))
            {
                AppendPlcTestLog("❌ 请输入PLC地址");
                return;
            }
            if (string.IsNullOrWhiteSpace(valueText))
            {
                AppendPlcTestLog("❌ 请输入写入值");
                return;
            }

            // 模拟模式
            if (chkSimMode != null && chkSimMode.Checked)
            {
                try
                {
                    if (dataType == "STRING")
                    {
                        _simulatedPlcData[address] = valueText.Length; // 存长度作为模拟
                        AppendPlcTestLog($"📤 [模拟] 写入 [{address}] (STRING) = \"{valueText}\"  成功");
                    }
                    else if (int.TryParse(valueText, out int simVal))
                    {
                        _simulatedPlcData[address] = simVal;
                        AppendPlcTestLog($"📤 [模拟] 写入 [{address}] = {simVal}  成功");
                    }
                    else
                    {
                        AppendPlcTestLog("❌ [模拟] 写入值必须是整数（模拟模式仅支持INT/STRING）");
                    }
                }
                catch (Exception ex)
                {
                    AppendPlcTestLog($"❌ [模拟] 写入失败：{ex.Message}");
                }
                return;
            }

            // 真实PLC模式
            if (!_plcConnected)
            {
                AppendPlcTestLog("❌ PLC未连接，请先连接PLC或切换到模拟模式");
                return;
            }

            try
            {
                bool writeOk = false;
                switch (dataType.ToUpperInvariant())
                {
                    case "INT16":
                        {
                            string at = ParseAddressType(address);
                            uint ao = ParseAddressOffset(address);
                            short iv = short.Parse(valueText);
                            writeOk = _siemensS7.WriterRegisterInt16(at, ao, iv);
                        }
                        break;
                    case "INT32":
                        {
                            string at = ParseAddressType(address);
                            uint ao = ParseAddressOffset(address);
                            int iv = int.Parse(valueText);
                            writeOk = _siemensS7.WriterRegisterInt32(at, ao, iv);
                        }
                        break;
                    case "REAL":
                        writeOk = _siemensS7.Writefloat(address, valueText);
                        break;
                    case "BYTE":
                        writeOk = _siemensS7.Writebyte(address, valueText);
                        break;
                    case "STRING":
                        {
                            string sat = ParseAddressType(address);
                            uint sao = ParseAddressOffset(address);
                            writeOk = _siemensS7.WriteString(sat + "." + sao, valueText);
                        }
                        break;
                    default:
                        AppendPlcTestLog($"❌ 不支持的数据类型：{dataType}");
                        return;
                }
                if (writeOk)
                    AppendPlcTestLog($"📤 写入 [{address}] ({dataType}) = {valueText}  成功");
                else
                    AppendPlcTestLog($"❌ 写入 [{address}] ({dataType}) 失败，PLC返回错误");
            }
            catch (Exception ex)
            {
                AppendPlcTestLog($"❌ 写入失败：{ex.Message}");
            }
        }

        #endregion

        /// <summary>
        /// 向PLC写入单个值（供DB调试页使用，失败抛异常）
        /// </summary>
        private void WritePlcValue(string address, string dataType, string valueText)
        {
            if (string.IsNullOrWhiteSpace(address)) return;

            switch (dataType?.ToUpperInvariant())
            {
                case "INT16":
                    {
                        string addrType = ParseAddressType(address);
                        uint addrOffset = ParseAddressOffset(address);
                        short intVal = short.Parse(valueText);
                        if (!_siemensS7.WriterRegisterInt16(addrType, addrOffset, intVal))
                            throw new Exception($"写入 INT16 [{address}]={valueText} 失败");
                    }
                    break;
                case "INT32":
                    {
                        string addrType = ParseAddressType(address);
                        uint addrOffset = ParseAddressOffset(address);
                        int int32Val = int.Parse(valueText);
                        if (!_siemensS7.WriterRegisterInt32(addrType, addrOffset, int32Val))
                            throw new Exception($"写入 INT32 [{address}]={valueText} 失败");
                    }
                    break;
                case "REAL":
                    if (!_siemensS7.Writefloat(address, valueText))
                        throw new Exception($"写入 REAL [{address}]={valueText} 失败");
                    break;
                case "BYTE":
                    if (!_siemensS7.Writebyte(address, valueText))
                        throw new Exception($"写入 BYTE [{address}]={valueText} 失败");
                    break;
                case "STRING":
                    {
                        string strAddrType = ParseAddressType(address);
                        uint strAddrOffset = ParseAddressOffset(address);
                        string strAddr = strAddrType + "." + strAddrOffset;
                        if (!_siemensS7.WriteString(strAddr, valueText))
                            throw new Exception($"写入 STRING [{strAddr}] 失败");
                    }
                    break;
                default:
                    throw new Exception($"不支持的数据类型：{dataType}");
            }
        }

        #region 数据库调试页

        /// <summary>
        /// 数据库调试页：手动填写条码字段值，测试写入OK/NG表
        /// </summary>
        private void InitDbDebugTab()
        {
            // 控件已在设计器中创建（lblDbDebugTitle + cmbDbProduct + lblDbProduct），此处仅初始化动态内容
            var pnlScroll = pnlDbScroll;

            // 产品选择器初始化（控件已在设计器的 pnlDbTop 中）
            if (cmbDbProduct != null)
            {
                cmbDbProduct.Items.Clear();
                cmbDbProduct.Items.AddRange(new[] { "压装", "推卡夹", "返工" });
                cmbDbProduct.SelectedIndex = _selectedProductIndex;
                cmbDbProduct.SelectedIndexChanged += (s, ev) =>
                {
                    SaveCurrentProductConfig();
                    _selectedProductIndex = cmbDbProduct.SelectedIndex;
                    LoadCurrentProductToUI();
                    RebuildDbInputs();
                };
            }

            // === 中间输入区（设计器中的 tlpDbInputs，此处仅配置） ===
            if (tlpDbInputs != null)
            {
                tlpDbInputs.ColumnCount = 5;
                tlpDbInputs.AutoSize = true;
                tlpDbInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tlpDbInputs.BackColor = Color.Transparent;
                tlpDbInputs.Padding = new Padding(0);
                tlpDbInputs.Location = new Point(10, 10);
                tlpDbInputs.MinimumSize = new Size(660, 0);
                if (tlpDbInputs.ColumnStyles.Count == 0)
                {
                    tlpDbInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
                    tlpDbInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
                    tlpDbInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
                    tlpDbInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                    tlpDbInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
                }
            }

            // 自动适配宽度
            pnlDbScroll.Resize += (s2, ev2) =>
            {
                if (tlpDbInputs != null)
                    tlpDbInputs.Width = Math.Max(pnlDbScroll.ClientSize.Width - 20, tlpDbInputs.MinimumSize.Width);
            };

            // 表头
            AddDbInputHeader(tlpDbInputs, "所属组", "字段名", "数据库列名", "值（手动填写）", "");

            // 根据 barcodeConfig 动态生成输入行
            BuildDbInputRows(tlpDbInputs);

            // === 底部操作栏：控件已在设计器中，事件由设计器绑定 ===
            // （btnDbWriteOk, btnDbWriteNg, btnDbRefresh, btnDbTestConn,
            //   btnDbFill, btnDbWritePlc, btnDbReadOk, btnDbReadNg 已全部由设计器绑定）

            // 首次日志延迟到界面显示后
            this.BeginInvoke(new Action(() =>
            {
                AppendDbDebugLog("✅ 数据库调试页已就绪，可手动填写值后点击写入OK/NG表");
            }));
        }

        /// <summary>
        /// 清空并重建DB调试页输入行（切换产品时调用）
        /// </summary>
        private void RebuildDbInputs()
        {
            if (tlpDbInputs == null) return;
            tlpDbInputs.Controls.Clear();
            tlpDbInputs.RowCount = 0;
            AddDbInputHeader(tlpDbInputs, "所属组", "字段名", "数据库列名", "值（手动填写）", "");
            BuildDbInputRows(tlpDbInputs);
            AppendDbDebugLog("🔄 已切换到产品：" + (_multiProductConfig?.Products?.ElementAtOrDefault(_selectedProductIndex)?.ProductName ?? ""));
        }

        /// <summary>
        /// 添加表头行
        /// </summary>
        private void AddDbInputHeader(TableLayoutPanel tlp, string c1, string c2, string c3, string c4, string c5)
        {
            var lblStyle = new Font("微软雅黑", 10F, FontStyle.Bold);
            var color = Color.FromArgb(60, 60, 60);
            tlp.RowCount++;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tlp.Controls.Add(new Label { Text = c1, Font = lblStyle, ForeColor = color, AutoSize = true }, 0, tlp.RowCount - 1);
            tlp.Controls.Add(new Label { Text = c2, Font = lblStyle, ForeColor = color, AutoSize = true }, 1, tlp.RowCount - 1);
            tlp.Controls.Add(new Label { Text = c3, Font = lblStyle, ForeColor = color, AutoSize = true }, 2, tlp.RowCount - 1);
            tlp.Controls.Add(new Label { Text = c4, Font = lblStyle, ForeColor = color, AutoSize = true }, 3, tlp.RowCount - 1);
            tlp.Controls.Add(new Label { Text = c5, Font = lblStyle, ForeColor = color, AutoSize = true }, 4, tlp.RowCount - 1);
        }

        /// <summary>
        /// 根据 barcodeConfig 动态生成每个字段的输入行
        /// </summary>
        private void BuildDbInputRows(TableLayoutPanel tlp)
        {
            var inputFont = new Font("微软雅黑", 10F);
            if (_barcodeConfig?.Groups == null) return;

            foreach (var group in _barcodeConfig.Groups)
            {
                if (group?.Columns == null) continue;
                foreach (var col in group.Columns)
                {
                    if (col == null) continue;

                    tlp.RowCount++;
                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                    int row = tlp.RowCount - 1;

                    // 组名
                    tlp.Controls.Add(new Label
                    {
                        Text = group.GroupName,
                        Font = inputFont,
                        ForeColor = Color.FromArgb(0, 114, 198),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 0, row);

                    // 字段显示名
                    string displayName = string.IsNullOrWhiteSpace(col.DisplayName) ? col.DbColumnName : col.DisplayName;
                    tlp.Controls.Add(new Label
                    {
                        Text = displayName,
                        Font = inputFont,
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 1, row);

                    // 数据库列名
                    tlp.Controls.Add(new Label
                    {
                        Text = col.DbColumnName ?? "",
                        Font = inputFont,
                        ForeColor = Color.FromArgb(100, 100, 100),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 2, row);

                    // 值输入框（用 Tag 存储 groupName|dbColumnName 以便回写时识别）
                    var txt = new TextBox
                    {
                        Font = inputFont,
                        Anchor = AnchorStyles.Left | AnchorStyles.Right,
                        Tag = $"{group.GroupName}|{col.DbColumnName}"
                    };
                    tlp.Controls.Add(txt, 3, row);

                    // 数据类型提示
                    tlp.Controls.Add(new Label
                    {
                        Text = col.DataType ?? "STRING",
                        Font = new Font("微软雅黑", 8F),
                        ForeColor = Color.FromArgb(150, 150, 150),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 4, row);
                }
            }
        }

        /// <summary>
        /// 从输入面板收集所有手动填写的值，构建 _barcodeValues 字典和写入记录
        /// </summary>
        private Dictionary<string, string> CollectDbDebugInputValues()
        {
            var result = new Dictionary<string, string>();
            if (tlpDbInputs == null) return result;

            foreach (Control ctrl in tlpDbInputs.Controls)
            {
                if (ctrl is TextBox txt && txt.Tag is string tag)
                {
                    string val = txt.Text?.Trim();
                    if (!string.IsNullOrEmpty(val))
                        result[tag] = val;  // key = "主码|主码内容"
                }
            }
            return result;
        }

        /// <summary>
        /// 从输入面板收集值，构建数据库写入字典（key = DbColumnName, value = 用户输入值）
        /// </summary>
        private Dictionary<string, object> BuildRecordFromInputs(Dictionary<string, string> inputs)
        {
            var dict = new Dictionary<string, object>();

            foreach (var kvp in inputs)
            {
                // kvp.Key 格式为 "组名|DbColumnName"，提取 DbColumnName 作为数据库列名
                string tag = kvp.Key;
                int pipeIdx = tag.IndexOf('|');
                string dbColName = pipeIdx >= 0 ? tag.Substring(pipeIdx + 1) : tag;
                if (!string.IsNullOrWhiteSpace(dbColName))
                    dict[dbColName] = kvp.Value ?? "";
            }

            dict["写入时间"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dict;
        }

        /// <summary>
        /// 写入OK表按钮
        /// </summary>
        private void BtnDbWriteOk_Click(object sender, EventArgs e)
        {
            try
            {
                var inputs = CollectDbDebugInputValues();
                if (inputs.Count == 0)
                {
                    AppendDbDebugLog("⚠️ 请至少填写一个字段的值");
                    return;
                }

                // 确保表存在（表不存在则自动创建）
                if (_mySqlSugarHelper != null && _barcodeConfig != null)
                    _mySqlSugarHelper.SyncTableFromConfig(_barcodeConfig);

                var dict = BuildRecordFromInputs(inputs);
                string okTable = _multiProductConfig?.Products?.ElementAtOrDefault(_selectedProductIndex)?.OkTableName ?? "OKTable";
                _mySqlSugarHelper.InsertOK(dict, okTable);
                AppendDbDebugLog($"✅ 已写入 {okTable}（{inputs.Count} 个字段）");
                RecordInformation($"✅ [手动] 已写入 {okTable}（{inputs.Count} 个字段）");
            }
            catch (Exception ex)
            {
                AppendDbDebugLog($"❌ 写入OKTable失败：{ex.Message}");
                RecordInformation($"❌ [手动] 写入OKTable失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 写入NG表按钮
        /// </summary>
        private void BtnDbWriteNg_Click(object sender, EventArgs e)
        {
            try
            {
                var inputs = CollectDbDebugInputValues();
                if (inputs.Count == 0)
                {
                    AppendDbDebugLog("⚠️ 请至少填写一个字段的值");
                    return;
                }

                // 确保表存在（表不存在则自动创建）
                if (_mySqlSugarHelper != null && _barcodeConfig != null)
                    _mySqlSugarHelper.SyncTableFromConfig(_barcodeConfig);

                var dict = BuildRecordFromInputs(inputs);
                string ngTable = _multiProductConfig?.Products?.ElementAtOrDefault(_selectedProductIndex)?.NgTableName ?? "NGTable";
                _mySqlSugarHelper.InsertNG(dict, ngTable);
                AppendDbDebugLog($"✅ 已写入 {ngTable}（{inputs.Count} 个字段）");
                RecordInformation($"✅ [手动] 已写入 {ngTable}（{inputs.Count} 个字段）");
            }
            catch (Exception ex)
            {
                AppendDbDebugLog($"❌ 写入NGTable失败：{ex.Message}");
                RecordInformation($"❌ [手动] 写入NGTable失败：{ex.Message}");
            }
        }

        private void AppendDbDebugLog(string msg)
        {
            if (txtDbDebugLog == null) return;
            if (txtDbDebugLog.InvokeRequired)
            {
                txtDbDebugLog.Invoke(new Action<string>(AppendDbDebugLog), msg);
                return;
            }
            string line = $"[{DateTime.Now:HH:mm:ss}] {msg}";
            txtDbDebugLog.AppendText(line + Environment.NewLine);
            txtDbDebugLog.ScrollToCaret();
        }

        #endregion

        #region 全界面响应式布局

        /// <summary>
        /// 为所有Tab页应用响应式布局：控件跟随窗口大小自动缩放
        /// </summary>
        private void ApplyResponsiveLayout()
        {
            // ---- 数据查询 (tabPage3) ----
            if (dgvQuery != null)
            {
                dgvQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            if (grpQuery != null)
            {
                grpQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }

            // ---- 配置 (tabPage4) ----
            if (grpPlcConfig != null)
            {
                grpPlcConfig.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }
            if (grpBarcodeAddr != null)
            {
                grpBarcodeAddr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            if (btnSaveComParam != null)
            {
                btnSaveComParam.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
            if (btnReconnect != null)
            {
                btnReconnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
            if (dgvGroupColumns != null)
            {
                dgvGroupColumns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            if (lstGroupSelector != null)
            {
                lstGroupSelector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            }

            // 注册配置页Resize事件
            if (tabPage4 != null)
            {
                tabPage4.Resize -= TabPage4_Resize;
                tabPage4.Resize += TabPage4_Resize;
                TabPage4_Resize(null, null);
            }
        }

        private void TabPage4_Resize(object sender, EventArgs e)
        {
            if (tabPage4 == null) return;

            int w = tabPage4.ClientSize.Width;
            int h = tabPage4.ClientSize.Height;
            int pad = 15;

            // --- grpPlcConfig: 顶部固定 ---
            if (grpPlcConfig != null)
            {
                grpPlcConfig.Width = w - pad * 2;
                grpPlcConfig.Left = pad;
                grpPlcConfig.Top = 6;
                grpPlcConfig.Height = 95;
            }

            // --- grpBarcodeAddr: 撑满剩余空间 ---
            if (grpBarcodeAddr != null)
            {
                grpBarcodeAddr.Width = w - pad * 2;
                grpBarcodeAddr.Left = pad;
                grpBarcodeAddr.Top = (grpPlcConfig != null ? grpPlcConfig.Bottom : 100) + 6;
                // 底部留出按钮空间
                grpBarcodeAddr.Height = Math.Max(320, h - grpBarcodeAddr.Top - 70);
            }

            // --- 右下角按钮 ---
            int btnY = h - 55;
            if (btnSaveComParam != null)
            {
                btnSaveComParam.Left = w - btnSaveComParam.Width - pad;
                btnSaveComParam.Top = btnY;
            }
            if (btnReconnect != null)
            {
                btnReconnect.Left = (btnSaveComParam != null ? btnSaveComParam.Left : w - pad) - btnReconnect.Width - 12;
                btnReconnect.Top = btnY;
            }

            // --- grpBarcodeAddr 内部布局 ---
            if (grpBarcodeAddr == null) return;

            int gw = grpBarcodeAddr.ClientSize.Width;
            int gh = grpBarcodeAddr.ClientSize.Height;
            int gpad = 12;

            // 左侧列表：固定宽度
            if (lstGroupSelector != null)
            {
                lstGroupSelector.Left = gpad;
                lstGroupSelector.Top = 30;
                lstGroupSelector.Width = 165;
                lstGroupSelector.Height = Math.Max(60, gh - 225);
            }

            // 右侧表格：填充剩余
            int gridLeft = (lstGroupSelector != null ? lstGroupSelector.Right : 180) + gpad;
            if (dgvGroupColumns != null)
            {
                dgvGroupColumns.Left = gridLeft;
                dgvGroupColumns.Top = 30;
                dgvGroupColumns.Width = Math.Max(200, gw - gridLeft - gpad);
                dgvGroupColumns.Height = Math.Max(60, gh - 225);
            }

            // --- 按钮行（表格下方） ---
            int btnRowY = gh - 185;
            if (btnAddColumn != null)
            {
                btnAddColumn.Left = gridLeft;
                btnAddColumn.Top = btnRowY;
            }
            if (btnDeleteColumn != null && btnAddColumn != null)
            {
                btnDeleteColumn.Left = btnAddColumn.Right + 8;
                btnDeleteColumn.Top = btnRowY;
            }
            if (chkAutoReconnect != null)
            {
                int chkLeft = (btnDeleteColumn != null) ? btnDeleteColumn.Right + 15 : gridLeft;
                chkAutoReconnect.Left = Math.Min(chkLeft, gw - chkAutoReconnect.Width - gpad);
                chkAutoReconnect.Top = btnRowY + 4;
                chkAutoReconnect.AutoSize = true;
            }

            // --- 地址输入行 ---
            int addrRowY = gh - 130;
            int[] addrCols = { gpad, gpad + 105, gpad + 255, gpad + 380, gpad + 530, gpad + 675 };
            // 每列宽度自适应
            int colW = Math.Min(150, (gw - gpad - addrCols[5]) / 3 + 20);

            if (lblHeartbeatAddr != null)
            {
                lblHeartbeatAddr.Left = addrCols[0];
                lblHeartbeatAddr.Top = addrRowY + 4;
                lblHeartbeatAddr.AutoSize = true;
            }
            if (txtHeartbeatAddr != null)
            {
                txtHeartbeatAddr.Left = addrCols[1];
                txtHeartbeatAddr.Top = addrRowY;
                txtHeartbeatAddr.Width = colW;
            }

            if (lblEnableReadAddr != null)
            {
                lblEnableReadAddr.Left = addrCols[2];
                lblEnableReadAddr.Top = addrRowY + 4;
                lblEnableReadAddr.AutoSize = true;
            }
            if (txtEnableReadAddr != null)
            {
                txtEnableReadAddr.Left = addrCols[3];
                txtEnableReadAddr.Top = addrRowY;
                txtEnableReadAddr.Width = colW;
            }

            if (lblCodeStatusAddr != null)
            {
                lblCodeStatusAddr.Left = addrCols[4];
                lblCodeStatusAddr.Top = addrRowY + 4;
                lblCodeStatusAddr.AutoSize = true;
            }
            if (txtCodeStatusAddr != null)
            {
                txtCodeStatusAddr.Left = addrCols[5];
                txtCodeStatusAddr.Top = addrRowY;
                txtCodeStatusAddr.Width = Math.Max(80, gw - addrCols[5] - gpad);
            }

            // --- 提示行1（地址说明） ---
            int hintY1 = addrRowY + 34;
            if (lblHeartbeatHint != null)
            {
                lblHeartbeatHint.Left = addrCols[0];
                lblHeartbeatHint.Top = hintY1;
                lblHeartbeatHint.AutoSize = true;
            }
            if (lblEnableReadHint != null)
            {
                lblEnableReadHint.Left = addrCols[2];
                lblEnableReadHint.Top = hintY1;
                lblEnableReadHint.AutoSize = true;
            }
            if (lblCodeStatusHint != null)
            {
                lblCodeStatusHint.Left = addrCols[4];
                lblCodeStatusHint.Top = hintY1;
                lblCodeStatusHint.AutoSize = true;
            }

            // --- 提示行2（通用说明） ---
            int hintY2 = hintY1 + 22;
            if (lblAddrHint != null)
            {
                lblAddrHint.Left = gpad;
                lblAddrHint.Top = hintY2;
                lblAddrHint.AutoSize = true;
                // 如果文字太长，限制宽度让其换行
                int maxHintW = gw - gpad * 2;
                if (lblAddrHint.Width > maxHintW)
                {
                    lblAddrHint.MaximumSize = new Size(maxHintW, 0);
                    lblAddrHint.AutoSize = true;
                }
            }
        }

        #endregion

        /// <summary>
        /// 数据库上传类型
        /// </summary>
        public DatabaseType datatype = new DatabaseType();
        //串口1
        public Network_ModbusTcpH5U _modbusTcp = new Network_ModbusTcpH5U();

        Thread _threadCommunication;

        ScrewMT _screwMT = new ScrewMT();

        public Network_SiemensS7 _siemensS7 = new Network_SiemensS7();

        public Network_ModbusTcp _modbusTcp_rfid = new Network_ModbusTcp();

        // PLC测试页控件已移入设计器 tabPage6
        private TabPage tabPagePlcTest; // 保留旧引用

        // 数据库调试页控件
        // DB调试页已移入设计器 tabPage5
        private TabPage tabPageDbDebug; // 保留引用以兼容旧代码

        // UI优化控件 - 已移入设计器，事件在代码中绑定
        // lblPlcHeartbeat, btnToggleLog 见 frmDatabase.Designer.cs


        #region 数据查询

        /// <summary>
        /// 初始化查询结果表格的列结构（根据条码配置动态生成列）
        /// </summary>
        private void InitQueryResultGrids()
        {
            // 初始化产品选择器
            if (cmbQueryProduct != null)
            {
                cmbQueryProduct.Items.Clear();
                if (_multiProductConfig?.Products != null)
                {
                    foreach (var p in _multiProductConfig.Products)
                        cmbQueryProduct.Items.Add(p.ProductName);
                }
                if (cmbQueryProduct.Items.Count > 0)
                    cmbQueryProduct.SelectedIndex = 0;
            }

            // OK结果表格
            if (dgvOkResult != null)
            {
                dgvOkResult.Columns.Clear();
                dgvOkResult.DataSource = null;
                dgvOkResult.AutoGenerateColumns = false;
                dgvOkResult.DefaultCellStyle.Font = new Font("微软雅黑", 10F);
                dgvOkResult.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            }

            // NG结果表格
            if (dgvNgResult != null)
            {
                dgvNgResult.Columns.Clear();
                dgvNgResult.DataSource = null;
                dgvNgResult.AutoGenerateColumns = false;
                dgvNgResult.DefaultCellStyle.Font = new Font("微软雅黑", 10F);
                dgvNgResult.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            }

            // 初始隐藏所有结果元素（标签+表格）
            if (lblOkTitle != null) lblOkTitle.Visible = false;
            if (dgvOkResult != null) dgvOkResult.Visible = false;
            if (lblNgTitle != null) lblNgTitle.Visible = false;
            if (dgvNgResult != null) dgvNgResult.Visible = false;

            // 初始化导出控件
            InitExportControls();
        }

        /// <summary>
        /// 初始化导出控件
        /// </summary>
        private void InitExportControls()
        {
            if (dtpExportFrom != null) dtpExportFrom.Value = DateTime.Today.AddMonths(-1);
            if (dtpExportTo != null) dtpExportTo.Value = DateTime.Today;
            if (cmbExportTable != null)
            {
                cmbExportTable.Items.Clear();
                var products = _multiProductConfig?.Products;
                if (products != null)
                {
                    foreach (var p in products)
                    {
                        cmbExportTable.Items.Add($"{p.ProductName}-OK");
                        cmbExportTable.Items.Add($"{p.ProductName}-NG");
                    }
                }
                if (cmbExportTable.Items.Count > 0) cmbExportTable.SelectedIndex = 0;
            }
            if (btnExportCsv != null) btnExportCsv.Click += BtnExportCsv_Click;
        }

        /// <summary>
        /// 导出CSV按钮
        /// </summary>
        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            if (cmbExportTable == null || cmbExportTable.SelectedItem == null)
            {
                MessageBox.Show("请选择要导出的表", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = cmbExportTable.SelectedItem.ToString();
            string[] parts = selected.Split('-');
            if (parts.Length != 2) return;
            string productName = parts[0];
            string okNg = parts[1];

            // 找到对应产品的表名
            var product = _multiProductConfig?.Products?.FirstOrDefault(p => p.ProductName == productName);
            string tableName = okNg == "OK" ? product?.OkTableName : product?.NgTableName;
            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("未找到对应表名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DateTime from = dtpExportFrom?.Value ?? DateTime.Today.AddMonths(-1);
                DateTime to = dtpExportTo?.Value ?? DateTime.Today;

                btnExportCsv.Enabled = false;
                btnExportCsv.Text = "⏳ 导出中...";

                DataTable dt = _mySqlSugarHelper.ExportTableByDateRange(tableName, from, to);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show($"表 [{tableName}] 在 {from:yyyy-MM-dd} ~ {to:yyyy-MM-dd} 无数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnExportCsv.Text = "📥 导出CSV";
                    btnExportCsv.Enabled = true;
                    return;
                }

                // 保存CSV
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV文件|*.csv";
                    sfd.FileName = $"{tableName}_{from:yyyyMMdd}_{to:yyyyMMdd}.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        WriteDataTableToCsv(dt, sfd.FileName);
                        MessageBox.Show($"导出成功！{dt.Rows.Count} 条记录 → {Path.GetFileName(sfd.FileName)}", "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExportCsv.Text = "📥 导出CSV";
                btnExportCsv.Enabled = true;
            }
        }

        /// <summary>
        /// 将 DataTable 写入 CSV 文件
        /// </summary>
        private void WriteDataTableToCsv(DataTable dt, string filePath)
        {
            // 跳过 ID 列
            var columns = dt.Columns.Cast<DataColumn>()
                .Where(c => !c.ColumnName.Equals("ID", StringComparison.OrdinalIgnoreCase))
                .ToList();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // 表头
                sw.WriteLine(string.Join(",", columns.Select(c => "\"" + c.ColumnName.Replace("\"", "\"\"") + "\"")));

                // 数据行
                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = columns.Select(c =>
                    {
                        object val = row[c];
                        return val == null ? "" : "\"" + val.ToString().Replace("\"", "\"\"") + "\"";
                    }).ToArray();
                    sw.WriteLine(string.Join(",", fields));
                }
            }
        }

        #region 开机自启

        private const string AUTO_START_REG_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string AUTO_START_APP_NAME = "DataBaseOrm";

        private void InitAutoStart()
        {
            if (chkAutoStart == null) return;
            chkAutoStart.Checked = IsAutoStartEnabled();
            chkAutoStart.CheckedChanged += (s, ev) =>
            {
                SetAutoStart(chkAutoStart.Checked);
            };
        }

        private bool IsAutoStartEnabled()
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AUTO_START_REG_KEY, false))
                {
                    if (key == null) return false;
                    var val = key.GetValue(AUTO_START_APP_NAME) as string;
                    if (string.IsNullOrWhiteSpace(val)) return false;

                    // 检查路径是否匹配当前exe（兼容vshost调试）
                    string currentPath = Application.ExecutablePath;
                    if (currentPath.EndsWith(".vshost.exe"))
                        currentPath = currentPath.Replace(".vshost.exe", ".exe");

                    return val.IndexOf(currentPath, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
            catch { return false; }
        }

        private void SetAutoStart(bool enable)
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AUTO_START_REG_KEY, true))
                {
                    if (key == null)
                    {
                        MessageBox.Show("无法访问注册表，请以管理员身份运行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (chkAutoStart != null) chkAutoStart.Checked = !enable;
                        return;
                    }

                    if (enable)
                    {
                        // 使用真实的exe路径（排除vshost调试宿主）
                        string exePath = Application.ExecutablePath;
                        if (exePath.EndsWith(".vshost.exe"))
                            exePath = exePath.Replace(".vshost.exe", ".exe");

                        key.SetValue(AUTO_START_APP_NAME, "\"" + exePath + "\"");
                        RecordInformation("已设置开机自启: " + exePath);
                    }
                    else
                    {
                        key.DeleteValue(AUTO_START_APP_NAME, false);
                        RecordInformation("已取消开机自启");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置开机自启失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (chkAutoStart != null) chkAutoStart.Checked = !enable;
            }
        }

        #endregion

        /// <summary>
        /// 为查询结果 DataGridView 动态创建列
        /// </summary>
        private void BuildQueryResultColumns(DataGridView grid)
        {
            if (grid == null) return;
            grid.Columns.Clear();
            grid.DataSource = null;
            grid.AutoGenerateColumns = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ScrollBars = ScrollBars.Both;

            var columns = MySqlSugarHelper.GetColumnNamesFromConfig(_barcodeConfig);
            foreach (var colName in columns)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = colName,
                    HeaderText = colName,
                    DataPropertyName = colName,
                    Width = 130,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                grid.Columns.Add(col);
            }
            // 写入时间列
            var timeCol = new DataGridViewTextBoxColumn
            {
                Name = "写入时间",
                HeaderText = "写入时间",
                DataPropertyName = "写入时间",
                Width = 160,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            grid.Columns.Add(timeCol);
        }

        /// <summary>
        /// 隐藏NG，仅显示OK（标签+表格占满）
        /// </summary>
        private void ShowOnlyOkPanel()
        {
            if (tblResults == null) return;
            lblOkTitle.Visible = true;
            dgvOkResult.Visible = true;
            lblNgTitle.Visible = false;
            dgvNgResult.Visible = false;

            tblResults.SuspendLayout();
            tblResults.RowStyles[0] = new RowStyle(SizeType.Absolute, 36F);
            tblResults.RowStyles[1] = new RowStyle(SizeType.Percent, 100F);
            tblResults.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);
            tblResults.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
            tblResults.ResumeLayout(false);
            tblResults.PerformLayout();
        }

        /// <summary>
        /// 隐藏OK，仅显示NG（标签+表格占满）
        /// </summary>
        private void ShowOnlyNgPanel()
        {
            if (tblResults == null) return;
            lblOkTitle.Visible = false;
            dgvOkResult.Visible = false;
            lblNgTitle.Visible = true;
            dgvNgResult.Visible = true;

            tblResults.SuspendLayout();
            tblResults.RowStyles[0] = new RowStyle(SizeType.Absolute, 0F);
            tblResults.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
            tblResults.RowStyles[2] = new RowStyle(SizeType.Absolute, 36F);
            tblResults.RowStyles[3] = new RowStyle(SizeType.Percent, 100F);
            tblResults.ResumeLayout(false);
            tblResults.PerformLayout();
        }

        /// <summary>
        /// OK查询按钮 - 仅查询OK表（动态列模式，只显示OK面板）
        /// </summary>
        private void btnQueryOk_Click(object sender, EventArgs e)
        {
            string code = txtQueryCode?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("请输入主码进行查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 获取当前选中产品的OK表名
            int selIdx = cmbQueryProduct?.SelectedIndex ?? 0;
            string productName = _multiProductConfig?.Products?.ElementAtOrDefault(selIdx)?.ProductName ?? "压装";
            string okTable = _multiProductConfig?.Products?.ElementAtOrDefault(selIdx)?.OkTableName ?? "OKTable";

            try
            {
                btnQueryOk.Enabled = false;
                btnQueryOk.Text = "⏳ 查询中...";

                BuildQueryResultColumns(dgvOkResult);
                ShowOnlyOkPanel();

                string mainColName = MySqlSugarHelper.GetMainCodeColumnName(_barcodeConfig);
                DataTable dtOk = _mySqlSugarHelper.QueryOkByMainCode(code, mainColName, okTable);
                if (dgvOkResult != null)
                {
                    dgvOkResult.DataSource = dtOk;
                    lblOkTitle.Text = dtOk != null && dtOk.Rows.Count > 0
                        ? $"  ✅ {productName} OK（{dtOk.Rows.Count} 条）"
                        : $"  ✅ {productName} OK（无结果）";
                }

                btnQueryOk.Text = "🔍 OK查询";
                btnQueryOk.Enabled = true;
            }
            catch (Exception ex)
            {
                btnQueryOk.Text = "🔍 OK查询";
                btnQueryOk.Enabled = true;
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// NG查询按钮 - 查询当前选中产品的NG表
        /// </summary>
        private void btnQueryNg_Click(object sender, EventArgs e)
        {
            string code = txtQueryCode?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("请输入主码进行查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 获取当前选中产品的NG表名
            int selIdx = cmbQueryProduct?.SelectedIndex ?? 0;
            string productName = _multiProductConfig?.Products?.ElementAtOrDefault(selIdx)?.ProductName ?? "压装";
            string ngTable = _multiProductConfig?.Products?.ElementAtOrDefault(selIdx)?.NgTableName ?? "NGTable";

            try
            {
                btnQueryNg.Enabled = false;
                btnQueryNg.Text = "⏳ 查询中...";

                BuildQueryResultColumns(dgvNgResult);
                ShowOnlyNgPanel();

                string mainColName = MySqlSugarHelper.GetMainCodeColumnName(_barcodeConfig);
                DataTable dtNg = _mySqlSugarHelper.QueryNgByMainCode(code, mainColName, ngTable);
                if (dgvNgResult != null)
                {
                    dgvNgResult.DataSource = dtNg;
                    lblNgTitle.Text = dtNg != null && dtNg.Rows.Count > 0
                        ? $"  ❌ {productName} NG（{dtNg.Rows.Count} 条）"
                        : $"  ❌ {productName} NG（无结果）";
                }

                btnQueryNg.Text = "🔍 NG查询";
                btnQueryNg.Enabled = true;
            }
            catch (Exception ex)
            {
                btnQueryNg.Text = "🔍 NG查询";
                btnQueryNg.Enabled = true;
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 旧版查询按钮（保留兼容，已隐藏）
        /// </summary>
        private void btnManualQuery_Click(object sender, EventArgs e)
        {
            dgvQuery.DataSource = (_mySqlSugarHelper.Query(txtSN.Text) as DataTable);
        }

        #endregion


        private void frmDatabase_Load(object sender, EventArgs e)
        {
            // 自动最大化适配不同分辨率
            this.WindowState = FormWindowState.Maximized;

            //加载数据库

            // 初始化条码列配置：左侧组选择 + 右侧字段编辑
            InitGroupSelector();
            InitProductSelector();
            InitGroupColumnsDataGridView();
            InitColumnConfigAddDeleteButtons();

            // 初始化主界面动态条码显示面板（必须在加载配置之前，确保DataGridView列已就绪）
            InitializeDynamicCodePanels();

            LoadBarcodeAddressParams();

            // 初始化数据查询页的表格列结构（依赖 barcodeConfig，放 LoadBarcodeAddressParams 之后）
            InitQueryResultGrids();

            // 初始化PLC测试页
            InitPlcTestTab();

            // 初始化数据库调试页
            InitDbDebugTab();

            // 应用全界面响应式布局
            ApplyResponsiveLayout();

            // 初始化开机自启选项
            InitAutoStart();

            Control.CheckForIllegalCrossThreadCalls = false;
            string sql = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? "server=localhost;User Id=root;password=YOUR_PASSWORD_HERE;Database=YOUR_DATABASE_NAME;SslMode=none;AllowPublicKeyRetrieval=True;Charset=utf8";
            _mySqlSugarHelper = new MySqlSugarHelper(sql);

            // 根据条码配置同步数据库表结构（对所有产品及各自的表名）
            if (_multiProductConfig?.Products != null)
            {
                foreach (var p in _multiProductConfig.Products)
                {
                    if (p?.BarcodeConfig != null)
                    {
                        _mySqlSugarHelper.SyncTableFromConfig(p.BarcodeConfig, p.OkTableName);
                        _mySqlSugarHelper.SyncTableFromConfig(p.BarcodeConfig, p.NgTableName);
                    }
                }
            }
            //加载通信参数
            // ReadCommunicationConfig();
            //  LoadComunicationControlParam();

            //读取打印机参数
            // ReadToshibaParams();


            //   LoadVppDataGrid(dgvParams, _toshibaParamsDataTable);
            //汇川5UPLC的ModbusTCP通信
            //bool status = _modbusTcp.Connect(_ethernetConfig.IP, Network_ModbusTcpH5U.DataFormat.CDAB);
            //RecordInformation("PLC连接状态：" + status.ToString());

            //扫码枪串口通信
            //  IniCommunicationSerialPort(_serialConfig);
            //加载螺丝机
            // bool status2 = _screwMT.Connect(_serialConfig);
            // RecordInformation("螺丝机连接状态：" + status2.ToString());

            //PLC通信 - 不在此处同步连接（会卡界面），交由后台线程处理
            _plcConnected = false;
            string plcIp = txtPlcIp?.Text?.Trim();
            string plcPortStr = txtPlcPort?.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(plcIp) && !string.IsNullOrWhiteSpace(plcPortStr)
                && plcIp != "Any" && int.TryParse(plcPortStr, out int plcPort))
            {
                RecordInformation("PLC连接将在后台线程中建立：" + plcIp + ":" + plcPort);
            }
            else
            {
                RecordInformation("PLC配置未设置或无效，将在后台线程中自动重试连接");
            }

          //  //RFID通信
          ////  bool status2 = _modbusTcp_rfid.Connect(_ethernetConfig3.IP, Network_ModbusTcp.DataFormat.ABCD);
          //bool status2 = false;
          //  if (status2)
          //  {
          //      RecordInformation("Rfid连接OK：" + status.ToString());

          //  }
          //  else
          //  {
          //      RecordInformation("Rfid连接NG：" + status.ToString());

          //  }

          //  //东芝打印机通信
          //  //   _toshibaPrint = new ToshibaPrint();
          //  // bool status3 = _toshibaPrint.connect(_ethernetConfig.IP, Convert.ToInt16(_ethernetConfig.Port));
          //  bool status3 = false;
          //  if (status3)
          //  {
          //      RecordInformation("打印机连接OK：" + status.ToString());
          //      ////设置打印机通用参数
          //      ////bool flag = _toshibaPrint.SetLabelParams();
          //      ////if (flag)
          //      ////{
          //      ////    RecordInformation("打印机通用参数设置OK");
          //      ////}
          //      ////else
          //      ////{
          //      ////    RecordInformation("打印机通用参数设置NG");
          //      ////}
          //  }
          //  else
          //  {
          //      RecordInformation("打印机连接NG：" + status.ToString());

          //  }


            //运行通信线程
            _threadCommunication = new Thread(ProcessPlcCommunication);
            _threadCommunication.IsBackground = true;
            _threadCommunication.Start();

            timerHeart.Enabled = true;

            // 心跳灯外观初始化（btnToggleLog 事件已由设计器绑定）
            if (lblPlcHeartbeat != null)
            {
                lblPlcHeartbeat.BackColor = Color.FromArgb(255, 100, 100);
                lblPlcHeartbeat.ForeColor = Color.FromArgb(180, 30, 30);
                lblPlcHeartbeat.Text = "● PLC离线";
                lblPlcHeartbeat.TextAlign = ContentAlignment.MiddleCenter;
            }


        }

        /// <summary>
        /// 日志面板折叠/展开
        /// </summary>
        private void BtnToggleLog_Click(object sender, EventArgs e)
        {
            if (tlpMain1 == null) return;
            bool isCollapsed = tlpMain1.ColumnStyles[1].Width == 0;
            if (isCollapsed)
            {
                // 展开日志面板
                tlpMain1.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 20F);
                btnToggleLog.Text = "◀";
            }
            else
            {
                // 折叠日志面板
                tlpMain1.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0F);
                btnToggleLog.Text = "▶";
            }
        }

        #region 表格化条码列配置（左右布局：左侧选组 + 右侧编辑字段）

        private string _selectedGroupName = "";

        /// <summary>
        /// 初始化左侧组选择列表（ListBox）
        /// </summary>
        private void InitGroupSelector()
        {
            if (lstGroupSelector == null) return;
            lstGroupSelector.Items.Clear();
            lstGroupSelector.Items.AddRange(BarcodeConfigManager.GetGroupNames());
            lstGroupSelector.SelectedIndexChanged += lstGroupSelector_SelectedIndexChanged;
        }

        /// <summary>
        /// 初始化产品选择下拉框事件（控件已在设计器中）
        /// </summary>
        private void InitProductSelector()
        {
            if (cmbProductSelector == null) return;
            cmbProductSelector.Items.Clear();
            cmbProductSelector.Items.AddRange(new[] { "压装", "推卡夹", "返工" });
            cmbProductSelector.SelectedIndex = 0;
            cmbProductSelector.SelectedIndexChanged += CmbProductSelector_SelectedIndexChanged;
        }

        /// <summary>
        /// 切换产品时保存当前产品配置，加载新产品配置
        /// </summary>
        private void CmbProductSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductSelector == null || _multiProductConfig == null) return;

            // 保存当前产品配置
            SaveCurrentProductConfig();

            // 切换产品（设标志位防止组选择事件误保存）
            _selectedProductIndex = cmbProductSelector.SelectedIndex;
            _isLoadingProduct = true;
            LoadCurrentProductToUI();
            _isLoadingProduct = false;
        }

        /// <summary>
        /// 保存当前产品到 _multiProductConfig
        /// </summary>
        private void SaveCurrentProductConfig()
        {
            if (_multiProductConfig?.Products == null) return;
            if (_selectedProductIndex < 0 || _selectedProductIndex >= _multiProductConfig.Products.Count) return;

            // 先保存当前DataGridView中的列配置
            SaveCurrentGroupColumnsToConfig();

            var product = _multiProductConfig.Products[_selectedProductIndex];
            product.EnableReadAddress = txtEnableReadAddr?.Text?.Trim() ?? "";
            product.CodeStatusAddress = txtCodeStatusAddr?.Text?.Trim() ?? "";
            product.OkTableName = txtOkTableName?.Text?.Trim() ?? "OKTable";
            product.NgTableName = txtNgTableName?.Text?.Trim() ?? "NGTable";
            product.BarcodeConfig = _barcodeConfig;
        }

        /// <summary>
        /// 加载当前产品配置到UI
        /// </summary>
        private void LoadCurrentProductToUI()
        {
            if (_multiProductConfig?.Products == null) return;
            if (_selectedProductIndex < 0 || _selectedProductIndex >= _multiProductConfig.Products.Count) return;

            var product = _multiProductConfig.Products[_selectedProductIndex];

            // 加载地址
            if (txtEnableReadAddr != null) txtEnableReadAddr.Text = product.EnableReadAddress;
            if (txtCodeStatusAddr != null) txtCodeStatusAddr.Text = product.CodeStatusAddress;
            if (txtOkTableName != null) txtOkTableName.Text = product.OkTableName;
            if (txtNgTableName != null) txtNgTableName.Text = product.NgTableName;

            // 加载条码配置
            _barcodeConfig = product.BarcodeConfig;
            LoadConfigToUI();

            // 同步数据库表结构
            if (_mySqlSugarHelper != null && _barcodeConfig != null)
                _mySqlSugarHelper.SyncTableFromConfig(_barcodeConfig);
        }

        /// <summary>
        /// 初始化右侧字段编辑表格（DataGridView），不含"组别"列
        /// </summary>
        private void InitGroupColumnsDataGridView()
        {
            if (dgvGroupColumns == null) return;

            dgvGroupColumns.Columns.Clear();

            // 清除固定行高，允许自动换行
            dgvGroupColumns.RowTemplate.Height = 0;
            dgvGroupColumns.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGroupColumns.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvGroupColumns.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 列1: 读取内容描述
            var displayCol = new DataGridViewTextBoxColumn();
            displayCol.Name = "DisplayName";
            displayCol.HeaderText = "读取内容";
            displayCol.Width = 200;
            dgvGroupColumns.Columns.Add(displayCol);

            // 列2: PLC地址
            var addrCol = new DataGridViewTextBoxColumn();
            addrCol.Name = "Address";
            addrCol.HeaderText = "地址";
            addrCol.Width = 200;
            dgvGroupColumns.Columns.Add(addrCol);

            // 列3: 数据类型 - 下拉框
            var typeCol = new DataGridViewComboBoxColumn();
            typeCol.Name = "DataType";
            typeCol.HeaderText = "数据类型";
            typeCol.Items.AddRange(BarcodeConfigManager.GetDataTypes());
            typeCol.DefaultCellStyle.NullValue = "STRING";
            typeCol.Width = 120;
            dgvGroupColumns.Columns.Add(typeCol);

            // 列4: 存入数据库列名
            var dbCol = new DataGridViewTextBoxColumn();
            dbCol.Name = "DbColumnName";
            dbCol.HeaderText = "存入列名";
            dbCol.Width = 200;
            dgvGroupColumns.Columns.Add(dbCol);
        }

        /// <summary>
        /// 绑定添加/删除按钮事件 + 组选择事件
        /// （按钮事件已在 Designer.cs 中绑定，此方法保留为空占位，避免调用处报错）
        /// </summary>
        private void InitColumnConfigAddDeleteButtons()
        {
            // 按钮 Click 事件已在 frmDatabase.Designer.cs 中绑定，避免重复订阅
        }

        /// <summary>
        /// 组选择变更时：保存当前组配置，加载新组配置
        /// </summary>
        private void lstGroupSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroupSelector.SelectedItem == null) return;
            if (_isLoadingProduct) return; // 切换产品时不保存，避免旧数据覆盖新配置

            // 保存当前组的配置到 _barcodeConfig
            SaveCurrentGroupColumnsToConfig();

            // 切换到新组
            _selectedGroupName = lstGroupSelector.SelectedItem.ToString();
            LoadSelectedGroupToGrid();
        }

        /// <summary>
        /// 将当前 DataGridView 中显示的字段保存到 _barcodeConfig 对应组中
        /// </summary>
        private void SaveCurrentGroupColumnsToConfig()
        {
            if (_barcodeConfig == null || dgvGroupColumns == null) return;
            if (string.IsNullOrEmpty(_selectedGroupName)) return;

            var group = _barcodeConfig.Groups.FirstOrDefault(g => g.GroupName == _selectedGroupName);
            if (group == null) return;

            group.Columns.Clear();
            foreach (DataGridViewRow row in dgvGroupColumns.Rows)
            {
                if (row.IsNewRow) continue;

                string displayName = row.Cells["DisplayName"]?.Value?.ToString() ?? "";
                string address = row.Cells["Address"]?.Value?.ToString() ?? "";

                // 跳过完全空行
                if (string.IsNullOrWhiteSpace(displayName) && string.IsNullOrWhiteSpace(address))
                    continue;

                group.Columns.Add(new BarcodeColumnConfig
                {
                    DisplayName = displayName,
                    Address = address,
                    DataType = row.Cells["DataType"]?.Value?.ToString() ?? "STRING",
                    DbColumnName = row.Cells["DbColumnName"]?.Value?.ToString() ?? ""
                });
            }
        }

        /// <summary>
        /// 将 _barcodeConfig 中当前选中组的列加载到 DataGridView
        /// </summary>
        private void LoadSelectedGroupToGrid()
        {
            if (dgvGroupColumns == null || _barcodeConfig == null) return;

            dgvGroupColumns.Rows.Clear();

            var group = _barcodeConfig.Groups.FirstOrDefault(g => g.GroupName == _selectedGroupName);
            if (group?.Columns == null) return;

            foreach (var col in group.Columns)
            {
                if (col == null) continue;
                int rowIdx = dgvGroupColumns.Rows.Add();
                dgvGroupColumns.Rows[rowIdx].Cells["DisplayName"].Value = col.DisplayName;
                dgvGroupColumns.Rows[rowIdx].Cells["Address"].Value = col.Address;
                dgvGroupColumns.Rows[rowIdx].Cells["DataType"].Value = col.DataType ?? "STRING";
                dgvGroupColumns.Rows[rowIdx].Cells["DbColumnName"].Value = col.DbColumnName;
            }
        }

        /// <summary>
        /// 添加一行空配置到当前选中组的DataGridView
        /// </summary>
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (dgvGroupColumns == null) return;
            int rowIdx = dgvGroupColumns.Rows.Add();
            dgvGroupColumns.Rows[rowIdx].Cells["DataType"].Value = "STRING";
            dgvGroupColumns.ClearSelection();
            dgvGroupColumns.Rows[rowIdx].Selected = true;
            dgvGroupColumns.CurrentCell = dgvGroupColumns.Rows[rowIdx].Cells["DisplayName"];
        }

        /// <summary>
        /// 删除DataGridView中当前选中的行
        /// </summary>
        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dgvGroupColumns == null) return;
            if (dgvGroupColumns.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show("确定删除选中的配置行？", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            // 从后往前删除，避免索引变化问题
            for (int i = dgvGroupColumns.SelectedRows.Count - 1; i >= 0; i--)
            {
                var row = dgvGroupColumns.SelectedRows[i];
                if (!row.IsNewRow)
                    dgvGroupColumns.Rows.Remove(row);
            }
        }

        #endregion

        private void LoadVppDataGrid(DataGridView dataGridView, VppParamsDataTable vppParamsDataTable)
        {
            dataGridView.DataSource = vppParamsDataTable.dataTable;
            dataGridView.AccessibleDescription = vppParamsDataTable.path;
            dataGridView.Columns[0].Width = 300;
            dataGridView.Columns[1].Width = 80;

        }

        //打印机参数表
        public VppParamsDataTable _toshibaParamsDataTable;
        //打印机
        public ToshibaPrint _toshibaPrint = new ToshibaPrint();

        /// <summary>
        /// 读取打印机参数
        /// </summary>
        /// <returns></returns>
        public VppParamsDataTable ReadToshibaParams()
        {
            string path = Application.StartupPath + "\\CommonParams\\ToshibaParams.csv";
            _toshibaParamsDataTable = new VppParamsDataTable();
            DataTable dataTable = new DataTable();
            try
            {

                if (File.Exists(path))
                {
                    dataTable = CommonUI.DataOperate.CsvHelper.OpenCSV(path);
                    _toshibaParamsDataTable.dataTable = dataTable;
                    _toshibaParamsDataTable.path = path;
                }
                else
                {
                    MessageBox.Show("产品路径错误");
                    return null;
                }

                GlobalsVar._lableHight = Convert.ToSingle(dataTable.Rows[0][1]);
                GlobalsVar._lableWidth = Convert.ToSingle(dataTable.Rows[1][1]);
                GlobalsVar._lableGap = Convert.ToSingle(dataTable.Rows[2][1]);
                GlobalsVar._PrintDepth = Convert.ToInt16(dataTable.Rows[3][1]);
                GlobalsVar._labelDao = Convert.ToInt16(dataTable.Rows[4][1]);
                GlobalsVar._printMethod = Convert.ToString(dataTable.Rows[5][1]);
                GlobalsVar._sensor = Convert.ToString(dataTable.Rows[6][1]);
                GlobalsVar._speedPrint = Convert.ToString(dataTable.Rows[7][1]);
                GlobalsVar._printMoshi = Convert.ToString(dataTable.Rows[8][1]);
                GlobalsVar._printDirection = Convert.ToString(dataTable.Rows[9][1]);

                GlobalsVar._strInstallPosition = Convert.ToString(dataTable.Rows[10][1]);
                GlobalsVar._strPartNumber = Convert.ToString(dataTable.Rows[11][1]);
                GlobalsVar._strPartSKU = Convert.ToString(dataTable.Rows[12][1]);
                GlobalsVar._strCountry = Convert.ToString(dataTable.Rows[13][1]);
                GlobalsVar._strCountryCode = Convert.ToString(dataTable.Rows[14][1]);
                GlobalsVar._strBarcodeFront = Convert.ToString(dataTable.Rows[15][1]);
                GlobalsVar._line = Convert.ToString(dataTable.Rows[16][1]);
                GlobalsVar._qualityCode = Convert.ToString(dataTable.Rows[17][1]);
                _productCount = Convert.ToInt16(dataTable.Rows[18][1]);
                //GlobalsVar
            }
            catch (Exception ex)
            {
                dataTable = null;
                RecordInformation(Path.GetFileNameWithoutExtension(path) + "加载数据异常： " + ex.Source.ToString());

            }
            return _toshibaParamsDataTable;
        }
        /// <summary>
        /// 读取网口参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>返回网口参数
        private StatusInfo<EthernetConfig> ReadEthernetConfig(string paramName)
        {
            StatusInfo<EthernetConfig> statusInfo = new StatusInfo<EthernetConfig>();
            try
            {

                string path = GlobalsVar._commonParamsPath + paramName;
                EthernetConfig ethernetConfig = new EthernetConfig();
                ethernetConfig.ReadConfig(path);
                statusInfo.Datatype = ethernetConfig;
                statusInfo.IsSuccess = true;

            }
            catch (Exception ex)
            {
                statusInfo.info = ex.Source.ToString();
                statusInfo.IsSuccess = false;
            }

            return statusInfo;

        }


        private void LoadComunicationControlParam()
        {
            //网口1
            ethernetCtl1.IP = _ethernetConfig.IP;
            ethernetCtl1.Port = _ethernetConfig.Port;

            //网口2
            ethernetCtl2.IP = _ethernetConfig2.IP;
            ethernetCtl2.Port = _ethernetConfig2.Port;
        }

        #region 数据库参数


        ///<summary>
        /// 标签数量
        /// </summary>
        public int _labelCount = 0;

        ///<summary>
        /// 水壶气密值
        /// </summary>
        public float _bottleAirtightValue = 0;

        ///<summary>
        /// 电机电压值
        /// </summary>
        public float _MotorVValue = 0;

        ///<summary>
        /// 1号电机电流值
        /// </summary>
        public float _Motor1AValue = 0;

        ///<summary>
        /// 2号电机电流值
        /// </summary>
        public float _Motor2AValue = 0;
        ///<summary>
        /// 3号电机电流值
        /// </summary>
        public float _Motor3AValue = 0;


        ///<summary>
        /// 产品二维码结果
        /// </summary>
        public int _proDMResult = 0;

        ///<summary>
        /// 产品RFID结果
        /// </summary>
        public int _proRFIDResult = 0;

        ///<summary>
        /// CCD相机检测结果
        /// </summary>
        public int _CCDResult = 0;

        ///<summary>
        /// 水壶气密值结果
        /// </summary>
        public int _bottleAirtightResult = 0;


        ///<summary>
        /// 电机电压值结果
        /// </summary>
        public int _motorVResult = 0;

        ///<summary>
        /// 1#电机电流值结果
        /// </summary>
        public int _motor1AResult = 0;

        ///<summary>
        ///  2#电机电流值结果
        /// </summary>
        public int _motor2AResult = 0;

        ///<summary>
        ///  二维码结果信息
        /// </summary>
        public string _serialInfo = string.Empty;

        ///<summary>
        /// 3#电机电流值结果
        /// </summary>
        public int _motor3AResult = 0;

        ///<summary>
        /// 计数器
        /// </summary>
        public int _productCount = 0;

        public List<string> serialList = new List<string>();



        #endregion
        ///<summary>
        /// 计数器，时间产生序列号
        /// </summary>
        public void CreatSerial(int count)
        {
            try
            {
                string hex = ConvertHex(count);//5
                string timeCode = ConvertTime();//3
                string frontCode = GlobalsVar._strBarcodeFront;//1
                string partCode = GlobalsVar._strPartNumber;
                string[] partCodeArray = partCode.Split('-');
                partCode = partCodeArray[0] + partCodeArray[1];//2
                string lineCode = GlobalsVar._line;//4
                string qualityCode = GlobalsVar._qualityCode;//6

                GlobalsVar._strBarcode = frontCode + partCode + timeCode + lineCode + hex + qualityCode;
                serialList.Add(GlobalsVar._strBarcode);
            }
            catch (Exception e)
            {
                MessageBox.Show("错误信息：" + e.ToString());

            }
        }


        private string getValuebyKey(string key)
        {
            string path = Application.StartupPath + "\\CommonParams\\dayCodeParams.csv";
            DataTable dataTable = new DataTable();
            try
            {
                if (File.Exists(path))
                {
                    dataTable = CsvHelper.OpenCSV(path);
                }
                else
                {
                    return "";
                }
            }
            catch { }
            DataRow[] drs = dataTable.Select("Day='" + key.ToString() + "'");

            if (drs.Count() == 0) return "";
            else
                return drs[0][1].ToString();
        }

        ///<summary>
        /// 根据当前时间，根据客户要求，产生时间代码
        /// </summary>

        public string ConvertTime()
        {
            try
            {
                string yearCode = string.Empty;
                string monthCode = string.Empty;
                string dayCode = string.Empty;
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                switch (year)
                {
                    case 2023:
                        yearCode = "N";
                        break;
                    case 2024:
                        yearCode = "O";
                        break;
                    case 2025:
                        yearCode = "P";
                        break;
                    case 2026:
                        yearCode = "Q";
                        break;
                    case 2027:
                        yearCode = "R";
                        break;
                    case 2028:
                        yearCode = "S";
                        break;
                    case 2029:
                        yearCode = "T";
                        break;
                    case 2030:
                        yearCode = "U";
                        break;
                    case 2031:
                        yearCode = "V";
                        break;
                    default:
                        break;
                }

                switch (month)
                {
                    case 1:
                        monthCode = "1";
                        break;
                    case 2:
                        monthCode = "2";
                        break;
                    case 3:
                        monthCode = "3";
                        break;
                    case 4:
                        monthCode = "4";
                        break;
                    case 5:
                        monthCode = "5";
                        break;
                    case 6:
                        monthCode = "6";
                        break;
                    case 7:
                        monthCode = "7";
                        break;
                    case 8:
                        monthCode = "8";
                        break;
                    case 9:
                        monthCode = "9";
                        break;
                    case 10:
                        monthCode = "A";
                        break;
                    case 11:
                        monthCode = "B";
                        break;
                    case 12:
                        monthCode = "C";
                        break;

                    default:
                        break;
                }

                dayCode = getValuebyKey(day.ToString());

                string dateString = yearCode + monthCode + dayCode;
                return dateString;
            }
            catch (Exception e)
            {

                MessageBox.Show("错误信息：" + e.ToString());
                return "";
            }
        }

        ///<summary>
        /// 二进制数字转化为16进制（4095最大）
        /// </summary>
        public string ConvertHex(int count)
        {
            try
            {
                string specifier = "X";
                string hex = count.ToString(specifier);
                int length = hex.Length;
                switch (length)
                {
                    case 1:
                        hex = "00" + hex;

                        break;
                    case 2:
                        hex = "0" + hex;
                        break;
                    case 3:

                        break;
                    default:
                        break;
                }
                return hex;
            }
            catch (Exception e)
            {
                MessageBox.Show("错误信息：" + e.ToString());
                return "";
            }

        }


        /// <summary>
        /// PLC通信线程 - 心跳写入 + 允许读取判断 + 读取条码内容
        /// </summary>
        private void ProcessPlcCommunication(object ob)
        {
            // 等待窗体加载完成
            Thread.Sleep(2000);

            while (true)
            {
                try
                {
                    // 如果PLC未连接，根据自动重连设置决定是否尝试重连
                    if (!_plcConnected)
                    {
                        if (_autoReconnect)
                        {
                            string plcIp = txtPlcIp?.Text?.Trim();
                            string plcPortStr = txtPlcPort?.Text?.Trim();

                            if (!string.IsNullOrWhiteSpace(plcIp) && !string.IsNullOrWhiteSpace(plcPortStr)
                                && plcIp != "Any" && int.TryParse(plcPortStr, out int plcPort))
                            {
                                bool connected = _siemensS7.Connect(plcIp, plcPort);
                                if (connected)
                                {
                                    _plcConnected = true;
                                    RecordInformation("PLC连接成功：" + plcIp + ":" + plcPort);
                                }
                                else
                                {
                                    RecordInformation("PLC连接失败，将在5秒后重试...");
                                }
                            }
                        }
                        Thread.Sleep(5000);
                        continue;
                    }

                    // 1. 心跳写入：向心跳地址循环写 1 和 0，间隔 1 秒
                    DoHeartbeat();

                    // 2. 遍历所有产品，检查各自的允许读取地址
                    int productCount = _multiProductConfig?.Products?.Count ?? 0;
                    bool hasNewData = false;
                    for (int pi = 0; pi < productCount; pi++)
                    {
                        var product = _multiProductConfig?.Products?.ElementAtOrDefault(pi);
                        if (product == null) continue;

                        bool canRead = CheckEnableReadForProduct(product);
                        if (canRead)
                        {
                            var savedConfig = _barcodeConfig;
                            _barcodeConfig = product.BarcodeConfig;

                            ReadAllBarcodeContents();

                            lock (_barcodeValuesLock)
                            {
                                _allBarcodeValues[pi] = new Dictionary<string, string>(_barcodeValues);
                            }

                            CheckAndWriteBarcodeStatusForProduct(product);
                            WriteEnableReadCompleteForProduct(product);

                            _barcodeConfig = savedConfig;
                            hasNewData = true;
                        }
                    }

                    // PLC触发读取后刷新UI
                    if (hasNewData)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            LoadProductValues(_selectedProductIndex);
                            UpdateMainDashboard();
                        }));
                    }

                    // 6. 周期性连接健康检查（每10次循环检测一次，避免频繁读）
                    _healthCheckCounter++;
                    if (_healthCheckCounter >= 10)
                    {
                        _healthCheckCounter = 0;
                        CheckPlcConnectionHealth();
                    }

                    Thread.Sleep(BARCODE_READ_INTERVAL_MS);
                }
                catch (Exception ex)
                {
                    if (_plcConnected)
                    {
                        RecordInformation("❌ PLC通信异常，连接断开：" + ex.Message);
                        _plcConnected = false;
                    }
                    Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// 心跳写入：向心跳地址循环写 1 和 0，间隔 1 秒
        /// 写入失败会抛出异常，由外层 catch 统一处理断线
        /// </summary>
        private void DoHeartbeat()
        {
            string heartbeatAddr = txtHeartbeatAddr?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(heartbeatAddr))
                heartbeatAddr = _heartbeatAddress;

            if ((DateTime.Now - _lastHeartbeatTime).TotalMilliseconds >= HEARTBEAT_INTERVAL_MS)
            {
                _heartbeatState = !_heartbeatState;
                short value = _heartbeatState ? (short)1 : (short)0;
                string addrType = ParseAddressType(heartbeatAddr);
                uint addrOffset = ParseAddressOffset(heartbeatAddr);
                bool ok = _siemensS7.WriterRegisterInt16(addrType, addrOffset, value);
                if (!ok)
                    throw new Exception($"心跳写入失败 [{heartbeatAddr}]，PLC可能已断开");
                _lastHeartbeatTime = DateTime.Now;
            }
        }

        /// <summary>
        /// 检查指定产品的允许读取地址
        /// </summary>
        private bool CheckEnableReadForProduct(ProductConfig product)
        {
            string addr = product?.EnableReadAddress;
            if (string.IsNullOrWhiteSpace(addr)) return false;
            try
            {
                string addrType = ParseAddressType(addr);
                uint addrOffset = ParseAddressOffset(addr);
                int value = _siemensS7.ReadRegisterInt16(addrType, addrOffset);
                if (value == 1)
                    RecordInformation($"[{product.ProductName}] 允许读取地址 {addr}=1，开始读取");
                return value == 1;
            }
            catch (Exception ex)
            {
                RecordInformation($"[{product.ProductName}] 读取允许地址 {addr} 失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 回写指定产品的允许读取地址为2
        /// </summary>
        private void WriteEnableReadCompleteForProduct(ProductConfig product)
        {
            string addr = product?.EnableReadAddress;
            if (string.IsNullOrWhiteSpace(addr)) return;
            try
            {
                string addrType = ParseAddressType(addr);
                uint addrOffset = ParseAddressOffset(addr);
                _siemensS7.WriterRegisterInt16(addrType, addrOffset, 2);
            }
            catch (Exception ex)
            {
                RecordInformation($"回写产品{product.ProductName}允许读取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 根据压装总成状态写库：1=OK表，其他=NG表
        /// </summary>
        private void CheckAndWriteBarcodeStatusForProduct(ProductConfig product)
        {
            Dictionary<string, object> insertDict;
            string statusVal;
            lock (_barcodeValuesLock)
            {
                insertDict = MySqlSugarHelper.BuildInsertDictFromBarcodeValues(_barcodeValues, product.BarcodeConfig);
                statusVal = _barcodeValues.TryGetValue("主码_压装总成状态", out string v) ? v : "";
            }

            bool isOk = statusVal == "1";
            string tableName = isOk ? product.OkTableName : product.NgTableName;

            try
            {
                if (isOk)
                    _mySqlSugarHelper.InsertOK(insertDict, tableName);
                else
                    _mySqlSugarHelper.InsertNG(insertDict, tableName);
                RecordInformation($"[{product.ProductName}] 总成状态={statusVal}，已写入{tableName}");
            }
            catch (Exception ex) { RecordInformation($"[{product.ProductName}] 写入{tableName}失败：" + ex.Message); }
        }

        /// <summary>
        /// 连接健康检查：简单读取一个地址，失败则抛出异常触发断线处理
        /// </summary>
        private void CheckPlcConnectionHealth()
        {
            string testAddr = GetFirstConfiguredAddress();
            if (string.IsNullOrWhiteSpace(testAddr))
                testAddr = "DB18.0";
            // 简单读一个字节，失败会抛异常 → 外层 catch 标记断线
            _siemensS7.Readbyte(testAddr);
        }

        /// <summary>
        /// 读取并写入数据库完成后，向允许读取地址回写 2，通知PLC处理已完成
        /// PLC侧流程：PLC写1 → PC读数据+写库 → PC写2 → PLC检测到2后写0 → 下一轮
        /// </summary>
        private void WriteEnableReadComplete()
        {
            string enableAddr = txtEnableReadAddr?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(enableAddr))
                enableAddr = _enableReadAddress;

            try
            {
                string addrType = ParseAddressType(enableAddr);
                uint addrOffset = ParseAddressOffset(enableAddr);
                _siemensS7.WriterRegisterInt16(addrType, addrOffset, 2);
            }
            catch (Exception ex)
            {
                RecordInformation($"回写允许读取地址 {enableAddr}=2 失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 解析地址类型部分，如 "DB100.78" -> "DB100"（不含末尾点号，
        /// 读取/写入方法内部会自动拼 "." + offset）
        /// </summary>
        private string ParseAddressType(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return "DB18";
            int dotIndex = address.LastIndexOf('.');
            if (dotIndex > 0)
                return address.Substring(0, dotIndex);
            // 如果没有点号，返回原字符串（去掉可能存在的末尾点）
            return address.TrimEnd('.');
        }

        /// <summary>
        /// 解析地址偏移量部分，如 "DB100.78" -> 78
        /// </summary>
        private uint ParseAddressOffset(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return 0;
            int dotIndex = address.LastIndexOf('.');
            if (dotIndex > 0 && uint.TryParse(address.Substring(dotIndex + 1), out uint offset))
                return offset;
            return 0;
        }

        /// <summary>
        /// 从PLC读取所有配置的条码字段内容（按BarcodeConfig循环读取）
        /// </summary>
        private void ReadAllBarcodeContents()
        {
            if (_barcodeConfig == null) return;

            // 先清空旧值，准备重新读取
            lock (_barcodeValuesLock)
            {
                _barcodeValues.Clear();

                foreach (var group in _barcodeConfig.Groups)
                {
                    if (group?.Columns == null) continue;

                    foreach (var col in group.Columns)
                    {
                        if (col == null || string.IsNullOrWhiteSpace(col.Address)) continue;

                        string value = ReadValueFromPlc(col.Address, col.DataType);
                        string key = BuildBarcodeValueKey(group.GroupName, col.DbColumnName);

                        if (!string.IsNullOrEmpty(value))
                        {
                            _barcodeValues[key] = value;
                        }
                        else
                        {
                            _barcodeValues[key] = null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据数据类型从PLC读取值
        /// </summary>
        private string ReadValueFromPlc(string address, string dataType)
        {
            if (string.IsNullOrWhiteSpace(address))
                return null;

            try
            {
                switch (dataType?.ToUpperInvariant())
                {
                    case "INT16":
                        string addrType = ParseAddressType(address);
                        uint addrOffset = ParseAddressOffset(address);
                        int intVal = _siemensS7.ReadRegisterInt16(addrType, addrOffset);
                        return intVal.ToString();

                    case "REAL":
                        // 西门子REAL = C# float，使用ReadRegisterfloat需要解析地址
                        string realAddrType = ParseAddressType(address);
                        uint realAddrOffset = ParseAddressOffset(address);
                        float floatVal = _siemensS7.ReadRegisterfloat(realAddrType, realAddrOffset);
                        return floatVal.ToString("F3"); // 保留3位小数

                    case "BYTE":
                        byte byteVal = _siemensS7.Readbyte(address);
                        return byteVal.ToString();

                    case "STRING":
                    default:
                        return ReadStringFromPlc(address);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ReadValueFromPlc 异常 [{address},{dataType}]: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 从指定PLC地址读取字符串内容
        /// 支持格式：DB100.0 或 DB100.10 等
        /// </summary>
        private string ReadStringFromPlc(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return string.Empty;

            try
            {
                // 西门子 STRING 格式：Byte0=最大长度, Byte1=实际长度, Byte2+=字符串内容
                // 先读2字节头部获取实际长度，再从 offset+2 读字符串
                byte[] header = _siemensS7.ReadBytes(address, 2);
                int actualLen = header.Length >= 2 ? header[1] : 0;
                if (actualLen <= 0) return string.Empty;

                string addrType = ParseAddressType(address);
                uint addrOffset = ParseAddressOffset(address);
                string dataAddr = addrType + "." + (addrOffset + 2);
                byte[] data = _siemensS7.ReadBytes(dataAddr, (ushort)actualLen);
                string result = Encoding.ASCII.GetString(data).Replace("\0", "").Trim();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ReadStringFromPlc 异常 [{address}]: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// 构建条码值的字典key: "{组名}_{数据库列名}"
        /// </summary>
        private string BuildBarcodeValueKey(string groupName, string dbColumnName)
        {
            return (groupName ?? "") + "_" + (dbColumnName ?? "");
        }

        /// <summary>
        /// 构建JSON格式的条码数据内容（所有读取值的键值对）
        /// </summary>
        private string BuildBarcodeDataContentJson()
        {
            if (_barcodeValues == null || _barcodeValues.Count == 0)
                return "{}";

            // 过滤掉null值（读取为空的情况）—— 用户要求"读取为空就null"
            // 这里我们用Json.NET来序列化
            var dict = new Dictionary<string, string>();
            foreach (var kvp in _barcodeValues)
            {
                // key只保留非空值，null值不加入JSON（数据库字段会为NULL）
                if (kvp.Value != null)
                    dict[kvp.Key] = kvp.Value;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(dict);
        }

        /// <summary>
        /// 读取码状态地址，根据值写入OKTable或NGTable
        /// 1=OK写入OKTable，2=NG写入NGTable
        /// 防止重复写入：只有值发生变化时才写入
        /// 数据写入方式：兼容旧字段(主码,副码1~4) + JSON数据内容(所有字段)
        /// </summary>
        private void CheckAndWriteBarcodeStatus()
        {
            string statusAddr = txtCodeStatusAddr?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(statusAddr))
                statusAddr = _codeStatusAddress;

            int statusValue = 0;
            try
            {
                string addrType = ParseAddressType(statusAddr);
                uint addrOffset = ParseAddressOffset(statusAddr);
                statusValue = _siemensS7.ReadRegisterInt16(addrType, addrOffset);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CheckAndWriteBarcodeStatus 读取状态地址异常 [{statusAddr}]: {ex.Message}");
                return;
            }

            // 如果状态值没有变化，不重复写入
            if (statusValue == _lastCodeStatusValue)
                return;

            _lastCodeStatusValue = statusValue;

            // 从 _barcodeValues + _barcodeConfig 构建动态列字典（加锁防止UI线程并发读）
            Dictionary<string, object> insertDict;
            lock (_barcodeValuesLock)
            {
                insertDict = MySqlSugarHelper.BuildInsertDictFromBarcodeValues(_barcodeValues, _barcodeConfig);
            }

            if (statusValue == 1)
            {
                // OK - 写入OKTable
                try
                {
                    _mySqlSugarHelper.InsertOK(insertDict);
                    RecordInformation("OK条码已写入OKTable表（动态列模式）");
                }
                catch (Exception ex)
                {
                    RecordInformation("写入OKTable失败：" + ex.Message);
                }
            }
            else if (statusValue == 2)
            {
                // NG - 写入NGTable
                try
                {
                    _mySqlSugarHelper.InsertNG(insertDict);
                    RecordInformation("NG条码已写入NGTable表（动态列模式）");
                }
                catch (Exception ex)
                {
                    RecordInformation("写入NGTable失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取指定组中第一个字段的值（用于兼容旧字段显示）
        /// </summary>
        private string GetGroupFirstValue(string groupName)
        {
            if (_barcodeConfig == null) return null;

            var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null || group.Columns.Count == 0) return null;

            var firstCol = group.Columns[0];
            string key = BuildBarcodeValueKey(groupName, firstCol.DbColumnName);

            lock (_barcodeValuesLock)
            {
                return _barcodeValues.TryGetValue(key, out string val) ? val : null;
            }
        }
        public void RecordInformation(string data)
        {
            RecordInformationBase(txtRecordinfo, data);
        }


        private void RecordInformationBase(RichTextBox txtDisText, string data)
        {
            if (txtDisText == null) return;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RichTextBox, string>(RecordInformationBase), new object[] { txtDisText, data });
                return;
            }

            if (txtDisText.TextLength > 4000 || data == "Clear")
            {
                txtDisText.Clear();
            }

            string writeData = DateTime.Now.ToString("HH:mm:ss :fff") + " " + data + Environment.NewLine;
            Log.WriteLog(InfoLevel.INFO, writeData);

            Color logColor = GetLogColor(data);
            int start = txtDisText.TextLength;
            txtDisText.SelectionStart = start;
            txtDisText.SelectionLength = 0;
            txtDisText.SelectionColor = logColor;
            txtDisText.AppendText(writeData);
            txtDisText.SelectionStart = txtDisText.TextLength;
            txtDisText.SelectionLength = 0;
            txtDisText.ScrollToCaret();
            txtDisText.SelectionColor = txtDisText.ForeColor;
        }

        private Color GetLogColor(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return txtRecordinfo.ForeColor;

            string text = data.ToLowerInvariant();

            if (text.Contains("失败") || text.Contains("ng") || text.Contains("异常") || text.Contains("错误") || text.Contains("断开") || text.Contains("报警"))
            {
                return Color.Red;
            }

            if (text.Contains("读取") || text.Contains("接收") || text.Contains("成功") || text.Contains("ok") || text.Contains("已写入") || text.Contains("连接成功"))
            {
                return Color.Green;
            }

            return txtRecordinfo.ForeColor;
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="path"></param>
        private void DisImage(PictureBox pictureBox, string path)
        {


            if (this.InvokeRequired)
            {
                this.Invoke(new Action<PictureBox, string>(DisImage), new object[] { pictureBox, path });
            }
            else
            {
                pictureBox.Image = Image.FromFile(path);

            }
        }


        private StatusInfo ReadCommunicationConfig()
        {


            StatusInfo statusInfo = new StatusInfo();
            try
            {
                //读取网口1
                StatusInfo<EthernetConfig> ethernetConfig = ReadEthernetConfig("ethernetCtl1.xml");
                if (ethernetConfig.IsSuccess)
                {
                    _ethernetConfig = ethernetConfig.Datatype;
                }

                //读取网口2
                StatusInfo<EthernetConfig> ethernetConfig2 = ReadEthernetConfig("ethernetCtl2.xml");
                if (ethernetConfig2.IsSuccess)
                {
                    _ethernetConfig2 = ethernetConfig2.Datatype;
                }

                //读取网口3
                StatusInfo<EthernetConfig> ethernetConfig3 = ReadEthernetConfig("ethernetCtl3.xml");
                if (ethernetConfig3.IsSuccess)
                {
                    _ethernetConfig3 = ethernetConfig3.Datatype;
                }

                statusInfo.IsSuccess = true;

            }
            catch (Exception ex)
            {
                statusInfo.info = ex.Source.ToString();
                statusInfo.IsSuccess = false;
            }

            return statusInfo;

        }

    

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            btnReconnect.Enabled = false;
            btnReconnect.Text = "重连中...";
            try
            {
                // 先断开当前连接
                if (_plcConnected)
                {
                    try { _siemensS7.DisConnect(); } catch { }
                    _plcConnected = false;
                }

                // 立即尝试重连
                string plcIp = txtPlcIp?.Text?.Trim();
                string plcPortStr = txtPlcPort?.Text?.Trim();

                if (!string.IsNullOrWhiteSpace(plcIp) && !string.IsNullOrWhiteSpace(plcPortStr)
                    && plcIp != "Any" && int.TryParse(plcPortStr, out int plcPort))
                {
                    bool connected = _siemensS7.Connect(plcIp, plcPort);
                    if (connected)
                    {
                        _plcConnected = true;
                        RecordInformation("手动重连成功：" + plcIp + ":" + plcPort);
                    }
                    else
                    {
                        RecordInformation("手动重连失败：" + plcIp + ":" + plcPort);
                    }
                }
                else
                {
                    RecordInformation("手动重连失败：PLC IP/端口未配置或无效");
                }
            }
            catch (Exception ex)
            {
                RecordInformation("手动重连异常：" + ex.Message);
            }
            finally
            {
                btnReconnect.Enabled = true;
                btnReconnect.Text = "通讯重连";
            }
        }

        private void btnSaveComParam_Click(object sender, EventArgs e)
        {
            SaveBarcodeAddressParams();
        }
        private void SaveEthernet(EthernetCtl ethernetCtl, string ethernetPathName)
        {

            string path = Application.StartupPath + "\\配置文件\\" + ethernetPathName;
            EthernetConfig ethernetConfig = new EthernetConfig();
            ethernetConfig.IP = ethernetCtl.IP;
            ethernetConfig.Port = ethernetCtl.Port;
            ethernetConfig.SaveConfig(path);

        }

        private void SaveBarcodeAddressParams()
        {
            try
            {
                btnSaveComParam.Enabled = false;
                btnSaveComParam.Text = "⏳ 保存中...";

                // 确保配置目录存在
                string configDir = Application.StartupPath + "\\配置文件";
                if (!Directory.Exists(configDir))
                    Directory.CreateDirectory(configDir);

                // 1. 保存当前产品配置 + 心跳地址
                SaveCurrentProductConfig();
                _heartbeatAddress = txtHeartbeatAddr?.Text?.Trim() ?? _heartbeatAddress;
                _multiProductConfig.HeartbeatAddress = _heartbeatAddress;
                bool autoReconnect = chkAutoReconnect?.Checked ?? true;

                // 写入旧INI兼容
                string iniPath = configDir + "\\barcodeAddress.config";
                using (var sw = new StreamWriter(iniPath, false))
                {
                    sw.WriteLine("Heartbeat=" + _heartbeatAddress);
                    sw.WriteLine("PlcIp=" + (txtPlcIp?.Text?.Trim() ?? "Any"));
                    sw.WriteLine("PlcPort=" + (txtPlcPort?.Text?.Trim() ?? "5000"));
                    sw.WriteLine("AutoReconnect=" + autoReconnect.ToString().ToLower());
                }

                _autoReconnect = autoReconnect;

                // 2. 保存多产品配置到JSON
                SaveColumnConfigToJson();
                RecordInformation("✅ 配置已保存到: " + BarcodeConfigManager.GetConfigDir());

                // 3. 同步数据库表结构（新增/修改字段后自动补充列）
                if (_mySqlSugarHelper != null)
                    _mySqlSugarHelper.SyncTableFromConfig(_barcodeConfig);

                // 4. 刷新查询结果表格列结构（动态列随配置变化）
                InitQueryResultGrids();

                // 5. 刷新主界面
                if (dgvMainCode != null)
                    RefreshAllGroupGrids();

                // 6. 保存成功反馈
                btnSaveComParam.Text = "✅ 已保存";
                btnSaveComParam.BackColor = Color.FromArgb(0, 153, 102);
                RecordInformation("✅ 配置已保存（协议地址 + JSON表格配置）");

                // 2秒后恢复按钮文字
                var timer = new System.Windows.Forms.Timer { Interval = 2000 };
                timer.Tick += (s, ev) =>
                {
                    btnSaveComParam.Text = "💾 保存参数";
                    btnSaveComParam.BackColor = Color.FromArgb(0, 153, 102);
                    btnSaveComParam.Enabled = true;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                btnSaveComParam.Text = "❌ 保存失败";
                btnSaveComParam.BackColor = Color.FromArgb(231, 76, 60);
                RecordInformation("❌ 保存配置失败：" + ex.Message);

                var timer = new System.Windows.Forms.Timer { Interval = 3000 };
                timer.Tick += (s, ev) =>
                {
                    btnSaveComParam.Text = "💾 保存参数";
                    btnSaveComParam.BackColor = Color.FromArgb(0, 153, 102);
                    btnSaveComParam.Enabled = true;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        /// <summary>
        /// 将所有组的配置保存为JSON文件（从内存 _barcodeConfig 中读取）
        /// </summary>
        private void SaveColumnConfigToJson()
        {
            if (_barcodeConfig == null) return;

            // 先保存当前 DataGridView 中显示的组到当前产品
            SaveCurrentGroupColumnsToConfig();

            // 更新当前产品配置
            if (_multiProductConfig?.Products != null && _selectedProductIndex < _multiProductConfig.Products.Count)
                _multiProductConfig.Products[_selectedProductIndex].BarcodeConfig = _barcodeConfig;

            // 保存完整多产品配置到JSON
            BarcodeConfigManager.SaveMultiConfig(_multiProductConfig);
        }

        private void frmDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("确定要退出程序吗？", "退出确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            SaveProductNameCSVParams();

        }

        public void SaveProductNameCSVParams()
        {
            string path = Application.StartupPath + "\\CommonParams\\ToshibaParams.csv";
            //_commonParamsDataTable = new VppParamsDataTable();
            DataTable dataTable = new DataTable();
            try
            {
                // DateTime.Now
                if (File.Exists(path))
                {
                    dataTable = CsvHelper.OpenCSV(path);
                    dataTable.Rows[17][1] = _productCount;
                    CsvHelper.SaveCSV(dataTable, path);
                }
                else
                {
                    MessageBox.Show("产品路径错误");

                }

                //GlobalsVar._imageFolderPath = Convert.ToString(dataTable.Rows[0][1]);
                //_imageSaveDays = Convert.ToUInt16(dataTable.Rows[1][1]);
                //_imageSaveSizes = Convert.ToUInt16(dataTable.Rows[2][1]);
                //_currentProductName = Convert.ToString(dataTable.Rows[3][1]);

            }
            catch (Exception ex)
            {
                dataTable = null;
                RecordInformation(Path.GetFileNameWithoutExtension(path) + "加载数据异常： " + ex.Source.ToString());
                Log.WriteLog(InfoLevel.ERROR, "保存产品名称加载数据异常： " + ex.Source.ToString());

            }
            // return _commonParamsDataTable;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void timerHeart_Tick(object sender, EventArgs e)
        {
            // 仅负责UI心跳闪烁标记，实际PLC连接检测由后台线程 ProcessPlcCommunication 负责
            // 不再在UI线程上调用PLC读操作，避免界面卡死
            try
            {
                if (_plcConnected)
                {
                    _heartbeatToggle = !_heartbeatToggle;
                }
            }
            catch { }
        }

        /// <summary>
        /// 获取配置中第一个非空PLC地址（用于心跳检测）
        /// </summary>
        private string GetFirstConfiguredAddress()
        {
            if (_barcodeConfig?.Groups != null)
            {
                foreach (var group in _barcodeConfig.Groups)
                {
                    if (group?.Columns != null)
                    {
                        foreach (var col in group.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(col?.Address))
                                return col.Address;
                        }
                    }
                }
            }
            return null;
        }

        //显示标记
        int recordflag = 0;

        /// <summary>
        /// 计时器显示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            try
            {
                timerDisplay.Enabled = false;
                UpdateMainDashboard();
                timerDisplay.Enabled = true;
                recordflag = 0;
            }
            catch { }
            finally
            {
                recordflag = 0;
                if (!timerDisplay.Enabled) timerDisplay.Enabled = true;
            }
        }

        private void UpdateMainDashboard()
        {
            if (lblMainCodeValue == null) return;

            // 获取各组第一个字段的值（用于状态显示和汇总）
            string mainCodeVal = GetGroupFirstValue("主码");

            // 刷新所有码组的动态显示面板（显示该组所有配置字段）
            RefreshAllGroupGrids();

            // 更新第一行压装标题状态（固定读 _allBarcodeValues[0]，不受当前选中产品影响）
            UpdateProductGroupTitleStatus(0, "主码", lblMainCodeTitle);
            UpdateProductGroupTitleStatus(0, "副码1", lblSub1Title);
            UpdateProductGroupTitleStatus(0, "副码2", lblSub2Title);
            UpdateProductGroupTitleStatus(0, "副码3", lblSub3Title);
            UpdateProductGroupTitleStatus(0, "副码4", lblSub4Title);

            // 更新第二行推卡夹标题状态（固定读 _allBarcodeValues[1]）
            if (_row2Titles != null)
            {
                string[] groupNames = { "主码", "副码1", "副码2", "副码3", "副码4" };
                for (int i = 0; i < _row2Titles.Length && i < groupNames.Length; i++)
                {
                    UpdateProductGroupTitleStatus(1, groupNames[i], _row2Titles[i]);
                }
            }

            // 更新PLC心跳指示灯
            UpdatePlcHeartbeat();

            // === 更新双产品状态栏 ===
            UpdateDualProductSummary();
        }

        /// <summary>
        /// 更新双产品状态栏（压装左 / 推卡夹右）
        /// </summary>
        private void UpdateDualProductSummary()
        {
            var products = _multiProductConfig?.Products;
            if (products == null) return;

            // --- 压装产品（索引0）---
            if (products.Count > 0 && lblProduct1Status != null)
            {
                string p1MainCode = GetProductGroupFirstValue(0, "主码");
                bool p1HasMain = !string.IsNullOrWhiteSpace(p1MainCode);

                if (_plcConnected)
                {
                    lblProduct1Status.Text = p1HasMain
                        ? $"压装主码：已接收 ✓"
                        : "压装主码：等待PLC数据...";
                    lblProduct1Status.ForeColor = p1HasMain
                        ? Color.FromArgb(0, 153, 102)
                        : Color.FromArgb(160, 160, 160);
                }
                else
                {
                    lblProduct1Status.Text = "压装：PLC未连接";
                    lblProduct1Status.ForeColor = Color.FromArgb(231, 76, 60);
                }

                if (lblProduct1SubSummary != null)
                {
                    string p1Summary = BuildProductSubCodeSummary(0);
                    lblProduct1SubSummary.Text = p1Summary;
                    bool p1AnyResult = HasAnySubResult(0);
                    lblProduct1SubSummary.ForeColor = p1AnyResult
                        ? Color.FromArgb(30, 55, 90)
                        : Color.FromArgb(160, 160, 160);
                }
            }

            // --- 推卡夹产品（索引1）---
            if (products.Count > 1 && lblProduct2Status != null)
            {
                string p2MainCode = GetProductGroupFirstValue(1, "主码");
                bool p2HasMain = !string.IsNullOrWhiteSpace(p2MainCode);

                if (_plcConnected)
                {
                    lblProduct2Status.Text = p2HasMain
                        ? $"推卡夹主码：已接收 ✓"
                        : "推卡夹主码：等待PLC数据...";
                    lblProduct2Status.ForeColor = p2HasMain
                        ? Color.FromArgb(0, 153, 102)
                        : Color.FromArgb(160, 160, 160);
                }
                else
                {
                    lblProduct2Status.Text = "推卡夹：PLC未连接";
                    lblProduct2Status.ForeColor = Color.FromArgb(231, 76, 60);
                }

                if (lblProduct2SubSummary != null)
                {
                    string p2Summary = BuildProductSubCodeSummary(1);
                    lblProduct2SubSummary.Text = p2Summary;
                    bool p2AnyResult = HasAnySubResult(1);
                    lblProduct2SubSummary.ForeColor = p2AnyResult
                        ? Color.FromArgb(30, 55, 90)
                        : Color.FromArgb(160, 160, 160);
                }
            }
        }

        /// <summary>
        /// 从 _allBarcodeValues 获取指定产品的指定组的第一个字段值
        /// </summary>
        private string GetProductGroupFirstValue(int productIndex, string groupName)
        {
            if (_multiProductConfig?.Products == null) return null;
            if (productIndex >= _multiProductConfig.Products.Count) return null;
            var product = _multiProductConfig.Products[productIndex];
            if (product?.BarcodeConfig == null) return null;

            var group = product.BarcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null || group.Columns.Count == 0) return null;

            var firstCol = group.Columns[0];
            string key = BuildBarcodeValueKey(groupName, firstCol.DbColumnName);

            lock (_barcodeValuesLock)
            {
                if (_allBarcodeValues.TryGetValue(productIndex, out var values))
                    return values.TryGetValue(key, out string val) ? val : null;
            }
            return null;
        }

        /// <summary>
        /// 从 _allBarcodeValues 获取指定产品的指定组的结果字段值
        /// </summary>
        private string GetProductGroupResultValue(int productIndex, string groupName)
        {
            if (_multiProductConfig?.Products == null) return null;
            if (productIndex >= _multiProductConfig.Products.Count) return null;
            var product = _multiProductConfig.Products[productIndex];
            if (product?.BarcodeConfig == null) return null;

            var group = product.BarcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null) return null;

            var resultCol = group.Columns.FirstOrDefault(c =>
                !string.IsNullOrWhiteSpace(c?.DbColumnName) &&
                (c.DbColumnName.Contains("结果") || c.DbColumnName.Contains("OK") || c.DbColumnName.Contains("NG")));

            if (resultCol == null) return null;

            string key = BuildBarcodeValueKey(groupName, resultCol.DbColumnName);
            lock (_barcodeValuesLock)
            {
                if (_allBarcodeValues.TryGetValue(productIndex, out var values))
                    return values.TryGetValue(key, out string val) ? val : null;
            }
            return null;
        }

        /// <summary>
        /// 构建指定产品的副码汇总文本
        /// </summary>
        private string BuildProductSubCodeSummary(int productIndex)
        {
            var parts = new List<string>();
            string[] subNames = { "副码1", "副码2", "副码3", "副码4" };
            foreach (var name in subNames)
            {
                string resultVal = GetProductGroupResultValue(productIndex, name);
                if (!string.IsNullOrWhiteSpace(resultVal))
                {
                    bool isOk = resultVal == "1" || resultVal.Equals("OK", StringComparison.OrdinalIgnoreCase);
                    parts.Add(isOk ? "✅" : "❌");
                }
                else
                {
                    parts.Add("·");
                }
            }

            string prefix = "副码：";
            if (parts.Count == 0)
                return prefix + "等待PLC数据...";
            // 紧凑格式：副码：✅ ❌ · ✅
            return prefix + string.Join("  ", parts);
        }

        /// <summary>
        /// 检查指定产品是否有任何副码结果
        /// </summary>
        private bool HasAnySubResult(int productIndex)
        {
            string[] subNames = { "副码1", "副码2", "副码3", "副码4" };
            foreach (var name in subNames)
            {
                if (!string.IsNullOrWhiteSpace(GetProductGroupResultValue(productIndex, name)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 更新指定产品的码组标题状态
        /// </summary>
        private void UpdateProductGroupTitleStatus(int productIndex, string groupName, Label titleLabel)
        {
            if (titleLabel == null) return;
            string baseTitle = groupName;
            string resultVal = GetProductGroupResultValue(productIndex, groupName);

            if (string.IsNullOrWhiteSpace(resultVal))
            {
                titleLabel.Text = baseTitle;
                titleLabel.ForeColor = Color.FromArgb(60, 60, 60);
            }
            else if (resultVal == "1" || resultVal.Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                titleLabel.Text = baseTitle + "  ✅";
                titleLabel.ForeColor = Color.FromArgb(0, 153, 102);
            }
            else
            {
                titleLabel.Text = baseTitle + "  ❌";
                titleLabel.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        /// <summary>
        /// 获取指定组的结果字段值（匹配 DbColumnName 中含 "结果" 或 "OK" 的字段）
        /// </summary>
        private string GetGroupResultValue(string groupName)
        {
            if (_barcodeConfig == null) return null;
            var group = _barcodeConfig.Groups?.FirstOrDefault(g => g.GroupName == groupName);
            if (group?.Columns == null) return null;

            // 优先找 DbColumnName 含 "结果" 或 "OK" 或 "NG" 的字段
            var resultCol = group.Columns.FirstOrDefault(c =>
                !string.IsNullOrWhiteSpace(c?.DbColumnName) &&
                (c.DbColumnName.Contains("结果") || c.DbColumnName.Contains("OK") || c.DbColumnName.Contains("NG")));

            if (resultCol == null) return null;

            string key = BuildBarcodeValueKey(groupName, resultCol.DbColumnName);
            lock (_barcodeValuesLock)
            {
                return _barcodeValues.TryGetValue(key, out string val) ? val : null;
            }
        }

        /// <summary>
        /// 更新码组标题标签，附加 OK/NG 状态图标
        /// </summary>
        private void UpdateGroupTitleStatus(string groupName, Label titleLabel)
        {
            if (titleLabel == null) return;
            string baseTitle = groupName;
            string resultVal = GetGroupResultValue(groupName);

            if (string.IsNullOrWhiteSpace(resultVal))
            {
                titleLabel.Text = baseTitle;
                titleLabel.ForeColor = Color.FromArgb(60, 60, 60);
            }
            else if (resultVal == "1" || resultVal.Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                titleLabel.Text = baseTitle + "  ✅";
                titleLabel.ForeColor = Color.FromArgb(0, 153, 102);
            }
            else
            {
                titleLabel.Text = baseTitle + "  ❌";
                titleLabel.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        /// <summary>
        /// 更新PLC心跳指示灯（绿色闪烁=连接正常，红色=断开）
        /// </summary>
        private void UpdatePlcHeartbeat()
        {
            if (lblPlcHeartbeat == null) return;
            if (_plcConnected)
            {
                _heartbeatToggle = !_heartbeatToggle;
                lblPlcHeartbeat.BackColor = _heartbeatToggle
                    ? Color.FromArgb(0, 220, 100)
                    : Color.FromArgb(0, 160, 60);
                lblPlcHeartbeat.Text = "● PLC在线";
                lblPlcHeartbeat.ForeColor = Color.FromArgb(0, 140, 50);
            }
            else
            {
                lblPlcHeartbeat.BackColor = Color.FromArgb(255, 100, 100);
                lblPlcHeartbeat.Text = "● PLC离线";
                lblPlcHeartbeat.ForeColor = Color.FromArgb(180, 30, 30);
            }
        }

        /// <summary>
        /// 构建副码汇总文本（显示结果字段值）
        /// </summary>
        private string BuildSubCodeSummary()
        {
            var parts = new List<string>();
            AddSubSummaryPart(parts, "副码1");
            AddSubSummaryPart(parts, "副码2");
            AddSubSummaryPart(parts, "副码3");
            AddSubSummaryPart(parts, "副码4");

            if (parts.Count == 0)
                return "副码结果汇总：等待PLC数据...";

            return "副码结果汇总：" + string.Join("  |  ", parts);
        }

        private void AddSubSummaryPart(List<string> parts, string name)
        {
            string resultVal = GetGroupResultValue(name);
            if (!string.IsNullOrWhiteSpace(resultVal))
            {
                bool isOk = resultVal == "1" || resultVal.Equals("OK", StringComparison.OrdinalIgnoreCase);
                parts.Add($"{name}={(isOk ? "✅OK" : "❌NG")}");
            }
            else
            {
                parts.Add($"{name}=--");
            }
        }

        private void SetMainCodeState(Label label, string text, bool hasData)
        {
            label.Text = text;
            label.ForeColor = hasData ? Color.FromArgb(0, 114, 198) : Color.FromArgb(160, 160, 160);
        }

        private void SetSubCodeState(Label label, string content, string title)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                label.Text = content;
                label.ForeColor = Color.FromArgb(0, 153, 102);
            }
            else
            {
                label.Text = "--";
                label.ForeColor = Color.FromArgb(160, 160, 160);
            }
        }

        private void timproCount_Tick(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            if (hour == 0)
            {
                _productCount = 0;
            }
        }

    

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _siemensS7.WriterRegisterInt16("DB18", 0, 1);
                RecordInformation("手动触发读取标签数量");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _siemensS7.WriterRegisterInt16("DB18", 6, 1);
                RecordInformation("手动触发pc请求打印机打印标签");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                _siemensS7.WriterRegisterInt16("DB18", 10, 1);
                RecordInformation("手动触发pc处理扫码枪扫码结果");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.ToString());
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                _siemensS7.WriterRegisterInt16("DB18", 22, 1);
                RecordInformation("手动触发pc处理RFID结果");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.ToString());
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                _siemensS7.WriterRegisterInt16("DB18", 34, 1);
                RecordInformation("手动触发pc读取产品各数据");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.ToString());
            }

        }

        


private void tabPage1_Resize(object sender, EventArgs e)
        {
            UpdateMainDashboard();
            AdjustCodeFontSize();
        }

        /// <summary>
        /// 根据窗口大小自适应调整条码卡片的字体大小
        /// </summary>
        private void AdjustCodeFontSize()
        {
            if (tabPage1 == null) return;

            int width = tabPage1.ClientSize.Width;

            // 标题字体统一（第一行 + 第二行）
            float titleSize = Math.Max(8f, Math.Min(16f, width / 110f));
            lblMainCodeTitle.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
            lblSub1Title.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
            lblSub2Title.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
            lblSub3Title.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
            lblSub4Title.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
            if (_row2Titles != null)
            {
                foreach (var lbl in _row2Titles)
                {
                    if (lbl != null) lbl.Font = new Font("微软雅黑", titleSize, FontStyle.Bold);
                }
            }

            // DataGridView 表格字体自适应（第一行 + 第二行统一字号）
            float gridFontSize = Math.Max(6f, Math.Min(10f, width / 150f));
            var allGrids = new List<DataGridView> { dgvMainCode, dgvSubCode1, dgvSubCode2, dgvSubCode3, dgvSubCode4 };
            if (_row2Grids != null) allGrids.AddRange(_row2Grids);
            foreach (var grid in allGrids)
            {
                if (grid == null) continue;
                grid.DefaultCellStyle.Font = new Font("微软雅黑", gridFontSize);
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", gridFontSize, FontStyle.Bold);
            }

            // 状态栏字体（AutoSize=true，需设 MaximumSize 防止溢出）
            float statusSize = Math.Max(10f, Math.Min(14f, width / 110f));
            int maxLabelWidth = (pnlSummary.ClientSize.Width / 2) - 30;
            if (lblProduct1Status != null)
            {
                lblProduct1Status.Font = new Font("微软雅黑", statusSize, FontStyle.Bold);
                lblProduct1Status.MaximumSize = new Size(maxLabelWidth, 0);
            }
            if (lblProduct2Status != null)
            {
                lblProduct2Status.Font = new Font("微软雅黑", statusSize, FontStyle.Bold);
                lblProduct2Status.MaximumSize = new Size(maxLabelWidth, 0);
            }

            float summarySize = Math.Max(9f, Math.Min(12f, width / 130f));
            if (lblProduct1SubSummary != null)
            {
                lblProduct1SubSummary.Font = new Font("微软雅黑", summarySize, FontStyle.Regular);
                lblProduct1SubSummary.MaximumSize = new Size(maxLabelWidth, 0);
            }
            if (lblProduct2SubSummary != null)
            {
                lblProduct2SubSummary.Font = new Font("微软雅黑", summarySize, FontStyle.Regular);
                lblProduct2SubSummary.MaximumSize = new Size(maxLabelWidth, 0);
            }
        }

        private void LoadBarcodeAddressParams()
        {
            // 1. 加载多产品配置
            _multiProductConfig = BarcodeConfigManager.LoadMultiConfig();
            _selectedProductIndex = 0;

            // 诊断：输出每个产品的第一条地址
            string configPath = BarcodeConfigManager.GetConfigDir();
            RecordInformation("配置路径: " + configPath);
            RecordInformation("配置文件存在: " + System.IO.File.Exists(configPath));
            RecordInformation("加载产品数: " + (_multiProductConfig?.Products?.Count ?? 0));
            if (_multiProductConfig?.Products != null)
            {
                foreach (var p in _multiProductConfig.Products)
                {
                    string firstAddr = p.BarcodeConfig?.Groups?.FirstOrDefault()?.Columns?.FirstOrDefault()?.Address ?? "无";
                    RecordInformation(string.Format("  {0}: 主码地址={1}, Enable={2}, Status={3}",
                        p.ProductName, firstAddr, p.EnableReadAddress, p.CodeStatusAddress));
                }
            }

            // 取产品1的配置作为当前
            if (_multiProductConfig.Products.Count > 0)
            {
                var p0 = _multiProductConfig.Products[0];
                _barcodeConfig = p0.BarcodeConfig;
                _heartbeatAddress = _multiProductConfig.HeartbeatAddress;
            }

            // 2. 加载UI（产品和条码配置）
            LoadCurrentProductToUI();

            // 3. 加载心跳 + PLC参数（兼容旧INI）
            string iniPath = Application.StartupPath + "\\配置文件\\barcodeAddress.config";
            if (File.Exists(iniPath))
            {
                try
                {
                    var lines = File.ReadAllLines(iniPath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(new[] { '=' }, 2);
                        if (parts.Length != 2) continue;
                        var key = parts[0].Trim();
                        var value = parts[1].Trim();
                        if (key == "Heartbeat") _heartbeatAddress = value;
                        if (key == "PlcIp" && txtPlcIp != null) txtPlcIp.Text = value;
                        if (key == "PlcPort" && txtPlcPort != null) txtPlcPort.Text = value;
                        if (key == "AutoReconnect")
                        {
                            _autoReconnect = value.Equals("true", StringComparison.OrdinalIgnoreCase);
                            if (chkAutoReconnect != null) chkAutoReconnect.Checked = _autoReconnect;
                        }
                    }
                }
                catch (Exception ex) { RecordInformation("协议地址配置加载失败：" + ex.Message); }
            }

            // 4. 填充心跳地址
            if (txtHeartbeatAddr != null) txtHeartbeatAddr.Text = _heartbeatAddress;

            // 5. 默认PLC参数
            if (txtPlcIp != null && string.IsNullOrWhiteSpace(txtPlcIp.Text)) txtPlcIp.Text = "Any";
            if (txtPlcPort != null && string.IsNullOrWhiteSpace(txtPlcPort.Text)) txtPlcPort.Text = "5000";

            // 6. 更新产品下拉框
            if (cmbProductSelector != null)
                cmbProductSelector.SelectedIndex = _selectedProductIndex;
        }

        /// <summary>
        /// 将加载的配置同步到UI：先填充DataGridView，再同步列表选择
        /// </summary>
        private void LoadConfigToUI()
        {
            _selectedGroupName = "主码";
            // 先填充 DGV（避免 SelectedIndexChanged 事件在空 DGV 时误保存）
            LoadSelectedGroupToGrid();
            // 再同步列表选择（不触发保存，因为 _isLoadingProduct=true）
            if (lstGroupSelector != null && lstGroupSelector.Items.Count > 0)
            {
                _isLoadingProduct = true;
                lstGroupSelector.SelectedIndex = 0;
                _isLoadingProduct = false;
            }
        }

    }
}
