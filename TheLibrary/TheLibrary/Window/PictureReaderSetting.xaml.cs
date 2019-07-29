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

namespace TheLibrary.Window
{
    /// <summary>
    /// PictureReaderSetting.xaml 的交互逻辑
    /// </summary>
    public partial class PictureReaderSetting
    {
        public PictureReaderSetting()
        {
            InitializeComponent();
            m_WheelPaging.IsChecked = true;
            m_WheelZoom.IsChecked = false;
        }

        private void M_WheelZoom_Checked(object sender, RoutedEventArgs e)
        {
            m_WheelPaging.IsChecked = !m_WheelZoom.IsChecked;
        }

        private void M_WheelPaging_Checked(object sender, RoutedEventArgs e)
        {
            m_WheelZoom.IsChecked = !m_WheelPaging.IsChecked;
        }
    }
}
