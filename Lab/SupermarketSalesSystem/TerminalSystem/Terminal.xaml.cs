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
using System.Threading;
using CR;

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
            Initial();
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
            // 初始化注册信息
            if(!File.Exists(@"Admin.data"))
            {
                File.WriteAllLines(@"Admin.data", new string[]
                {

                });
            }
            if (!File.Exists(@"Assistant.data"))
            {
                File.WriteAllLines(@"Assistant.data", new string[]
                {

                });
            }
            var fs = File.OpenText(@"config.cfg");
            m_TerminalIP.Text = fs.ReadLine();
            m_TerminalPort.Text = fs.ReadLine();
            m_MaxBacklog = int.Parse(fs.ReadLine());
            fs.Close();
            // 初始化销售统计
            m_Items = new List<Item>();
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
            string name = "";
            byte[] buffer = new byte[1024];
            while(clientSocket.Connected)
            {
                int length = clientSocket.Receive(buffer);
                Protocal ptl = (Protocal)Tools.BytesToInt32(buffer, 0);
                switch (ptl)
                {
                    case Protocal.Sale:
                        {
                            int itemID = Tools.BytesToInt32(buffer, 4);
                            foreach (var item in m_Items)
                            {
                                if (item.id == itemID)
                                {
                                    item.saleCount += Tools.BytesToInt32(buffer, 8);
                                    break;
                                }
                            }
                        }
                        break;
                    case Protocal.Check:Check(clientSocket, buffer, name);
                        break;
                    case Protocal.UpdateBegin:
                        break;
                    case Protocal.Update:
                        break;
                    case Protocal.UpdateEnd:
                        break;
                    case Protocal.Same:
                        break;
                    case Protocal.Login:Login(clientSocket, in buffer, out name);
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
                Thread clientThread = new Thread(ReceiveThread);
                clientThread.Start(clientSocket);         
                m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                {
                    m_MessageListBox.Items.Add(DateTime.Now.ToString() + @"：新客户端接入。");
                }));
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
            Thread listenThread = new Thread(ListenClientConnect);
            listenThread.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitialSocket();
            Button button = (Button)sender;
            button.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// 客户端登录的函数
        /// </summary>
        /// <param name="clientSocket">客户端socket</param>
        /// <param name="buffer">使用的缓冲区</param>
        /// <param name="oname">返回的用户名</param>
        private void Login(Socket clientSocket, in byte[] buffer, out string oname)
        {
            Character loginCharacter = (Character)Tools.BytesToInt32(buffer, 4);
            int nameLength = Tools.BytesToInt32(buffer, 8);
            string name = oname = Tools.BytesToString(buffer, 12, nameLength);
            int passwordLength = Tools.BytesToInt32(buffer, 12 + nameLength);
            string password = Tools.BytesToString(buffer, 16 + nameLength, passwordLength);
            m_MessageListBox.Dispatcher.Invoke(new Action(() =>
            {
                m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + name + @"：请求登录。");
            }));
            StreamReader ft = (loginCharacter == Character.Admin) ? (
                File.OpenText(@"Admin.data")) : (File.OpenText(@"Assistant.data"));
            buffer[4] = 0;
            while (!ft.EndOfStream)
            {
                string fname = ft.ReadLine();
                if (name == fname)
                {
                    if (password == ft.ReadLine())
                    {
                        buffer[4] = 1;
                        m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                        {
                            string dname = name;
                            m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + dname + @"：登录成功。");
                        }));
                    }
                    else
                    {
                        m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                        {
                            string dname = name;
                            m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + dname + @"：密码错误。");
                        }));
                    }
                    break;
                }
            }
            clientSocket.Send(buffer);
            if (buffer[4] == 0)
            {
                m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                {
                    string dname = name;
                    m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + dname + @"：帐号不存在,断开连接。");
                }));
                clientSocket.Close();
            }
        }

        /// <summary>
        /// 检查更新的函数
        /// </summary>
        /// <param name="clientSocket">客户端socket</param>
        /// <param name="buffer">使用的缓冲区</param>
        /// <param name="name">客户端名称</param>
        private void Check(Socket clientSocket, in byte[] buffer, string name)
        {
            m_MessageListBox.Dispatcher.Invoke(new Action(() => 
            {
                m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + name + "：请求检查货物数据。");
            }));
            var ft = File.OpenText(@"item.data");
            if (Tools.BytesToInt32(buffer, 4) == Int32.Parse(ft.ReadLine()))
            {
                m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                {
                    m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + name + "：货物数据一致。");
                }));
                Tools.AddToBytes(buffer, 0, (int)Protocal.Same);
                clientSocket.Send(buffer);
                ft.Close();
            }
            else
            {
                m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                {
                    m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + name + "：货物数据不一致，开始同步数据。");
                }));
                ft.Close();
                Tools.AddToBytes(buffer, 0, (int)Protocal.UpdateBegin);
                var fs = File.Open(@"item.data", FileMode.Open);
                var flength = fs.Length;
                var times = flength / m_FSsize + ((flength % m_FSsize == 0) ? 0 : 1);
                // 告诉服务端开始更新
                // 写入协议
                Tools.AddToBytes(buffer, 0, (int)Protocal.UpdateBegin);
                // 写入文件长度
                Tools.AddToBytes(buffer, 4, (int)flength);
                // 写入发送次数
                Tools.AddToBytes(buffer, 8, (int)times);
                // 告诉客户端准备开始更新
                clientSocket.Send(buffer);
                // 开始更新
                // 写入协议
                Tools.AddToBytes(buffer, 0, (int)Protocal.Update);
                // 写入文件信息
                for (int i = 0; i != times; ++i)
                {
                    // 写入包编号
                    Tools.AddToBytes(buffer, 4, i);
                    // 写入文件流
                    fs.Read(buffer, 8, m_FSsize);
                    // 发送
                    clientSocket.Send(buffer);
                }
                fs.Close();
                m_MessageListBox.Dispatcher.Invoke(new Action(() =>
                {
                    m_MessageListBox.Items.Add(DateTime.Now.ToString() + " " + name + "：同步数据完成。");
                }));
                // 告诉客户端更新完毕
                //Tools.AddToBytes(buffer, 0, (int)Protocal.UpdateEnd);
                //clientSocket.Send(buffer);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StringBuilder strb = new StringBuilder();
            int count = m_MessageListBox.Items.Count;
            for(int i = 0; i != count; ++i)
            {
                strb.Append(m_MessageListBox.Items[i]);
                strb.Append("\r\n");
            }
            File.WriteAllText(@"record.data", strb.ToString(), Encoding.Default);
        }
    }
}