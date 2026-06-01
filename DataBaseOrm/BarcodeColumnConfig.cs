using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOrm
{
    /// <summary>
    /// 单个字段的配置：定义从PLC读取什么、怎么读、存到哪
    /// </summary>
    public class BarcodeColumnConfig
    {
        /// <summary>
        /// 读取内容描述（如"压力最大"）
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// PLC地址（如 "DB100.0"）
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 数据类型：STRING / INT16 / REAL / BYTE
        /// </summary>
        public string DataType { get; set; } = "STRING";

        /// <summary>
        /// 存入数据库的列名
        /// </summary>
        public string DbColumnName { get; set; } = string.Empty;
    }

    /// <summary>
    /// 一个码组（主码 或 副码1~4）的完整配置
    /// </summary>
    public class CodeGroupConfig
    {
        /// <summary>
        /// 组名：主码 / 副码1 / 副码2 / 副码3 / 副码4
        /// </summary>
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// 该组下的所有字段配置列表
        /// </summary>
        public List<BarcodeColumnConfig> Columns { get; set; } = new List<BarcodeColumnConfig>();
    }

    /// <summary>
    /// 整个程序的条码列配置（顶层结构，序列化为JSON）
    /// </summary>
    public class BarcodeConfig
    {
        /// <summary>
        /// 5个码组的配置
        /// </summary>
        public List<CodeGroupConfig> Groups { get; set; } = new List<CodeGroupConfig>();
    }

    /// <summary>
    /// 单个产品的完整配置（允许读取地址 + 码状态地址 + 条码列配置）
    /// </summary>
    public class ProductConfig
    {
        /// <summary>
        /// 产品名称（如"产品1"）
        /// </summary>
        public string ProductName { get; set; } = "产品1";

        /// <summary>
        /// 允许读取的PLC地址（=1时读取条码数据）
        /// </summary>
        public string EnableReadAddress { get; set; } = "DB18.80";

        /// <summary>
        /// 码状态PLC地址（1=OK, 2=NG）
        /// </summary>
        public string CodeStatusAddress { get; set; } = "DB18.82";

        /// <summary>
        /// OK数据库表名
        /// </summary>
        public string OkTableName { get; set; } = "OKTable";

        /// <summary>
        /// NG数据库表名
        /// </summary>
        public string NgTableName { get; set; } = "NGTable";

        /// <summary>
        /// 该产品的条码列配置
        /// </summary>
        public BarcodeConfig BarcodeConfig { get; set; } = new BarcodeConfig();
    }

    /// <summary>
    /// 多产品配置根（序列化为JSON）
    /// </summary>
    public class MultiProductConfig
    {
        /// <summary>
        /// 心跳地址（所有产品共用）
        /// </summary>
        public string HeartbeatAddress { get; set; } = "DB18.78";

        /// <summary>
        /// 产品列表（支持1~3个产品）
        /// </summary>
        public List<ProductConfig> Products { get; set; } = new List<ProductConfig>();
    }
}
