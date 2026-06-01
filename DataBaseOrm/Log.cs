using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using DataBaseOrm;

namespace CommonUI.DataOperate
{
    /// <summary>
    /// 软件运行等级信息记录
    /// </summary>
    public enum InfoLevel
    {
        [Description("调试信息")]
        DEBUG,
        [Description("正常信息")]
        INFO,
        [Description("警告信息")]
        WARN,
        [Description("错误信息")]
        ERROR,
        [Description("严重错误信息")]
        FATAL
    }


    public class Log
    {
        public static string logPath = GlobalsVar._commonParamsPath + "日志文件\\";
        private static object _lock = new object();
        public static  event Action<string> ERRORChangedEventHandler;

        /// <summary>
        /// 自定义Log名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="infoLevel"></param>
        /// <param name="text"></param>
        public static void WriteLog(string fileName, InfoLevel infoLevel, string text)
        {

            System.IO.StreamWriter sw = null;
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            string fileFullFileName =   fileName + DateTime.Now.ToString("yyyyMMdd") + ".Log";
            lock (_lock)
            {
                using (sw = System.IO.File.AppendText(fileFullFileName))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:  ") +":"+ infoLevel.ToString()+":"+text);
                    //程序运行Info达到错误以上类型时，需要通过事件监控
                    if ((int)infoLevel > 3)
                    {
                        ERRORChangedEventHandler(text);

                    }
                }
            }
        }

        /// <summary>
        /// Log名称为日期
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="infoLevel"></param>
        /// <param name="text"></param>
        public static void WriteLog( InfoLevel infoLevel, string text)
        {

            System.IO.StreamWriter sw = null;
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string fileFullFileName = logPath  + DateTime.Now.ToString("yyyyMMdd") + ".Log";
            lock (_lock)
            {
                using (sw = System.IO.File.AppendText(fileFullFileName))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:  ") + ":" + infoLevel.ToString() + ":" + text);
                    //程序运行Info达到错误以上类型时，需要通过事件监控
                    if ((int)infoLevel > 3)
                    {
                        ERRORChangedEventHandler(text);

                    }
                }
            }
        }
    }
}
