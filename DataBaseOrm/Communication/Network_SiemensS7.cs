using HslCommunication;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace CommonUI.Communication
{
    public class Network_SiemensS7:IPlcCommunicationBase
    {
      
       // private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1500;
        private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200 ;
        private SiemensS7Net siemensTcpNet;

        public   bool Connect(string ip, int port)
        {
            siemensPLCSelected = SiemensPLCS.S1200;
            siemensTcpNet = new SiemensS7Net(siemensPLCSelected);

            siemensTcpNet.IpAddress = ip;
            try
            {

                OperateResult connect = siemensTcpNet.ConnectServer();
                if (connect.IsSuccess)
                {
                    return true;
                }
                else
                {
                    // 不弹窗，由调用方记录日志
                    return false;
                }

            }
            catch (Exception ex)
            {
                // 不弹窗，由调用方记录日志
                System.Diagnostics.Debug.WriteLine("PLC连接异常: " + ex.Message);
                return false;
            }
        }

       

        private  float Readfloat(string address)
        {
            OperateResult<float> operateResult = siemensTcpNet.ReadFloat(address);
            return operateResult.Content;
        }

        public bool Writefloat(string address, string value)
        {
            OperateResult operateResult = siemensTcpNet.Write(address, float.Parse(value));
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public byte Readbyte(string address)
        {
            OperateResult<byte> operateResult = siemensTcpNet.ReadByte(address);
            if (!operateResult.IsSuccess)
                throw new Exception("ReadByte [" + address + "] 失败: " + operateResult.Message);
            return operateResult.Content;
        }

        public bool Writebyte(string address, string value)
        {
            OperateResult operateResult = siemensTcpNet.Write(address, byte.Parse(value));
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 向西门子PLC写入字符串
        /// </summary>
        public bool WriteString(string address, string value)
        {
            OperateResult operateResult = siemensTcpNet.Write(address, value);
            if (operateResult.IsSuccess)
                return true;
            else
                return false;
        }

        public float[] ReadManyfloat(string address, UInt16 dataLength)
        {

            float[] resultArr = new float[dataLength];
            try
            {
                OperateResult<float[]> operateResult = siemensTcpNet.ReadFloat(address, dataLength);
                if (operateResult.IsSuccess)
                {
                    resultArr = operateResult.Content;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReadManyFloat 失败: " + ex.Message);
            }
            return resultArr;

        }

        public override bool Connect()
        {
            string ip = string.Empty;
            siemensPLCSelected = SiemensPLCS.S1500;
            siemensTcpNet = new SiemensS7Net(siemensPLCSelected);

            siemensTcpNet.IpAddress = ip;
            try
            {

                OperateResult connect = siemensTcpNet.ConnectServer();
                if (connect.IsSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PLC连接异常: " + ex.Message);
                return false;
            }
        }

        public override void  DisConnect()
        {
            siemensTcpNet.ConnectClose();
            
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
            string tempAddress = AddressTypeName.ToString()+ address.ToString();
            OperateResult<Int16 > operateResult = siemensTcpNet.ReadInt16(tempAddress);
            return operateResult.Content;
        }

        public override short[] ReadRegisterShortArr(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }

        public override int ReadRegisterInt32(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int32> operateResult = siemensTcpNet.ReadInt32(tempAddress);
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
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<float> operateResult = siemensTcpNet.ReadFloat(tempAddress);
            if (!operateResult.IsSuccess)
                throw new Exception("ReadFloat [" + tempAddress + "] 失败: " + operateResult.Message);
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
            OperateResult operateResult = siemensTcpNet.Write(address.ToString(), value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool WriterRegisterInt16(string AddressTypeName, uint address, short value)
        {
            string tempAddress = AddressTypeName.ToString() +  "." + address.ToString();
            OperateResult operateResult = siemensTcpNet.Write(tempAddress, value);
            if (operateResult.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 向西门子PLC写入32位有符号整数（DWORD）
        /// </summary>
        public override bool WriterRegisterInt32(string AddressTypeName, uint address, int value)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult operateResult = siemensTcpNet.Write(tempAddress, value);
            if (operateResult.IsSuccess)
                return true;
            else
                return false;
        }

        

        public override bool WriterRegisterShortArr(string AddressTypeName, uint address, short[] valueArr)
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

        public override bool WriterRegisterfloat(string AddressTypeName, uint address, float value)
        {
            OperateResult operateResult = siemensTcpNet.Write(address.ToString(), value);
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

        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            string tempAddress = AddressTypeName.ToString() + "." + address.ToString();
            OperateResult<Int16> operateResult = siemensTcpNet.ReadInt16(tempAddress);
            if (!operateResult.IsSuccess)
                throw new Exception("ReadInt16 [" + tempAddress + "] 失败: " + operateResult.Message);
            return operateResult.Content;
        }

        /// <summary>
        /// 从西门子PLC读取字符串（使用HslCommunication的ReadString方法）
        /// </summary>
        /// <param name="address">地址，如 "DB100.0"</param>
        /// <param name="length">要读取的字节长度</param>
        /// <returns>读取到的字符串内容</returns>
        public string ReadString(string address, ushort length = 256)
        {
            try
            {
                OperateResult<string> operateResult = siemensTcpNet.ReadString(address, length, Encoding.ASCII);
                if (operateResult.IsSuccess)
                {
                    return operateResult.Content?.TrimEnd('\0')?.Trim() ?? string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 从西门子PLC读取指定字节数组
        /// </summary>
        /// <param name="address">地址，如 "DB100.0"</param>
        /// <param name="length">要读取的字节数</param>
        /// <returns>字节数组</returns>
        public byte[] ReadBytes(string address, ushort length)
        {
            try
            {
                OperateResult<byte[]> operateResult = siemensTcpNet.Read(address, length);
                if (operateResult.IsSuccess)
                {
                    return operateResult.Content;
                }
                else
                {
                    return new byte[length];
                }
            }
            catch
            {
                return new byte[length];
            }
        }
    }
}
