using HslCommunication;
using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonUI.Communication
{
    public class Network_ModbusTcp : IPlcCommunicationBase
    {
        private ModbusTcpNet busTcpClient = null;
      
        public enum DataFormat
        {
            ABCD,
            BADC,
            CDAB,
            DCBA

        }

        public bool Connect(string ipAddress, DataFormat dataFormat)
        {

            int port = 502;
            byte station = 1;
            bool isStringReverse = false;
            // 连接
            //if (!System.Net.IPAddress.TryParse(textBox1.Text, out System.Net.IPAddress address))
            //{
            //    MessageBox.Show(DemoUtils.IpAddressInputWrong);
            //    return;
            //}


            //if (!int.TryParse(textBox2.Text, out int port))
            //{
            //    MessageBox.Show(DemoUtils.PortInputWrong);
            //    return;
            //}


            //if (!byte.TryParse(textBox15.Text, out byte station))
            //{
            //    MessageBox.Show("Station input is wrong！");
            //    return;
            //}

            busTcpClient?.ConnectClose();
            busTcpClient = new ModbusTcpNet(ipAddress, port, station);
            busTcpClient.AddressStartWithZero = true;

            switch (dataFormat.ToString())
            {
                case "ABCD": busTcpClient.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
                case "BADC": busTcpClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                case "CDAB": busTcpClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                case "DCBA": busTcpClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                default: break;
            }



            busTcpClient.IsStringReverse = isStringReverse;

            try
            {
                OperateResult connect = busTcpClient.ConnectServer();
                if (connect.IsSuccess)
                {
                    // MessageBox.Show(HslCommunication.StringResources.Language.ConnectedSuccess);
                    //button2.Enabled = true;
                    //button1.Enabled = false;
                    //panel2.Enabled = true;
                    //userControlCurve1.ReadWriteNet = busTcpClient;
                    return true;
                }
                else
                {
                    MessageBox.Show(HslCommunication.StringResources.Language.ConnectedFailed);
                    return false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }

        /// <summary>
        /// 勿用
        /// </summary>
        /// <returns></returns>
        public override bool Connect()
        {
            throw new NotImplementedException();
        }





        public override void DisConnect()
        {
            // 断开连接
            busTcpClient.ConnectClose();

        }

        public override bool GetState()
        {
            throw new NotImplementedException();
        }

        public override bool ReadCoilBit(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override bool ReadCoilBitArr(string AddressTypeName, uint[] address)
        {
            throw new NotImplementedException();
        }

        public override bool ReadInputBit(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override bool[] ReadInputBitArr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override double ReadRegisterdouble(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override double ReadRegisterdoubleArr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override float ReadRegisterfloat(string AddressTypeName, uint address)
        {

            OperateResult<float> operateResult = busTcpClient.ReadFloat(address.ToString());
            return operateResult.Content;

        }

        public override float ReadRegisterfloatArr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override int ReadRegisterInt32(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override int[] ReadRegisterInt32Arr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override long ReadRegisterInt64(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override long[] ReadRegisterInt64Arr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override short ReadRegisterShort(string AddressTypeName, uint address)
        {
           
            OperateResult<short> operateResult = busTcpClient.ReadInt16(address.ToString());
            return operateResult.Content;

        }

        public string readRfid(string str)
        {
            OperateResult<byte[]> read = busTcpClient.ReadFromCoreServer(HslCommunication.Serial.SoftCRC16.CRC16(HslCommunication.BasicFramework.SoftBasic.HexStringToBytes(str)));
            if (read.IsSuccess)
            {
                string info = HslCommunication.BasicFramework.SoftBasic.ByteToHexString(read.Content);
                return info;
            }
            else
            {
                MessageBox.Show("Read Failed：" + read.ToMessageShowString());
                return "";
            }
        }
        public override short[] ReadRegisterShortArr(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override void SetDataBaseTypeAddresss(ulong addressBase, string dataTypeName)
        {
            throw new NotImplementedException();
        }

        public override void SetDelayTime(ushort delayTime)
        {
            throw new NotImplementedException();
        }

        public override void SetStation(ushort station)
        {
            throw new NotImplementedException();
        }

        public override bool WriterCoilBit(string AddressTypeName, uint address, bool value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterCoilBitArr(string AddressTypeName, uint[] address, bool[] valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterdouble(string AddressTypeName, uint address, double value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterdoubleArr(string AddressTypeName, uint[] addressArr, double valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterfloat(string AddressTypeName, uint address, float value)
        {

         
            OperateResult operateResult = busTcpClient.Write(address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool WriterRegisterfloatArr(string AddressTypeName, uint[] addressArr, float[] valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterInt32(string AddressTypeName, uint address, int value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterInt32Arr(string AddressTypeName, uint[] addressArr, int[] valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterInt64(string AddressTypeName, uint address, long value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterInt64Arr(string AddressTypeName, uint[] addressArr, long valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterShort(string AddressTypeName, uint address, short value)
        {

            OperateResult operateResult = busTcpClient.Write(address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool WriterRegisterShortArr(string AddressTypeName, uint address, short[] valueArr)
        {
            throw new NotImplementedException();
        }
        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int16> operateResult = busTcpClient.ReadInt16(tempAddress);
            return operateResult.Content;
        }
        
    }
}
