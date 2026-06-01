using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommonUI.Communication
{
    /// <summary>
    /// 客户端，同步
    /// </summary>
    public   class SyncClient : IDisposable
    {

        private  Socket client;
        private object ob = new object();
        public  bool Open(string ip, string port)
        {
            try
            {
                IPAddress IP = IPAddress.Parse(ip);
                IPEndPoint Host = new IPEndPoint(IP, Convert.ToInt32(port));
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(Host);
                return true;
            }
            catch (Exception ex)
            {
                string error = "客户端连接打开出现错误，信息为" + ex.Message;
                 
                return false;
            }
        }
        public bool IsConnected()
        {
            try
            {
                if (client != null && (!(client.Poll(1000, SelectMode.SelectRead) && client.Available == 0)) && client.Connected)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string error = "判断客户端是否连接出现错误，信息为" + ex.Message;
                
                return false;
            }
        }
        private  void  WaitReadAll(long time)
        {
            int prenum =client .Available ;
            int nownum = 0;
            for (int i = 0; i < time/10; i++)
            {
                Thread.Sleep(10);
                nownum = client.Available;
                if (prenum == nownum)
                    break;
                else
                {
                    prenum = nownum;
                }
            }
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Read()
        {
            lock (ob)
            {
                string datastr = string.Empty;
                try
                {
                    if (IsConnected ()&&client.Available > 0)
                    {
                        WaitReadAll(10000);
                        byte[] data = new byte[client.Available];
                        client.Receive(data);
                        datastr=Encoding.ASCII.GetString(data);
                    }
                }
                catch (Exception ex)
                {
                    string error = "读数据出现错误，信息为" + ex.Message;
                   
                }
                return datastr;
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Write(string str)
        {
            lock (ob)
            {
                try
                {
                    if (IsConnected ())
                    {
                        byte[] data = Encoding .ASCII .GetBytes(str);
                        client.Send(data);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    string error = "写数据出现错误，信息为" + ex.Message;
                    
                    return false;
                }
            }
        }
        public void Dispose()
        {
            if (client != null)
            {
                if (client.Connected&&(!client .Poll (1000,SelectMode.SelectRead)))
                {
                    try
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Disconnect(true);
                    }
                    catch (Exception ex)
                    {
                        string error = "断开客户端连接出现错误，信息为" + ex.Message;
                         
                    }
                }
                client.Close();
                client = null;
            }
            GC.Collect();
        }

    }
}
