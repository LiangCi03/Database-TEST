using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOrm
{
    public class MySqlSugarHelper
    {

      
        SqlSugarClient _sql;
        ConnectionConfig _conConfig = new SqlSugar.ConnectionConfig();



        public MySqlSugarHelper(string connectionString)
        {
            _conConfig = new SqlSugar.ConnectionConfig();
            //数据库字符串
            _conConfig.ConnectionString = connectionString;
            //设置数据库类型
            _conConfig.DbType = SqlSugar.DbType.MySql;
            //自动释放数据务，如果存在事务，在事务结束后释放
            _conConfig.IsAutoCloseConnection = true;
            //从实体特性中读取主键自增列信息
            _conConfig.InitKeyType = InitKeyType.Attribute;//从实体特性中读取主键自增列信息
            _sql = new SqlSugarClient(_conConfig);
        }

        public void Open()
        {
            _sql.Open();
            // return _sql
        }



        public void Close()
        {
            _sql.Close();
        }


        /// <summary>
        /// 查询某行的值
        /// </summary>
        /// <param name="columnsName"></param>
        /// <returns></returns>
        public object Query(string columnsName)
        {

          //  object ob = _sql.Queryable<DatabaseType>().Where(it => it.SN == columnsName).ToDataTable();
            return "";
        }



        /// <summary>
        /// 查询整张表
        /// </summary>
        /// <returns></returns>
        public object QueryTable()
        {

            DataTable dataTable = _sql.Queryable<DatabaseType>().ToDataTable();
            return dataTable;

        }

        public void Insert(DatabaseType dataType)
        {

            _sql.Insertable<DatabaseType>(dataType).ExecuteCommand(); //都是参数化实现

        }

        #region 动态列模式 — OK/NG 表操作

        /// <summary>
        /// 从 BarcodeConfig 中提取所有唯一的数据库列名
        /// </summary>
        public static List<string> GetColumnNamesFromConfig(BarcodeConfig config)
        {
            var columns = new List<string>();
            if (config?.Groups == null) return columns;

            // 顺序：KSZ码 → FSH码1(全部) → FSH码2(全部) → FSH码3(全部) → FSH码4(全部) → KSZ码状态 → 写入时间
            var groupOrder = new[] { "KSZ码", "FSH码1", "FSH码2", "FSH码3", "FSH码4" };

            // 1. KSZ码：只取第一个字段（条码内容）
            var mainGroup = config.Groups.FirstOrDefault(g => g.GroupName == "KSZ码");
            var mainFirst = mainGroup?.Columns?.FirstOrDefault();
            if (mainFirst != null && !string.IsNullOrWhiteSpace(mainFirst.DbColumnName))
                columns.Add(mainFirst.DbColumnName);

            // 2. FSH码1~4：每个组的全部字段
            foreach (var gn in groupOrder.Skip(1)) // 跳过 KSZ码
            {
                var group = config.Groups.FirstOrDefault(g => g.GroupName == gn);
                if (group?.Columns == null) continue;
                foreach (var col in group.Columns)
                {
                    if (!string.IsNullOrWhiteSpace(col?.DbColumnName) && !columns.Contains(col.DbColumnName))
                        columns.Add(col.DbColumnName);
                }
            }

            // 3. KSZ码 组的其余状态字段
            if (mainGroup?.Columns != null)
            {
                foreach (var col in mainGroup.Columns.Skip(1))
                {
                    if (!string.IsNullOrWhiteSpace(col?.DbColumnName) && !columns.Contains(col.DbColumnName))
                        columns.Add(col.DbColumnName);
                }
            }

            return columns;
        }

        /// <summary>
        /// 获取主码对应的数据库列名（主码组中第一个字段的 DbColumnName）
        /// </summary>
        public static string GetMainCodeColumnName(BarcodeConfig config)
        {
            var mainGroup = config?.Groups?.FirstOrDefault(g => g.GroupName == "KSZ码");
            var firstCol = mainGroup?.Columns?.FirstOrDefault();
            return firstCol?.DbColumnName ?? "KSZ码";
        }

        /// <summary>
        /// 从 PLC 通信获取的条码值构建数据库写入字典
        /// 将 _barcodeValues (key="组名_DbColumnName") 转为 (key=DbColumnName) 的字典
        /// </summary>
        public static Dictionary<string, object> BuildInsertDictFromBarcodeValues(
            Dictionary<string, string> barcodeValues, BarcodeConfig config)
        {
            var dict = new Dictionary<string, object>();

            if (config?.Groups != null)
            {
                foreach (var group in config.Groups)
                {
                    if (group?.Columns == null) continue;
                    foreach (var col in group.Columns)
                    {
                        if (col == null || string.IsNullOrWhiteSpace(col.DbColumnName)) continue;
                        string valueKey = (group.GroupName ?? "") + "_" + (col.DbColumnName ?? "");
                        string val = "";
                        if (barcodeValues != null && barcodeValues.TryGetValue(valueKey, out string v) && v != null)
                            val = v;

                        // 结果字段转换：1→OK、0→无结果、其他→NG
                        if (!string.IsNullOrEmpty(col.DbColumnName) && col.DbColumnName.Contains("结果"))
                        {
                            if (val == "1") val = "OK";
                            else if (val == "0") val = "无结果";
                            else val = "NG";
                        }

                        dict[col.DbColumnName] = val;
                    }
                }
            }

            dict["写入时间"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dict;
        }

        /// <summary>
        /// 根据条码配置同步 OKTable / NGTable 表结构（自动创建表、补充缺失列、建索引）
        /// </summary>
        public void SyncTableFromConfig(BarcodeConfig config, string customTableName = null)
        {
            // 必须指定表名，不传则跳过
            if (string.IsNullOrWhiteSpace(customTableName)) return;

            var columns = GetColumnNamesFromConfig(config);
            if (columns.Count == 0) return;

            string mainColName = GetMainCodeColumnName(config);

            EnsureDynamicTable(customTableName, columns);
            EnsureMainCodeIndex(customTableName, mainColName);
            EnsureTimeIndex(customTableName);
        }

        /// <summary>
        /// 确保主码列上有索引（用于精确查询加速）
        /// </summary>
        private void EnsureMainCodeIndex(string tableName, string mainColName)
        {
            if (string.IsNullOrWhiteSpace(mainColName)) return;
            try
            {
                string indexName = $"idx_{tableName}_{mainColName}";
                // 索引名不能太长，MySQL 限制 64 字符
                if (indexName.Length > 64)
                    indexName = indexName.Substring(0, 64);

                string checkIdxSql = $"SELECT COUNT(*) FROM information_schema.statistics " +
                    $"WHERE table_schema = DATABASE() AND table_name = '{tableName}' AND index_name = '{indexName}'";
                int idxCount = _sql.Ado.GetInt(checkIdxSql);

                if (idxCount == 0)
                {
                    string createIdxSql = $"CREATE INDEX `{indexName}` ON `{tableName}` (`{mainColName}`)";
                    _sql.Ado.ExecuteCommand(createIdxSql);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"为 {tableName}.{mainColName} 创建索引失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 确保 写入时间 列有索引（日期查询加速）
        /// </summary>
        private void EnsureTimeIndex(string tableName)
        {
            try
            {
                string indexName = $"idx_{tableName}_写入时间";
                if (indexName.Length > 64) indexName = indexName.Substring(0, 64);

                string checkSql = $"SELECT COUNT(*) FROM information_schema.statistics " +
                    $"WHERE table_schema = DATABASE() AND table_name = '{tableName}' AND index_name = '{indexName}'";
                if (_sql.Ado.GetInt(checkSql) == 0)
                {
                    _sql.Ado.ExecuteCommand($"CREATE INDEX `{indexName}` ON `{tableName}` (`写入时间`)");
                }
            }
            catch { /* 忽略索引创建失败 */ }
        }

        /// <summary>
        /// 确保动态表存在且包含所需列（不存在则创建，缺列则补充）
        /// </summary>
        private void EnsureDynamicTable(string tableName, List<string> columns)
        {
            try
            {
                // 检查表是否存在
                string checkSql = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = DATABASE() AND table_name = '{tableName}'";
                int count = _sql.Ado.GetInt(checkSql);

                if (count == 0)
                {
                    // 创建新表
                    var colDefs = new List<string> { "Id INT AUTO_INCREMENT PRIMARY KEY" };
                    foreach (var col in columns)
                        colDefs.Add($"`{col}` VARCHAR(500)");
                    colDefs.Add("`写入时间` VARCHAR(50)");

                    string createSql = $"CREATE TABLE `{tableName}` ({string.Join(", ", colDefs)}) ENGINE=InnoDB DEFAULT CHARSET=utf8";
                    _sql.Ado.ExecuteCommand(createSql);
                }
                else
                {
                    // 表已存在，补充缺失的列
                    foreach (var col in columns)
                    {
                        string colCheckSql = $"SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = '{tableName}' AND column_name = '{col}'";
                        int colCount = _sql.Ado.GetInt(colCheckSql);
                        if (colCount == 0)
                        {
                            string alterSql = $"ALTER TABLE `{tableName}` ADD COLUMN `{col}` VARCHAR(500)";
                            _sql.Ado.ExecuteCommand(alterSql);
                        }
                    }

                    // 确保 写入时间 列存在
                    string timeColCheck = $"SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = '{tableName}' AND column_name = '写入时间'";
                    int timeColCount = _sql.Ado.GetInt(timeColCheck);
                    if (timeColCount == 0)
                    {
                        _sql.Ado.ExecuteCommand($"ALTER TABLE `{tableName}` ADD COLUMN `写入时间` VARCHAR(50)");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"同步表 {tableName} 结构失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 动态插入OK条码记录（使用字典，每个 DbColumnName 作为独立列）
        /// </summary>
        public void InsertOK(Dictionary<string, object> values, string customTableName = null)
        {
            if (values == null || values.Count == 0) return;
            string tableName = customTableName ?? "OKTable";
            _sql.Insertable(values).AS(tableName).ExecuteCommand();
        }

        /// <summary>
        /// 动态插入NG条码记录
        /// </summary>
        public void InsertNG(Dictionary<string, object> values, string customTableName = null)
        {
            if (values == null || values.Count == 0) return;
            string tableName = customTableName ?? "NGTable";
            _sql.Insertable(values).AS(tableName).ExecuteCommand();
        }

        /// <summary>
        /// 获取数据库中所有表名
        /// </summary>
        public List<string> GetTableNames()
        {
            var names = new List<string>();
            try
            {
                string sql = "SELECT TABLE_NAME FROM information_schema.tables WHERE table_schema = DATABASE() AND table_type = 'BASE TABLE' ORDER BY TABLE_NAME";
                var dt = _sql.Ado.GetDataTable(sql);
                foreach (DataRow row in dt.Rows)
                    names.Add(row["TABLE_NAME"]?.ToString() ?? "");
            }
            catch { }
            return names;
        }

        /// <summary>
        /// 按主码精确查询OK表（走索引，加 LIMIT 防全量返回）
        /// </summary>
        /// <param name="mainCode">主码精确值</param>
        /// <param name="mainCodeColumn">主码对应的数据库列名</param>
        public DataTable QueryOkByMainCode(string mainCode, string mainCodeColumn, string tableName = null)
        {
            if (string.IsNullOrWhiteSpace(mainCodeColumn))
                mainCodeColumn = "KSZ码";
            string tbl = string.IsNullOrWhiteSpace(tableName) ? "OKTable" : tableName;

            string sql = $"SELECT * FROM `{tbl}` WHERE `{mainCodeColumn}` = @mainCode ORDER BY `写入时间` DESC LIMIT 500";
            var dt = _sql.Ado.GetDataTable(sql, new { mainCode });

            // 兼容旧数据列名"主码"（忽略列不存在的错误）
            if ((dt == null || dt.Rows.Count == 0) && mainCodeColumn == "KSZ码")
            {
                try
                {
                    string oldSql = $"SELECT * FROM `{tbl}` WHERE `主码` = @mainCode ORDER BY `写入时间` DESC LIMIT 500";
                    dt = _sql.Ado.GetDataTable(oldSql, new { mainCode });
                }
                catch { /* 旧列不存在，忽略 */ }
            }

            return dt;
        }

        /// <summary>
        /// 按主码精确查询NG表（走索引，加 LIMIT 防全量返回）
        /// </summary>
        /// <param name="mainCode">主码精确值</param>
        /// <param name="mainCodeColumn">主码对应的数据库列名</param>
        /// <param name="tableName">可选自定义表名</param>
        public DataTable QueryNgByMainCode(string mainCode, string mainCodeColumn, string tableName = null)
        {
            if (string.IsNullOrWhiteSpace(mainCodeColumn))
                mainCodeColumn = "KSZ码";
            string tbl = string.IsNullOrWhiteSpace(tableName) ? "NGTable" : tableName;

            string sql = $"SELECT * FROM `{tbl}` WHERE `{mainCodeColumn}` = @mainCode ORDER BY `写入时间` DESC LIMIT 500";
            var dt = _sql.Ado.GetDataTable(sql, new { mainCode });
            return dt;
        }

        /// <summary>
        /// 全库查询：在所有表中搜索指定KSZ码
        /// </summary>
        public DataTable QueryAllTablesByMainCode(string mainCode, string mainCodeColumn,
            Dictionary<string, string> tableFriendlyNames = null)
        {
            if (string.IsNullOrWhiteSpace(mainCodeColumn))
                mainCodeColumn = "KSZ码";

            var result = new DataTable();
            result.Columns.Add("来源表", typeof(string));

            try
            {
                // 获取数据库中所有表名
                string showTablesSql = "SELECT TABLE_NAME FROM information_schema.tables WHERE table_schema = DATABASE() AND table_type = 'BASE TABLE'";
                var tablesDt = _sql.Ado.GetDataTable(showTablesSql);

                bool first = true;
                foreach (DataRow row in tablesDt.Rows)
                {
                    string tableName = row["TABLE_NAME"]?.ToString();
                    if (string.IsNullOrWhiteSpace(tableName)) continue;

                    // 检查表是否有主码列
                    string colCheckSql = $"SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = @tbl AND column_name = @col";
                    int colCount = _sql.Ado.GetInt(colCheckSql, new { tbl = tableName, col = mainCodeColumn });
                    if (colCount == 0) continue;

                    // 友好名称
                    string friendlyName = tableName;
                    if (tableFriendlyNames != null && tableFriendlyNames.TryGetValue(tableName, out string fn))
                        friendlyName = fn;

                    string sql = $"SELECT *, '{friendlyName}' AS 来源表 FROM `{tableName}` WHERE `{mainCodeColumn}` = @mainCode ORDER BY `写入时间` DESC LIMIT 200";
                    var dt = _sql.Ado.GetDataTable(sql, new { mainCode });

                    if (first)
                    {
                        result = dt;
                        first = false;
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        result.Merge(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("全库查询失败: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 按时间范围导出指定表数据
        /// </summary>
        public DataTable ExportTableByDateRange(string tableName, DateTime from, DateTime to)
        {
            string tbl = string.IsNullOrWhiteSpace(tableName) ? "OKTable" : tableName;
            string sql = $"SELECT * FROM `{tbl}` WHERE `写入时间` >= @from AND `写入时间` <= @to ORDER BY `写入时间` DESC LIMIT 5000";
            var dt = _sql.Ado.GetDataTable(sql, new { from = from.ToString("yyyy-MM-dd HH:mm:ss"), to = to.ToString("yyyy-MM-dd 23:59:59") });
            return dt;
        }

        #endregion

    }







}
