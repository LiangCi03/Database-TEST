using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DataBaseOrm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 防止程序重复运行
            using (Mutex mutex = new Mutex(true, "DataBaseOrm_SingleInstance", out bool createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("程序已在运行中，请勿重复启动。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmDatabase());
            }
        }
    }
}
