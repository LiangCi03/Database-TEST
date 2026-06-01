
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.ModBus;
using HslCommunication.Profinet.Inovance;
using CommonUI.Communication;
using HslCommunication.Profinet;

using System.Threading;

using System.Xml.Linq;
using HslCommunication.BasicFramework;
using System.Windows.Forms;

namespace CommonUI.Communication
{

    public class Network_ModbusTcpH5U : IPlcCommunicationBase
    {

        //  private InovanceTcpNet inovanceH3UTcp = null;
        private InovanceH5UTcp inovanceH5UTcp = null;


        public enum DataFormat
        {
            ABCD,
            BADC,
            CDAB,
            DCBA

        }


        public override bool Connect()
        {
            throw new NotImplementedException();


            // inovanceH5UTcp?.ConnectClose();
            // inovanceH5UTcp = new InovanceH5UTcp(ipAddress, port, station)
            // inovanceH5UTcp.AddressStartWithZero = checkBox1.Checked;
            //// inovanceH5UTcp.Series = (InovanceSeries)comboBox4.SelectedItem;

            // ComboBox1_SelectedIndexChanged(null, new EventArgs());  // 设置数据服务
            // inovanceH5UTcp.IsStringReverse = checkBox3.Checked;
            // inovanceH5UTcp.LogNet = LogNet;
        }


        public bool Connect(string ipAddress, DataFormat dataFormat, int port = 502, byte station = 1, bool isStringReverse = false)
        {
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

            inovanceH5UTcp?.ConnectClose();
            inovanceH5UTcp = new InovanceH5UTcp(ipAddress, port, station);
            inovanceH5UTcp.AddressStartWithZero = true;


            switch (dataFormat.ToString())
            {
                case "ABCD": inovanceH5UTcp.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
                case "BADC": inovanceH5UTcp.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                case "CDAB": inovanceH5UTcp.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                case "DCBA": inovanceH5UTcp.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                default: break;
            }



            inovanceH5UTcp.IsStringReverse = isStringReverse;

            try
            {
                OperateResult connect = inovanceH5UTcp.ConnectServer();
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
                    //MessageBox.Show(HslCommunication.StringResources.Language.ConnectedFailed);
                    return false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }

        public override void DisConnect()
        {
            inovanceH5UTcp.ConnectClose();
            //  throw new NotImplementedException();
        }

        public override bool GetState()
        {
            throw new NotImplementedException();
        }
        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int16> operateResult = inovanceH5UTcp.ReadInt16(tempAddress);
            return operateResult.Content;
        }
        public override bool ReadCoilBit(string AddressTypeName, uint address)
        {
            OperateResult<bool> operateResult = inovanceH5UTcp.ReadCoil(AddressTypeName + address.ToString());
            return operateResult.Content;
        }

        public  string  ReadStr(string AddressTypeName, uint address,ushort  length)
        {
            OperateResult<string> operateResult = inovanceH5UTcp.ReadString(AddressTypeName + address.ToString(), 5, Encoding.ASCII         );
            return operateResult.Content;
        }
        public bool[] ReadCoilBit(string AddressTypeName, uint address, ushort count)
        {
            OperateResult<bool[]> operateResult = inovanceH5UTcp.ReadCoil(AddressTypeName + address.ToString(), count);
            return operateResult.Content;
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
            OperateResult<float> operateResult = inovanceH5UTcp.ReadFloat(AddressTypeName + address.ToString());
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
        //public  int ReadRegisterInt16(string AddressTypeName, uint address)
        //{
        //    OperateResult<Int16> operateResult = inovanceH5UTcp.ReadInt16(AddressTypeName + address.ToString());
        //    return operateResult.Content;
        //}

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
            throw new NotImplementedException();
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
             OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool WriterStr(string AddressTypeName, uint address, string value,ushort length)
        {
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value, length);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool WriterStr(string AddressTypeName, uint address, string value)
        {
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value,Encoding.ASCII );
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool WriterCoilBitArr(string AddressTypeName, uint[] address, bool[] valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterdouble(string AddressTypeName, uint address, double value)
        {
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool WriterRegisterdoubleArr(string AddressTypeName, uint[] addressArr, double valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterfloat(string AddressTypeName, uint address, float value)
        {
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName+address.ToString(), value);
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
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool WriterRegisterInt16(string AddressTypeName, uint address, short   value)
        {
            OperateResult operateResult = inovanceH5UTcp.Write(AddressTypeName + address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            throw new NotImplementedException();
        }

        public override bool WriterRegisterShortArr(string AddressTypeName, uint address, short[] valueArr)
        {
            throw new NotImplementedException();
        }
    }
}
