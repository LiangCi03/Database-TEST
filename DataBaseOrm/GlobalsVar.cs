using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOrm
{
    public class GlobalsVar
    {
        public static readonly string _commonParamsPath = Application.StartupPath + @"\配置文件\";
        public static readonly string _picturePath = Application.StartupPath + @"\显示图片\";

        //RFID list集合
        public static List<string> rfidList = new List<string>();

        //打印机参数
        //速度

        /// <summary>
        /// 标签高度
        /// </summary>
        public static float _lableHight = 0;
        /// <summary>
        /// 标签宽度
        /// </summary>
        public static float _lableWidth = 0;
        /// <summary>
        /// 标签间隙
        /// </summary>
        public static float _lableGap = 0;
        /// <summary>
        /// 打印浓度
        /// </summary>
        public static int _PrintDepth = 0;
        /// <summary>
        /// 切刀设置
        /// </summary>
        public static int _labelDao = 0;

        /// <summary>
        /// 打印速度
        /// </summary>
        public static string _speedPrint = string.Empty;

        /// <summary>
        /// 打印模式
        /// </summary>
        public static string _printMethod = string.Empty;

        /// <summary>
        /// 传感器类型
        /// </summary>
        public static string _sensor = string.Empty;
        /// <summary>
        /// 走纸模式
        /// </summary>
        public static string _printMoshi = string.Empty;

        /// <summary>
        /// 打印方向
        /// </summary>
        public static string _printDirection = string.Empty;

        /// <summary>
        /// 安装位置
        /// </summary>
        public static string _strInstallPosition = string.Empty;

        public static string _strPartNumber = string.Empty;    //SUK 目前有194,197,198 3个
        public static string _strPartSKU = string.Empty;  //基本固定，但是客户可能变更
        public static string _strCountry = string.Empty; //基本固定
        public static string _strCountryCode = string.Empty; //基本固定


        /// <summary>
        /// 序列号
        /// </summary>
        public static string _strBarcode = string.Empty; //序列号

        /// <summary>
        /// 序列号前两位RW
        /// </summary>
        public static string _strBarcodeFront = string.Empty; //序列号

        /// <summary>
        /// 制造商线体
        /// </summary>
        public static string _line = string.Empty;

        /// <summary>
        /// 质量代号
        /// </summary>
        public static string _qualityCode = string.Empty;

        public struct StatusInfo
        {
            public string info;
            public bool IsSuccess;
            public int ErrorCode;

        }

        public struct StatusInfo<T>
        {
            public string info;
            public bool IsSuccess;
            public T Datatype;
            public int ErrorCode;
        }


        public enum LoginLevel
        {
            Operator,
            Administrator,
            Manufacturer
        }

        public class VppParamsDataTable
        {
            public DataTable dataTable;
          //  public VisionInputParam visionInputParam;
            public string path;
        }
    }
}
