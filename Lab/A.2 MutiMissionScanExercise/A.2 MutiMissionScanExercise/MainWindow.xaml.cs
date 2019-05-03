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
using System.Threading;

namespace A._2_MutiMissionScanExercise
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPAddress m_IPAddress;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            m_LabelWarning.Visibility = Visibility.Hidden;
            m_TextBeginPort.Text = "100";
            m_TextEndPort.Text = "110";

        }

        private bool IP_Worning(bool isRight)
        {
            if (isRight)
            {
                m_LabelWarning.Visibility = Visibility.Hidden;
            }
            else
            {
                m_LabelWarning.Visibility = Visibility.Visible;
            }
            return isRight;
        }

        private void IP_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_LabelWarning == null)
            {
                return;
            }
            IP_Worning(IPAddress.TryParse(m_TextIP.Text, out m_IPAddress));
        }

        private void ScanThread(object ip_in)
        {
            IPAddress ip = (IPAddress)ip_in;
            var time = DateTime.Now.ToBinary();
            try
            {
                var entry = Dns.GetHostEntry(ip);
                string name = entry.HostName;
                time = (DateTime.Now.ToBinary() - time) / 1000;
                m_ListBox.Dispatcher.Invoke(new Action(() =>
                {
                    m_ListBox.Items.Add(@"扫描地址：" + ip.ToString() +
                      @"，扫描用时：" + time.ToString() + @"毫秒，主机DNS名称：" + name);
                }));
            }
            catch(Exception error)
            {

            }          
        }

        private void ScanBegin(object sender, RoutedEventArgs e)
        {
            m_ListBox.Items.Clear();
            UInt16 begin, end;
            if (!IP_Worning(UInt16.TryParse(m_TextBeginPort.Text, out begin)))
            {
                return;
            }
            if (!IP_Worning(UInt16.TryParse(m_TextEndPort.Text, out end)))
            {
                return;
            }

            if (end > 255)
            {
                m_TextEndPort.Text = "255";
            }
            if (begin > 255)
            {
                m_TextBeginPort.Text = "255";
            }
            if (begin > end)
            {
                m_TextEndPort.Text = m_TextBeginPort.Text;
            }
            for (UInt16 i = begin; i <= end; ++i) 
            {
                Thread thread = new Thread(new ParameterizedThreadStart(ScanThread));
                thread.Start(IPAddress.Parse(m_TextIP.Text + i.ToString()));
            }
        }
    }

}
