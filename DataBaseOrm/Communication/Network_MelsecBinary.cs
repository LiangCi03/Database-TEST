using HslCommunication;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace CommonUI.Communication
{
    public class Network_MelsecBinary : IPlcCommunicationBase
    {


        public MelsecMcNet melsec_net = null;
        public bool Connect(string ip, int port)
        {
            melsec_net = new MelsecMcNet();
            melsec_net.IpAddress = ip;
            melsec_net.Port = port;
            melsec_net.ConnectClose();

            try
            {
                OperateResult connect = melsec_net.ConnectServer();
                if (connect.IsSuccess)
                {
                    //MessageBox.Show(HslCommunication.StringResources.Language.ConnectedSuccess);
                }
                else
                {
                    MessageBox.Show(HslCommunication.StringResources.Language.ConnectedFailed);
                }
                return true;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                return false;
            }

        }

        public float[] ReadManyfloat(string address, UInt16 dataLength)
        {

            float[] resultArr = new float[dataLength];
            try
            {
                OperateResult<float[]> operateResult = melsec_net.ReadFloat(address, dataLength);
                if (operateResult.IsSuccess)
                {
                    resultArr = operateResult.Content;
                }
                else
                {
                    MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Failed：" + ex.Message);
            }
            return resultArr;

        }


        public override void DisConnect()
        {
            melsec_net.ConnectClose();

        }

        public override bool GetState()
        {
            throw new NotImplementedException();
        }

        public override void SetDataBaseTypeAddresss(ulong addressBase, string dataTypeName)
        {
            throw new NotImplementedException();
        }

        public override void SetStation(ushort station)
        {
            throw new NotImplementedException();
        }

        public override void SetDelayTime(ushort delayTime)
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
        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int16> operateResult = melsec_net.ReadInt16(tempAddress);
            return operateResult.Content;
        }
        public override bool ReadCoilBit(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override bool ReadCoilBitArr(string AddressTypeName, uint[] address)
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

        public override int ReadRegisterInt32(string AddressTypeName, uint address)
        {
            OperateResult<Int32> operateResult = melsec_net.ReadInt32(address.ToString());
            return operateResult.Content;
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

        public override float ReadRegisterfloat(string AddressTypeName, uint address)
        {
            OperateResult<float> operateResult = melsec_net.ReadFloat(AddressTypeName.ToString()+address.ToString());
            return operateResult.Content;
        }

        public override float ReadRegisterfloatArr(string AddressTypeName, uint[] addressArr)
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

        public override bool WriterCoilBit(string AddressTypeName, uint address, bool value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterCoilBitArr(string AddressTypeName, uint[] address, bool[] valueArr)
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

        /// <summary>
        /// 写入整形数据
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool WriterRegisterInt32(string AddressTypeName, uint address, int value)
        {

            OperateResult operateResult = melsec_net.Write(address.ToString(), value);
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

        /// <summary>
        /// 写入浮点型数据
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool WriterRegisterfloat(string AddressTypeName, uint address, float value)
        {
            OperateResult operateResult = melsec_net.Write(AddressTypeName.ToString()+address.ToString(), value);
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

        public override bool WriterRegisterdouble(string AddressTypeName, uint address, double value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterdoubleArr(string AddressTypeName, uint[] addressArr, double valueArr)
        {
            throw new NotImplementedException();
        }

        public override bool Connect()
        {
            throw new NotImplementedException();
        }
    }
}
