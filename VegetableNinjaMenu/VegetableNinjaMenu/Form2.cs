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
using System.Windows;

namespace VegetableNinjaMenu
{
    public partial class Form2 : Form
    {
        public Form1 form1;

        private string[] m_Question;
        private string[] m_Answer;
        private int mode;
        private bool is_NoEdit = true;
        private int m_Index = 0;
        public Form2()
        {
            InitializeComponent();
            initialization();
        }

        /// <summary>
        /// 自定义初始化
        /// </summary>
        private void initialization()
        {
            //先查看有没有储存问题的文件
            if (!File.Exists(@"Data\question.dat") || !File.Exists(@"Data\answer.dat"))
            {
                MessageBox.Show("未找到题库文件，初始化存档。");
                FileStream file = File.Create(@"Data\question.dat");
                file.Close();
                file = File.Create(@"Data\answer.dat");
                file.Close();
            }
            m_Question = File.ReadAllLines(@"Data\question.dat", Encoding.Default);
            m_Answer = File.ReadAllLines(@"Data\answer.dat", Encoding.Default);
            if(m_Question.Length == 0)
            {
                mode1();
            }
            else
            {
                mode0();
            }
        }

        /// <summary>
        /// 关闭编辑器按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 当编辑器窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Question.Length == 0)
            {
                File.Delete(@"Data\question.dat");
                File.Delete(@"Data\answer.dat");
            }
            else
            {
                File.WriteAllLines(@"Data\question.dat", m_Question, Encoding.Default);
                File.WriteAllLines(@"Data\answer.dat", m_Answer, Encoding.Default);
            }
            form1.Visible = true;
        }

        /// <summary>
        /// 查改题目模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode0()
        {
            button2.BackColor = Color.DodgerBlue;
            button3.BackColor = Color.LightSkyBlue;
            button2.Enabled = false;
            button3.Enabled = true;
            is_NoEdit = true;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
            comboBox1.DataSource = m_Question;
            comboBox1.Text = null;
            button4.Text = "保存完成√";
            button4.BackColor = Color.LimeGreen;
            button4.Enabled = false;
            mode = 0;
        }

        /// <summary>
        /// 跳转到模式0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //DarkSalmon颜色是未保存
            if(button4.BackColor == Color.DarkSalmon)
            {
                if (MessageBox.Show("有未保存的更改，仍然切换？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    button4.Text = "保存完成√";
                    button4.BackColor = Color.LimeGreen;
                    button4.Enabled = false;                   
                }
                else
                {
                    return;
                }
            }
            if(m_Question.Length == 0)
            {
                MessageBox.Show("题库为空！");
            }
            else
            {
                mode0();
            }
        }

        /// <summary>
        ///添加题目模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode1()
        {
            button3.BackColor = Color.DodgerBlue;
            button2.BackColor = Color.LightSkyBlue;
            button3.Enabled = false;
            button2.Enabled = true;
            is_NoEdit = true;
            comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
            comboBox1.DataSource = null;
            button4.Text = "保存完成√";
            button4.BackColor = Color.LimeGreen;
            button4.Enabled = false;
            mode = 1;
        }

        /// <summary>
        /// 跳转到模式1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //DarkSalmon颜色是未保存
            if (button4.BackColor == Color.DarkSalmon)
            {
                if (MessageBox.Show("有未保存的更改，仍然切换？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    button4.Text = "保存完成√";
                    button4.BackColor = Color.LimeGreen;
                    button4.Enabled = false;
                    mode1();
                }
            }
            else
            {
                mode1();
            }
        }

        /// <summary>
        /// 保存更改的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("有未填写的题目信息！");
                return;
            }
            switch (mode)
            {
                case 0://查改模式
                    {
                        break;
                    }
                case 1://添加模式
                    {
                        int length = m_Question.Length;
                        m_Index = length;
                        string[] newstring = new string[m_Index + 1];
                        for (int i = 0; i < m_Index; i++)
                        {
                            newstring[i] = m_Question[i];
                        }
                        m_Question = newstring;
                        int length2 = m_Index * 4;
                        newstring = new string[length2 + 4];
                        for (int i = 0; i < length2; i++)
                        {
                            newstring[i] = m_Answer[i];
                        }
                        m_Answer = newstring;
                        break;
                    }
                default:
                    return;
            }
            m_Question[m_Index] = comboBox1.Text;
            m_Answer[m_Index * 4] = textBox1.Text;
            m_Answer[m_Index * 4 + 1] = textBox2.Text;
            m_Answer[m_Index * 4 + 2] = textBox3.Text;
            m_Answer[m_Index * 4 + 3] = textBox4.Text;
            button4.Text = "保存完成√";
            button4.BackColor = Color.LimeGreen;
            button4.Enabled = false;
            mode0();
            is_NoEdit = true;
            textBox1.Text = m_Answer[m_Index * 4];
            textBox2.Text = m_Answer[m_Index * 4 + 1];
            textBox3.Text = m_Answer[m_Index * 4 + 2];
            textBox4.Text = m_Answer[m_Index * 4 + 3];
            comboBox1.SelectedIndex = m_Index;
        }

        /// <summary>
        /// 如果下拉列表显示的文字改动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged(0);  
        }

        /// <summary>
        /// 如果正确答案的文字改动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged(1);
        }

        /// <summary>
        /// 如果错误答案1的文字改动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textChanged(2);
        }

        /// <summary>
        /// 如果错误答案2的文字改动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textChanged(3);
        }

        /// <summary>
        /// 如果错误答案3的文字改动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textChanged(4);
        }

        /// <summary>
        /// 每次展示文字改动都调用
        /// </summary>
        private void textChanged(int m_Index)
        {
            if (is_NoEdit)
            {
                if (m_Index == 0)
                {
                    is_NoEdit = false;
                }
            }
            else
            {
                button4.Text = "确认修改？";
                button4.BackColor = Color.DarkSalmon;
                button4.Enabled = true;
            }
        }

        /// <summary>
        /// 如果这次combobox的文字改动是因为下拉选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            is_NoEdit = true;
            switch (mode)
            {
                case 0://查改模式
                    {
                        m_Index = comboBox1.SelectedIndex;
                        textBox1.Text = m_Answer[m_Index * 4];
                        textBox2.Text = m_Answer[m_Index * 4 + 1];
                        textBox3.Text = m_Answer[m_Index * 4 + 2];
                        textBox4.Text = m_Answer[m_Index * 4 + 3];
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 如果下拉完了之后点击了combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_Click(object sender, EventArgs e)
        {
            is_NoEdit = false;
        }
    }
}
