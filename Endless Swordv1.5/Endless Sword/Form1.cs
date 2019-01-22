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

namespace Endless_Sword
{
    public partial class Form1 : Form
    {
        int mode = 2;
        int generation = 0;                                                         //user文件记录
        int experience = 0;
        int level = 1;
        int hp = 500;
        int maxhp = 500;
        string weapen = "古老的剑";
        int atk = 15;
        int critrate = 10;
        int gold = 400;
        int myatkinterval = 1000;
        int death_of_boss = 0;
        int[] backpacklist = new int[7];
        int place  = 0;
        int placechk = 1;
        int infinityblade = 0;//user文件记录
        string path;
        Random rand = new Random();
        storylist estory = new storylist();
        storylist way1list = new storylist();
        storylist way2list = new storylist();
        storylist truehead = new storylist();
        storylist end1 = new storylist();
        story p = new story();
        Button[] bton = new Button[6];

        int myval;
        int enemyval;
        int enemyhp;
        int atkdirection;
        string[] enemyattack = { "↑", "→", "↓", "←" };
        int truedamage;
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            label23.Visible = false;
            string[] give = new string[3];
            give[0] = "牛头头盔";
            give[1] = "鹿头头盔";
            give[2] = "虎头头盔" ;
            truehead.Append("二十多年后……", "0", "0", "0", "0", "0", 0, 0, 0, 0);
            truehead.Append("“父亲，我会为你复仇的。”", "0", "0", "0", "0", "0", 0, 0, 0, 0);
            end1.Append("你向神王跪下，宣誓效忠", "1", "神王", "很好,明智的选择，那这个" + give[rand.Next(0, 3)] + "就赐给你了,向我效忠吧！为我守住这个城堡，筛选来挑战我的人。", "塔顶", "0", 0, 0, 0, 0);
            mode = 1;
            path = Directory.GetCurrentDirectory() + '/';
            bton[0] = button1;
            bton[1] = button2;
            bton[2] = button3;
            bton[3] = button4;
            bton[4] = button5;
            bton[5] = button6;
            userload();
            storyload();
            storyvis(p.surroundings);
        }
   

        private void storyvis(string show)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            if (p.anotherway != 0)
            {
                button8.Visible = true;
            }
            else
            {
                button8.Visible = false;
            }
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label1.Text = show;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            if(p.placename == "神秘遗迹")
            {
                infinityblade = 1;

                if (backpacklist[6]!=1) 
                {
                    button8.Visible = false;
                }
                else
                {
                    button8.Visible = true;
                }
            }
        }


        private void fightvis()
        {
            label3.Text = hp.ToString();
            label5.Text = maxhp.ToString();
            label23.Text = p.npcname;
            label7.Text = p.enemymaxhp.ToString();
            label9.Text = p.enemymaxhp.ToString();
            label15.Text = weapen;
            label13.Text = atk.ToString();
            label10.Text = myatkinterval.ToString();
            label11.Text = p.enemyatkinterval.ToString();
            atkdirection = rand.Next(0, 4);
            label14.Text = enemyattack[atkdirection];
            enemyval = p.enemyatkinterval;
            label22.Text = p.placename;
            myval = myatkinterval;
            enemyhp = p.enemymaxhp * (death_of_boss+1);
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = true;
            label26.Text = "";
            label27.Visible = false;
            timer1.Start();
            timer2.Start();
        }

        private void nextlevelvis()
        {
            mode = 3;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label5.Text = maxhp.ToString();
            label3.Text = hp.ToString();
            label15.Text = weapen;
            label13.Text = atk.ToString();
            if(experience>=100)
            {
                MessageBox.Show("经过这次战斗，你仿佛感觉自己变强了");
                experience -= 100;
                level++;
                maxhp += 50;
                hp = maxhp;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {          

            switch(e.KeyCode)
            {
                case Keys.W:
                    {
                        bton[0].PerformClick();
                        break;
                    }
                case Keys.A:
                    {
                        bton[1].PerformClick();
                        break;
                    }
                case Keys.D:
                    {
                        bton[2].PerformClick();
                        break;
                    }
                case Keys.S:
                    {
                        bton[3].PerformClick();
                        break;
                    }
                case Keys.Z:
                    {
                        bton[4].PerformClick();
                        break;
                    }
                case Keys.C:
                    {
                        bton[5].PerformClick();
                        break;
                    }
            }
        }

        private void button9_Click(object sender, EventArgs e)                              //商店
        {
            if(button9.Text == "商店")
            {
                label24.Text = gold.ToString();
                button9.Text = "返回";
                button10.Visible = false;
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label15.Visible = true;
                label16.Text = "血瓶                 回复所有生命值";
                label17.Text = "生锈武士刀                 30攻击力";
                label18.Text = "铁剑                             40攻击力";
                label19.Text = "青金工剑                     70攻击力";
                label20.Text = "黯灭                             90攻击力";
                label21.Text = "蝴蝶                            120攻击力";
                label27.Text = "无尽之剑                   300攻击力";
                button11.Text = "200金币";
                button12.Text = "600金币";
                button13.Text = "800金币";
                button14.Text = "1800金币";
                button15.Text = "2600金币";
                button16.Text = "4000金币";
                button17.Text = "10000金币";
                button7.Visible = false;
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label24.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
                button14.Visible = true;
                button15.Visible = true;
                button16.Visible = true;
                if(infinityblade == 1)
                {
                    button17.Visible = true;
                    label27.Visible = true;
                }
            }
           else
            {
                button9.Text = "商店";
                nextlevelvis();
            }
        }

        private void button10_Click(object sender, EventArgs e)                            //背包
        {
            if(button10.Text =="背包")
            {
                label24.Text = gold.ToString();
                button10.Text = "返回";
                button7.Visible = false;
                button9.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label15.Visible = true;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label24.Visible = true;
                button11.Text = button12.Text = button13.Text = button14.Text = button15.Text = button16.Text = button17.Text = "装备";
                if (backpacklist[1] == 1)
                {
                    label17.Visible = true;
                    button12.Visible = true;
                }
                if (backpacklist[2] == 1)
                {
                    label18.Visible = true;
                    button13.Visible = true;
                }
                if (backpacklist[3] == 1)
                {
                    label19.Visible = true;
                    button14.Visible = true;
                }
                if (backpacklist[4] == 1)
                {
                    label20.Visible = true;
                    button15.Visible = true;
                }
                if (backpacklist[5] == 1)
                {
                    label21.Visible = true;
                    button16.Visible = true;
                }
                if (backpacklist[6] == 1)
                {
                    label27.Visible = true;
                    button17.Visible = true;
                }
            }
            else
            {
                button10.Text = "背包";
                nextlevelvis();
            }
        }

        private void button7_Click(object sender, EventArgs e)                           //每次按下一页的处理
        {
           
            switch(mode)
            {
                case 1:
                    {
                        if(p.npccheck=="1")
                        {
                            mode = 2;
                            label23.Text = p.npcname;
                            label23.Visible = true;
                            storyvis(p.npcsays);
                        }
                        else
                        {
                            if (p.next == null)
                            {
                                p = truehead.head;
                                place = 0;
                                generation++;
                            }
                            else
                            {
                                p = p.next;
                            }
                            if (placechk == 1)
                            {
                                place++;
                            }
                            mode = 1;
                            label23.Visible = false;
                            storyvis(p.surroundings);
                        }
                        break;
                    }
                case 2:
                    {
                        if (p.enemycheck == "1")
                        {
                            fightvis();
                        }
                        else
                        {
                            if(p.next == null)
                            {
                                p = truehead.head;
                                place = 0;
                                generation++;
                            }
                            else
                            {
                                p = p.next;
                            }
                            if (placechk == 1)
                            {
                                place++;
                            }
                            mode = 1;
                            label23.Visible = false;
                            storyvis(p.surroundings);
                        }
                        break;
                    }
                case 3:
                    {
                        if(p.next == null)
                        {
                            p = truehead.head;
                        }
                        else
                        {
                            if (placechk == 1)
                            {
                                place++;
                            }
                            p = p.next;
                        }
                        mode = 1;
                        label23.Visible = false;
                        storyvis(p.surroundings);
                        break;
                    }
            }
        }

        private int buy(int cost,int backpacknum)
        {
            if (gold >= cost)
            {
                if (backpacklist[backpacknum] == 1)
                {
                    MessageBox.Show("已经拥有该装备");
                }
                else
                {
                    backpacklist[backpacknum] = 1;
                    gold -= cost;
                    label24.Text = gold.ToString();
                    MessageBox.Show("购买成功");
                    return 1;
                }
            }
            else
            {
                MessageBox.Show("金钱不足");
            }
            return 0;
        }

        private void button11_Click(object sender, EventArgs e)                              //装备页面第一个
        {
            if(buy(200, 0) == 1)
            {
                hp = maxhp;
                MessageBox.Show("生命值已经回复");
                backpacklist[0] = 0;
                label24.Text = gold.ToString();
                label3.Text = hp.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(button12.Text == "装备")
            {
                atk = 30;
                weapen = "生锈武士刀";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(600, 1);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "装备")
            {
                atk = 40;
                weapen = "铁剑";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(800, 2);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button12.Text == "装备")
            {
                atk = 70;
                weapen = "青金工剑";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(1800, 3);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button12.Text == "装备")
            {
                atk = 90;
                weapen = "黯灭";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(2600, 4);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button12.Text == "装备")
            {
                atk = 120;
                weapen = "蝴蝶";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(4000, 5);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button12.Text == "装备")
            {
                atk = 300;
                weapen = "无尽之剑";
                label15.Text = weapen;
                label13.Text = atk.ToString();
            }
            else
            {
                buy(10000, 6);
            }
        }

        private void userload()
        {
            if(File.Exists(path+"user.txt")==true)
            {
                string[] userdata = File.ReadAllLines(path + "user.txt", Encoding.Default);
                generation = Convert.ToInt32(userdata[0]);
                experience = Convert.ToInt32(userdata[1]);
                level = Convert.ToInt32(userdata[2]);
                hp = Convert.ToInt32(userdata[3]);
                maxhp = Convert.ToInt32(userdata[4]);
                weapen = userdata[5];
                atk = Convert.ToInt32(userdata[6]);
                critrate = Convert.ToInt32(userdata[7]);
                gold = Convert.ToInt32(userdata[8]);
                myatkinterval = Convert.ToInt32(userdata[9]);
                death_of_boss = Convert.ToInt32(userdata[10]);
                backpacklist[0] = Convert.ToInt32(userdata[11]);
                backpacklist[1] = Convert.ToInt32(userdata[12]);
                backpacklist[2] = Convert.ToInt32(userdata[13]);
                backpacklist[3] = Convert.ToInt32(userdata[14]);
                backpacklist[4] = Convert.ToInt32(userdata[15]);
                backpacklist[5] = Convert.ToInt32(userdata[16]);
                backpacklist[6] = Convert.ToInt32(userdata[17]);
                place = Convert.ToInt32(userdata[18]);
                infinityblade = Convert.ToInt32(userdata[19]);
                critrate += level * 5;
                myatkinterval -= level * 50;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(path + "user.txt", generation.ToString() + "\r\n" + experience.ToString() + "\r\n" + level.ToString() + "\r\n" + hp.ToString() + "\r\n" + maxhp.ToString() + "\r\n" + weapen + "\r\n" + atk.ToString() + "\r\n" + critrate.ToString() + "\r\n" + gold.ToString() + "\r\n" + myatkinterval.ToString() + "\r\n" + death_of_boss.ToString() + "\r\n" + backpacklist[0].ToString() + "\r\n" + backpacklist[1].ToString() + "\r\n" + backpacklist[2].ToString() + "\r\n" + backpacklist[3].ToString() + "\r\n" + backpacklist[4].ToString() + "\r\n" + backpacklist[5].ToString() +"\r\n"+backpacklist[6].ToString()+ "\r\n" + place.ToString()+"\r\n"+infinityblade.ToString(),Encoding.Default);
        }

        private void storyload()
        {
            string[] txt = File.ReadAllLines(path + "storypage.txt", Encoding.Default);
            string[] way1 = File.ReadAllLines(path + "1.txt", Encoding.Default);
            string[] way2 = File.ReadAllLines(path + "2.txt", Encoding.Default);
            way2list.Append(way2[0], way2[1], way2[2], way2[3], way2[4], way2[5], Convert.ToInt32(way2[6]), Convert.ToInt32(way2[7]), Convert.ToInt32(way2[8]), Convert.ToInt32(way2[9]));
            for (int a = 1;a <(way2.Length/10);a++)
            {
                way2list.Append(way2[a * 10], way2[a * 10 + 1], way2[a * 10 + 2], way2[a * 10 + 3], way2[a * 10 + 4], way2[a * 10 + 5], Convert.ToInt32(way2[a * 10 + 6]), Convert.ToInt32(way2[a * 10 + 7]), Convert.ToInt32(way2[a * 10 + 8]), Convert.ToInt32(way2[a * 10 + 9]));
            }
            way1list.Append(way1[0], way1[1], way1[2], way1[3], way1[4], way1[5], Convert.ToInt32(way1[6]), Convert.ToInt32(way1[7]), Convert.ToInt32(way1[8]), Convert.ToInt32(way1[9]));
            p = way1list.head;
            for(int a = 1;a<(way1.Length/10);a++)
            {
                way1list.Append(way1[a * 10], way1[a * 10 + 1], way1[a * 10 + 2], way1[a * 10 + 3], way1[a * 10 + 4], way1[a * 10 + 5], Convert.ToInt32(way1[a * 10 + 6]), Convert.ToInt32(way1[a * 10 + 7]), Convert.ToInt32(way1[a * 10 + 8]), Convert.ToInt32(way1[a * 10 + 9]));
                p = p.next;
                if (p.anotherway == 2)
                {
                    p.another = way2list.head;
                }
                if (p.anotherway == 3)
                {
                    p.another = end1.head;
                }
            }
            estory.Append(txt[0], txt[1], txt[2], txt[3], txt[4], txt[5], Convert.ToInt32(txt[6]), Convert.ToInt32(txt[7]), Convert.ToInt32(txt[8]), Convert.ToInt32(txt[9]));
            p = estory.head;
            for (int a = 1; a < (txt.Length / 10); a++)
            {
                estory.Append(txt[a * 10], txt[a * 10 + 1], txt[a * 10 + 2], txt[a * 10 + 3], txt[a * 10 + 4], txt[a * 10 + 5], Convert.ToInt32(txt[a * 10 + 6]), Convert.ToInt32(txt[a * 10 + 7]), Convert.ToInt32(txt[a * 10 + 8]), Convert.ToInt32(txt[a * 10 + 9]));
                p = p.next;
                if (p.anotherway == 1)
                {
                    p.another = way1list.head;
                }
                if(p.anotherway == 3)
                {
                    p.another = end1.head;
                }
            }
            p = estory.head;
            p = p.next;
            p = p.next;
            truehead.head.next.next = p;
            if(generation == 0)
            {
                p = estory.head;
            }
            for(int a = 0;a<place;a++)
            {
                p = p.next;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myval -= 10;
            if(myval<=0)
            {
                myval = 0;
                buttonok();
            }
            else
            {
                buttonoff();
            }
            label10.Text = myval.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)         //敌人攻击时间
        {
            enemyval -= 10;
            if(enemyval >1000)
            {
                label11.ForeColor = Color.DeepSkyBlue;
            }
            else if (enemyval>600)
            {
                label11.ForeColor = Color.Goldenrod;
            }
            else if(enemyval>0)
            {
                label11.ForeColor = Color.Red;
            }
            else
            {
                truedamage = p.enemyatk + rand.Next(-10, 11);
                label25.Text = "-"+truedamage.ToString();
                hp -= truedamage;
                label3.Text = hp.ToString();
                label25.Visible = true;
                timer3.Start();
                if(hp<=0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    label11.Text = enemyval.ToString();
                    MessageBox.Show("复仇的机械永不停止，而你只是其中崩坏的一小块齿轮。你不知道你构成的机械最终铸造了什么，你只知道，你不能停下来。");
                    hp = maxhp;
                    p = truehead.head;
                    generation++;
                    label23.Visible = false;
                    storyvis(p.surroundings);
                    return;
                }
                label11.ForeColor = Color.DeepSkyBlue;
                atkdirection = rand.Next(0, 4);
                label14.Text = enemyattack[atkdirection];
                enemyval = p.enemyatkinterval;
            }          
            label11.Text = enemyval.ToString();
        }

        private void buttonok()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button1.BackColor = Color.YellowGreen;
            button2.BackColor = Color.YellowGreen;
            button3.BackColor = Color.YellowGreen;
            button4.BackColor = Color.YellowGreen;
            button5.BackColor = Color.LightBlue;
            button6.BackColor = Color.LightBlue;
        }

        private void buttonoff()
        {

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button1.BackColor = Color.Maroon;
            button2.BackColor = Color.Maroon;
            button3.BackColor = Color.Maroon;
            button4.BackColor = Color.Maroon;
            button5.BackColor = Color.Maroon;
            button6.BackColor = Color.Maroon;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label25.Visible = false;
            timer3.Stop();
        }


        private void timer4_Tick(object sender, EventArgs e)
        {
            label26.Visible = false;
            timer4.Stop();
        }

        private void hit(int myhit)
        {
            if (enemyval <= 800&& myhit == atkdirection)
            {
                enemyval = Convert.ToInt32(Convert.ToDouble(p.enemyatkinterval) * 1.5);
                label11.Text = enemyval.ToString();
                label11.Visible = true;
                label26.Text = "招架！";
                timer4.Start();
                atkdirection = rand.Next(0, 4);
                label14.Text = enemyattack[atkdirection];
                myval = Convert.ToInt32(Convert.ToDouble(myatkinterval) * 0.5);
                label10.Text = myval.ToString();
            }
            else
            {
                truedamage = atk + rand.Next(-10, 11);
                if (rand.Next(0, 101) < critrate)
                {
                    truedamage *= 2;
                }
                label26.Text = "-"+truedamage.ToString();
                label26.Visible = true;
                enemyhp -= truedamage;
                label7.Text = enemyhp.ToString();
                myval = myatkinterval;
                label10.Text = myval.ToString();
                timer4.Start();
                if (enemyhp <= 0)
                {
                    gold += rand.Next(40, 120)*(death_of_boss+1);
                    if(p.npcname == "神王")
                    {
                        gold += 1000 * (death_of_boss + 1);
                    }
                    experience += rand.Next(10, 50);
                    timer1.Stop();
                    timer2.Stop();
                    mode = 3;
                    label1.Text = "战斗胜利！";
                    nextlevelvis();
                }
            }
          

        }

        private void dodge(int dodgeway)
        {
            if(enemyval<=1000)
            {
                if (dodgeway != atkdirection)
                {
                    enemyval = Convert.ToInt32(Convert.ToDouble(p.enemyatkinterval) * 1.5);
                    label11.Text = enemyval.ToString();
                    atkdirection = rand.Next(0, 4);
                    label14.Text = enemyattack[atkdirection];
                    label26.Text = "miss！";
                    timer4.Start();
                    enemyval = p.enemyatkinterval;
                }
                myval = myatkinterval;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hit(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hit(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hit(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dodge(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dodge(3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            p = p.another;
            if(placechk == 1)
            {
                placechk = 0;
            }
            mode = 1;
            storyvis(p.surroundings);
        }
    }


    public class story
    {
        public string surroundings;
        public string npccheck;
        public string npcname;
        public string npcsays;
        public string placename;
        public string enemycheck;
        public int enemymaxhp;
        public int enemyatk;
        public int enemyatkinterval;
        public int anotherway;
        public story next;
        public story another;

        public story(string srod,string npc,string npcna,string says,string planame, string emychk,int hp,int atk,int interval,int way)
        {
            this.surroundings = srod;
            this.npccheck = npc;
            this.npcname = npcna;
            this.npcsays = says;
            this.placename = planame;
            this.enemycheck = emychk;
            this.enemymaxhp = hp;
            this.enemyatk = atk;
            this.enemyatkinterval = interval;
            this.anotherway = way;
            this.next = null;
            this.another = null;
        }

        public story()
        {
            this.next = null;
            this.another = null;
        }
    }

    public class storylist
    {
        public story head;

        public storylist()
        {
            head = null;
        }

        public void Append(string srod, string npc, string npcna, string says, string planame, string emychk, int hp, int atk, int interval,int way)
        {
            story foot = new story(srod, npc, npcna,says, planame,emychk, hp, atk, interval,way);
            story A = new story();
            if(head == null)
            {
                head = foot;
                return;
            }
            A = head;
            while(A.next!= null)
            {
                A = A.next;
            }
            A.next = foot;
        }
    }
}