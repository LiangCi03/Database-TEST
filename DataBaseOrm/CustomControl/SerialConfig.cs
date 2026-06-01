using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static CommonUI.Config.EthernetConfig;
using static DataBaseOrm.GlobalsVar;

namespace CommonUI.Config
{
    public sealed class SerialConfig
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string PortName { set; get; }

        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate { set; get; }

        /// <summary>
        /// 数据位
        /// </summary>
        public string DataBits { set; get; }

        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBits { set; get; }

        /// <summary>
        /// 校验位
        /// </summary>
        public string Paritys { set; get; }

  
        /// <summary>
        /// 保存串口配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StatusInfo SaveConfig(string path)
        {
            StatusInfo statusInfo = new StatusInfo();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerialConfig));
                StreamWriter streamWriter = new StreamWriter(path);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                statusInfo.IsSuccess = true;
            }
            catch (Exception ex)
            {

                statusInfo.IsSuccess = false;
                statusInfo.info = ex.Source.ToString();

            }
            return statusInfo;

        }


        /// <summary>
        /// 读取串口配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StatusInfo ReadConfig(string path)
        {

            StatusInfo statusInfo = new StatusInfo();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerialConfig));
                StreamReader streamReader = new StreamReader(path);
                SerialConfig _serialConfig = xmlSerializer.Deserialize(streamReader) as SerialConfig;
                PortName = _serialConfig.PortName;
                BaudRate = _serialConfig.BaudRate;
                DataBits = _serialConfig.DataBits;
                StopBits = _serialConfig.StopBits;
                Paritys = _serialConfig.Paritys;
                streamReader.Close();
                statusInfo.IsSuccess = true;
            }
            catch (Exception ex)
            {
                statusInfo.IsSuccess = false;
                statusInfo.info = ex.Source.ToString();
            }
            return statusInfo;
        }


        public  System.IO.Ports.Parity GetSerialPortParity(string parity)
        {
            switch (parity)
            {
                case "无":
                    return System.IO.Ports.Parity.None;
                case "奇":
                    return System.IO.Ports.Parity.Odd;
                case "偶":
                    return System.IO.Ports.Parity.Even;
                case "Mark":
                    return System.IO.Ports.Parity.Mark ;
                case "Space":
                    return System.IO.Ports.Parity.Space ;
                default:
                    return System.IO.Ports.Parity.None;
            }

           
        }

        public System.IO.Ports.StopBits GetSerialPortStopBits(string stopBits)
        {
            switch (stopBits)
            {
                case "无":
                    return System.IO.Ports.StopBits.None;
                case "1":
                    return System.IO.Ports.StopBits.One;
                case "1.5":
                    return System.IO.Ports.StopBits.OnePointFive;
                case "2":
                    return System.IO.Ports.StopBits.Two;

                default:
                    return System.IO.Ports.StopBits.None;
            }


        }



    }




}
