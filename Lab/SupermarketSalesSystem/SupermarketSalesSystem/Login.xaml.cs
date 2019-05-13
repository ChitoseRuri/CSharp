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
using CR;

namespace SupermarketSalesSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Character m_Character;
        public LoginWindow()
        {
            InitializeComponent();
            Initial();
            Mode_ChooseCharactor();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            m_Name.Margin = m_AdminLogin.Margin;
            m_Password.Margin = m_AssistantLogin.Margin;
            if (!File.Exists(@"config.cfg"))
            {
                File.WriteAllLines(@"config.cfg", new string[] { @"127.0.0.1", @"12235" });
            }
            var fs = File.OpenText(@"config.cfg");
            m_TerminalIP.Text = fs.ReadLine();
            m_TerminalPort.Text = fs.ReadLine();
            fs.Close();
        }
        private void Mode_ChooseCharactor()
        {
            m_Cancel.Visibility = Visibility.Hidden;
            m_Enter.Visibility = Visibility.Hidden;
            m_Password.Visibility = Visibility.Hidden;
            m_Name.Visibility = Visibility.Hidden;
            m_AdminLogin.Visibility = Visibility.Visible;
            m_AssistantLogin.Visibility = Visibility.Visible;
        }

        private void Login(Character charactor)
        {
            m_Character = charactor;
            m_Cancel.Visibility = Visibility.Visible;
            m_Enter.Visibility = Visibility.Visible;
            m_Password.Visibility = Visibility.Visible;
            m_Name.Visibility = Visibility.Visible;
            m_AdminLogin.Visibility = Visibility.Hidden;
            m_AssistantLogin.Visibility = Visibility.Hidden;
            m_Password.Text = "";
            m_Name.Text = "";
        }

        private void M_AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            Login(Character.Admin);
        }

        private void M_AssistantLogin_Click(object sender, RoutedEventArgs e)
        {
            Login(Character.Assistant);
        }

        /// <summary>
        /// 登录，检查登录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_Enter_Click(object sender, RoutedEventArgs e)
        {
            // 检查ip地址
            IPAddress terminalIP;
            if (IPAddress.TryParse(m_TerminalIP.Text, out terminalIP))
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(m_TerminalIP.Text), Int16.Parse(m_TerminalPort.Text)));
                // 向服务器请求登录
                byte[] buffer = new byte[1024];
                Tools.AddToBytes(buffer, 0, (int)Protocal.Login);
                int length1 = m_Name.Text.Length;
                Tools.AddToBytes(buffer, 4, (Int32)m_Character);
                Tools.AddToBytes(buffer, 8, length1);
                Tools.AddToBytes(buffer, 12, m_Name.Text);
                int length2 = m_Password.Text.Length;
                Tools.AddToBytes(buffer, 12 + length1, length2);
                Tools.AddToBytes(buffer, 16 + length1, m_Password.Text);
                //接受服务器反馈信息并处理
                socket.Receive(buffer);
                if(buffer[5] == 1)// 服务器认证成功
                {
                    Window window;
                    if(m_Character == Character.Admin)
                    {
                        window = new Admin(socket);
                    }
                    else
                    {
                        window = new Assistant(socket);
                    }
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"帐号不存在或密码错误！", @"登录失败");
                }
            }
            else
            {
                MessageBox.Show("错误的终端ip地址！");
            }
        }

        /// <summary>
        /// 取消登录，返回上一个界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Mode_ChooseCharactor();
        }
    }
}
