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
using Microsoft.Win32;

namespace A._1_VideoDrawExercise
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton[] m_Radios;
        private MediaElement[] m_Medias;
        private bool[] m_IsGetVideo;
        private OpenFileDialog m_Ofd;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            // 初始化RadioButton绑定
            m_Radios = new RadioButton[] { m_RadioButton1, m_RadioButton2 };
            // 初始化MediaPlayer绑定
            m_Medias = new MediaElement[] { m_Vedio1, m_Vedio2 };
            m_IsGetVideo = new bool[] { false, false };
            // 初始化文件选择器
            m_Ofd = new OpenFileDialog();
            m_Ofd.Filter = @"video file|*.mkv;*.mp4;*.3gp";
        }

        /// <summary>
        /// 选择了一个视频之后暂停其它视频
        /// </summary>
        /// <param name="index">按下的RadioButton对应下标</param>
        private void ChooseVideo(int index)
        {
            foreach(var md in m_Medias)
            {
                md.Pause();
            }
            m_Medias[index].Play();
        }

        private void ChooseFile(int index)
        {
            m_Ofd.ShowDialog();
            if(m_Ofd.FileName != null)
            {
                m_Medias[index].Source = new Uri(m_Ofd.FileName);
                ////m_Medias[index].Play();
                m_Ofd.FileName = null;
                m_IsGetVideo[index] = true;
                ChooseVideo(index);
            }
        }

        private void M_RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int index = 0;
            while(rb != m_Radios[index])
            {
                ++index;
            }
            if(m_IsGetVideo[index])
            {
                ChooseVideo(index);
            }
            else
            {
                ChooseFile(index);
            }
        }
    }
}
