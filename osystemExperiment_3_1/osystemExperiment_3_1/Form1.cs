using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace osystemExperiment_3_1
{
    public partial class Form1 : Form
    {
        Base m_TB;
        Bitmap m_Pic;
        int[] m_ID = { 1, 2, 3, 2, 4, 3, 1, 5, 6, 7, 8 };
        int[] m_Work = { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1 };
        Area[] m_Area = { new Area(130, 1), new Area(60, 2), new Area(100, 3), new Area(200, 4), new Area(140, 5), new Area(60, 6), new Area(50, 7), new Area(60, 8) };
        int m_Index;
        StringBuilder m_StringB;

        public Form1()
        {
            InitializeComponent();
            m_StringB = new StringBuilder();
            reInitialize();
        }

        /// <summary>
        /// 初始化控件并隐藏
        /// </summary>
        private void reInitialize()
        {
            if(m_Pic != null)
            {
                m_Pic.Dispose();
            }
            m_Pic = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);//初始化图片
            pictureBox1.Image = m_Pic;
            pictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            label2.Text = @"";
            m_Index = 0;
        }

        /// <summary>
        /// 显示控件
        /// </summary>
        private void showControl()
        {
            button1.Visible = false;
            button2.Visible = false;
            pictureBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            m_TB.initial(m_Pic);
            m_TB.refreshBitmap();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_StringB.Clear();
            m_StringB.Append(@"作业");
            m_StringB.Append(m_ID[m_Index].ToString());
            if (m_Work[m_Index] == 1)
            {
                m_StringB.Append(@"申请");
                m_TB.apply(m_Area[m_ID[m_Index] - 1]);
            }
            else
            {
                m_StringB.Append(@"释放");
                m_TB.release(m_Area[m_ID[m_Index] - 1]);
            }
            m_StringB.Append(m_Area[m_ID[m_Index] - 1].area.ToString());
            m_StringB.Append(@"KB");
            label2.Text = m_StringB.ToString();
            pictureBox1.Image = m_Pic;
            m_Index++;
            if(m_Index >= 11)
            {
                timer1.Stop();
                button3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_TB = new First();
            showControl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_TB = new Best();
            showControl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reInitialize();
        }
    }
}
