using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonUI.Communication
{
    enum ModbusRTUDataType
    {
        X,
        Y,
        M,
        D
    }
   public  sealed class SerialPort_ModbusRTU : IPlcCommunicationBase
    {



        #region  属性

       

        public System.IO.Ports.SerialPort Comport
        {
            get { return _port; }
        }

        public SerialPort_ModbusRTU(SerialPort serialPort)
        {
            _port = serialPort;
        }

        private SerialPort _port;
        private static object ob = new object();

        //不是所有的PLC寄存器都D0对应地址0，
        public Int16 _DAddress = 0;
        public Int16 _XAddress = 0;
        public Int16 _YAddress = 0;
        public Int16 _MAddress = 0;
        public string _intstation = "01";
        //接受数据的延时，默认是100MS
        public Int16 _delayTime = 50;

        public  event Action<object> ConnectEventHandler;
        public  event Action<object> DisconnectEventHandler;
        public  event Action<object, string> ReceivedDataEventHandler;
        public  event EventHandler<EventArgs> ReceivedErrorEventHandler;
        public  event Action<Exception> ErrorLogEventHandler;
        #endregion

        /// <summary>
        /// 释放PLC串口
        /// </summary>
        private  void Dispose()
        {
            try
            {
                if (_port != null)
                {
                    if (_port.IsOpen)
                        _port.Close();
                    _port.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLogEventHandler(ex);
            }
        }

        private byte[] LockSerial(byte[] senddata, int address, int count)
        {
            byte[] Received = new byte[30];

            lock (ob)
            {
                _port.Write(senddata, address, count);
                System.Threading.Thread.Sleep(_delayTime);
                int len = _port.Read(Received, 0, 30);
            }
            return Received;

        }

        public int[] ReadMore2D(int station, Int16 address, Int16 count)
        {
            int[] Result = new int[count];
            byte[] bytes = new byte[20];
            try
            {
                //站号
                string _intstation = station.ToString("X").PadLeft(2, '0');
                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                string intvalue = (count * 2).ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                for (int i = 0; i < count * 4; i = i + 4)
                {
                    string total = bytes[5 + i].ToString("X2") + bytes[6 + i].ToString("X2") + bytes[3 + i].ToString("X2") + bytes[4 + i].ToString("X2");
                    Result[i / 4] = Convert.ToInt32(total, 16);
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < count; i++)
                {
                    Result[i] = -1;
                }
            }
            return Result;

        }

        public bool WriteMore2D(int station, int address, int count, int[] value, bool checkResult = false)
        {
            bool Result = true;
            byte[] bytes = new byte[50];
            try
            {
                //站号
                string _intstation = station.ToString("X").PadLeft(2, '0');
                //D寄存器范围
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                string DCount = (count * 2).ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //字节个数            
                string ByteCount = (count * 4).ToString("X").PadLeft(2, '0');
                //数值
                string totalValue = string.Empty;
                //for (int i = 0; i < count; i++)
                //{
                //    if (count > value.Length)
                //    {
                //        MessageBox.Show("写入数据个数需要小于数组长度");
                //    }
                //    string intvalue = value[i].ToString("X").PadLeft(4, '0');
                //    string valueH = intvalue.Substring(0, 2);
                //    string valueL = intvalue.Substring(2, 2);
                //    totalValue += " " + valueH + " " + valueL;
                //}

                for (int i = 0; i < count; i++)
                {
                    if (count > value.Length)
                    {
                        //MessageBox.Show("写入数据个数需要小于数组长度");
                    }
                    string intvalue = value[i].ToString("X").PadLeft(8, '0');
                    string valueH = intvalue.Substring(4, 2);
                    string valueL = intvalue.Substring(6, 2);
                    string valueH2 = intvalue.Substring(0, 2);
                    string valueL2 = intvalue.Substring(2, 2);
                    totalValue += " " + valueH + " " + valueL + " " + valueH2 + " " + valueL2;
                }

                string data1 = _intstation + " " + "10" + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + ByteCount + totalValue;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);

                //检查校验结果，写入多个数据时，发送值与返回值的数值前5个一样，后面两个是校验码，表示写入成功
                if (checkResult)
                {
                    string checkCRC = string.Empty;
                    for (int i = 0; i < 6; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                            break;
                        }
                        checkCRC += bytes[i].ToString("X2") + " ";
                    }
                    checkCRC = checkCRC.TrimEnd();
                    string temp_str = getHexStr(CRCck(getStrHex(checkCRC)), CRCck(getStrHex(checkCRC)).Length);
                    string cc = bytes[6].ToString("X2") + " " + bytes[7].ToString("X2");
                    if ((bytes[6].ToString("X2") + " " + bytes[7].ToString("X2")) != temp_str.TrimEnd())
                    {
                        Result = false;
                    }
                }

            }
            catch
            {
                Result = false;
            }
            return Result;

        }

        public bool Write2D(int station, int address, int value, bool checkResult = false)
        {
            bool Result = true;
            byte[] bytes = new byte[50];
            try
            {
                //站号
                string _intstation = station.ToString("X").PadLeft(2, '0');
                //D寄存器范围
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                int count = 2;
                string DCount = count.ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //字节个数            
                string ByteCount = (count * 2).ToString("X").PadLeft(2, '0');
                //数值
                string totalValue = string.Empty;
                //for (int i = 0; i < count; i++)
                //{
                //    if (count > value.Length)
                //    {
                //        MessageBox.Show("写入数据个数需要小于数组长度");
                //    }
                string intvalue = value.ToString("X").PadLeft(8, '0');
                string valueH = intvalue.Substring(4, 2);
                string valueL = intvalue.Substring(6, 2);
                string valueH2 = intvalue.Substring(0, 2);
                string valueL2 = intvalue.Substring(2, 2);
                totalValue = " " + valueH + " " + valueL + " " + valueH2 + " " + valueL2;
                //}

                string data1 = _intstation + " " + "10" + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + ByteCount + totalValue;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);

                //检查校验结果，写入多个数据时，发送值与返回值的数值前5个一样，后面两个是校验码，表示写入成功
                if (checkResult)
                {
                    string checkCRC = string.Empty;
                    for (int i = 0; i < 6; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                            break;
                        }
                        checkCRC += bytes[i].ToString("X2") + " ";
                    }
                    checkCRC = checkCRC.TrimEnd();
                    string temp_str = getHexStr(CRCck(getStrHex(checkCRC)), CRCck(getStrHex(checkCRC)).Length);
                    string cc = bytes[6].ToString("X2") + " " + bytes[7].ToString("X2");
                    if ((bytes[6].ToString("X2") + " " + bytes[7].ToString("X2")) != temp_str.TrimEnd())
                    {
                        Result = false;
                    }
                }

            }
            catch
            {
                Result = false;
            }
            return Result;

        }

        public int Read2D(int station, Int16 address)
        {
            int Result = -1;
            byte[] bytes = new byte[20];
            try
            {
                //站号
                string _intstation = station.ToString("X").PadLeft(2, '0');
                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                Int16 count = 2;
                string intvalue = count.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                string total = bytes[5].ToString("X2") + bytes[6].ToString("X2") + bytes[3].ToString("X2") + bytes[4].ToString("X2");
                Result = Convert.ToInt32(total, 16);

            }
            catch (Exception ex)
            {
                Result = -1;
            }
            return Result;

        }

        public string IntChangeString(int data)
        {
            string intvalue = data.ToString("X").PadLeft(4, '0');
            string valueH = intvalue.Substring(0, 2);
            string valueL = intvalue.Substring(2, 2);
            return valueH + " " + valueL;
        }

        private byte[] CRCck(byte[] data)
        {
            byte CRC_L = 0xFF;
            byte CRC_H = 0xFF;   //CRC寄存器 
            byte SH;
            byte SL;
            byte[] temp = data;
            int j;

            for (int i = 0; i < temp.Length; i++)
            {
                CRC_L = (byte)(CRC_L ^ temp[i]); //每一个数据与CRC寄存器进行异或 
                for (j = 0; j < 8; j++)
                {
                    SH = (byte)(CRC_H & 0x01);
                    SL = (byte)(CRC_L & 0x01);

                    CRC_H = (byte)(CRC_H >> 1);      //高位右移一位
                    CRC_H = (byte)(CRC_H & 0x7F);
                    CRC_L = (byte)(CRC_L >> 1);      //低位右移一位 
                    CRC_L = (byte)(CRC_L & 0x7F);

                    if (SH == 0x01) //如果高位字节最后一位为1 
                    {
                        CRC_L = (byte)(CRC_L | 0x80);   //则低位字节右移后前面补1 
                    }             //否则自动补0 
                    if (SL == 0x01) //如果LSB为1，则与多项式码进行异或 
                    {
                        CRC_H = (byte)(CRC_H ^ 0xA0);
                        CRC_L = (byte)(CRC_L ^ 0x01);
                    }
                }
            }
            byte[] result = new byte[2];
            result[0] = CRC_L;       //CRC高位 
            result[1] = CRC_H;       //CRC低位 
            return result;
        }

        private string getHexStr(byte[] buffer, int count)//字节数组转为字符串
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (Regex.Match(Convert.ToString(buffer[i], 16), "[a-f0-9]{2}").Value == "")
                {
                    sb.Append("0" + Convert.ToString(buffer[i], 16) + " ");
                }
                else
                    if ((count - i) == 1)
                {
                    sb.Append(Convert.ToString(buffer[i], 16));
                }
                else
                {
                    sb.Append(Convert.ToString(buffer[i], 16) + " ");
                }

            }

            return sb.ToString().ToUpper();

        }

        private byte[] getStrHex(string cache)//字符串转为字节数组
        {
            string[] temp = cache.Split(' ');
            int len = temp.Length;
            byte[] buffer = new byte[len];
            for (int i = 0; i < len; i++)
            {
                buffer[i] = Convert.ToByte(temp[i], 16);
            }
            return buffer;
        }

   
        
      
    

        public override bool GetState()
        {
            try
            {
                if (_port != null)
                {
                    if (_port.IsOpen)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                ErrorLogEventHandler(ex);
            }
        }

       

        public  bool Close()
        {
            try
            {
                if (_port != null)
                {
                    if (_port.IsOpen)
                        _port.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Int16[] GetFuncodeAdress(Communication_PLS.ControlBit control, bool Write, bool operateOneCount)
        {
            Int16[] FuncodeAdress = new Int16[2];

            if (control == Communication_PLS.ControlBit.M)
            {
                _MAddress = 0;
                FuncodeAdress[0] = _MAddress;
                if (operateOneCount && Write)
                {//写单个线圈
                    FuncodeAdress[1] = 0x05;
                }
                else if (operateOneCount && !Write)
                {//读单个线圈
                    FuncodeAdress[1] = 0x01;
                }
                else if (!operateOneCount && Write)
                {//写多个线圈
                    FuncodeAdress[1] = 0x0F;
                }
            }
            else if (control == Communication_PLS.ControlBit.X)
            {
                _XAddress = 0x4000;
                FuncodeAdress[0] = _XAddress;
                FuncodeAdress[1] = 1;
            }
            else if (control == Communication_PLS.ControlBit.Y)
            {
                _YAddress = 0x4800;
                FuncodeAdress[0] = _YAddress;

                if (operateOneCount && Write)
                {//写单个线圈
                    FuncodeAdress[1] = 0x05;
                }
                else if (operateOneCount && !Write)
                {//读单个线圈
                    FuncodeAdress[1] = 0x01;
                }
                else if (!operateOneCount && Write)
                {//写多个线圈
                    FuncodeAdress[1] = 15;
                }

            }
            else if (control == Communication_PLS.ControlBit.D)
            {
                _DAddress = 0;
                FuncodeAdress[0] = _YAddress;

                if (operateOneCount && Write)
                {//写单个线圈
                    FuncodeAdress[1] = 0x03;
                }
                else if (operateOneCount && !Write)
                {//读单个线圈
                    FuncodeAdress[1] = 0x06;
                }
                else if (!operateOneCount && Write)
                {//写多个线圈
                    FuncodeAdress[1] = 0x10;
                }
                else if (!operateOneCount && !Write)
                {//读多个线圈
                    FuncodeAdress[1] = 0x06;
                }
            }
            return FuncodeAdress;
        }

        public  bool WriteWord(int address, short value, Communication_PLS.ControlBit bit)
        {
            bool Result = true;
            /*等于short, 占2个字节， PLC数值的范围-32768 32767*/
            byte[] bytes = new byte[20];
            try
            {
                //D寄存器
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                string intvalue = value.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC检查 
                string data1 = _intstation + " " + "06" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);

                //检查校验结果，写入单个数据时，发送值与返回值的数值一样，表示写入成功
                if (true)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                        }
                    }
                }
            }
            catch
            {
                Result = false;
            }
            return Result;

        }

        public  short ReadWord(int address, short value, Communication_PLS.ControlBit bit)
        {
            Int16 Result = -1;
            byte[] bytes = new byte[20];
            try
            {

                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                int count = 1;
                string intvalue = count.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                string total = bytes[3].ToString("X2") + bytes[4].ToString("X2");
                Result = Convert.ToInt16(total, 16);
            }
            catch (Exception ex)
            {
                ErrorLogEventHandler(ex);
                Result = -1;
            }
            return Result;
        }

        public  bool WriteManyWord(int address, short[] value, Communication_PLS.ControlBit bit)
        {
            bool Result = true;
            byte[] bytes = new byte[50];
            try
            {

                //D寄存器范围
                int count = value.Length;
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                string DCount = count.ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //字节个数            
                string ByteCount = (count * 2).ToString("X").PadLeft(2, '0');
                //数值
                string totalValue = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    if (count > value.Length)
                    {
                        //MessageBox.Show("写入数据个数需要小于数组长度");
                    }
                    string intvalue = value[i].ToString("X").PadLeft(4, '0');
                    string valueH = intvalue.Substring(0, 2);
                    string valueL = intvalue.Substring(2, 2);
                    totalValue += " " + valueH + " " + valueL;
                }

                string data1 = _intstation + " " + "10" + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + ByteCount + totalValue;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                //检查校验结果，写入多个数据时，发送值与返回值的数值前5个一样，后面两个是校验码，表示写入成功
                if (true)
                {
                    string checkCRC = string.Empty;
                    for (int i = 0; i < 6; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                            break;
                        }
                        checkCRC += bytes[i].ToString("X2") + " ";
                    }
                    checkCRC = checkCRC.TrimEnd();
                    string temp_str = getHexStr(CRCck(getStrHex(checkCRC)), CRCck(getStrHex(checkCRC)).Length);
                    string cc = bytes[6].ToString("X2") + " " + bytes[7].ToString("X2");
                    if ((bytes[6].ToString("X2") + " " + bytes[7].ToString("X2")) != temp_str.TrimEnd())
                    {
                        Result = false;
                    }
                }
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public short[] ReadManyWord(int address, short value, Communication_PLS.ControlBit bit)
        {
            int count = value;
            Int16[] Result = new Int16[count];
            byte[] bytes = new byte[20];
            try
            {

                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                string intvalue = count.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                for (int i = 0; i < count * 2; i = i + 2)
                {
                    string total = bytes[3 + i].ToString("X2") + bytes[4 + i].ToString("X2");
                    Result[i / 2] = Convert.ToInt16(total, 16);
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < count; i++)
                {
                    Result[i] = -1;
                }
            }
            return Result;

        }

        public  bool WriteDWord(int address, int value, Communication_PLS.ControlBit bit)
        {
            bool Result = true;
            byte[] bytes = new byte[50];
            try
            {

                //D寄存器范围
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                int count = 2;
                string DCount = count.ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //字节个数            
                string ByteCount = (count * 2).ToString("X").PadLeft(2, '0');
                //数值
                string totalValue = string.Empty;
                //for (int i = 0; i < count; i++)
                //{
                //    if (count > value.Length)
                //    {
                //        MessageBox.Show("写入数据个数需要小于数组长度");
                //    }
                string intvalue = value.ToString("X").PadLeft(8, '0');
                string valueH = intvalue.Substring(4, 2);
                string valueL = intvalue.Substring(6, 2);
                string valueH2 = intvalue.Substring(0, 2);
                string valueL2 = intvalue.Substring(2, 2);
                totalValue = " " + valueH + " " + valueL + " " + valueH2 + " " + valueL2;
                //}

                string data1 = _intstation + " " + "10" + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + ByteCount + totalValue;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);

                //检查校验结果，写入多个数据时，发送值与返回值的数值前5个一样，后面两个是校验码，表示写入成功
                if (true)
                {
                    string checkCRC = string.Empty;
                    for (int i = 0; i < 6; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                            break;
                        }
                        checkCRC += bytes[i].ToString("X2") + " ";
                    }
                    checkCRC = checkCRC.TrimEnd();
                    string temp_str = getHexStr(CRCck(getStrHex(checkCRC)), CRCck(getStrHex(checkCRC)).Length);
                    string cc = bytes[6].ToString("X2") + " " + bytes[7].ToString("X2");
                    if ((bytes[6].ToString("X2") + " " + bytes[7].ToString("X2")) != temp_str.TrimEnd())
                    {
                        Result = false;
                    }
                }

            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public int ReadDWord(int address, int value, Communication_PLS.ControlBit bit)
        {
            int Result = -1;
            byte[] bytes = new byte[20];
            try
            {
                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                Int16 count = 2;
                string intvalue = count.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                string total = bytes[5].ToString("X2") + bytes[6].ToString("X2") + bytes[3].ToString("X2") + bytes[4].ToString("X2");
                Result = Convert.ToInt32(total, 16);

            }
            catch (Exception ex)
            {
                Result = -1;
            }
            return Result;
        }

        public  bool WriteManyDWord(int address, int[] value, Communication_PLS.ControlBit bit)
        {
            bool Result = true;
            byte[] bytes = new byte[50];
            try
            {
                int count = value.Length;
                //D寄存器范围
                address = address + _DAddress;
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                string DCount = (count * 2).ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //字节个数            
                string ByteCount = (count * 4).ToString("X").PadLeft(2, '0');
                //数值
                string totalValue = string.Empty;
                //for (int i = 0; i < count; i++)
                //{
                //    if (count > value.Length)
                //    {
                //        MessageBox.Show("写入数据个数需要小于数组长度");
                //    }
                //    string intvalue = value[i].ToString("X").PadLeft(4, '0');
                //    string valueH = intvalue.Substring(0, 2);
                //    string valueL = intvalue.Substring(2, 2);
                //    totalValue += " " + valueH + " " + valueL;
                //}

                for (int i = 0; i < count; i++)
                {
                    if (count > value.Length)
                    {
                        //MessageBox.Show("写入数据个数需要小于数组长度");
                    }
                    string intvalue = value[i].ToString("X").PadLeft(8, '0');
                    string valueH = intvalue.Substring(4, 2);
                    string valueL = intvalue.Substring(6, 2);
                    string valueH2 = intvalue.Substring(0, 2);
                    string valueL2 = intvalue.Substring(2, 2);
                    totalValue += " " + valueH + " " + valueL + " " + valueH2 + " " + valueL2;
                }

                string data1 = _intstation + " " + "10" + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + ByteCount + totalValue;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);

                //检查校验结果，写入多个数据时，发送值与返回值的数值前5个一样，后面两个是校验码，表示写入成功
                if (true)
                {
                    string checkCRC = string.Empty;
                    for (int i = 0; i < 6; i++)
                    {
                        if (temp[i] != bytes[i])
                        {
                            Result = false;
                            break;
                        }
                        checkCRC += bytes[i].ToString("X2") + " ";
                    }
                    checkCRC = checkCRC.TrimEnd();
                    string temp_str = getHexStr(CRCck(getStrHex(checkCRC)), CRCck(getStrHex(checkCRC)).Length);
                    string cc = bytes[6].ToString("X2") + " " + bytes[7].ToString("X2");
                    if ((bytes[6].ToString("X2") + " " + bytes[7].ToString("X2")) != temp_str.TrimEnd())
                    {
                        Result = false;
                    }
                }

            }
            catch
            {
                Result = false;
            }
            return Result;

        }

        public  int[] ReadManyDWord(int address, int value, Communication_PLS.ControlBit bit)
        {
            int count = value;
            int[] Result = new int[value];
            byte[] bytes = new byte[20];
            try
            {

                //D寄存器
                address = Convert.ToInt16(address + _DAddress);
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //数值
                string intvalue = (count * 2).ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);
                //CRC校验
                string data1 = _intstation + " " + "03" + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                bytes = LockSerial(temp, 0, temp.Length);
                for (int i = 0; i < count * 4; i = i + 4)
                {
                    string total = bytes[5 + i].ToString("X2") + bytes[6 + i].ToString("X2") + bytes[3 + i].ToString("X2") + bytes[4 + i].ToString("X2");
                    Result[i / 4] = Convert.ToInt32(total, 16);
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < count; i++)
                {
                    Result[i] = -1;
                }
            }
            return Result;
        }

        public  bool WriteBit(int address, bool OnOrOff, Communication_PLS.ControlBit bit)
        {
            bool isWriteOK = true;
            try
            {
                Int16[] funcodeAdress = GetFuncodeAdress(bit, true, true);
                address = address + funcodeAdress[0];
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                string valueH, valueL;
                if (OnOrOff)
                {
                    valueH = "FF";
                    valueL = "00";
                }
                else
                {
                    valueH = "00";
                    valueL = "00";
                }
                string data1 = _intstation + " " + funcodeAdress[1].ToString("X").PadLeft(2, '0') + " " + AddressH + " " + AddressL + " " + valueH + " " + valueL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                byte[] temp = getStrHex(data2);
                byte[] bytes = LockSerial(temp, 0, temp.Length);
                //检查校验结果，写入单个数据时，发送值与返回值的数值一样，表示写入成功
                if (true)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] != bytes[i] && i != 2)
                        {
                            isWriteOK = false;
                        }
                    }
                }
            }
            catch
            {
                isWriteOK = false;
            }
            return isWriteOK;
        }

        public  short ReadBit(int address, Int16 count, Communication_PLS.ControlBit bit)
        {
            short tempdata = -1;
            try
            {

                Int16[] funcodeAdress = GetFuncodeAdress(bit, false, true);

                address = address + funcodeAdress[0];
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);

                //寄存器个数
                string DCount = count.ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);

                string data1 = _intstation + " " + funcodeAdress[1].ToString("X").PadLeft(2, '0') + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                byte[] bytes = LockSerial(temp, 0, temp.Length);
                string total = bytes[3].ToString("X2");
                Int16 Result = Convert.ToInt16(total, 16);
                tempdata = Result;
            }
            catch (Exception ex)
            {
                if (ErrorLogEventHandler != null)
                {
                    ErrorLogEventHandler(ex);
                }
                return -1;
            }
            return tempdata;
        }

        public  bool WriteManyBit(int address, short value, short count, Communication_PLS.ControlBit bit)
        {
            bool isWriteOK = true;
            try
            {
                Int16[] funcodeAdress = GetFuncodeAdress(bit, true, false);
                //寄存器地址
                address = address + funcodeAdress[0];
                string intaddress = address.ToString("X").PadLeft(4, '0');
                string AddressH = intaddress.Substring(0, 2);
                string AddressL = intaddress.Substring(2, 2);
                //寄存器个数
                string DCount = count.ToString("X").PadLeft(4, '0');
                string CountH = DCount.Substring(0, 2);
                string CountL = DCount.Substring(2, 2);
                //数值
                string intvalue = value.ToString("X").PadLeft(4, '0');
                string valueH = intvalue.Substring(0, 2);
                string valueL = intvalue.Substring(2, 2);

                string data1 = _intstation + " " + funcodeAdress[1].ToString("X").PadLeft(2, '0') + " " + AddressH + " " + AddressL + " " + CountH + " " + CountL + " " + "02" + " " + valueL + " " + valueH;
                string data2 = data1 + " " + getHexStr(CRCck(getStrHex(data1)), CRCck(getStrHex(data1)).Length);
                string a = data2.Substring(data2.Length - 1, 1);
                char tempchar;
                bool Flagchar = char.TryParse(a, out tempchar);
                if (tempchar == 32)
                {
                    data2 = data2.Substring(0, data2.Length - 1);
                }
                byte[] temp = getStrHex(data2);
                byte[] bytes = LockSerial(temp, 0, temp.Length);
            }
            catch (Exception ex)
            {
                if (ErrorLogEventHandler != null)
                {
                    ErrorLogEventHandler(ex);
                }
                isWriteOK = false;
            }
            return isWriteOK;
        }







        public override bool Connect()
        {
            try
            {
                if (!_port.IsOpen)
                {
                    _port.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogEventHandler(ex);
                return false;
            }
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
        public override int ReadRegisterInt16(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
        }
        public override double ReadRegisterdoubleArr(string AddressTypeName, uint[] addressArr)
        {
            throw new NotImplementedException();
        }

        public override float ReadRegisterfloat(string AddressTypeName, uint address)
        {
            throw new NotImplementedException();
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
            _delayTime =Convert.ToInt16( delayTime);
        }

        public override void SetStation(ushort station)
        {
            _intstation = station.ToString("X").PadLeft(2, '0');
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override bool WriterRegisterShortArr(string AddressTypeName, uint address, short[] valueArr)
        {
            throw new NotImplementedException();
        }

        public override void DisConnect()
        {
            try
            {
                if (_port.IsOpen)
                {
                    _port.Close();
                }
             
            }
            catch (Exception ex)
            {
                if (ErrorLogEventHandler != null)
                {
                    ErrorLogEventHandler(ex);
                }
              
            }
        }
    }
}
