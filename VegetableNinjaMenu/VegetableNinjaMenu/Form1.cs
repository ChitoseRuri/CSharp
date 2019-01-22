using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VegetableNinjaMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始游戏的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(@"Data\question.dat") || !File.Exists(@"Data\answer.dat"))
            {
                MessageBox.Show("没有找到题库文件，请先设置题目。");
                return;
            }
            if(File.Exists(@"Vegetable Ninja.exe"))
            {
                System.Diagnostics.Process.Start(@"Vegetable Ninja.exe");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("程序文件损坏！");
            }
        }
        /// <summary>
        /// 打开内容编辑器的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.form1 = this;
            form2.Show();
            this.Visible = false;
        }
        /// <summary>
        /// 退出游戏的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
