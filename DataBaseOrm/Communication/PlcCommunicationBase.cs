using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUI.Communication
{
    public abstract class IPlcCommunicationBase
    {

  

        /// <summary>
        /// 打开通信
        /// </summary>
        /// <returns></returns>
        public abstract bool Connect();

        /// <summary>
        /// 关闭通信
        /// </summary>
        /// <returns></returns>
        public abstract void  DisConnect();

        /// <summary>
        /// 获取当前通信的状态
        /// </summary>
        /// <returns></returns>
        public abstract bool GetState();

        /// <summary>
        /// 设置数据类型基础值
        /// </summary>
        /// <param name="addressBase"></param>
        /// <param name="dataTypeName"></param>
        public abstract void SetDataBaseTypeAddresss(UInt64 addressBase, string dataTypeName);

        /// <summary>
        /// 设置站号
        /// </summary>
        /// <param name="station"></param>
        public abstract void SetStation(UInt16 station);

        /// <summary>
        ///设置延时时间
        /// </summary>
        /// <param name="delayTime"></param>
        public abstract void SetDelayTime(UInt16 delayTime);

        /// <summary>
        /// 读取输入的状态单个位，例如X
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract bool ReadInputBit(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取输入的状态多个位，例如X
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <returns></returns>
        public abstract bool[] ReadInputBitArr(string AddressTypeName, UInt32[] addressArr);

        /// <summary>
        /// 读取线圈的位状态
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract bool ReadCoilBit(string AddressTypeName, UInt32 address);
        /// <summary>
        /// 读取多个线圈的位状态
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract bool ReadCoilBitArr(string AddressTypeName, UInt32[] address);

        /// <summary>
        /// 读取单个寄存器的值，数据类型short
        /// </summary>
        /// <param name="AddressTypeName"></param>数据类型
        /// <param name="address"></param>地址
        /// <returns></returns>
        public abstract short ReadRegisterShort(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取多个寄存器的值，数据类型short
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract short[] ReadRegisterShortArr(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取单个寄存器的值，数据类型Int16
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract Int32 ReadRegisterInt16(string AddressTypeName, UInt32 address);

        /// <summary>
        ///  读取单个寄存器的值，数据类型Int32
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract Int32 ReadRegisterInt32(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取多个寄存器的值，数据类型Int32
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <returns></returns>
        public abstract Int32[] ReadRegisterInt32Arr(string AddressTypeName, UInt32[] addressArr);

        /// <summary>
        /// 读取单个寄存器的值，数据类型Int64
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract Int64 ReadRegisterInt64(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取多个寄存器的值，数据类型Int64
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <returns></returns>
        public abstract Int64[] ReadRegisterInt64Arr(string AddressTypeName, UInt32[] addressArr);

        /// <summary>
        /// 读取单个寄存器的值，数据类型float
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract float ReadRegisterfloat(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取多个寄存器的值，数据类型float
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <returns></returns>
        public abstract float ReadRegisterfloatArr(string AddressTypeName, UInt32[] addressArr);

        /// <summary>
        /// 读取单个寄存器的值，数据类型double
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public abstract double ReadRegisterdouble(string AddressTypeName, UInt32 address);

        /// <summary>
        /// 读取多个寄存器的值，数据类型double
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <returns></returns>
        public abstract double ReadRegisterdoubleArr(string AddressTypeName, UInt32[] addressArr);


      



        /// <summary>
        /// 写单个寄存器的值，数据类型Bool
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterCoilBit(string AddressTypeName, UInt32 address, bool value);

        /// <summary>
        /// 写多个寄存器的值，数据类型Bool
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterCoilBitArr(string AddressTypeName, UInt32[] address, bool[] valueArr);

        /// <summary>
        /// 写单个寄存器的值，数据类型Short
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterShort(string AddressTypeName, UInt32 address, short value);

        /// <summary>
        /// 写多个寄存器的值，数据类型Short
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterShortArr(string AddressTypeName, UInt32 address, short[] valueArr);

        /// <summary>
        /// 写单个寄存器的值，数据类型Int32
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterInt32(string AddressTypeName, UInt32 address, Int32 value);

        /// <summary>
        ///  写多个寄存器的值，数据类型Int32
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterInt32Arr(string AddressTypeName, UInt32[] addressArr, Int32[] valueArr);

        /// <summary>
        ///  写单个寄存器的值，数据类型Int64
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterInt64(string AddressTypeName, UInt32 address, Int64 value);

        /// <summary>
        ///  写多个寄存器的值，数据类型Int64
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterInt64Arr(string AddressTypeName, UInt32[] addressArr, Int64 valueArr);

        /// <summary>
        ///  写单个寄存器的值，数据类型float
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterfloat(string AddressTypeName, UInt32 address, float value);

        /// <summary>
        /// 写多个寄存器的值，数据类型float
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterfloatArr(string AddressTypeName, UInt32[] addressArr, float[] valueArr);


        /// <summary>
        ///写单个寄存器的值，数据类型double
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterdouble(string AddressTypeName, UInt32 address, double value);

        /// <summary>
        /// 写多个寄存器的值，数据类型double
        /// </summary>
        /// <param name="AddressTypeName"></param>
        /// <param name="addressArr"></param>
        /// <param name="valueArr"></param>
        /// <returns></returns>
        public abstract bool WriterRegisterdoubleArr(string AddressTypeName, UInt32[] addressArr, double valueArr);



    }
}
