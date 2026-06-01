using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOrm
{

    [SugarTable("table1")]//当和数据库名称不一样可以设置表别名 指定表明
    public  class DatabaseType
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
        public int Id { get; set; }

        public string SN { get; set; }

        public string 水壶气密性 { get; set; }

        public string 电机电压值 { get; set; }

        public string 电机1电流值{ get; set; }

        public string 电机2电流值 { get; set; }


        public string 电机3电流值 { get; set; }

        public string 二维码结果 { get; set; }

        public string RFID结果 { get; set; }

        public string 水壶气密值结果 { get; set; }

        public string 电机电压值结果 { get; set; }

        public string 电机1电流值结果 { get; set; }

        public string 电机2电流值结果 { get; set; }

        public string 电机3电流值结果 { get; set; }

        public string 相机结果 { get; set; }


        public string 日期 { get; set; }

        public string 完成时间 { get; set; }


    }

    /// <summary>
    /// OK条码记录 - 动态列模式（不再使用 SugarTable/SugarColumn 固定列）
    /// 实际写入时使用 Dictionary&lt;string, object&gt;，每个 DbColumnName 作为一个独立列
    /// </summary>
    public class BarcodeOKRecord
    {
        /// <summary>
        /// 所有字段的值，key = DbColumnName（如 "主码", "副码1压力" 等）
        /// </summary>
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();

        public string 写入时间 { get; set; }

        /// <summary>
        /// 获取指定字段的值
        /// </summary>
        public string GetValue(string dbColumnName)
        {
            return Fields.TryGetValue(dbColumnName, out string val) ? val : null;
        }

        /// <summary>
        /// 设置指定字段的值
        /// </summary>
        public void SetValue(string dbColumnName, string value)
        {
            Fields[dbColumnName] = value;
        }

        /// <summary>
        /// 转换为写入数据库用的 Dictionary
        /// </summary>
        public Dictionary<string, object> ToDbDictionary()
        {
            var dict = new Dictionary<string, object>();
            foreach (var kvp in Fields)
                dict[kvp.Key] = kvp.Value ?? "";
            dict["写入时间"] = 写入时间 ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dict;
        }
    }

    /// <summary>
    /// NG条码记录 - 动态列模式（同 OK 记录）
    /// </summary>
    public class BarcodeNGRecord
    {
        /// <summary>
        /// 所有字段的值，key = DbColumnName
        /// </summary>
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();

        public string 写入时间 { get; set; }

        public string GetValue(string dbColumnName)
        {
            return Fields.TryGetValue(dbColumnName, out string val) ? val : null;
        }

        public void SetValue(string dbColumnName, string value)
        {
            Fields[dbColumnName] = value;
        }

        public Dictionary<string, object> ToDbDictionary()
        {
            var dict = new Dictionary<string, object>();
            foreach (var kvp in Fields)
                dict[kvp.Key] = kvp.Value ?? "";
            dict["写入时间"] = 写入时间 ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dict;
        }
    }
}
