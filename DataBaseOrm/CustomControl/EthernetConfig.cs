using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static DataBaseOrm.GlobalsVar;

namespace CommonUI.Config
{
    public sealed class EthernetConfig
    {


        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { set; get; }

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port { set; get; }

        /// <summary>
        /// 保存网口配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StatusInfo SaveConfig(string path)
        {
            StatusInfo statusInfo = new StatusInfo();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(EthernetConfig));
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
        /// 读取网口配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StatusInfo ReadConfig(string path)
        {

            StatusInfo statusInfo = new StatusInfo();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(EthernetConfig));
                StreamReader streamReader = new StreamReader(path);
                EthernetConfig _ethernetConfig = xmlSerializer.Deserialize(streamReader) as EthernetConfig;
                IP = _ethernetConfig.IP;
                Port = _ethernetConfig.Port;             
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



    }
}
