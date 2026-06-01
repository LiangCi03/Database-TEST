using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Omron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CommonUI.Communication
{
    public class Network_OmronFinsTcp : IPlcCommunicationBase
    {

        private OmronFinsNet omronFinsNet = new OmronFinsNet(); 
       
        public ILogNet LogNet { get; set; }

        public override bool Connect()
        {
            throw new NotImplementedException();
        }

        public bool Connect(string ip, int port)
        {

            //omronFinsNet = new OmronFinsNet();
            omronFinsNet.ConnectTimeOut = 4000;
            //if (!int.TryParse(textBox2.Text, out int port))
            //{
            //    MessageBox.Show(DemoUtils.PortInputWrong);
            //    return;
            //}

            //if (!byte.TryParse(textBox16.Text, out byte DA2))
            //{
            //    MessageBox.Show("PLC DA2 input wrong！");
            //    return;
            //}

            Thread.Sleep(1000);

            bool flag = false;
            try
            {
              
                omronFinsNet.IpAddress = ip;
                omronFinsNet.Port = port;
                omronFinsNet.DA2 = 0;
                omronFinsNet.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB   ;             
               omronFinsNet.SA1 = 192;
                omronFinsNet.LogNet = LogNet;
                omronFinsNet.ConnectClose();

                OperateResult connect = omronFinsNet.ConnectServer();

                if (connect.IsSuccess)
                {
                   // MessageBox.Show(StringResources.Language.ConnectedSuccess);
                    flag = true;


                }
                else
                {
                    flag = false;
                    MessageBox.Show(StringResources.Language.ConnectedFailed + " " + connect.ToMessageShowString());
                }

                return flag;
            }
            catch (Exception ex)
            {

                return flag;
            }
           


        }

        public override void DisConnect()
        {
            // 断开连接
            omronFinsNet.ConnectClose();
        }

        public override bool GetState()
        {
            throw new NotImplementedException();
        }

        public override bool ReadCoilBit(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }
        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int16> operateResult = omronFinsNet.ReadInt16(tempAddress);
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
            string addressData = AddressTypeName + address.ToString();
            float data = omronFinsNet.ReadFloat(addressData).Content;
            return data;
        }

        public override float ReadRegisterfloatArr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override int ReadRegisterInt32(string AddressTypeName, uint address)
        {
            string addressData = AddressTypeName + address.ToString();
            int data = omronFinsNet.ReadInt32(addressData).Content;
            return data;
        }

        public override int[] ReadRegisterInt32Arr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override long ReadRegisterInt64(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();


        }

        public ulong ReadRegisterULong(string AddressTypeName, uint address)
        {

            string addressData = AddressTypeName + address.ToString();
            ulong ulong_D100 = omronFinsNet.ReadUInt64(addressData).Content;
            return ulong_D100;

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

            string addressData = AddressTypeName + address;
            OperateResult operateResult = omronFinsNet.Write(addressData, value);
            return operateResult.IsSuccess;

           
        }

        public override bool WriterRegisterfloatArr(string AddressTypeName, uint[] addressArr, float[] valueArr)
        {

            throw new NotImplementedException();

        }

        public  bool WriterRegisterfloatArr(string AddressTypeName, uint address, float[] valueArr)
        {
            string addressData = AddressTypeName + address;
            OperateResult operateResult = omronFinsNet.Write(AddressTypeName, valueArr);
            return operateResult.IsSuccess;

        }

        public  bool WriterRegisterInt16(string AddressTypeName, uint address, Int16  value)
        {

            string addressData = AddressTypeName + address;
            OperateResult operateResult = omronFinsNet.Write(addressData, value);
            return operateResult.IsSuccess;


        }



        public override bool WriterRegisterInt32(string AddressTypeName, uint address, int value)
        {
           
            string addressData = AddressTypeName + address;
            OperateResult operateResult= omronFinsNet.Write(addressData, value);
            return operateResult.IsSuccess;


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
        /// 写入无符号长整形
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriterRegisterULong(string AddressTypeName, uint address, ulong value)
        {

            string addressData = AddressTypeName + address;
            OperateResult operateResult = omronFinsNet.Write(addressData, value);
            return operateResult.IsSuccess;

        }
        public override bool WriterRegisterShort(string AddressTypeName, uint address, short value)
        {
            throw new NotImplementedException();
        }

        public override bool WriterRegisterShortArr(string AddressTypeName, uint address, short[] valueArr)
        {
            throw new NotImplementedException();
        }

        //public  int ReadRegisterInt16(string AddressTypeName, uint address)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
