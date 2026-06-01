using CommonUI.Config;
using ScrewMotion;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOrm.Screw
{
    public class ScrewMT
    {
        public bool Connect(SerialConfig serialConfig)
        {
            //if (button1.Text == "连接" && comboBoxPort.Text != "")
            //{


            SerialPort port = new SerialPort();
            port.PortName = serialConfig.PortName;
            port.BaudRate = Convert.ToInt16(serialConfig.BaudRate);
            port.DataBits = Convert.ToInt16(serialConfig.DataBits);
            port.StopBits = serialConfig.GetSerialPortStopBits(serialConfig.StopBits);
            port.Parity = serialConfig.GetSerialPortParity(serialConfig.Paritys);
            try
            {
                CardNet.IntializeComm(port);
                if (CardNet.NetSucceed)
                {
                    //pictureBoxColor.BackColor = Color.Green;
                    //button1.Text = "断开";

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            //}
            //else
            //{
            //    try
            //    {
            //        CardNet.Disposed();
            //        pictureBoxColor.BackColor = Color.Red;
            //        button1.Text = "连接";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }


        public  string Read()
        {

            string 扭矩值 = ReadData.GetParamater(ReadEnum.FarceValue).ToString("f3") + "mN.m";
            return 扭矩值;

        }


    }
}
