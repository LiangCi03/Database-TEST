namespace DataBaseOrm
{
    partial class frmDatabase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 形体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timproCount = new System.Windows.Forms.Timer(this.components);
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.timerHeart = new System.Windows.Forms.Timer(this.components);
            this.txtRecordinfo = new System.Windows.Forms.RichTextBox();
            this.tlpMain1 = new System.Windows.Forms.TableLayoutPanel();
            this.tab2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlMainRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnToggleLog = new System.Windows.Forms.Button();
            this.lblPlcHeartbeat = new System.Windows.Forms.Label();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.tblCodes = new System.Windows.Forms.TableLayoutPanel();
            this.lblSection1 = new System.Windows.Forms.Label();
            this.pnlMainCode = new System.Windows.Forms.Panel();
            this.dgvMainCode = new System.Windows.Forms.DataGridView();
            this.lblMainCodeTitle = new System.Windows.Forms.Label();
            this.pnlSub1 = new System.Windows.Forms.Panel();
            this.dgvSubCode1 = new System.Windows.Forms.DataGridView();
            this.lblSub1Title = new System.Windows.Forms.Label();
            this.pnlSub2 = new System.Windows.Forms.Panel();
            this.dgvSubCode2 = new System.Windows.Forms.DataGridView();
            this.lblSub2Title = new System.Windows.Forms.Label();
            this.pnlSub3 = new System.Windows.Forms.Panel();
            this.dgvSubCode3 = new System.Windows.Forms.DataGridView();
            this.lblSub3Title = new System.Windows.Forms.Label();
            this.pnlSub4 = new System.Windows.Forms.Panel();
            this.dgvSubCode4 = new System.Windows.Forms.DataGridView();
            this.lblSub4Title = new System.Windows.Forms.Label();
            this.lblSection2 = new System.Windows.Forms.Label();
            this.pnlRow2Main = new System.Windows.Forms.Panel();
            this.dgvRow2Main = new System.Windows.Forms.DataGridView();
            this.lblRow2MainTitle = new System.Windows.Forms.Label();
            this.pnlRow2Sub1 = new System.Windows.Forms.Panel();
            this.dgvRow2Sub1 = new System.Windows.Forms.DataGridView();
            this.lblRow2Sub1Title = new System.Windows.Forms.Label();
            this.pnlRow2Sub2 = new System.Windows.Forms.Panel();
            this.dgvRow2Sub2 = new System.Windows.Forms.DataGridView();
            this.lblRow2Sub2Title = new System.Windows.Forms.Label();
            this.pnlRow2Sub3 = new System.Windows.Forms.Panel();
            this.dgvRow2Sub3 = new System.Windows.Forms.DataGridView();
            this.lblRow2Sub3Title = new System.Windows.Forms.Label();
            this.pnlRow2Sub4 = new System.Windows.Forms.Panel();
            this.dgvRow2Sub4 = new System.Windows.Forms.DataGridView();
            this.lblRow2Sub4Title = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tblSummary = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSummaryLeft = new System.Windows.Forms.Panel();
            this.lblProduct1SubSummary = new System.Windows.Forms.Label();
            this.lblProduct1Status = new System.Windows.Forms.Label();
            this.pnlSummaryRight = new System.Windows.Forms.Panel();
            this.lblProduct2SubSummary = new System.Windows.Forms.Label();
            this.lblProduct2Status = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tblResults = new System.Windows.Forms.TableLayoutPanel();
            this.lblOkTitle = new System.Windows.Forms.Label();
            this.dgvOkResult = new System.Windows.Forms.DataGridView();
            this.lblNgTitle = new System.Windows.Forms.Label();
            this.dgvNgResult = new System.Windows.Forms.DataGridView();
            this.pnlQueryTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQueryTitle = new System.Windows.Forms.Label();
            this.btnQueryNg = new System.Windows.Forms.Button();
            this.btnQueryOk = new System.Windows.Forms.Button();
            this.cmbQueryProduct = new System.Windows.Forms.ComboBox();
            this.lblQueryProduct = new System.Windows.Forms.Label();
            this.txtQueryCode = new System.Windows.Forms.TextBox();
            this.lblQueryInput = new System.Windows.Forms.Label();
            this.dtpExportFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExportTo = new System.Windows.Forms.Label();
            this.dtpExportTo = new System.Windows.Forms.DateTimePicker();
            this.lblQueryHelp = new System.Windows.Forms.Label();
            this.cmbExportTable = new System.Windows.Forms.ComboBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExportFrom = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grpPlcConfig = new System.Windows.Forms.GroupBox();
            this.txtPlcPort = new System.Windows.Forms.TextBox();
            this.txtPlcIp = new System.Windows.Forms.TextBox();
            this.lblPlcPort = new System.Windows.Forms.Label();
            this.lblPlcIp = new System.Windows.Forms.Label();
            this.cmbProductSelector = new System.Windows.Forms.ComboBox();
            this.lblProductSelector = new System.Windows.Forms.Label();
            this.lblOkTable = new System.Windows.Forms.Label();
            this.txtOkTableName = new System.Windows.Forms.TextBox();
            this.lblNgTable = new System.Windows.Forms.Label();
            this.txtNgTableName = new System.Windows.Forms.TextBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.grpBarcodeAddr = new System.Windows.Forms.GroupBox();
            this.lstGroupSelector = new System.Windows.Forms.ListBox();
            this.dgvGroupColumns = new System.Windows.Forms.DataGridView();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.btnDeleteColumn = new System.Windows.Forms.Button();
            this.chkAutoReconnect = new System.Windows.Forms.CheckBox();
            this.lblHeartbeatAddr = new System.Windows.Forms.Label();
            this.txtHeartbeatAddr = new System.Windows.Forms.TextBox();
            this.lblEnableReadAddr = new System.Windows.Forms.Label();
            this.txtEnableReadAddr = new System.Windows.Forms.TextBox();
            this.lblCodeStatusAddr = new System.Windows.Forms.Label();
            this.txtCodeStatusAddr = new System.Windows.Forms.TextBox();
            this.lblHeartbeatHint = new System.Windows.Forms.Label();
            this.lblEnableReadHint = new System.Windows.Forms.Label();
            this.lblCodeStatusHint = new System.Windows.Forms.Label();
            this.lblAddrHint = new System.Windows.Forms.Label();
            this.btnSaveComParam = new System.Windows.Forms.Button();
            this.btnReconnect = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tlpDbPage = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDbTop = new System.Windows.Forms.Panel();
            this.tlpDbTopBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblDbDebugTitle = new System.Windows.Forms.Label();
            this.pnlDbProduct = new System.Windows.Forms.Panel();
            this.cmbDbProduct = new System.Windows.Forms.ComboBox();
            this.lblDbProduct = new System.Windows.Forms.Label();
            this.pnlDbScroll = new System.Windows.Forms.Panel();
            this.tlpDbInputs = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDbBottom = new System.Windows.Forms.Panel();
            this.tlpDbBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDbButtons = new System.Windows.Forms.Panel();
            this.btnDbWriteOk = new System.Windows.Forms.Button();
            this.btnDbWriteNg = new System.Windows.Forms.Button();
            this.btnDbRefresh = new System.Windows.Forms.Button();
            this.btnDbTestConn = new System.Windows.Forms.Button();
            this.grpDbTestData = new System.Windows.Forms.GroupBox();
            this.rdoDbFull = new System.Windows.Forms.RadioButton();
            this.rdoDbOk = new System.Windows.Forms.RadioButton();
            this.rdoDbNg = new System.Windows.Forms.RadioButton();
            this.btnDbFill = new System.Windows.Forms.Button();
            this.btnDbWritePlc = new System.Windows.Forms.Button();
            this.btnDbReadOk = new System.Windows.Forms.Button();
            this.btnDbReadNg = new System.Windows.Forms.Button();
            this.pnlDbLog = new System.Windows.Forms.Panel();
            this.txtDbDebugLog = new System.Windows.Forms.RichTextBox();
            this.lblDbLog = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tlpPlcPage = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPlcTop = new System.Windows.Forms.Panel();
            this.chkSimMode = new System.Windows.Forms.CheckBox();
            this.lblPlcTestTitle = new System.Windows.Forms.Label();
            this.grpPlcInput = new System.Windows.Forms.GroupBox();
            this.tlpPlcInput = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlcAddr = new System.Windows.Forms.Label();
            this.txtTestAddress = new System.Windows.Forms.TextBox();
            this.lblPlcDataType = new System.Windows.Forms.Label();
            this.cmbTestDataType = new System.Windows.Forms.ComboBox();
            this.lblPlcValue = new System.Windows.Forms.Label();
            this.txtTestValue = new System.Windows.Forms.TextBox();
            this.pnlPlcButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlcRead = new System.Windows.Forms.Button();
            this.btnPlcWrite = new System.Windows.Forms.Button();
            this.btnSimInit = new System.Windows.Forms.Button();
            this.lblPlcLog = new System.Windows.Forms.Label();
            this.txtPlcTestLog = new System.Windows.Forms.RichTextBox();
            this.tlpPlcTopBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubSummaryValue = new System.Windows.Forms.Label();
            this.lblMainStatusValue = new System.Windows.Forms.Label();
            this.pnlOkResult = new System.Windows.Forms.Panel();
            this.pnlNgResult = new System.Windows.Forms.Panel();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.btnManualQuery = new System.Windows.Forms.Button();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.lblMainCodeValue = new System.Windows.Forms.Label();
            this.lblSubCode1Value = new System.Windows.Forms.Label();
            this.lblSubCode2Value = new System.Windows.Forms.Label();
            this.lblSubCode3Value = new System.Windows.Forms.Label();
            this.lblSubCode4Value = new System.Windows.Forms.Label();
            this.ethernetCtl2 = new CommonUI.CustomControl.EthernetCtl();
            this.ethernetCtl1 = new CommonUI.CustomControl.EthernetCtl();
            this.tlpMain1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlMainRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tblCodes.SuspendLayout();
            this.pnlMainCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCode)).BeginInit();
            this.pnlSub1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode1)).BeginInit();
            this.pnlSub2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode2)).BeginInit();
            this.pnlSub3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode3)).BeginInit();
            this.pnlSub4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode4)).BeginInit();
            this.pnlRow2Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Main)).BeginInit();
            this.pnlRow2Sub1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub1)).BeginInit();
            this.pnlRow2Sub2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub2)).BeginInit();
            this.pnlRow2Sub3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub3)).BeginInit();
            this.pnlRow2Sub4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub4)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.tblSummary.SuspendLayout();
            this.pnlSummaryLeft.SuspendLayout();
            this.pnlSummaryRight.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tblResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNgResult)).BeginInit();
            this.pnlQueryTop.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpPlcConfig.SuspendLayout();
            this.grpBarcodeAddr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupColumns)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tlpDbPage.SuspendLayout();
            this.pnlDbTop.SuspendLayout();
            this.tlpDbTopBar.SuspendLayout();
            this.pnlDbProduct.SuspendLayout();
            this.pnlDbScroll.SuspendLayout();
            this.pnlDbBottom.SuspendLayout();
            this.tlpDbBottom.SuspendLayout();
            this.pnlDbButtons.SuspendLayout();
            this.grpDbTestData.SuspendLayout();
            this.pnlDbLog.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tlpPlcPage.SuspendLayout();
            this.pnlPlcTop.SuspendLayout();
            this.grpPlcInput.SuspendLayout();
            this.tlpPlcInput.SuspendLayout();
            this.pnlPlcButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // timproCount
            // 
            this.timproCount.Enabled = true;
            this.timproCount.Interval = 1000;
            this.timproCount.Tick += new System.EventHandler(this.timproCount_Tick);
            // 
            // timerDisplay
            // 
            this.timerDisplay.Enabled = true;
            this.timerDisplay.Interval = 1000;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // timerHeart
            // 
            this.timerHeart.Interval = 1000;
            this.timerHeart.Tick += new System.EventHandler(this.timerHeart_Tick);
            // 
            // txtRecordinfo
            // 
            this.txtRecordinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecordinfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRecordinfo.Location = new System.Drawing.Point(1252, 2);
            this.txtRecordinfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecordinfo.Name = "txtRecordinfo";
            this.txtRecordinfo.ReadOnly = true;
            this.txtRecordinfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRecordinfo.Size = new System.Drawing.Size(307, 890);
            this.txtRecordinfo.TabIndex = 1;
            this.txtRecordinfo.Text = "";
            // 
            // tlpMain1
            // 
            this.tlpMain1.ColumnCount = 2;
            this.tlpMain1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMain1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain1.Controls.Add(this.tab2, 0, 0);
            this.tlpMain1.Controls.Add(this.txtRecordinfo, 1, 0);
            this.tlpMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain1.Location = new System.Drawing.Point(0, 0);
            this.tlpMain1.Name = "tlpMain1";
            this.tlpMain1.RowCount = 1;
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain1.Size = new System.Drawing.Size(1562, 894);
            this.tlpMain1.TabIndex = 1;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.tabPage1);
            this.tab2.Controls.Add(this.tabPage3);
            this.tab2.Controls.Add(this.tabPage4);
            this.tab2.Controls.Add(this.tabPage5);
            this.tab2.Controls.Add(this.tabPage6);
            this.tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab2.Font = new System.Drawing.Font("宋体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab2.Location = new System.Drawing.Point(3, 3);
            this.tab2.Name = "tab2";
            this.tab2.SelectedIndex = 0;
            this.tab2.Size = new System.Drawing.Size(1243, 888);
            this.tab2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage1.Controls.Add(this.pnlMainRoot);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 53);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1235, 831);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.Resize += new System.EventHandler(this.tabPage1_Resize);
            // 
            // pnlMainRoot
            // 
            this.pnlMainRoot.ColumnCount = 1;
            this.pnlMainRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMainRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.pnlMainRoot.Controls.Add(this.tblCodes, 0, 1);
            this.pnlMainRoot.Controls.Add(this.pnlSummary, 0, 2);
            this.pnlMainRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainRoot.Location = new System.Drawing.Point(3, 2);
            this.pnlMainRoot.Name = "pnlMainRoot";
            this.pnlMainRoot.RowCount = 3;
            this.pnlMainRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlMainRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.35332F));
            this.pnlMainRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64668F));
            this.pnlMainRoot.Size = new System.Drawing.Size(1229, 827);
            this.pnlMainRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.btnToggleLog);
            this.pnlHeader.Controls.Add(this.lblPlcHeartbeat);
            this.pnlHeader.Controls.Add(this.btnChangePwd);
            this.pnlHeader.Controls.Add(this.btnPermission);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1223, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(736, 0);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(351, 25);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "实时显示PLC下发的主码与四个副码结果";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeaderTitle.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(276, 50);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "PLC读码主界面";
            // 
            // btnToggleLog
            // 
            this.btnToggleLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToggleLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleLog.Location = new System.Drawing.Point(1087, 0);
            this.btnToggleLog.Name = "btnToggleLog";
            this.btnToggleLog.Size = new System.Drawing.Size(26, 54);
            this.btnToggleLog.TabIndex = 3;
            this.btnToggleLog.Text = "◀";
            this.btnToggleLog.UseVisualStyleBackColor = true;
            this.btnToggleLog.Click += new System.EventHandler(this.BtnToggleLog_Click);
            // 
            // lblPlcHeartbeat
            // 
            this.lblPlcHeartbeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPlcHeartbeat.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlcHeartbeat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlcHeartbeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPlcHeartbeat.Location = new System.Drawing.Point(1113, 0);
            this.lblPlcHeartbeat.Name = "lblPlcHeartbeat";
            this.lblPlcHeartbeat.Size = new System.Drawing.Size(110, 54);
            this.lblPlcHeartbeat.TabIndex = 2;
            this.lblPlcHeartbeat.Text = "● PLC离线";
            this.lblPlcHeartbeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnChangePwd.FlatAppearance.BorderSize = 0;
            this.btnChangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangePwd.ForeColor = System.Drawing.Color.White;
            this.btnChangePwd.Location = new System.Drawing.Point(421, 4);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(133, 47);
            this.btnChangePwd.TabIndex = 3;
            this.btnChangePwd.Text = "🔒 修改密码";
            this.btnChangePwd.UseVisualStyleBackColor = false;
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPermission.FlatAppearance.BorderSize = 0;
            this.btnPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermission.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnPermission.ForeColor = System.Drawing.Color.White;
            this.btnPermission.Location = new System.Drawing.Point(282, 4);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(133, 47);
            this.btnPermission.TabIndex = 3;
            this.btnPermission.Text = "🔒 操作员";
            this.btnPermission.UseVisualStyleBackColor = false;
            // 
            // tblCodes
            // 
            this.tblCodes.ColumnCount = 5;
            this.tblCodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCodes.Controls.Add(this.lblSection1, 0, 0);
            this.tblCodes.Controls.Add(this.pnlMainCode, 0, 1);
            this.tblCodes.Controls.Add(this.pnlSub1, 1, 1);
            this.tblCodes.Controls.Add(this.pnlSub2, 2, 1);
            this.tblCodes.Controls.Add(this.pnlSub3, 3, 1);
            this.tblCodes.Controls.Add(this.pnlSub4, 4, 1);
            this.tblCodes.Controls.Add(this.lblSection2, 0, 2);
            this.tblCodes.Controls.Add(this.pnlRow2Main, 0, 3);
            this.tblCodes.Controls.Add(this.pnlRow2Sub1, 1, 3);
            this.tblCodes.Controls.Add(this.pnlRow2Sub2, 2, 3);
            this.tblCodes.Controls.Add(this.pnlRow2Sub3, 3, 3);
            this.tblCodes.Controls.Add(this.pnlRow2Sub4, 4, 3);
            this.tblCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCodes.Location = new System.Drawing.Point(3, 63);
            this.tblCodes.Name = "tblCodes";
            this.tblCodes.RowCount = 4;
            this.tblCodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblCodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblCodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCodes.Size = new System.Drawing.Size(1223, 663);
            this.tblCodes.TabIndex = 1;
            // 
            // lblSection1
            // 
            this.lblSection1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.tblCodes.SetColumnSpan(this.lblSection1, 5);
            this.lblSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSection1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSection1.ForeColor = System.Drawing.Color.White;
            this.lblSection1.Location = new System.Drawing.Point(3, 0);
            this.lblSection1.Name = "lblSection1";
            this.lblSection1.Size = new System.Drawing.Size(1217, 30);
            this.lblSection1.TabIndex = 2;
            this.lblSection1.Text = "压装数据区域";
            this.lblSection1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainCode
            // 
            this.pnlMainCode.BackColor = System.Drawing.Color.White;
            this.pnlMainCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainCode.Controls.Add(this.dgvMainCode);
            this.pnlMainCode.Controls.Add(this.lblMainCodeTitle);
            this.pnlMainCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainCode.Location = new System.Drawing.Point(3, 33);
            this.pnlMainCode.Name = "pnlMainCode";
            this.pnlMainCode.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMainCode.Size = new System.Drawing.Size(238, 295);
            this.pnlMainCode.TabIndex = 0;
            // 
            // dgvMainCode
            // 
            this.dgvMainCode.AllowUserToAddRows = false;
            this.dgvMainCode.AllowUserToDeleteRows = false;
            this.dgvMainCode.AllowUserToResizeRows = false;
            this.dgvMainCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMainCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMainCode.BackgroundColor = System.Drawing.Color.White;
            this.dgvMainCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMainCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainCode.EnableHeadersVisualStyles = false;
            this.dgvMainCode.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvMainCode.Location = new System.Drawing.Point(6, 38);
            this.dgvMainCode.Name = "dgvMainCode";
            this.dgvMainCode.ReadOnly = true;
            this.dgvMainCode.RowHeadersVisible = false;
            this.dgvMainCode.RowHeadersWidth = 51;
            this.dgvMainCode.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainCode.Size = new System.Drawing.Size(224, 249);
            this.dgvMainCode.TabIndex = 2;
            // 
            // lblMainCodeTitle
            // 
            this.lblMainCodeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblMainCodeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMainCodeTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainCodeTitle.ForeColor = System.Drawing.Color.White;
            this.lblMainCodeTitle.Location = new System.Drawing.Point(6, 6);
            this.lblMainCodeTitle.Name = "lblMainCodeTitle";
            this.lblMainCodeTitle.Size = new System.Drawing.Size(224, 32);
            this.lblMainCodeTitle.TabIndex = 0;
            this.lblMainCodeTitle.Text = "KSZ码";
            this.lblMainCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSub1
            // 
            this.pnlSub1.BackColor = System.Drawing.Color.White;
            this.pnlSub1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSub1.Controls.Add(this.dgvSubCode1);
            this.pnlSub1.Controls.Add(this.lblSub1Title);
            this.pnlSub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSub1.Location = new System.Drawing.Point(247, 33);
            this.pnlSub1.Name = "pnlSub1";
            this.pnlSub1.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSub1.Size = new System.Drawing.Size(238, 295);
            this.pnlSub1.TabIndex = 1;
            // 
            // dgvSubCode1
            // 
            this.dgvSubCode1.AllowUserToAddRows = false;
            this.dgvSubCode1.AllowUserToDeleteRows = false;
            this.dgvSubCode1.AllowUserToResizeRows = false;
            this.dgvSubCode1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubCode1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubCode1.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubCode1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubCode1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubCode1.EnableHeadersVisualStyles = false;
            this.dgvSubCode1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSubCode1.Location = new System.Drawing.Point(6, 38);
            this.dgvSubCode1.Name = "dgvSubCode1";
            this.dgvSubCode1.ReadOnly = true;
            this.dgvSubCode1.RowHeadersVisible = false;
            this.dgvSubCode1.RowHeadersWidth = 51;
            this.dgvSubCode1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubCode1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubCode1.Size = new System.Drawing.Size(224, 249);
            this.dgvSubCode1.TabIndex = 2;
            // 
            // lblSub1Title
            // 
            this.lblSub1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSub1Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSub1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblSub1Title.Location = new System.Drawing.Point(6, 6);
            this.lblSub1Title.Name = "lblSub1Title";
            this.lblSub1Title.Size = new System.Drawing.Size(224, 32);
            this.lblSub1Title.TabIndex = 0;
            this.lblSub1Title.Text = "PSH码1";
            // 
            // pnlSub2
            // 
            this.pnlSub2.BackColor = System.Drawing.Color.White;
            this.pnlSub2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSub2.Controls.Add(this.dgvSubCode2);
            this.pnlSub2.Controls.Add(this.lblSub2Title);
            this.pnlSub2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSub2.Location = new System.Drawing.Point(491, 33);
            this.pnlSub2.Name = "pnlSub2";
            this.pnlSub2.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSub2.Size = new System.Drawing.Size(238, 295);
            this.pnlSub2.TabIndex = 2;
            // 
            // dgvSubCode2
            // 
            this.dgvSubCode2.AllowUserToAddRows = false;
            this.dgvSubCode2.AllowUserToDeleteRows = false;
            this.dgvSubCode2.AllowUserToResizeRows = false;
            this.dgvSubCode2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubCode2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubCode2.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubCode2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubCode2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCode2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubCode2.EnableHeadersVisualStyles = false;
            this.dgvSubCode2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSubCode2.Location = new System.Drawing.Point(6, 38);
            this.dgvSubCode2.Name = "dgvSubCode2";
            this.dgvSubCode2.ReadOnly = true;
            this.dgvSubCode2.RowHeadersVisible = false;
            this.dgvSubCode2.RowHeadersWidth = 51;
            this.dgvSubCode2.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubCode2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubCode2.Size = new System.Drawing.Size(224, 249);
            this.dgvSubCode2.TabIndex = 2;
            // 
            // lblSub2Title
            // 
            this.lblSub2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSub2Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSub2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblSub2Title.Location = new System.Drawing.Point(6, 6);
            this.lblSub2Title.Name = "lblSub2Title";
            this.lblSub2Title.Size = new System.Drawing.Size(224, 32);
            this.lblSub2Title.TabIndex = 0;
            this.lblSub2Title.Text = "PSH码2";
            // 
            // pnlSub3
            // 
            this.pnlSub3.BackColor = System.Drawing.Color.White;
            this.pnlSub3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSub3.Controls.Add(this.dgvSubCode3);
            this.pnlSub3.Controls.Add(this.lblSub3Title);
            this.pnlSub3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSub3.Location = new System.Drawing.Point(735, 33);
            this.pnlSub3.Name = "pnlSub3";
            this.pnlSub3.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSub3.Size = new System.Drawing.Size(238, 295);
            this.pnlSub3.TabIndex = 3;
            // 
            // dgvSubCode3
            // 
            this.dgvSubCode3.AllowUserToAddRows = false;
            this.dgvSubCode3.AllowUserToDeleteRows = false;
            this.dgvSubCode3.AllowUserToResizeRows = false;
            this.dgvSubCode3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubCode3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubCode3.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubCode3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubCode3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCode3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubCode3.EnableHeadersVisualStyles = false;
            this.dgvSubCode3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSubCode3.Location = new System.Drawing.Point(6, 38);
            this.dgvSubCode3.Name = "dgvSubCode3";
            this.dgvSubCode3.ReadOnly = true;
            this.dgvSubCode3.RowHeadersVisible = false;
            this.dgvSubCode3.RowHeadersWidth = 51;
            this.dgvSubCode3.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubCode3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubCode3.Size = new System.Drawing.Size(224, 249);
            this.dgvSubCode3.TabIndex = 2;
            // 
            // lblSub3Title
            // 
            this.lblSub3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSub3Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSub3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblSub3Title.Location = new System.Drawing.Point(6, 6);
            this.lblSub3Title.Name = "lblSub3Title";
            this.lblSub3Title.Size = new System.Drawing.Size(224, 32);
            this.lblSub3Title.TabIndex = 0;
            this.lblSub3Title.Text = "PSH码3";
            // 
            // pnlSub4
            // 
            this.pnlSub4.BackColor = System.Drawing.Color.White;
            this.pnlSub4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSub4.Controls.Add(this.dgvSubCode4);
            this.pnlSub4.Controls.Add(this.lblSub4Title);
            this.pnlSub4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSub4.Location = new System.Drawing.Point(979, 33);
            this.pnlSub4.Name = "pnlSub4";
            this.pnlSub4.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSub4.Size = new System.Drawing.Size(241, 295);
            this.pnlSub4.TabIndex = 4;
            // 
            // dgvSubCode4
            // 
            this.dgvSubCode4.AllowUserToAddRows = false;
            this.dgvSubCode4.AllowUserToDeleteRows = false;
            this.dgvSubCode4.AllowUserToResizeRows = false;
            this.dgvSubCode4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubCode4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubCode4.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubCode4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubCode4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCode4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubCode4.EnableHeadersVisualStyles = false;
            this.dgvSubCode4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSubCode4.Location = new System.Drawing.Point(6, 38);
            this.dgvSubCode4.Name = "dgvSubCode4";
            this.dgvSubCode4.ReadOnly = true;
            this.dgvSubCode4.RowHeadersVisible = false;
            this.dgvSubCode4.RowHeadersWidth = 51;
            this.dgvSubCode4.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubCode4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubCode4.Size = new System.Drawing.Size(227, 249);
            this.dgvSubCode4.TabIndex = 2;
            // 
            // lblSub4Title
            // 
            this.lblSub4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSub4Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSub4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblSub4Title.Location = new System.Drawing.Point(6, 6);
            this.lblSub4Title.Name = "lblSub4Title";
            this.lblSub4Title.Size = new System.Drawing.Size(227, 32);
            this.lblSub4Title.TabIndex = 0;
            this.lblSub4Title.Text = "PSH码4";
            // 
            // lblSection2
            // 
            this.lblSection2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.tblCodes.SetColumnSpan(this.lblSection2, 5);
            this.lblSection2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSection2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSection2.ForeColor = System.Drawing.Color.White;
            this.lblSection2.Location = new System.Drawing.Point(3, 331);
            this.lblSection2.Name = "lblSection2";
            this.lblSection2.Size = new System.Drawing.Size(1217, 30);
            this.lblSection2.TabIndex = 3;
            this.lblSection2.Text = "推卡夹数据区域";
            this.lblSection2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRow2Main
            // 
            this.pnlRow2Main.BackColor = System.Drawing.Color.White;
            this.pnlRow2Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRow2Main.Controls.Add(this.dgvRow2Main);
            this.pnlRow2Main.Controls.Add(this.lblRow2MainTitle);
            this.pnlRow2Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow2Main.Location = new System.Drawing.Point(3, 364);
            this.pnlRow2Main.Name = "pnlRow2Main";
            this.pnlRow2Main.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRow2Main.Size = new System.Drawing.Size(238, 296);
            this.pnlRow2Main.TabIndex = 5;
            // 
            // dgvRow2Main
            // 
            this.dgvRow2Main.AllowUserToAddRows = false;
            this.dgvRow2Main.AllowUserToDeleteRows = false;
            this.dgvRow2Main.AllowUserToResizeRows = false;
            this.dgvRow2Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow2Main.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRow2Main.BackgroundColor = System.Drawing.Color.White;
            this.dgvRow2Main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRow2Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow2Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow2Main.EnableHeadersVisualStyles = false;
            this.dgvRow2Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRow2Main.Location = new System.Drawing.Point(8, 48);
            this.dgvRow2Main.Name = "dgvRow2Main";
            this.dgvRow2Main.ReadOnly = true;
            this.dgvRow2Main.RowHeadersVisible = false;
            this.dgvRow2Main.RowHeadersWidth = 51;
            this.dgvRow2Main.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow2Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRow2Main.Size = new System.Drawing.Size(220, 238);
            this.dgvRow2Main.TabIndex = 1;
            this.dgvRow2Main.Tag = "推卡夹";
            // 
            // lblRow2MainTitle
            // 
            this.lblRow2MainTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblRow2MainTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRow2MainTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRow2MainTitle.ForeColor = System.Drawing.Color.White;
            this.lblRow2MainTitle.Location = new System.Drawing.Point(8, 8);
            this.lblRow2MainTitle.Name = "lblRow2MainTitle";
            this.lblRow2MainTitle.Size = new System.Drawing.Size(220, 40);
            this.lblRow2MainTitle.TabIndex = 0;
            this.lblRow2MainTitle.Text = "KSZ码";
            this.lblRow2MainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRow2Sub1
            // 
            this.pnlRow2Sub1.BackColor = System.Drawing.Color.White;
            this.pnlRow2Sub1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRow2Sub1.Controls.Add(this.dgvRow2Sub1);
            this.pnlRow2Sub1.Controls.Add(this.lblRow2Sub1Title);
            this.pnlRow2Sub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow2Sub1.Location = new System.Drawing.Point(247, 364);
            this.pnlRow2Sub1.Name = "pnlRow2Sub1";
            this.pnlRow2Sub1.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRow2Sub1.Size = new System.Drawing.Size(238, 296);
            this.pnlRow2Sub1.TabIndex = 6;
            // 
            // dgvRow2Sub1
            // 
            this.dgvRow2Sub1.AllowUserToAddRows = false;
            this.dgvRow2Sub1.AllowUserToDeleteRows = false;
            this.dgvRow2Sub1.AllowUserToResizeRows = false;
            this.dgvRow2Sub1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow2Sub1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRow2Sub1.BackgroundColor = System.Drawing.Color.White;
            this.dgvRow2Sub1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRow2Sub1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow2Sub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow2Sub1.EnableHeadersVisualStyles = false;
            this.dgvRow2Sub1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRow2Sub1.Location = new System.Drawing.Point(8, 49);
            this.dgvRow2Sub1.Name = "dgvRow2Sub1";
            this.dgvRow2Sub1.ReadOnly = true;
            this.dgvRow2Sub1.RowHeadersVisible = false;
            this.dgvRow2Sub1.RowHeadersWidth = 51;
            this.dgvRow2Sub1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow2Sub1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRow2Sub1.Size = new System.Drawing.Size(220, 237);
            this.dgvRow2Sub1.TabIndex = 1;
            this.dgvRow2Sub1.Tag = "推卡夹";
            // 
            // lblRow2Sub1Title
            // 
            this.lblRow2Sub1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRow2Sub1Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRow2Sub1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRow2Sub1Title.Location = new System.Drawing.Point(8, 8);
            this.lblRow2Sub1Title.Name = "lblRow2Sub1Title";
            this.lblRow2Sub1Title.Size = new System.Drawing.Size(220, 41);
            this.lblRow2Sub1Title.TabIndex = 0;
            this.lblRow2Sub1Title.Text = "FSH码1";
            this.lblRow2Sub1Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRow2Sub2
            // 
            this.pnlRow2Sub2.BackColor = System.Drawing.Color.White;
            this.pnlRow2Sub2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRow2Sub2.Controls.Add(this.dgvRow2Sub2);
            this.pnlRow2Sub2.Controls.Add(this.lblRow2Sub2Title);
            this.pnlRow2Sub2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow2Sub2.Location = new System.Drawing.Point(491, 364);
            this.pnlRow2Sub2.Name = "pnlRow2Sub2";
            this.pnlRow2Sub2.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRow2Sub2.Size = new System.Drawing.Size(238, 296);
            this.pnlRow2Sub2.TabIndex = 7;
            // 
            // dgvRow2Sub2
            // 
            this.dgvRow2Sub2.AllowUserToAddRows = false;
            this.dgvRow2Sub2.AllowUserToDeleteRows = false;
            this.dgvRow2Sub2.AllowUserToResizeRows = false;
            this.dgvRow2Sub2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow2Sub2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRow2Sub2.BackgroundColor = System.Drawing.Color.White;
            this.dgvRow2Sub2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRow2Sub2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow2Sub2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow2Sub2.EnableHeadersVisualStyles = false;
            this.dgvRow2Sub2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRow2Sub2.Location = new System.Drawing.Point(8, 49);
            this.dgvRow2Sub2.Name = "dgvRow2Sub2";
            this.dgvRow2Sub2.ReadOnly = true;
            this.dgvRow2Sub2.RowHeadersVisible = false;
            this.dgvRow2Sub2.RowHeadersWidth = 51;
            this.dgvRow2Sub2.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow2Sub2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRow2Sub2.Size = new System.Drawing.Size(220, 237);
            this.dgvRow2Sub2.TabIndex = 1;
            this.dgvRow2Sub2.Tag = "推卡夹";
            // 
            // lblRow2Sub2Title
            // 
            this.lblRow2Sub2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRow2Sub2Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRow2Sub2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRow2Sub2Title.Location = new System.Drawing.Point(8, 8);
            this.lblRow2Sub2Title.Name = "lblRow2Sub2Title";
            this.lblRow2Sub2Title.Size = new System.Drawing.Size(220, 41);
            this.lblRow2Sub2Title.TabIndex = 0;
            this.lblRow2Sub2Title.Text = "FSH码2";
            this.lblRow2Sub2Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRow2Sub3
            // 
            this.pnlRow2Sub3.BackColor = System.Drawing.Color.White;
            this.pnlRow2Sub3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRow2Sub3.Controls.Add(this.dgvRow2Sub3);
            this.pnlRow2Sub3.Controls.Add(this.lblRow2Sub3Title);
            this.pnlRow2Sub3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow2Sub3.Location = new System.Drawing.Point(735, 364);
            this.pnlRow2Sub3.Name = "pnlRow2Sub3";
            this.pnlRow2Sub3.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRow2Sub3.Size = new System.Drawing.Size(238, 296);
            this.pnlRow2Sub3.TabIndex = 8;
            // 
            // dgvRow2Sub3
            // 
            this.dgvRow2Sub3.AllowUserToAddRows = false;
            this.dgvRow2Sub3.AllowUserToDeleteRows = false;
            this.dgvRow2Sub3.AllowUserToResizeRows = false;
            this.dgvRow2Sub3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow2Sub3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRow2Sub3.BackgroundColor = System.Drawing.Color.White;
            this.dgvRow2Sub3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRow2Sub3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow2Sub3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow2Sub3.EnableHeadersVisualStyles = false;
            this.dgvRow2Sub3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRow2Sub3.Location = new System.Drawing.Point(8, 49);
            this.dgvRow2Sub3.Name = "dgvRow2Sub3";
            this.dgvRow2Sub3.ReadOnly = true;
            this.dgvRow2Sub3.RowHeadersVisible = false;
            this.dgvRow2Sub3.RowHeadersWidth = 51;
            this.dgvRow2Sub3.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow2Sub3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRow2Sub3.Size = new System.Drawing.Size(220, 237);
            this.dgvRow2Sub3.TabIndex = 1;
            this.dgvRow2Sub3.Tag = "推卡夹";
            // 
            // lblRow2Sub3Title
            // 
            this.lblRow2Sub3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRow2Sub3Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRow2Sub3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRow2Sub3Title.Location = new System.Drawing.Point(8, 8);
            this.lblRow2Sub3Title.Name = "lblRow2Sub3Title";
            this.lblRow2Sub3Title.Size = new System.Drawing.Size(220, 41);
            this.lblRow2Sub3Title.TabIndex = 0;
            this.lblRow2Sub3Title.Text = "FSH码3";
            this.lblRow2Sub3Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRow2Sub4
            // 
            this.pnlRow2Sub4.BackColor = System.Drawing.Color.White;
            this.pnlRow2Sub4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRow2Sub4.Controls.Add(this.dgvRow2Sub4);
            this.pnlRow2Sub4.Controls.Add(this.lblRow2Sub4Title);
            this.pnlRow2Sub4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow2Sub4.Location = new System.Drawing.Point(979, 364);
            this.pnlRow2Sub4.Name = "pnlRow2Sub4";
            this.pnlRow2Sub4.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRow2Sub4.Size = new System.Drawing.Size(241, 296);
            this.pnlRow2Sub4.TabIndex = 9;
            // 
            // dgvRow2Sub4
            // 
            this.dgvRow2Sub4.AllowUserToAddRows = false;
            this.dgvRow2Sub4.AllowUserToDeleteRows = false;
            this.dgvRow2Sub4.AllowUserToResizeRows = false;
            this.dgvRow2Sub4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow2Sub4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRow2Sub4.BackgroundColor = System.Drawing.Color.White;
            this.dgvRow2Sub4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRow2Sub4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow2Sub4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow2Sub4.EnableHeadersVisualStyles = false;
            this.dgvRow2Sub4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRow2Sub4.Location = new System.Drawing.Point(8, 49);
            this.dgvRow2Sub4.Name = "dgvRow2Sub4";
            this.dgvRow2Sub4.ReadOnly = true;
            this.dgvRow2Sub4.RowHeadersVisible = false;
            this.dgvRow2Sub4.RowHeadersWidth = 51;
            this.dgvRow2Sub4.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow2Sub4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRow2Sub4.Size = new System.Drawing.Size(223, 237);
            this.dgvRow2Sub4.TabIndex = 1;
            this.dgvRow2Sub4.Tag = "推卡夹";
            // 
            // lblRow2Sub4Title
            // 
            this.lblRow2Sub4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRow2Sub4Title.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRow2Sub4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRow2Sub4Title.Location = new System.Drawing.Point(8, 8);
            this.lblRow2Sub4Title.Name = "lblRow2Sub4Title";
            this.lblRow2Sub4Title.Size = new System.Drawing.Size(223, 41);
            this.lblRow2Sub4Title.TabIndex = 0;
            this.lblRow2Sub4Title.Text = "FSH码4";
            this.lblRow2Sub4Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.tblSummary);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(3, 732);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1223, 92);
            this.pnlSummary.TabIndex = 2;
            // 
            // tblSummary
            // 
            this.tblSummary.BackColor = System.Drawing.Color.White;
            this.tblSummary.ColumnCount = 2;
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.Controls.Add(this.pnlSummaryLeft, 0, 0);
            this.tblSummary.Controls.Add(this.pnlSummaryRight, 1, 0);
            this.tblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSummary.Location = new System.Drawing.Point(0, 0);
            this.tblSummary.Name = "tblSummary";
            this.tblSummary.RowCount = 1;
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSummary.Size = new System.Drawing.Size(1221, 90);
            this.tblSummary.TabIndex = 0;
            // 
            // pnlSummaryLeft
            // 
            this.pnlSummaryLeft.BackColor = System.Drawing.Color.White;
            this.pnlSummaryLeft.Controls.Add(this.lblProduct1SubSummary);
            this.pnlSummaryLeft.Controls.Add(this.lblProduct1Status);
            this.pnlSummaryLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummaryLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlSummaryLeft.Name = "pnlSummaryLeft";
            this.pnlSummaryLeft.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSummaryLeft.Size = new System.Drawing.Size(604, 84);
            this.pnlSummaryLeft.TabIndex = 0;
            // 
            // lblProduct1SubSummary
            // 
            this.lblProduct1SubSummary.AutoSize = true;
            this.lblProduct1SubSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct1SubSummary.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProduct1SubSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProduct1SubSummary.Location = new System.Drawing.Point(6, 37);
            this.lblProduct1SubSummary.Name = "lblProduct1SubSummary";
            this.lblProduct1SubSummary.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblProduct1SubSummary.Size = new System.Drawing.Size(190, 23);
            this.lblProduct1SubSummary.TabIndex = 1;
            this.lblProduct1SubSummary.Text = "FSH码：等待PLC数据...";
            this.lblProduct1SubSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProduct1Status
            // 
            this.lblProduct1Status.AutoSize = true;
            this.lblProduct1Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct1Status.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProduct1Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProduct1Status.Location = new System.Drawing.Point(6, 6);
            this.lblProduct1Status.Name = "lblProduct1Status";
            this.lblProduct1Status.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.lblProduct1Status.Size = new System.Drawing.Size(251, 31);
            this.lblProduct1Status.TabIndex = 0;
            this.lblProduct1Status.Text = "压装主码：等待PLC数据...";
            this.lblProduct1Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummaryRight
            // 
            this.pnlSummaryRight.BackColor = System.Drawing.Color.White;
            this.pnlSummaryRight.Controls.Add(this.lblProduct2SubSummary);
            this.pnlSummaryRight.Controls.Add(this.lblProduct2Status);
            this.pnlSummaryRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummaryRight.Location = new System.Drawing.Point(613, 3);
            this.pnlSummaryRight.Name = "pnlSummaryRight";
            this.pnlSummaryRight.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSummaryRight.Size = new System.Drawing.Size(605, 84);
            this.pnlSummaryRight.TabIndex = 1;
            // 
            // lblProduct2SubSummary
            // 
            this.lblProduct2SubSummary.AutoSize = true;
            this.lblProduct2SubSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct2SubSummary.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProduct2SubSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProduct2SubSummary.Location = new System.Drawing.Point(6, 37);
            this.lblProduct2SubSummary.Name = "lblProduct2SubSummary";
            this.lblProduct2SubSummary.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblProduct2SubSummary.Size = new System.Drawing.Size(190, 23);
            this.lblProduct2SubSummary.TabIndex = 1;
            this.lblProduct2SubSummary.Text = "FSH码：等待PLC数据...";
            this.lblProduct2SubSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProduct2Status
            // 
            this.lblProduct2Status.AutoSize = true;
            this.lblProduct2Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct2Status.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProduct2Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProduct2Status.Location = new System.Drawing.Point(6, 6);
            this.lblProduct2Status.Name = "lblProduct2Status";
            this.lblProduct2Status.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.lblProduct2Status.Size = new System.Drawing.Size(271, 31);
            this.lblProduct2Status.TabIndex = 0;
            this.lblProduct2Status.Text = "推卡夹主码：等待PLC数据...";
            this.lblProduct2Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage3.Controls.Add(this.tblResults);
            this.tabPage3.Controls.Add(this.pnlQueryTop);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Location = new System.Drawing.Point(4, 53);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1235, 831);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据查询";
            // 
            // tblResults
            // 
            this.tblResults.BackColor = System.Drawing.Color.White;
            this.tblResults.ColumnCount = 1;
            this.tblResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblResults.Controls.Add(this.lblOkTitle, 0, 0);
            this.tblResults.Controls.Add(this.dgvOkResult, 0, 1);
            this.tblResults.Controls.Add(this.lblNgTitle, 0, 2);
            this.tblResults.Controls.Add(this.dgvNgResult, 0, 3);
            this.tblResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblResults.Location = new System.Drawing.Point(3, 282);
            this.tblResults.Name = "tblResults";
            this.tblResults.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.tblResults.RowCount = 4;
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblResults.Size = new System.Drawing.Size(1229, 547);
            this.tblResults.TabIndex = 1;
            // 
            // lblOkTitle
            // 
            this.lblOkTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.lblOkTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOkTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOkTitle.ForeColor = System.Drawing.Color.White;
            this.lblOkTitle.Location = new System.Drawing.Point(12, 0);
            this.lblOkTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOkTitle.Name = "lblOkTitle";
            this.lblOkTitle.Size = new System.Drawing.Size(1205, 36);
            this.lblOkTitle.TabIndex = 0;
            this.lblOkTitle.Text = "  ✅ OK 数据";
            this.lblOkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvOkResult
            // 
            this.dgvOkResult.AllowUserToAddRows = false;
            this.dgvOkResult.AllowUserToDeleteRows = false;
            this.dgvOkResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOkResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvOkResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOkResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOkResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOkResult.Location = new System.Drawing.Point(12, 36);
            this.dgvOkResult.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dgvOkResult.Name = "dgvOkResult";
            this.dgvOkResult.ReadOnly = true;
            this.dgvOkResult.RowHeadersVisible = false;
            this.dgvOkResult.RowHeadersWidth = 51;
            this.dgvOkResult.RowTemplate.Height = 27;
            this.dgvOkResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOkResult.Size = new System.Drawing.Size(1205, 234);
            this.dgvOkResult.TabIndex = 1;
            // 
            // lblNgTitle
            // 
            this.lblNgTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblNgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNgTitle.ForeColor = System.Drawing.Color.White;
            this.lblNgTitle.Location = new System.Drawing.Point(12, 270);
            this.lblNgTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgTitle.Name = "lblNgTitle";
            this.lblNgTitle.Size = new System.Drawing.Size(1205, 36);
            this.lblNgTitle.TabIndex = 0;
            this.lblNgTitle.Text = "  ❌ NG 数据";
            this.lblNgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvNgResult
            // 
            this.dgvNgResult.AllowUserToAddRows = false;
            this.dgvNgResult.AllowUserToDeleteRows = false;
            this.dgvNgResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNgResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvNgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNgResult.Location = new System.Drawing.Point(12, 306);
            this.dgvNgResult.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dgvNgResult.Name = "dgvNgResult";
            this.dgvNgResult.ReadOnly = true;
            this.dgvNgResult.RowHeadersVisible = false;
            this.dgvNgResult.RowHeadersWidth = 51;
            this.dgvNgResult.RowTemplate.Height = 27;
            this.dgvNgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNgResult.Size = new System.Drawing.Size(1205, 235);
            this.dgvNgResult.TabIndex = 1;
            // 
            // pnlQueryTop
            // 
            this.pnlQueryTop.Controls.Add(this.button1);
            this.pnlQueryTop.Controls.Add(this.label2);
            this.pnlQueryTop.Controls.Add(this.lblQueryTitle);
            this.pnlQueryTop.Controls.Add(this.btnQueryNg);
            this.pnlQueryTop.Controls.Add(this.btnQueryOk);
            this.pnlQueryTop.Controls.Add(this.cmbQueryProduct);
            this.pnlQueryTop.Controls.Add(this.lblQueryProduct);
            this.pnlQueryTop.Controls.Add(this.txtQueryCode);
            this.pnlQueryTop.Controls.Add(this.lblQueryInput);
            this.pnlQueryTop.Controls.Add(this.dtpExportFrom);
            this.pnlQueryTop.Controls.Add(this.lblExportTo);
            this.pnlQueryTop.Controls.Add(this.dtpExportTo);
            this.pnlQueryTop.Controls.Add(this.lblQueryHelp);
            this.pnlQueryTop.Controls.Add(this.cmbExportTable);
            this.pnlQueryTop.Controls.Add(this.btnExportCsv);
            this.pnlQueryTop.Controls.Add(this.label1);
            this.pnlQueryTop.Controls.Add(this.lblExportFrom);
            this.pnlQueryTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueryTop.Location = new System.Drawing.Point(3, 2);
            this.pnlQueryTop.Name = "pnlQueryTop";
            this.pnlQueryTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlQueryTop.Size = new System.Drawing.Size(1229, 280);
            this.pnlQueryTop.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(702, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 42);
            this.button1.TabIndex = 12;
            this.button1.Text = "🔍 日期查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDateQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(11, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "日期查询";
            // 
            // lblQueryTitle
            // 
            this.lblQueryTitle.AutoSize = true;
            this.lblQueryTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.lblQueryTitle.Location = new System.Drawing.Point(11, 12);
            this.lblQueryTitle.Name = "lblQueryTitle";
            this.lblQueryTitle.Size = new System.Drawing.Size(123, 36);
            this.lblQueryTitle.TabIndex = 0;
            this.lblQueryTitle.Text = "条码查询";
            // 
            // btnQueryNg
            // 
            this.btnQueryNg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnQueryNg.FlatAppearance.BorderSize = 0;
            this.btnQueryNg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryNg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryNg.ForeColor = System.Drawing.Color.White;
            this.btnQueryNg.Location = new System.Drawing.Point(871, 55);
            this.btnQueryNg.Name = "btnQueryNg";
            this.btnQueryNg.Size = new System.Drawing.Size(149, 42);
            this.btnQueryNg.TabIndex = 3;
            this.btnQueryNg.Text = "🔍 全库查询";
            this.btnQueryNg.UseVisualStyleBackColor = false;
            this.btnQueryNg.Click += new System.EventHandler(this.btnQueryNg_Click);
            // 
            // btnQueryOk
            // 
            this.btnQueryOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnQueryOk.FlatAppearance.BorderSize = 0;
            this.btnQueryOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryOk.ForeColor = System.Drawing.Color.White;
            this.btnQueryOk.Location = new System.Drawing.Point(702, 55);
            this.btnQueryOk.Name = "btnQueryOk";
            this.btnQueryOk.Size = new System.Drawing.Size(149, 42);
            this.btnQueryOk.TabIndex = 2;
            this.btnQueryOk.Text = "🔍 单表查询";
            this.btnQueryOk.UseVisualStyleBackColor = false;
            this.btnQueryOk.Click += new System.EventHandler(this.btnQueryOk_Click);
            // 
            // cmbQueryProduct
            // 
            this.cmbQueryProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryProduct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbQueryProduct.FormattingEnabled = true;
            this.cmbQueryProduct.Location = new System.Drawing.Point(463, 60);
            this.cmbQueryProduct.Name = "cmbQueryProduct";
            this.cmbQueryProduct.Size = new System.Drawing.Size(201, 35);
            this.cmbQueryProduct.TabIndex = 5;
            // 
            // lblQueryProduct
            // 
            this.lblQueryProduct.AutoSize = true;
            this.lblQueryProduct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblQueryProduct.Location = new System.Drawing.Point(388, 64);
            this.lblQueryProduct.Name = "lblQueryProduct";
            this.lblQueryProduct.Size = new System.Drawing.Size(72, 27);
            this.lblQueryProduct.TabIndex = 4;
            this.lblQueryProduct.Text = "表名：";
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryCode.Location = new System.Drawing.Point(118, 60);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(260, 34);
            this.txtQueryCode.TabIndex = 1;
            // 
            // lblQueryInput
            // 
            this.lblQueryInput.AutoSize = true;
            this.lblQueryInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblQueryInput.Location = new System.Drawing.Point(23, 63);
            this.lblQueryInput.Name = "lblQueryInput";
            this.lblQueryInput.Size = new System.Drawing.Size(89, 27);
            this.lblQueryInput.TabIndex = 0;
            this.lblQueryInput.Text = "KSZ码：";
            // 
            // dtpExportFrom
            // 
            this.dtpExportFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpExportFrom.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.dtpExportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportFrom.Location = new System.Drawing.Point(118, 169);
            this.dtpExportFrom.Name = "dtpExportFrom";
            this.dtpExportFrom.Size = new System.Drawing.Size(232, 32);
            this.dtpExportFrom.TabIndex = 7;
            // 
            // lblExportTo
            // 
            this.lblExportTo.AutoSize = true;
            this.lblExportTo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblExportTo.Location = new System.Drawing.Point(374, 169);
            this.lblExportTo.Name = "lblExportTo";
            this.lblExportTo.Size = new System.Drawing.Size(32, 27);
            this.lblExportTo.TabIndex = 8;
            this.lblExportTo.Text = "至";
            // 
            // dtpExportTo
            // 
            this.dtpExportTo.CustomFormat = "yyyy-MM-dd";
            this.dtpExportTo.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.dtpExportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportTo.Location = new System.Drawing.Point(431, 166);
            this.dtpExportTo.Name = "dtpExportTo";
            this.dtpExportTo.Size = new System.Drawing.Size(210, 32);
            this.dtpExportTo.TabIndex = 9;
            // 
            // lblQueryHelp
            // 
            this.lblQueryHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblQueryHelp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblQueryHelp.Location = new System.Drawing.Point(20, 250);
            this.lblQueryHelp.Name = "lblQueryHelp";
            this.lblQueryHelp.Size = new System.Drawing.Size(1189, 18);
            this.lblQueryHelp.TabIndex = 20;
            this.lblQueryHelp.Text = "💡 输入KSZ码 → 选择表 →【单表查询】查指定表 /【全库查询】搜所有表 | 日期查询：选表+日期 →【日期查询】";
            // 
            // cmbExportTable
            // 
            this.cmbExportTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExportTable.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cmbExportTable.FormattingEnabled = true;
            this.cmbExportTable.Location = new System.Drawing.Point(118, 214);
            this.cmbExportTable.Name = "cmbExportTable";
            this.cmbExportTable.Size = new System.Drawing.Size(201, 32);
            this.cmbExportTable.TabIndex = 10;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnExportCsv.FlatAppearance.BorderSize = 0;
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCsv.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Location = new System.Drawing.Point(871, 163);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(149, 42);
            this.btnExportCsv.TabIndex = 11;
            this.btnExportCsv.Text = "📥 导出CSV";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            this.btnExportCsv.Click += new System.EventHandler(this.BtnExportCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(38, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "表名：";
            // 
            // lblExportFrom
            // 
            this.lblExportFrom.AutoSize = true;
            this.lblExportFrom.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblExportFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblExportFrom.Location = new System.Drawing.Point(38, 169);
            this.lblExportFrom.Name = "lblExportFrom";
            this.lblExportFrom.Size = new System.Drawing.Size(72, 27);
            this.lblExportFrom.TabIndex = 6;
            this.lblExportFrom.Text = "导出：";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage4.Controls.Add(this.grpPlcConfig);
            this.tabPage4.Controls.Add(this.grpBarcodeAddr);
            this.tabPage4.Controls.Add(this.btnSaveComParam);
            this.tabPage4.Controls.Add(this.btnReconnect);
            this.tabPage4.Font = new System.Drawing.Font("宋体", 13.8F);
            this.tabPage4.Location = new System.Drawing.Point(4, 53);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1235, 831);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "配置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grpPlcConfig
            // 
            this.grpPlcConfig.BackColor = System.Drawing.Color.White;
            this.grpPlcConfig.Controls.Add(this.txtPlcPort);
            this.grpPlcConfig.Controls.Add(this.txtPlcIp);
            this.grpPlcConfig.Controls.Add(this.lblPlcPort);
            this.grpPlcConfig.Controls.Add(this.lblPlcIp);
            this.grpPlcConfig.Controls.Add(this.cmbProductSelector);
            this.grpPlcConfig.Controls.Add(this.lblProductSelector);
            this.grpPlcConfig.Controls.Add(this.lblOkTable);
            this.grpPlcConfig.Controls.Add(this.txtOkTableName);
            this.grpPlcConfig.Controls.Add(this.lblNgTable);
            this.grpPlcConfig.Controls.Add(this.txtNgTableName);
            this.grpPlcConfig.Controls.Add(this.chkAutoStart);
            this.grpPlcConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.grpPlcConfig.Location = new System.Drawing.Point(25, 10);
            this.grpPlcConfig.Name = "grpPlcConfig";
            this.grpPlcConfig.Size = new System.Drawing.Size(1220, 120);
            this.grpPlcConfig.TabIndex = 5;
            this.grpPlcConfig.TabStop = false;
            this.grpPlcConfig.Text = "PLC通信配置";
            // 
            // txtPlcPort
            // 
            this.txtPlcPort.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPlcPort.Location = new System.Drawing.Point(645, 66);
            this.txtPlcPort.Name = "txtPlcPort";
            this.txtPlcPort.Size = new System.Drawing.Size(200, 32);
            this.txtPlcPort.TabIndex = 3;
            this.txtPlcPort.Text = "5000";
            // 
            // txtPlcIp
            // 
            this.txtPlcIp.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPlcIp.Location = new System.Drawing.Point(100, 66);
            this.txtPlcIp.Name = "txtPlcIp";
            this.txtPlcIp.Size = new System.Drawing.Size(400, 32);
            this.txtPlcIp.TabIndex = 1;
            this.txtPlcIp.Text = "Any";
            // 
            // lblPlcPort
            // 
            this.lblPlcPort.AutoSize = true;
            this.lblPlcPort.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblPlcPort.Location = new System.Drawing.Point(560, 69);
            this.lblPlcPort.Name = "lblPlcPort";
            this.lblPlcPort.Size = new System.Drawing.Size(85, 25);
            this.lblPlcPort.TabIndex = 2;
            this.lblPlcPort.Text = "PLC端口";
            // 
            // lblPlcIp
            // 
            this.lblPlcIp.AutoSize = true;
            this.lblPlcIp.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblPlcIp.Location = new System.Drawing.Point(30, 69);
            this.lblPlcIp.Name = "lblPlcIp";
            this.lblPlcIp.Size = new System.Drawing.Size(71, 25);
            this.lblPlcIp.TabIndex = 0;
            this.lblPlcIp.Text = "PLC IP";
            // 
            // cmbProductSelector
            // 
            this.cmbProductSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductSelector.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cmbProductSelector.FormattingEnabled = true;
            this.cmbProductSelector.Location = new System.Drawing.Point(120, 26);
            this.cmbProductSelector.Name = "cmbProductSelector";
            this.cmbProductSelector.Size = new System.Drawing.Size(150, 32);
            this.cmbProductSelector.TabIndex = 5;
            // 
            // lblProductSelector
            // 
            this.lblProductSelector.AutoSize = true;
            this.lblProductSelector.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblProductSelector.Location = new System.Drawing.Point(20, 28);
            this.lblProductSelector.Name = "lblProductSelector";
            this.lblProductSelector.Size = new System.Drawing.Size(107, 26);
            this.lblProductSelector.TabIndex = 4;
            this.lblProductSelector.Text = "选择产品：";
            // 
            // lblOkTable
            // 
            this.lblOkTable.AutoSize = true;
            this.lblOkTable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblOkTable.Location = new System.Drawing.Point(349, 26);
            this.lblOkTable.Name = "lblOkTable";
            this.lblOkTable.Size = new System.Drawing.Size(86, 23);
            this.lblOkTable.TabIndex = 21;
            this.lblOkTable.Text = "OK表名：";
            // 
            // txtOkTableName
            // 
            this.txtOkTableName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOkTableName.Location = new System.Drawing.Point(464, 25);
            this.txtOkTableName.Name = "txtOkTableName";
            this.txtOkTableName.Size = new System.Drawing.Size(140, 29);
            this.txtOkTableName.TabIndex = 22;
            // 
            // lblNgTable
            // 
            this.lblNgTable.AutoSize = true;
            this.lblNgTable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblNgTable.Location = new System.Drawing.Point(641, 28);
            this.lblNgTable.Name = "lblNgTable";
            this.lblNgTable.Size = new System.Drawing.Size(88, 23);
            this.lblNgTable.TabIndex = 23;
            this.lblNgTable.Text = "NG表名：";
            // 
            // txtNgTableName
            // 
            this.txtNgTableName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtNgTableName.Location = new System.Drawing.Point(735, 25);
            this.txtNgTableName.Name = "txtNgTableName";
            this.txtNgTableName.Size = new System.Drawing.Size(140, 29);
            this.txtNgTableName.TabIndex = 24;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.chkAutoStart.Location = new System.Drawing.Point(900, 68);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(148, 29);
            this.chkAutoStart.TabIndex = 25;
            this.chkAutoStart.Text = "开机自动启动";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // grpBarcodeAddr
            // 
            this.grpBarcodeAddr.BackColor = System.Drawing.Color.White;
            this.grpBarcodeAddr.Controls.Add(this.lstGroupSelector);
            this.grpBarcodeAddr.Controls.Add(this.dgvGroupColumns);
            this.grpBarcodeAddr.Controls.Add(this.btnAddColumn);
            this.grpBarcodeAddr.Controls.Add(this.btnDeleteColumn);
            this.grpBarcodeAddr.Controls.Add(this.chkAutoReconnect);
            this.grpBarcodeAddr.Controls.Add(this.lblHeartbeatAddr);
            this.grpBarcodeAddr.Controls.Add(this.txtHeartbeatAddr);
            this.grpBarcodeAddr.Controls.Add(this.lblEnableReadAddr);
            this.grpBarcodeAddr.Controls.Add(this.txtEnableReadAddr);
            this.grpBarcodeAddr.Controls.Add(this.lblCodeStatusAddr);
            this.grpBarcodeAddr.Controls.Add(this.txtCodeStatusAddr);
            this.grpBarcodeAddr.Controls.Add(this.lblHeartbeatHint);
            this.grpBarcodeAddr.Controls.Add(this.lblEnableReadHint);
            this.grpBarcodeAddr.Controls.Add(this.lblCodeStatusHint);
            this.grpBarcodeAddr.Controls.Add(this.lblAddrHint);
            this.grpBarcodeAddr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.grpBarcodeAddr.Location = new System.Drawing.Point(25, 120);
            this.grpBarcodeAddr.Name = "grpBarcodeAddr";
            this.grpBarcodeAddr.Size = new System.Drawing.Size(1220, 580);
            this.grpBarcodeAddr.TabIndex = 6;
            this.grpBarcodeAddr.TabStop = false;
            this.grpBarcodeAddr.Text = "条码列配置（主码 + 副码1~4）";
            // 
            // lstGroupSelector
            // 
            this.lstGroupSelector.BackColor = System.Drawing.Color.White;
            this.lstGroupSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGroupSelector.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lstGroupSelector.FormattingEnabled = true;
            this.lstGroupSelector.ItemHeight = 27;
            this.lstGroupSelector.Items.AddRange(new object[] {
            "KSZ码",
            "FSH码1",
            "FSH码2",
            "FSH码3",
            "FSH码4"});
            this.lstGroupSelector.Location = new System.Drawing.Point(20, 40);
            this.lstGroupSelector.Name = "lstGroupSelector";
            this.lstGroupSelector.Size = new System.Drawing.Size(180, 353);
            this.lstGroupSelector.TabIndex = 22;
            // 
            // dgvGroupColumns
            // 
            this.dgvGroupColumns.AllowUserToAddRows = false;
            this.dgvGroupColumns.AllowUserToDeleteRows = false;
            this.dgvGroupColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupColumns.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupColumns.Location = new System.Drawing.Point(220, 40);
            this.dgvGroupColumns.MultiSelect = false;
            this.dgvGroupColumns.Name = "dgvGroupColumns";
            this.dgvGroupColumns.RowHeadersVisible = false;
            this.dgvGroupColumns.RowHeadersWidth = 51;
            this.dgvGroupColumns.RowTemplate.Height = 30;
            this.dgvGroupColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupColumns.Size = new System.Drawing.Size(980, 360);
            this.dgvGroupColumns.TabIndex = 23;
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnAddColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColumn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddColumn.ForeColor = System.Drawing.Color.White;
            this.btnAddColumn.Location = new System.Drawing.Point(220, 408);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(100, 36);
            this.btnAddColumn.TabIndex = 20;
            this.btnAddColumn.Text = "+ 添加";
            this.btnAddColumn.UseVisualStyleBackColor = false;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteColumn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteColumn.ForeColor = System.Drawing.Color.White;
            this.btnDeleteColumn.Location = new System.Drawing.Point(330, 408);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.Size = new System.Drawing.Size(100, 36);
            this.btnDeleteColumn.TabIndex = 21;
            this.btnDeleteColumn.Text = "- 删除";
            this.btnDeleteColumn.UseVisualStyleBackColor = false;
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // chkAutoReconnect
            // 
            this.chkAutoReconnect.AutoSize = true;
            this.chkAutoReconnect.Checked = true;
            this.chkAutoReconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReconnect.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.chkAutoReconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.chkAutoReconnect.Location = new System.Drawing.Point(480, 408);
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.Size = new System.Drawing.Size(224, 30);
            this.chkAutoReconnect.TabIndex = 24;
            this.chkAutoReconnect.Text = "自动重连（心跳检测）";
            this.chkAutoReconnect.UseVisualStyleBackColor = true;
            // 
            // lblHeartbeatAddr
            // 
            this.lblHeartbeatAddr.AutoSize = true;
            this.lblHeartbeatAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblHeartbeatAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblHeartbeatAddr.Location = new System.Drawing.Point(30, 465);
            this.lblHeartbeatAddr.Name = "lblHeartbeatAddr";
            this.lblHeartbeatAddr.Size = new System.Drawing.Size(88, 25);
            this.lblHeartbeatAddr.TabIndex = 10;
            this.lblHeartbeatAddr.Text = "心跳地址";
            // 
            // txtHeartbeatAddr
            // 
            this.txtHeartbeatAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtHeartbeatAddr.Location = new System.Drawing.Point(130, 462);
            this.txtHeartbeatAddr.Name = "txtHeartbeatAddr";
            this.txtHeartbeatAddr.Size = new System.Drawing.Size(200, 32);
            this.txtHeartbeatAddr.TabIndex = 11;
            this.txtHeartbeatAddr.Text = "DB18.78";
            // 
            // lblEnableReadAddr
            // 
            this.lblEnableReadAddr.AutoSize = true;
            this.lblEnableReadAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblEnableReadAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.lblEnableReadAddr.Location = new System.Drawing.Point(380, 465);
            this.lblEnableReadAddr.Name = "lblEnableReadAddr";
            this.lblEnableReadAddr.Size = new System.Drawing.Size(126, 25);
            this.lblEnableReadAddr.TabIndex = 12;
            this.lblEnableReadAddr.Text = "允许读取地址";
            // 
            // txtEnableReadAddr
            // 
            this.txtEnableReadAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtEnableReadAddr.Location = new System.Drawing.Point(510, 462);
            this.txtEnableReadAddr.Name = "txtEnableReadAddr";
            this.txtEnableReadAddr.Size = new System.Drawing.Size(200, 32);
            this.txtEnableReadAddr.TabIndex = 13;
            this.txtEnableReadAddr.Text = "DB18.80";
            // 
            // lblCodeStatusAddr
            // 
            this.lblCodeStatusAddr.AutoSize = true;
            this.lblCodeStatusAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblCodeStatusAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblCodeStatusAddr.Location = new System.Drawing.Point(760, 465);
            this.lblCodeStatusAddr.Name = "lblCodeStatusAddr";
            this.lblCodeStatusAddr.Size = new System.Drawing.Size(107, 25);
            this.lblCodeStatusAddr.TabIndex = 14;
            this.lblCodeStatusAddr.Text = "码状态地址";
            // 
            // txtCodeStatusAddr
            // 
            this.txtCodeStatusAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtCodeStatusAddr.Location = new System.Drawing.Point(870, 462);
            this.txtCodeStatusAddr.Name = "txtCodeStatusAddr";
            this.txtCodeStatusAddr.Size = new System.Drawing.Size(200, 32);
            this.txtCodeStatusAddr.TabIndex = 15;
            this.txtCodeStatusAddr.Text = "DB18.82";
            // 
            // lblHeartbeatHint
            // 
            this.lblHeartbeatHint.AutoSize = true;
            this.lblHeartbeatHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblHeartbeatHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblHeartbeatHint.Location = new System.Drawing.Point(30, 502);
            this.lblHeartbeatHint.Name = "lblHeartbeatHint";
            this.lblHeartbeatHint.Size = new System.Drawing.Size(352, 20);
            this.lblHeartbeatHint.TabIndex = 16;
            this.lblHeartbeatHint.Text = "心跳：程序每秒向此地址交替写1/0，表示PC端在线";
            // 
            // lblEnableReadHint
            // 
            this.lblEnableReadHint.AutoSize = true;
            this.lblEnableReadHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblEnableReadHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblEnableReadHint.Location = new System.Drawing.Point(380, 502);
            this.lblEnableReadHint.Name = "lblEnableReadHint";
            this.lblEnableReadHint.Size = new System.Drawing.Size(329, 20);
            this.lblEnableReadHint.TabIndex = 17;
            this.lblEnableReadHint.Text = "允许读取：当地址值=1时，程序才读取条码数据";
            // 
            // lblCodeStatusHint
            // 
            this.lblCodeStatusHint.AutoSize = true;
            this.lblCodeStatusHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCodeStatusHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblCodeStatusHint.Location = new System.Drawing.Point(760, 502);
            this.lblCodeStatusHint.Name = "lblCodeStatusHint";
            this.lblCodeStatusHint.Size = new System.Drawing.Size(354, 20);
            this.lblCodeStatusHint.TabIndex = 18;
            this.lblCodeStatusHint.Text = "码状态：1=OK写入OKTable，2=NG写入NGTable";
            // 
            // lblAddrHint
            // 
            this.lblAddrHint.AutoSize = true;
            this.lblAddrHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblAddrHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblAddrHint.Location = new System.Drawing.Point(30, 538);
            this.lblAddrHint.Name = "lblAddrHint";
            this.lblAddrHint.Size = new System.Drawing.Size(637, 20);
            this.lblAddrHint.TabIndex = 19;
            this.lblAddrHint.Text = "提示：组别下拉选择主码/副码1~4，读取内容自定义，数据类型选STRING/INT16/REAL/BYTE";
            // 
            // btnSaveComParam
            // 
            this.btnSaveComParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnSaveComParam.FlatAppearance.BorderSize = 0;
            this.btnSaveComParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveComParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveComParam.ForeColor = System.Drawing.Color.White;
            this.btnSaveComParam.Location = new System.Drawing.Point(1003, 798);
            this.btnSaveComParam.Name = "btnSaveComParam";
            this.btnSaveComParam.Size = new System.Drawing.Size(160, 45);
            this.btnSaveComParam.TabIndex = 2;
            this.btnSaveComParam.Text = "💾 保存参数";
            this.btnSaveComParam.UseVisualStyleBackColor = false;
            this.btnSaveComParam.Click += new System.EventHandler(this.btnSaveComParam_Click);
            // 
            // btnReconnect
            // 
            this.btnReconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnReconnect.FlatAppearance.BorderSize = 0;
            this.btnReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReconnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnReconnect.ForeColor = System.Drawing.Color.White;
            this.btnReconnect.Location = new System.Drawing.Point(1003, 730);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(160, 45);
            this.btnReconnect.TabIndex = 7;
            this.btnReconnect.Text = "通讯重连";
            this.btnReconnect.UseVisualStyleBackColor = false;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage5.Controls.Add(this.tlpDbPage);
            this.tabPage5.Font = new System.Drawing.Font("宋体", 13.8F);
            this.tabPage5.Location = new System.Drawing.Point(4, 53);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1235, 831);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "DB调试";
            // 
            // tlpDbPage
            // 
            this.tlpDbPage.ColumnCount = 1;
            this.tlpDbPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbPage.Controls.Add(this.pnlDbTop, 0, 0);
            this.tlpDbPage.Controls.Add(this.pnlDbScroll, 0, 1);
            this.tlpDbPage.Controls.Add(this.pnlDbBottom, 0, 2);
            this.tlpDbPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDbPage.Location = new System.Drawing.Point(3, 2);
            this.tlpDbPage.Name = "tlpDbPage";
            this.tlpDbPage.RowCount = 3;
            this.tlpDbPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDbPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpDbPage.Size = new System.Drawing.Size(1229, 827);
            this.tlpDbPage.TabIndex = 4;
            // 
            // pnlDbTop
            // 
            this.pnlDbTop.Controls.Add(this.tlpDbTopBar);
            this.pnlDbTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbTop.Location = new System.Drawing.Point(3, 3);
            this.pnlDbTop.Name = "pnlDbTop";
            this.pnlDbTop.Size = new System.Drawing.Size(1223, 44);
            this.pnlDbTop.TabIndex = 0;
            // 
            // tlpDbTopBar
            // 
            this.tlpDbTopBar.ColumnCount = 2;
            this.tlpDbTopBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbTopBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpDbTopBar.Controls.Add(this.lblDbDebugTitle, 0, 0);
            this.tlpDbTopBar.Controls.Add(this.pnlDbProduct, 1, 0);
            this.tlpDbTopBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDbTopBar.Location = new System.Drawing.Point(0, 0);
            this.tlpDbTopBar.Name = "tlpDbTopBar";
            this.tlpDbTopBar.RowCount = 1;
            this.tlpDbTopBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbTopBar.Size = new System.Drawing.Size(1223, 44);
            this.tlpDbTopBar.TabIndex = 3;
            // 
            // lblDbDebugTitle
            // 
            this.lblDbDebugTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbDebugTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblDbDebugTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.lblDbDebugTitle.Location = new System.Drawing.Point(3, 0);
            this.lblDbDebugTitle.Name = "lblDbDebugTitle";
            this.lblDbDebugTitle.Size = new System.Drawing.Size(1037, 44);
            this.lblDbDebugTitle.TabIndex = 0;
            this.lblDbDebugTitle.Text = "数据库调试";
            this.lblDbDebugTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDbProduct
            // 
            this.pnlDbProduct.Controls.Add(this.cmbDbProduct);
            this.pnlDbProduct.Controls.Add(this.lblDbProduct);
            this.pnlDbProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbProduct.Location = new System.Drawing.Point(1046, 3);
            this.pnlDbProduct.Name = "pnlDbProduct";
            this.pnlDbProduct.Size = new System.Drawing.Size(174, 38);
            this.pnlDbProduct.TabIndex = 4;
            // 
            // cmbDbProduct
            // 
            this.cmbDbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDbProduct.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbDbProduct.FormattingEnabled = true;
            this.cmbDbProduct.Location = new System.Drawing.Point(55, 5);
            this.cmbDbProduct.Name = "cmbDbProduct";
            this.cmbDbProduct.Size = new System.Drawing.Size(115, 31);
            this.cmbDbProduct.TabIndex = 1;
            // 
            // lblDbProduct
            // 
            this.lblDbProduct.AutoSize = true;
            this.lblDbProduct.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblDbProduct.Location = new System.Drawing.Point(0, 8);
            this.lblDbProduct.Name = "lblDbProduct";
            this.lblDbProduct.Size = new System.Drawing.Size(61, 23);
            this.lblDbProduct.TabIndex = 0;
            this.lblDbProduct.Text = "产品：";
            // 
            // pnlDbScroll
            // 
            this.pnlDbScroll.AutoScroll = true;
            this.pnlDbScroll.BackColor = System.Drawing.Color.White;
            this.pnlDbScroll.Controls.Add(this.tlpDbInputs);
            this.pnlDbScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbScroll.Location = new System.Drawing.Point(3, 53);
            this.pnlDbScroll.Name = "pnlDbScroll";
            this.pnlDbScroll.Size = new System.Drawing.Size(1223, 561);
            this.pnlDbScroll.TabIndex = 1;
            // 
            // tlpDbInputs
            // 
            this.tlpDbInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDbInputs.Location = new System.Drawing.Point(0, 0);
            this.tlpDbInputs.Name = "tlpDbInputs";
            this.tlpDbInputs.Size = new System.Drawing.Size(200, 100);
            this.tlpDbInputs.TabIndex = 0;
            // 
            // pnlDbBottom
            // 
            this.pnlDbBottom.BackColor = System.Drawing.Color.White;
            this.pnlDbBottom.Controls.Add(this.tlpDbBottom);
            this.pnlDbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDbBottom.Location = new System.Drawing.Point(3, 620);
            this.pnlDbBottom.Name = "pnlDbBottom";
            this.pnlDbBottom.Size = new System.Drawing.Size(1223, 204);
            this.pnlDbBottom.TabIndex = 2;
            // 
            // tlpDbBottom
            // 
            this.tlpDbBottom.ColumnCount = 2;
            this.tlpDbBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpDbBottom.Controls.Add(this.pnlDbButtons, 0, 0);
            this.tlpDbBottom.Controls.Add(this.grpDbTestData, 1, 0);
            this.tlpDbBottom.Controls.Add(this.pnlDbLog, 0, 1);
            this.tlpDbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDbBottom.Location = new System.Drawing.Point(0, 0);
            this.tlpDbBottom.Name = "tlpDbBottom";
            this.tlpDbBottom.RowCount = 2;
            this.tlpDbBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDbBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDbBottom.Size = new System.Drawing.Size(1223, 204);
            this.tlpDbBottom.TabIndex = 0;
            // 
            // pnlDbButtons
            // 
            this.pnlDbButtons.Controls.Add(this.btnDbWriteOk);
            this.pnlDbButtons.Controls.Add(this.btnDbWriteNg);
            this.pnlDbButtons.Controls.Add(this.btnDbRefresh);
            this.pnlDbButtons.Controls.Add(this.btnDbTestConn);
            this.pnlDbButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlDbButtons.Name = "pnlDbButtons";
            this.pnlDbButtons.Size = new System.Drawing.Size(957, 44);
            this.pnlDbButtons.TabIndex = 0;
            // 
            // btnDbWriteOk
            // 
            this.btnDbWriteOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnDbWriteOk.FlatAppearance.BorderSize = 0;
            this.btnDbWriteOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbWriteOk.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDbWriteOk.ForeColor = System.Drawing.Color.White;
            this.btnDbWriteOk.Location = new System.Drawing.Point(0, 4);
            this.btnDbWriteOk.Name = "btnDbWriteOk";
            this.btnDbWriteOk.Size = new System.Drawing.Size(150, 38);
            this.btnDbWriteOk.TabIndex = 0;
            this.btnDbWriteOk.Text = "✅ 写入OK表";
            this.btnDbWriteOk.UseVisualStyleBackColor = false;
            this.btnDbWriteOk.Click += new System.EventHandler(this.BtnDbWriteOk_Click);
            // 
            // btnDbWriteNg
            // 
            this.btnDbWriteNg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDbWriteNg.FlatAppearance.BorderSize = 0;
            this.btnDbWriteNg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbWriteNg.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDbWriteNg.ForeColor = System.Drawing.Color.White;
            this.btnDbWriteNg.Location = new System.Drawing.Point(160, 4);
            this.btnDbWriteNg.Name = "btnDbWriteNg";
            this.btnDbWriteNg.Size = new System.Drawing.Size(150, 38);
            this.btnDbWriteNg.TabIndex = 1;
            this.btnDbWriteNg.Text = "❌ 写入NG表";
            this.btnDbWriteNg.UseVisualStyleBackColor = false;
            this.btnDbWriteNg.Click += new System.EventHandler(this.BtnDbWriteNg_Click);
            // 
            // btnDbRefresh
            // 
            this.btnDbRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDbRefresh.FlatAppearance.BorderSize = 0;
            this.btnDbRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbRefresh.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDbRefresh.ForeColor = System.Drawing.Color.White;
            this.btnDbRefresh.Location = new System.Drawing.Point(320, 4);
            this.btnDbRefresh.Name = "btnDbRefresh";
            this.btnDbRefresh.Size = new System.Drawing.Size(140, 38);
            this.btnDbRefresh.TabIndex = 2;
            this.btnDbRefresh.Text = "🔄 刷新字段";
            this.btnDbRefresh.UseVisualStyleBackColor = false;
            this.btnDbRefresh.Click += new System.EventHandler(this.BtnDbRefresh_Click);
            // 
            // btnDbTestConn
            // 
            this.btnDbTestConn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnDbTestConn.FlatAppearance.BorderSize = 0;
            this.btnDbTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbTestConn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDbTestConn.ForeColor = System.Drawing.Color.White;
            this.btnDbTestConn.Location = new System.Drawing.Point(470, 4);
            this.btnDbTestConn.Name = "btnDbTestConn";
            this.btnDbTestConn.Size = new System.Drawing.Size(150, 38);
            this.btnDbTestConn.TabIndex = 3;
            this.btnDbTestConn.Text = "🔗 测试连接";
            this.btnDbTestConn.UseVisualStyleBackColor = false;
            this.btnDbTestConn.Click += new System.EventHandler(this.BtnDbTestConn_Click);
            // 
            // grpDbTestData
            // 
            this.grpDbTestData.Controls.Add(this.rdoDbFull);
            this.grpDbTestData.Controls.Add(this.rdoDbOk);
            this.grpDbTestData.Controls.Add(this.rdoDbNg);
            this.grpDbTestData.Controls.Add(this.btnDbFill);
            this.grpDbTestData.Controls.Add(this.btnDbWritePlc);
            this.grpDbTestData.Controls.Add(this.btnDbReadOk);
            this.grpDbTestData.Controls.Add(this.btnDbReadNg);
            this.grpDbTestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDbTestData.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.grpDbTestData.Location = new System.Drawing.Point(966, 3);
            this.grpDbTestData.Name = "grpDbTestData";
            this.tlpDbBottom.SetRowSpan(this.grpDbTestData, 2);
            this.grpDbTestData.Size = new System.Drawing.Size(254, 198);
            this.grpDbTestData.TabIndex = 1;
            this.grpDbTestData.TabStop = false;
            this.grpDbTestData.Text = "测试数据";
            // 
            // rdoDbFull
            // 
            this.rdoDbFull.AutoSize = true;
            this.rdoDbFull.Checked = true;
            this.rdoDbFull.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdoDbFull.Location = new System.Drawing.Point(10, 22);
            this.rdoDbFull.Name = "rdoDbFull";
            this.rdoDbFull.Size = new System.Drawing.Size(90, 24);
            this.rdoDbFull.TabIndex = 0;
            this.rdoDbFull.TabStop = true;
            this.rdoDbFull.Text = "完整测试";
            this.rdoDbFull.UseVisualStyleBackColor = true;
            // 
            // rdoDbOk
            // 
            this.rdoDbOk.AutoSize = true;
            this.rdoDbOk.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdoDbOk.Location = new System.Drawing.Point(115, 22);
            this.rdoDbOk.Name = "rdoDbOk";
            this.rdoDbOk.Size = new System.Drawing.Size(82, 24);
            this.rdoDbOk.TabIndex = 1;
            this.rdoDbOk.Text = "OK产品";
            this.rdoDbOk.UseVisualStyleBackColor = true;
            // 
            // rdoDbNg
            // 
            this.rdoDbNg.AutoSize = true;
            this.rdoDbNg.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdoDbNg.Location = new System.Drawing.Point(10, 48);
            this.rdoDbNg.Name = "rdoDbNg";
            this.rdoDbNg.Size = new System.Drawing.Size(83, 24);
            this.rdoDbNg.TabIndex = 2;
            this.rdoDbNg.Text = "NG产品";
            this.rdoDbNg.UseVisualStyleBackColor = true;
            // 
            // btnDbFill
            // 
            this.btnDbFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDbFill.FlatAppearance.BorderSize = 0;
            this.btnDbFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbFill.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnDbFill.ForeColor = System.Drawing.Color.White;
            this.btnDbFill.Location = new System.Drawing.Point(10, 76);
            this.btnDbFill.Name = "btnDbFill";
            this.btnDbFill.Size = new System.Drawing.Size(235, 30);
            this.btnDbFill.TabIndex = 3;
            this.btnDbFill.Text = "📥 一键填充到上方";
            this.btnDbFill.UseVisualStyleBackColor = false;
            this.btnDbFill.Click += new System.EventHandler(this.BtnDbFill_Click);
            // 
            // btnDbWritePlc
            // 
            this.btnDbWritePlc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnDbWritePlc.FlatAppearance.BorderSize = 0;
            this.btnDbWritePlc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbWritePlc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnDbWritePlc.ForeColor = System.Drawing.Color.White;
            this.btnDbWritePlc.Location = new System.Drawing.Point(10, 112);
            this.btnDbWritePlc.Name = "btnDbWritePlc";
            this.btnDbWritePlc.Size = new System.Drawing.Size(235, 30);
            this.btnDbWritePlc.TabIndex = 4;
            this.btnDbWritePlc.Text = "📤 写入PLC";
            this.btnDbWritePlc.UseVisualStyleBackColor = false;
            this.btnDbWritePlc.Click += new System.EventHandler(this.BtnDbWritePlc_Click);
            // 
            // btnDbReadOk
            // 
            this.btnDbReadOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnDbReadOk.FlatAppearance.BorderSize = 0;
            this.btnDbReadOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbReadOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnDbReadOk.ForeColor = System.Drawing.Color.White;
            this.btnDbReadOk.Location = new System.Drawing.Point(10, 148);
            this.btnDbReadOk.Name = "btnDbReadOk";
            this.btnDbReadOk.Size = new System.Drawing.Size(115, 30);
            this.btnDbReadOk.TabIndex = 5;
            this.btnDbReadOk.Text = "✅ OK读取";
            this.btnDbReadOk.UseVisualStyleBackColor = false;
            this.btnDbReadOk.Click += new System.EventHandler(this.BtnDbReadOk_Click);
            // 
            // btnDbReadNg
            // 
            this.btnDbReadNg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDbReadNg.FlatAppearance.BorderSize = 0;
            this.btnDbReadNg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbReadNg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnDbReadNg.ForeColor = System.Drawing.Color.White;
            this.btnDbReadNg.Location = new System.Drawing.Point(130, 148);
            this.btnDbReadNg.Name = "btnDbReadNg";
            this.btnDbReadNg.Size = new System.Drawing.Size(115, 30);
            this.btnDbReadNg.TabIndex = 6;
            this.btnDbReadNg.Text = "❌ NG读取";
            this.btnDbReadNg.UseVisualStyleBackColor = false;
            this.btnDbReadNg.Click += new System.EventHandler(this.BtnDbReadNg_Click);
            // 
            // pnlDbLog
            // 
            this.pnlDbLog.Controls.Add(this.txtDbDebugLog);
            this.pnlDbLog.Controls.Add(this.lblDbLog);
            this.pnlDbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbLog.Location = new System.Drawing.Point(3, 53);
            this.pnlDbLog.Name = "pnlDbLog";
            this.pnlDbLog.Size = new System.Drawing.Size(957, 148);
            this.pnlDbLog.TabIndex = 2;
            // 
            // txtDbDebugLog
            // 
            this.txtDbDebugLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDbDebugLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDbDebugLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbDebugLog.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtDbDebugLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtDbDebugLog.Location = new System.Drawing.Point(0, 24);
            this.txtDbDebugLog.Name = "txtDbDebugLog";
            this.txtDbDebugLog.ReadOnly = true;
            this.txtDbDebugLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDbDebugLog.Size = new System.Drawing.Size(957, 124);
            this.txtDbDebugLog.TabIndex = 1;
            this.txtDbDebugLog.Text = "";
            // 
            // lblDbLog
            // 
            this.lblDbLog.AutoSize = true;
            this.lblDbLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDbLog.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblDbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDbLog.Location = new System.Drawing.Point(0, 0);
            this.lblDbLog.Name = "lblDbLog";
            this.lblDbLog.Size = new System.Drawing.Size(95, 24);
            this.lblDbLog.TabIndex = 0;
            this.lblDbLog.Text = "操作日志：";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage6.Controls.Add(this.tlpPlcPage);
            this.tabPage6.Font = new System.Drawing.Font("宋体", 13.8F);
            this.tabPage6.Location = new System.Drawing.Point(4, 53);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Size = new System.Drawing.Size(1235, 831);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "PLC测试";
            // 
            // tlpPlcPage
            // 
            this.tlpPlcPage.ColumnCount = 1;
            this.tlpPlcPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlcPage.Controls.Add(this.pnlPlcTop, 0, 0);
            this.tlpPlcPage.Controls.Add(this.grpPlcInput, 0, 1);
            this.tlpPlcPage.Controls.Add(this.lblPlcLog, 0, 2);
            this.tlpPlcPage.Controls.Add(this.txtPlcTestLog, 0, 3);
            this.tlpPlcPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlcPage.Location = new System.Drawing.Point(3, 2);
            this.tlpPlcPage.Name = "tlpPlcPage";
            this.tlpPlcPage.RowCount = 4;
            this.tlpPlcPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpPlcPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPlcPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPlcPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlcPage.Size = new System.Drawing.Size(1229, 827);
            this.tlpPlcPage.TabIndex = 5;
            // 
            // pnlPlcTop
            // 
            this.pnlPlcTop.Controls.Add(this.chkSimMode);
            this.pnlPlcTop.Controls.Add(this.lblPlcTestTitle);
            this.pnlPlcTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlcTop.Location = new System.Drawing.Point(3, 3);
            this.pnlPlcTop.Name = "pnlPlcTop";
            this.pnlPlcTop.Size = new System.Drawing.Size(1223, 118);
            this.pnlPlcTop.TabIndex = 0;
            // 
            // chkSimMode
            // 
            this.chkSimMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSimMode.AutoSize = true;
            this.chkSimMode.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.chkSimMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.chkSimMode.Location = new System.Drawing.Point(917, 10);
            this.chkSimMode.Name = "chkSimMode";
            this.chkSimMode.Size = new System.Drawing.Size(297, 30);
            this.chkSimMode.TabIndex = 1;
            this.chkSimMode.Text = "模拟模式（不连PLC也可测试）";
            this.chkSimMode.UseVisualStyleBackColor = true;
            // 
            // lblPlcTestTitle
            // 
            this.lblPlcTestTitle.AutoSize = true;
            this.lblPlcTestTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlcTestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            this.lblPlcTestTitle.Location = new System.Drawing.Point(20, 6);
            this.lblPlcTestTitle.Name = "lblPlcTestTitle";
            this.lblPlcTestTitle.Size = new System.Drawing.Size(354, 31);
            this.lblPlcTestTitle.TabIndex = 0;
            this.lblPlcTestTitle.Text = "PLC 读写测试（支持模拟模式）";
            // 
            // grpPlcInput
            // 
            this.grpPlcInput.BackColor = System.Drawing.Color.White;
            this.grpPlcInput.Controls.Add(this.tlpPlcInput);
            this.grpPlcInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlcInput.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.grpPlcInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.grpPlcInput.Location = new System.Drawing.Point(3, 127);
            this.grpPlcInput.Name = "grpPlcInput";
            this.grpPlcInput.Padding = new System.Windows.Forms.Padding(15, 25, 15, 10);
            this.grpPlcInput.Size = new System.Drawing.Size(1223, 242);
            this.grpPlcInput.TabIndex = 1;
            this.grpPlcInput.TabStop = false;
            this.grpPlcInput.Text = "读写参数";
            // 
            // tlpPlcInput
            // 
            this.tlpPlcInput.ColumnCount = 4;
            this.tlpPlcInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpPlcInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlcInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpPlcInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlcInput.Controls.Add(this.lblPlcAddr, 0, 0);
            this.tlpPlcInput.Controls.Add(this.txtTestAddress, 1, 0);
            this.tlpPlcInput.Controls.Add(this.lblPlcDataType, 2, 0);
            this.tlpPlcInput.Controls.Add(this.cmbTestDataType, 3, 0);
            this.tlpPlcInput.Controls.Add(this.lblPlcValue, 0, 1);
            this.tlpPlcInput.Controls.Add(this.txtTestValue, 1, 1);
            this.tlpPlcInput.Controls.Add(this.pnlPlcButtons, 0, 2);
            this.tlpPlcInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlcInput.Location = new System.Drawing.Point(15, 50);
            this.tlpPlcInput.Name = "tlpPlcInput";
            this.tlpPlcInput.RowCount = 3;
            this.tlpPlcInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPlcInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPlcInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPlcInput.Size = new System.Drawing.Size(1193, 182);
            this.tlpPlcInput.TabIndex = 0;
            // 
            // lblPlcAddr
            // 
            this.lblPlcAddr.AutoSize = true;
            this.lblPlcAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblPlcAddr.Location = new System.Drawing.Point(3, 0);
            this.lblPlcAddr.Name = "lblPlcAddr";
            this.lblPlcAddr.Size = new System.Drawing.Size(66, 40);
            this.lblPlcAddr.TabIndex = 4;
            this.lblPlcAddr.Text = "PLC地址：";
            this.lblPlcAddr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTestAddress
            // 
            this.txtTestAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestAddress.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtTestAddress.Location = new System.Drawing.Point(88, 3);
            this.txtTestAddress.Name = "txtTestAddress";
            this.txtTestAddress.Size = new System.Drawing.Size(505, 32);
            this.txtTestAddress.TabIndex = 0;
            this.txtTestAddress.Text = "DB18.80";
            // 
            // lblPlcDataType
            // 
            this.lblPlcDataType.AutoSize = true;
            this.lblPlcDataType.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblPlcDataType.Location = new System.Drawing.Point(599, 0);
            this.lblPlcDataType.Name = "lblPlcDataType";
            this.lblPlcDataType.Size = new System.Drawing.Size(69, 40);
            this.lblPlcDataType.TabIndex = 5;
            this.lblPlcDataType.Text = "数据类型：";
            this.lblPlcDataType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTestDataType
            // 
            this.cmbTestDataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTestDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTestDataType.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cmbTestDataType.FormattingEnabled = true;
            this.cmbTestDataType.Location = new System.Drawing.Point(684, 3);
            this.cmbTestDataType.Name = "cmbTestDataType";
            this.cmbTestDataType.Size = new System.Drawing.Size(506, 32);
            this.cmbTestDataType.TabIndex = 1;
            // 
            // lblPlcValue
            // 
            this.lblPlcValue.AutoSize = true;
            this.lblPlcValue.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblPlcValue.Location = new System.Drawing.Point(3, 40);
            this.lblPlcValue.Name = "lblPlcValue";
            this.lblPlcValue.Size = new System.Drawing.Size(50, 40);
            this.lblPlcValue.TabIndex = 6;
            this.lblPlcValue.Text = "写入值：";
            this.lblPlcValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTestValue
            // 
            this.txtTestValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestValue.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtTestValue.Location = new System.Drawing.Point(88, 43);
            this.txtTestValue.Name = "txtTestValue";
            this.txtTestValue.Size = new System.Drawing.Size(505, 32);
            this.txtTestValue.TabIndex = 2;
            this.txtTestValue.Text = "1";
            // 
            // pnlPlcButtons
            // 
            this.pnlPlcButtons.BackColor = System.Drawing.Color.Transparent;
            this.tlpPlcInput.SetColumnSpan(this.pnlPlcButtons, 4);
            this.pnlPlcButtons.Controls.Add(this.btnPlcRead);
            this.pnlPlcButtons.Controls.Add(this.btnPlcWrite);
            this.pnlPlcButtons.Controls.Add(this.btnSimInit);
            this.pnlPlcButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlcButtons.Location = new System.Drawing.Point(3, 83);
            this.pnlPlcButtons.Name = "pnlPlcButtons";
            this.pnlPlcButtons.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlPlcButtons.Size = new System.Drawing.Size(1187, 96);
            this.pnlPlcButtons.TabIndex = 3;
            // 
            // btnPlcRead
            // 
            this.btnPlcRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnPlcRead.FlatAppearance.BorderSize = 0;
            this.btnPlcRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcRead.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlcRead.ForeColor = System.Drawing.Color.White;
            this.btnPlcRead.Location = new System.Drawing.Point(0, 4);
            this.btnPlcRead.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnPlcRead.Name = "btnPlcRead";
            this.btnPlcRead.Size = new System.Drawing.Size(150, 38);
            this.btnPlcRead.TabIndex = 0;
            this.btnPlcRead.Text = "📥 读取";
            this.btnPlcRead.UseVisualStyleBackColor = false;
            this.btnPlcRead.Click += new System.EventHandler(this.btnPlcRead_Click);
            // 
            // btnPlcWrite
            // 
            this.btnPlcWrite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnPlcWrite.FlatAppearance.BorderSize = 0;
            this.btnPlcWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcWrite.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlcWrite.ForeColor = System.Drawing.Color.White;
            this.btnPlcWrite.Location = new System.Drawing.Point(160, 4);
            this.btnPlcWrite.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnPlcWrite.Name = "btnPlcWrite";
            this.btnPlcWrite.Size = new System.Drawing.Size(150, 38);
            this.btnPlcWrite.TabIndex = 1;
            this.btnPlcWrite.Text = "📤 写入";
            this.btnPlcWrite.UseVisualStyleBackColor = false;
            this.btnPlcWrite.Click += new System.EventHandler(this.btnPlcWrite_Click);
            // 
            // btnSimInit
            // 
            this.btnSimInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnSimInit.FlatAppearance.BorderSize = 0;
            this.btnSimInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimInit.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimInit.ForeColor = System.Drawing.Color.White;
            this.btnSimInit.Location = new System.Drawing.Point(320, 4);
            this.btnSimInit.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSimInit.Name = "btnSimInit";
            this.btnSimInit.Size = new System.Drawing.Size(160, 38);
            this.btnSimInit.TabIndex = 2;
            this.btnSimInit.Text = "⚙ 模拟初始化";
            this.btnSimInit.UseVisualStyleBackColor = false;
            this.btnSimInit.Click += new System.EventHandler(this.BtnSimInit_Click);
            // 
            // lblPlcLog
            // 
            this.lblPlcLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlcLog.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblPlcLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPlcLog.Location = new System.Drawing.Point(3, 372);
            this.lblPlcLog.Name = "lblPlcLog";
            this.lblPlcLog.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
            this.lblPlcLog.Size = new System.Drawing.Size(1223, 28);
            this.lblPlcLog.TabIndex = 2;
            this.lblPlcLog.Text = "操作日志：";
            // 
            // txtPlcTestLog
            // 
            this.txtPlcTestLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPlcTestLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlcTestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlcTestLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtPlcTestLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtPlcTestLog.Location = new System.Drawing.Point(3, 416);
            this.txtPlcTestLog.Name = "txtPlcTestLog";
            this.txtPlcTestLog.ReadOnly = true;
            this.txtPlcTestLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtPlcTestLog.Size = new System.Drawing.Size(1223, 408);
            this.txtPlcTestLog.TabIndex = 3;
            this.txtPlcTestLog.Text = "";
            // 
            // tlpPlcTopBar
            // 
            this.tlpPlcTopBar.Location = new System.Drawing.Point(0, 0);
            this.tlpPlcTopBar.Name = "tlpPlcTopBar";
            this.tlpPlcTopBar.Size = new System.Drawing.Size(200, 100);
            this.tlpPlcTopBar.TabIndex = 0;
            // 
            // lblSubSummaryValue
            // 
            this.lblSubSummaryValue.Location = new System.Drawing.Point(0, 0);
            this.lblSubSummaryValue.Name = "lblSubSummaryValue";
            this.lblSubSummaryValue.Size = new System.Drawing.Size(100, 23);
            this.lblSubSummaryValue.TabIndex = 0;
            // 
            // lblMainStatusValue
            // 
            this.lblMainStatusValue.Location = new System.Drawing.Point(0, 0);
            this.lblMainStatusValue.Name = "lblMainStatusValue";
            this.lblMainStatusValue.Size = new System.Drawing.Size(100, 23);
            this.lblMainStatusValue.TabIndex = 0;
            // 
            // pnlOkResult
            // 
            this.pnlOkResult.Location = new System.Drawing.Point(0, 0);
            this.pnlOkResult.Name = "pnlOkResult";
            this.pnlOkResult.Size = new System.Drawing.Size(200, 100);
            this.pnlOkResult.TabIndex = 0;
            // 
            // pnlNgResult
            // 
            this.pnlNgResult.Location = new System.Drawing.Point(0, 0);
            this.pnlNgResult.Name = "pnlNgResult";
            this.pnlNgResult.Size = new System.Drawing.Size(200, 100);
            this.pnlNgResult.TabIndex = 0;
            // 
            // grpQuery
            // 
            this.grpQuery.Location = new System.Drawing.Point(0, 0);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(0, 0);
            this.grpQuery.TabIndex = 99;
            this.grpQuery.TabStop = false;
            this.grpQuery.Visible = false;
            // 
            // btnManualQuery
            // 
            this.btnManualQuery.Location = new System.Drawing.Point(0, 0);
            this.btnManualQuery.Name = "btnManualQuery";
            this.btnManualQuery.Size = new System.Drawing.Size(0, 0);
            this.btnManualQuery.TabIndex = 99;
            this.btnManualQuery.Visible = false;
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(0, 0);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(0, 25);
            this.txtSN.TabIndex = 99;
            this.txtSN.Visible = false;
            // 
            // dgvQuery
            // 
            this.dgvQuery.ColumnHeadersHeight = 29;
            this.dgvQuery.Location = new System.Drawing.Point(0, 0);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.RowHeadersWidth = 51;
            this.dgvQuery.Size = new System.Drawing.Size(0, 0);
            this.dgvQuery.TabIndex = 99;
            this.dgvQuery.Visible = false;
            // 
            // lblMainCodeValue
            // 
            this.lblMainCodeValue.Location = new System.Drawing.Point(0, 0);
            this.lblMainCodeValue.Name = "lblMainCodeValue";
            this.lblMainCodeValue.Size = new System.Drawing.Size(100, 23);
            this.lblMainCodeValue.TabIndex = 0;
            // 
            // lblSubCode1Value
            // 
            this.lblSubCode1Value.Location = new System.Drawing.Point(0, 0);
            this.lblSubCode1Value.Name = "lblSubCode1Value";
            this.lblSubCode1Value.Size = new System.Drawing.Size(100, 23);
            this.lblSubCode1Value.TabIndex = 0;
            // 
            // lblSubCode2Value
            // 
            this.lblSubCode2Value.Location = new System.Drawing.Point(0, 0);
            this.lblSubCode2Value.Name = "lblSubCode2Value";
            this.lblSubCode2Value.Size = new System.Drawing.Size(100, 23);
            this.lblSubCode2Value.TabIndex = 0;
            // 
            // lblSubCode3Value
            // 
            this.lblSubCode3Value.Location = new System.Drawing.Point(0, 0);
            this.lblSubCode3Value.Name = "lblSubCode3Value";
            this.lblSubCode3Value.Size = new System.Drawing.Size(100, 23);
            this.lblSubCode3Value.TabIndex = 0;
            // 
            // lblSubCode4Value
            // 
            this.lblSubCode4Value.Location = new System.Drawing.Point(0, 0);
            this.lblSubCode4Value.Name = "lblSubCode4Value";
            this.lblSubCode4Value.Size = new System.Drawing.Size(100, 23);
            this.lblSubCode4Value.TabIndex = 0;
            // 
            // ethernetCtl2
            // 
            this.ethernetCtl2.IP = "Any";
            this.ethernetCtl2.Location = new System.Drawing.Point(25, 222);
            this.ethernetCtl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ethernetCtl2.Name = "ethernetCtl2";
            this.ethernetCtl2.Port = "5000";
            this.ethernetCtl2.Size = new System.Drawing.Size(981, 141);
            this.ethernetCtl2.TabIndex = 3;
            this.ethernetCtl2.Text = "PLC通信";
            // 
            // ethernetCtl1
            // 
            this.ethernetCtl1.IP = "Any";
            this.ethernetCtl1.Location = new System.Drawing.Point(25, 72);
            this.ethernetCtl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ethernetCtl1.Name = "ethernetCtl1";
            this.ethernetCtl1.Port = "5000";
            this.ethernetCtl1.Size = new System.Drawing.Size(1000, 120);
            this.ethernetCtl1.TabIndex = 0;
            this.ethernetCtl1.Text = "PLC通信";
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 894);
            this.Controls.Add(this.tlpMain1);
            this.Name = "frmDatabase";
            this.Text = "压力记录系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabase_FormClosing);
            this.Load += new System.EventHandler(this.frmDatabase_Load);
            this.tlpMain1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlMainRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblCodes.ResumeLayout(false);
            this.pnlMainCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCode)).EndInit();
            this.pnlSub1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode1)).EndInit();
            this.pnlSub2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode2)).EndInit();
            this.pnlSub3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode3)).EndInit();
            this.pnlSub4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCode4)).EndInit();
            this.pnlRow2Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Main)).EndInit();
            this.pnlRow2Sub1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub1)).EndInit();
            this.pnlRow2Sub2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub2)).EndInit();
            this.pnlRow2Sub3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub3)).EndInit();
            this.pnlRow2Sub4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow2Sub4)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.tblSummary.ResumeLayout(false);
            this.pnlSummaryLeft.ResumeLayout(false);
            this.pnlSummaryLeft.PerformLayout();
            this.pnlSummaryRight.ResumeLayout(false);
            this.pnlSummaryRight.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tblResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNgResult)).EndInit();
            this.pnlQueryTop.ResumeLayout(false);
            this.pnlQueryTop.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.grpPlcConfig.ResumeLayout(false);
            this.grpPlcConfig.PerformLayout();
            this.grpBarcodeAddr.ResumeLayout(false);
            this.grpBarcodeAddr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupColumns)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tlpDbPage.ResumeLayout(false);
            this.pnlDbTop.ResumeLayout(false);
            this.tlpDbTopBar.ResumeLayout(false);
            this.pnlDbProduct.ResumeLayout(false);
            this.pnlDbProduct.PerformLayout();
            this.pnlDbScroll.ResumeLayout(false);
            this.pnlDbBottom.ResumeLayout(false);
            this.tlpDbBottom.ResumeLayout(false);
            this.pnlDbButtons.ResumeLayout(false);
            this.grpDbTestData.ResumeLayout(false);
            this.grpDbTestData.PerformLayout();
            this.pnlDbLog.ResumeLayout(false);
            this.pnlDbLog.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tlpPlcPage.ResumeLayout(false);
            this.pnlPlcTop.ResumeLayout(false);
            this.pnlPlcTop.PerformLayout();
            this.grpPlcInput.ResumeLayout(false);
            this.tlpPlcInput.ResumeLayout(false);
            this.tlpPlcInput.PerformLayout();
            this.pnlPlcButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timproCount;
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.Timer timerHeart;
        private System.Windows.Forms.RichTextBox txtRecordinfo;
        private System.Windows.Forms.TableLayoutPanel tlpMain1;
        private System.Windows.Forms.TabControl tab2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel pnlQueryTop;
        private System.Windows.Forms.Label lblQueryHelp;
        private System.Windows.Forms.Label lblQueryTitle;
        private System.Windows.Forms.Button btnQueryOk;
        private System.Windows.Forms.Button btnQueryNg;
        private System.Windows.Forms.Label lblQueryProduct;
        private System.Windows.Forms.DateTimePicker dtpExportFrom;
        private System.Windows.Forms.DateTimePicker dtpExportTo;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Label lblExportFrom;
        private System.Windows.Forms.Label lblExportTo;
        private System.Windows.Forms.TextBox txtQueryCode;
        private System.Windows.Forms.Label lblQueryInput;
        private System.Windows.Forms.TableLayoutPanel tblResults;
        private System.Windows.Forms.Panel pnlOkResult;
        private System.Windows.Forms.Label lblOkTitle;
        private System.Windows.Forms.DataGridView dgvOkResult;
        private System.Windows.Forms.Panel pnlNgResult;
        private System.Windows.Forms.Label lblNgTitle;
        private System.Windows.Forms.DataGridView dgvNgResult;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.Button btnManualQuery;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.DataGridView dgvQuery;
        private System.Windows.Forms.TabPage tabPage4;
        private CommonUI.CustomControl.EthernetCtl ethernetCtl2;
        private System.Windows.Forms.Button btnSaveComParam;
        private CommonUI.CustomControl.EthernetCtl ethernetCtl1;
        private System.Windows.Forms.TableLayoutPanel pnlMainRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TableLayoutPanel tblCodes;
        private System.Windows.Forms.Panel pnlMainCode;
        private System.Windows.Forms.Label lblMainCodeTitle;
        private System.Windows.Forms.Label lblMainCodeValue;
        private System.Windows.Forms.DataGridView dgvMainCode;
        private System.Windows.Forms.Panel pnlSub1;
        private System.Windows.Forms.Label lblSub1Title;
        private System.Windows.Forms.Label lblSubCode1Value;
        private System.Windows.Forms.DataGridView dgvSubCode1;
        private System.Windows.Forms.Panel pnlSub2;
        private System.Windows.Forms.Label lblSub2Title;
        private System.Windows.Forms.Label lblSubCode2Value;
        private System.Windows.Forms.DataGridView dgvSubCode2;
        private System.Windows.Forms.Panel pnlSub3;
        private System.Windows.Forms.Label lblSub3Title;
        private System.Windows.Forms.Label lblSubCode3Value;
        private System.Windows.Forms.DataGridView dgvSubCode3;
        private System.Windows.Forms.Panel pnlSub4;
        private System.Windows.Forms.Label lblSub4Title;
        private System.Windows.Forms.Label lblSubCode4Value;
        private System.Windows.Forms.DataGridView dgvSubCode4;
        private System.Windows.Forms.Panel pnlRow2Main;
        private System.Windows.Forms.Label lblRow2MainTitle;
        private System.Windows.Forms.DataGridView dgvRow2Main;
        private System.Windows.Forms.Panel pnlRow2Sub1;
        private System.Windows.Forms.Label lblRow2Sub1Title;
        private System.Windows.Forms.DataGridView dgvRow2Sub1;
        private System.Windows.Forms.Panel pnlRow2Sub2;
        private System.Windows.Forms.Label lblRow2Sub2Title;
        private System.Windows.Forms.DataGridView dgvRow2Sub2;
        private System.Windows.Forms.Panel pnlRow2Sub3;
        private System.Windows.Forms.Label lblRow2Sub3Title;
        private System.Windows.Forms.DataGridView dgvRow2Sub3;
        private System.Windows.Forms.Panel pnlRow2Sub4;
        private System.Windows.Forms.Label lblRow2Sub4Title;
        private System.Windows.Forms.DataGridView dgvRow2Sub4;
        private System.Windows.Forms.Label lblSection1;
        private System.Windows.Forms.Label lblSection2;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblMainStatusValue;
        private System.Windows.Forms.Label lblSubSummaryValue;
        private System.Windows.Forms.TableLayoutPanel tblSummary;
        private System.Windows.Forms.Panel pnlSummaryLeft;
        private System.Windows.Forms.Panel pnlSummaryRight;
        private System.Windows.Forms.Label lblProduct1Status;
        private System.Windows.Forms.Label lblProduct1SubSummary;
        private System.Windows.Forms.Label lblProduct2Status;
        private System.Windows.Forms.Label lblProduct2SubSummary;
        private System.Windows.Forms.GroupBox grpPlcConfig;
        private System.Windows.Forms.Label lblPlcIp;
        private System.Windows.Forms.TextBox txtPlcIp;
        private System.Windows.Forms.Label lblPlcPort;
        private System.Windows.Forms.TextBox txtPlcPort;
        private System.Windows.Forms.ComboBox cmbProductSelector;
        private System.Windows.Forms.Label lblProductSelector;
        private System.Windows.Forms.GroupBox grpBarcodeAddr;
        private System.Windows.Forms.ListBox lstGroupSelector;
        private System.Windows.Forms.DataGridView dgvGroupColumns;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Button btnDeleteColumn;
        private System.Windows.Forms.CheckBox chkAutoReconnect;
        private System.Windows.Forms.Label lblHeartbeatAddr;
        private System.Windows.Forms.TextBox txtHeartbeatAddr;
        private System.Windows.Forms.Label lblEnableReadAddr;
        private System.Windows.Forms.TextBox txtEnableReadAddr;
        private System.Windows.Forms.Label lblCodeStatusAddr;
        private System.Windows.Forms.TextBox txtCodeStatusAddr;
        private System.Windows.Forms.Label lblHeartbeatHint;
        private System.Windows.Forms.Label lblEnableReadHint;
        private System.Windows.Forms.Label lblCodeStatusHint;
        private System.Windows.Forms.Label lblAddrHint;
        private System.Windows.Forms.Button btnReconnect;
        private System.Windows.Forms.Label lblOkTable;
        private System.Windows.Forms.TextBox txtOkTableName;
        private System.Windows.Forms.Label lblNgTable;
        private System.Windows.Forms.TextBox txtNgTableName;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel pnlDbTop;
        private System.Windows.Forms.Panel pnlDbScroll;
        private System.Windows.Forms.Panel pnlDbBottom;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel pnlPlcTop;
        private System.Windows.Forms.Label lblPlcHeartbeat;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Button btnToggleLog;
        private System.Windows.Forms.TableLayoutPanel tlpDbBottom;
        private System.Windows.Forms.Panel pnlDbButtons;
        private System.Windows.Forms.Button btnDbWriteOk;
        private System.Windows.Forms.Button btnDbWriteNg;
        private System.Windows.Forms.Button btnDbRefresh;
        private System.Windows.Forms.Button btnDbTestConn;
        private System.Windows.Forms.GroupBox grpDbTestData;
        private System.Windows.Forms.RadioButton rdoDbFull;
        private System.Windows.Forms.RadioButton rdoDbOk;
        private System.Windows.Forms.RadioButton rdoDbNg;
        private System.Windows.Forms.Button btnDbFill;
        private System.Windows.Forms.Button btnDbWritePlc;
        private System.Windows.Forms.Button btnDbReadOk;
        private System.Windows.Forms.Button btnDbReadNg;
        private System.Windows.Forms.Panel pnlDbLog;
        private System.Windows.Forms.Label lblDbLog;
        private System.Windows.Forms.RichTextBox txtDbDebugLog;
        private System.Windows.Forms.GroupBox grpPlcInput;
        private System.Windows.Forms.TableLayoutPanel tlpPlcInput;
        private System.Windows.Forms.Label lblPlcAddr;
        private System.Windows.Forms.Label lblPlcDataType;
        private System.Windows.Forms.Label lblPlcValue;
        private System.Windows.Forms.TextBox txtTestAddress;
        private System.Windows.Forms.ComboBox cmbTestDataType;
        private System.Windows.Forms.TextBox txtTestValue;
        private System.Windows.Forms.FlowLayoutPanel pnlPlcButtons;
        private System.Windows.Forms.Button btnPlcRead;
        private System.Windows.Forms.Button btnPlcWrite;
        private System.Windows.Forms.Button btnSimInit;
        private System.Windows.Forms.CheckBox chkSimMode;
        private System.Windows.Forms.Label lblPlcLog;
        private System.Windows.Forms.RichTextBox txtPlcTestLog;
        private System.Windows.Forms.Label lblPlcTestTitle;
        private System.Windows.Forms.Label lblDbDebugTitle;
        private System.Windows.Forms.ComboBox cmbDbProduct;
        private System.Windows.Forms.Label lblDbProduct;
        private System.Windows.Forms.TableLayoutPanel tlpDbTopBar;
        private System.Windows.Forms.Panel pnlDbProduct;
        private System.Windows.Forms.TableLayoutPanel tlpPlcTopBar;
        private System.Windows.Forms.TableLayoutPanel tlpPlcPage;
        private System.Windows.Forms.TableLayoutPanel tlpDbPage;
        private System.Windows.Forms.TableLayoutPanel tlpDbInputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbQueryProduct;
        private System.Windows.Forms.ComboBox cmbExportTable;
        private System.Windows.Forms.Button btnChangePwd;
    }
}
