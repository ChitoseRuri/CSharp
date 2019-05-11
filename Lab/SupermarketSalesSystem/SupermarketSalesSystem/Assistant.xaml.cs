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
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SupermarketSalesSystem
{
    /// <summary>
    /// Assistant.xaml 的交互逻辑
    /// </summary>
    public partial class Assistant : Window
    {
        private Socket m_Socket;
        public Assistant(Socket socket)
        {
            InitializeComponent();
            m_Socket = socket;
        }
    }
}
