using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TerminalSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPAddress m_IPAddress;
        private UInt16 m_Port;
        private Socket m_Socket;
        private int m_MaxBacklog;
        private List<Item> m_Items;
        private const int m_FSsize = 1016; // 一次传输的文件流长度
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Initial()
        {
            // 初始化ip地址
            if (!File.Exists(@"config.cfg"))
            {
                File.WriteAllLines(@"config.cfg", new string[] 
                {
                    @"127.0.0.1",// IP
                    @"12345",    // Port
                    @"256"       // Max Backlog
                });
            }
            var fs = File.OpenText(@"config.cfg");
            m_TerminalIP.Text = fs.ReadLine();
            m_TerminalPort.Text = fs.ReadLine();
            m_MaxBacklog = int.Parse(fs.ReadLine());
            fs.Close();
            // 初始化销售统计
            if(!File.Exists(@"item.data"))
            {
                File.WriteAllLines(@"item.data", new string[] 
                {
                    @"0"// 版本号
                });
            }
            fs = File.OpenText(@"item.data");
            fs.ReadLine();//跳过版本号
            while(!fs.EndOfStream)
            {
                m_Items.Add(new Item(
                    int.Parse(fs.ReadLine()),
                    fs.ReadLine(),
                    int.Parse(fs.ReadLine()),
                    int.Parse(fs.ReadLine()),
                    int.Parse(fs.ReadLine())
                    ));
            }
            fs.Close();
        }

        /// <summary>
        /// 分发给各个客户端通信的线程
        /// </summary>
        private void ReceiveThread(object socket)
        {
            Socket clientSocket = (Socket)socket;
            byte[] buffer = new byte[1024];
            while(true)
            {
                int length = clientSocket.Receive(buffer);
                Protocal ptl = (Protocal)BitConverter.ToInt32(buffer, 0);
                switch (ptl)
                {
                    case Protocal.Sale:
                        {
                            int itemIP = BitConverter.ToInt32(buffer, 4);
                            foreach(var item in m_Items)
                            {
                                if(item.ip == itemIP)
                                {
                                    item.saleCount += BitConverter.ToInt32(buffer, 8);
                                    break;
                                }
                            }
                        }
                        break;
                    case Protocal.Check:
                        {
                            var ft = File.OpenText(@"item.data");
                            if(BitConverter.ToInt32(buffer, 4) == Int32.Parse(ft.ReadLine()))
                            {
                                clientSocket.Send(BitConverter.GetBytes((int)(Protocal.Same)));
                                ft.Close();
                            }
                            else
                            {
                                ft.Close();
                                clientSocket.Send(BitConverter.GetBytes((int)(Protocal.UpdateBegin)));
                                var fs = File.Open(@"item.data", FileMode.Open);
                                var flength = fs.Length;
                                var times = flength / m_FSsize + ((flength % m_FSsize == 0) ? 0 : 1);
                                // 告诉服务端开始更新
                                int prot = (Int32)Protocal.UpdateBegin;
                                // 写入协议
                                buffer[0] = (byte)(prot >> 24);
                                buffer[1] = (byte)(prot >> 16);
                                buffer[2] = (byte)(prot >> 8);
                                buffer[3] = (byte)(prot);
                                // 写入文件长度
                                buffer[4] = (byte)(flength >> 24);
                                buffer[5] = (byte)(flength >> 16);
                                buffer[6] = (byte)(flength >> 8);
                                buffer[7] = (byte)(flength);
                                // 写入发送次数
                                buffer[8] = (byte)(times >> 24);
                                buffer[9] = (byte)(times >> 16);
                                buffer[10] = (byte)(times >> 8);
                                buffer[11] = (byte)(times);
                                // 告诉客户端准备开始更新
                                clientSocket.Send(buffer);
                                // 写入协议
                                prot = (Int32)Protocal.Update;
                                buffer[0] = (byte)(prot >> 24);
                                buffer[1] = (byte)(prot >> 16);
                                buffer[2] = (byte)(prot >> 8);
                                buffer[3] = (byte)(prot);
                                // 写入文件信息
                                for (int i = 0; i != times; ++i)
                                {
                                    // 写入包编号
                                    buffer[4] = (byte)(i >> 24);
                                    buffer[5] = (byte)(i >> 16);
                                    buffer[6] = (byte)(i >> 8);
                                    buffer[7] = (byte)(i);
                                    // 写入文件流
                                    fs.Read(buffer, 12, m_FSsize);
                                    // 发送
                                    clientSocket.Send(buffer);
                                }
                                fs.Close();
                                // 告诉客户端更新完毕
                                clientSocket.Send(BitConverter.GetBytes((int)(Protocal.UpdateEnd)));
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 监听客户端接入
        /// </summary>
        private void ListenClientConnect()
        {
            while(true)
            {
                Socket clientSocket = m_Socket.Accept();
                
            }
        }

        private void InitialSocket()
        {
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if(!IPAddress.TryParse(m_TerminalIP.Text,out m_IPAddress))
            {
                MessageBox.Show(@"错误的IP地址！", @"ip绑定失败");
            }
            if (!UInt16.TryParse(m_TerminalPort.Text, out m_Port)) 
            {
                MessageBox.Show(@"错误的端口号！", @"ip绑定失败");
            }
            m_Socket.Bind(new IPEndPoint(m_IPAddress, m_Port));
            m_Socket.Listen(m_MaxBacklog);
        }
    }
}