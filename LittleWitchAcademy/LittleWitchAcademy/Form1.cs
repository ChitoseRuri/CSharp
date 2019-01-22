using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LittleWitchAcademy
{
    public partial class Form1 : Form
    {
        Graphics gc;
        Bitmap bmp = new Bitmap(1280, 720);
        Bitmap bmp2 = new Bitmap(1280, 720);
        Bitmap Role0, Role1, Role2, Role3;
        Graphics gc2, gc3;
        int[] Element = new int[6];
        int[] mousechk = new int[60];
        //初始存档设定
        int HP = 100, MP = 200, Lv = 1, MagicInterval = 800, Day = 1;
        //初始存档设定
        int menu = 0, MouseClickEnable = 1;
        int Circletimes = 0, XofCircle, YofCircle;
        Pen PenforCircle = new Pen(Color.Black, 2);
        Random rand = new Random();
        string path = Environment.CurrentDirectory;
        public Form1()
        {
            InitializeComponent();
            Role0 = new Bitmap(path + "/Picture/Role0.png");
            Role1 = new Bitmap(path + "/Picture/Role1.png");
            Role2 = new Bitmap(path + "/Picture/Role2.png");
            gc = this.CreateGraphics();
            gc2 = Graphics.FromImage(bmp);
            MainMenuFlash();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.CreateGraphics().DrawImage(bmp, 0, 0);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (menu)
            {
                case 0:
                    {
                        MainMenuMove();
                        break;
                    }
                case 1:
                    {

                        break;
                    }
                case 2:
                    {
                        FightVisMove();
                        break;
                    }
            }
            //  MessageBox.Show(this.PointToClient(Control.MousePosition).ToString());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (menu)
            {
                case 0:
                    {
                        MainMenuClick();
                        break;
                    }
                case 1:
                    {
                        FightVisClick();
                        break;
                    }
            }
        }

        private void MainMenuFlash()
        {
            Brush CColor = new SolidBrush(Color.Black);
            Bitmap b = new Bitmap(path + "/Picture/mainmenu.bmp");
            gc2.DrawImage(b, 0, 0);
            gc2.DrawString("开始冒险", new Font("宋体", 28, FontStyle.Bold), CColor, new PointF(150, 550));
            gc2.DrawString("退出游戏", new Font("宋体", 28, FontStyle.Bold), CColor, new PointF(150, 600));
        }

        private void MainMenuMove()
        {
            Brush blue = new SolidBrush(Color.SkyBlue);
            Brush black = new SolidBrush(Color.Black);
            if (this.PointToClient(Control.MousePosition).X > 150 && this.PointToClient(Control.MousePosition).X < 325 && this.PointToClient(Control.MousePosition).Y > 550 && this.PointToClient(Control.MousePosition).Y < 597)
            {
                if (mousechk[0] != 1)
                {
                    gc.DrawString("开始冒险", new Font("宋体", 28, FontStyle.Bold), blue, new PointF(150, 550));
                    gc.DrawString("退出游戏", new Font("宋体", 28, FontStyle.Bold), black, new PointF(150, 600));
                    mousechk[0] = 1;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X > 150 && this.PointToClient(Control.MousePosition).X < 325 && this.PointToClient(Control.MousePosition).Y > 600 && this.PointToClient(Control.MousePosition).Y < 647)
            {
                if (mousechk[0] != 2)
                {
                    gc.DrawString("开始冒险", new Font("宋体", 28, FontStyle.Bold), black, new PointF(150, 550));
                    gc.DrawString("退出游戏", new Font("宋体", 28, FontStyle.Bold), blue, new PointF(150, 600));
                    mousechk[0] = 2;
                }
            }
            else
            {
                if (mousechk[0] != 0)
                {
                    this.CreateGraphics().DrawImage(bmp, 0, 0);
                    mousechk[0] = 0;
                }
            }
        }

        private void MainMenuClick()
        {
            if (this.PointToClient(Control.MousePosition).X > 150 && this.PointToClient(Control.MousePosition).X < 325 && this.PointToClient(Control.MousePosition).Y > 550 && this.PointToClient(Control.MousePosition).Y < 597)
            {
                menu = 1;
                gc.Clear(BackColor);
                StoryVisFlash();
                this.CreateGraphics().DrawImage(bmp, 0, 0);
            }
            else if (this.PointToClient(Control.MousePosition).X > 150 && this.PointToClient(Control.MousePosition).X < 325 && this.PointToClient(Control.MousePosition).Y > 600 && this.PointToClient(Control.MousePosition).Y < 647)
            {
                Application.Exit();
            }
        }

        private void DayCheckFlash()
        {

        }

        private void DayCheckMove()
        {

        }

        private void DayCheckClick()
        {

        }

        private void EventFlash()
        {

        }

        private void EventMove()
        {

        }

        private void EventClick()
        {

        }

        private void FightVisFlash()
        {
            gc2.Clear(BackColor);
            //字圈
            gc2.DrawEllipse(new Pen(Color.Black, 2), 900, 300, 300, 300);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 875, 275, 350, 350);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 980, 380, 140, 140);
            //外线
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1018, 275, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1013, 270, 70, 70);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1150, 485, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1145, 480, 70, 70);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 890, 485, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 885, 480, 70, 70);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1147, 350, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1142, 345, 70, 70);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 893, 350, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 888, 345, 70, 70);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1020, 565, 60, 60);
            gc2.DrawEllipse(new Pen(Color.Black, 2), 1015, 560, 70, 70);
            //内线
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 300, 920.096f, 525);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 300, 1179.9038f, 525);
            gc2.DrawLine(new Pen(Color.Black, 2), 920.096f, 525, 1179.9038f, 525);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 600, 920.096f, 375);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 600, 1179.9038f, 375);
            gc2.DrawLine(new Pen(Color.Black, 2), 920.096f, 375, 1179.9038f, 375);
            //内圈
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 310, 928.756f, 520);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 310, 1171.2438f, 520);
            gc2.DrawLine(new Pen(Color.Black, 2), 928.756f, 520, 1171.2438f, 520);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 590, 928.756f, 380);
            gc2.DrawLine(new Pen(Color.Black, 2), 1050, 590, 1171.2438f, 380);
            gc2.DrawLine(new Pen(Color.Black, 2), 928.756f, 380, 1171.2438f, 380);
            gc2.DrawString("火", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(1013, 275));
            gc2.DrawString("雷", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(1148, 490));
            gc2.DrawString("冰", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(888, 490));
            gc2.DrawString("光", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(888, 350));
            gc2.DrawString("暗", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(1143, 352));
            gc2.DrawString("魂", new Font("宋体", 40, FontStyle.Regular), new SolidBrush(Color.Black), new Point(1015, 568));
            //施法
            gc2.DrawString("Drawn from\ndeep within", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.Black), new Point(985, 425));
            //人设
            Bitmap DimalPainting = new Bitmap(path + "/Picture/Role2.png");
            gc2.DrawImage(DimalPainting, 0, 200);
            //HPMP
            gc2.DrawString("HP", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.Red), new Point(0, 0));
            gc2.DrawString("1000", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.Red), new Point(260, 0));
            gc2.FillRectangle(new SolidBrush(Color.Red), 50, 00, 200, 20);
            gc2.DrawString(HP.ToString(), new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.Black), new Point(55, 0));
            gc2.DrawString("MP", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.SkyBlue), new Point(0, 20));
            gc2.DrawString("2000", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.SkyBlue), new Point(260, 20));
            gc2.FillRectangle(new SolidBrush(Color.SkyBlue), 50, 20, 200, 20);
            gc2.DrawString(MP.ToString(), new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.Black), new Point(55, 20));
        }

        private void FightVisMove()
        {
            if (this.PointToClient(Control.MousePosition).X >= 1013 && this.PointToClient(Control.MousePosition).X <= 1093 && this.PointToClient(Control.MousePosition).Y >= 273 && this.PointToClient(Control.MousePosition).Y <= 355)
            {
                if (mousechk[2] != 1)
                {
                    gc.DrawString("火", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.Red), new Point(1013, 275));
                    mousechk[2] = 1;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1145 && this.PointToClient(Control.MousePosition).X <= 1225 && this.PointToClient(Control.MousePosition).Y >= 500 && this.PointToClient(Control.MousePosition).Y <= 580)
            {
                if (mousechk[2] != 2)
                {
                    gc.DrawString("雷", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.DarkViolet), new Point(1148, 490));
                    mousechk[2] = 2;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 888 && this.PointToClient(Control.MousePosition).X <= 968 && this.PointToClient(Control.MousePosition).Y >= 500 && this.PointToClient(Control.MousePosition).Y <= 580)
            {
                if (mousechk[2] != 3)
                {
                    gc.DrawString("冰", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.SkyBlue), new Point(888, 490));
                    mousechk[2] = 3;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 888 && this.PointToClient(Control.MousePosition).X <= 968 && this.PointToClient(Control.MousePosition).Y >= 350 && this.PointToClient(Control.MousePosition).Y <= 430)
            {
                if (mousechk[2] != 4)
                {
                    gc.DrawString("光", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.Goldenrod), new Point(888, 350));
                    mousechk[2] = 4;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1145 && this.PointToClient(Control.MousePosition).X <= 1225 && this.PointToClient(Control.MousePosition).Y >= 355 && this.PointToClient(Control.MousePosition).Y <= 435)
            {
                if (mousechk[2] != 5)
                {
                    gc.DrawString("暗", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.DarkGray), new Point(1143, 352)); ;
                    mousechk[2] = 5;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1013 && this.PointToClient(Control.MousePosition).X <= 1093 && this.PointToClient(Control.MousePosition).Y >= 575 && this.PointToClient(Control.MousePosition).Y <= 655)
            {
                if (mousechk[2] != 6)
                {
                    gc.DrawString("魂", new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.DeepPink), new Point(1015, 568));
                    mousechk[2] = 6;
                }
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1000 && this.PointToClient(Control.MousePosition).X <= 1100 && this.PointToClient(Control.MousePosition).Y >= 400 && this.PointToClient(Control.MousePosition).Y <= 500)
            {
                if (mousechk[2] != 7)
                {
                    gc.DrawString("Drawn from\ndeep within", new Font("华文隶书", 20, FontStyle.Regular), new SolidBrush(Color.MediumPurple), new Point(985, 425));
                    mousechk[2] = 7;
                }
            }
            else
            {
                if (mousechk[2] != 0)
                {
                    this.CreateGraphics().DrawImage(bmp, 0, 0);
                    mousechk[2] = 0;
                }
            }
        }

        private void FightVisClick()
        {
            if (this.PointToClient(Control.MousePosition).X >= 1013 && this.PointToClient(Control.MousePosition).X <= 1093 && this.PointToClient(Control.MousePosition).Y >= 273 && this.PointToClient(Control.MousePosition).Y <= 355)
            {
                XofCircle = 998;
                YofCircle = 255;
                PenforCircle.Color = Color.Red;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1145 && this.PointToClient(Control.MousePosition).X <= 1225 && this.PointToClient(Control.MousePosition).Y >= 500 && this.PointToClient(Control.MousePosition).Y <= 580)
            {
                XofCircle = 1130;
                YofCircle = 465;
                PenforCircle.Color = Color.DarkViolet;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 888 && this.PointToClient(Control.MousePosition).X <= 968 && this.PointToClient(Control.MousePosition).Y >= 500 && this.PointToClient(Control.MousePosition).Y <= 580)
            {
                XofCircle = 870;
                YofCircle = 465;
                PenforCircle.Color = Color.SkyBlue;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 888 && this.PointToClient(Control.MousePosition).X <= 968 && this.PointToClient(Control.MousePosition).Y >= 350 && this.PointToClient(Control.MousePosition).Y <= 430)
            {
                XofCircle = 873;
                YofCircle = 330;
                PenforCircle.Color = Color.Goldenrod;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1145 && this.PointToClient(Control.MousePosition).X <= 1225 && this.PointToClient(Control.MousePosition).Y >= 355 && this.PointToClient(Control.MousePosition).Y <= 435)
            {
                XofCircle = 1127;
                YofCircle = 330;
                PenforCircle.Color = Color.DarkGray;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1013 && this.PointToClient(Control.MousePosition).X <= 1093 && this.PointToClient(Control.MousePosition).Y >= 575 && this.PointToClient(Control.MousePosition).Y <= 655)
            {
                XofCircle = 1000;
                YofCircle = 545;
                PenforCircle.Color = Color.DeepPink;
                Circletimes = 20;
                timer1.Start();
            }
            else if (this.PointToClient(Control.MousePosition).X >= 1000 && this.PointToClient(Control.MousePosition).X <= 1100 && this.PointToClient(Control.MousePosition).Y >= 400 && this.PointToClient(Control.MousePosition).Y <= 500)
            {
                XofCircle = 1000;
                YofCircle = 400;
                PenforCircle.Color = Color.MediumPurple;
                Circletimes = 20;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Circletimes > 0)
            {
                this.CreateGraphics().DrawImage(bmp, 0, 0);
                gc.DrawEllipse(PenforCircle, XofCircle - Circletimes * 5, YofCircle - Circletimes * 5, 100 + Circletimes * 10, 100 + Circletimes * 10);
                Circletimes--;
            }
            else
            {
                Circletimes = 20;
                this.CreateGraphics().DrawImage(bmp, 0, 0);
                timer1.Stop();
            }
        }  //魔法阵点击特效

        private void StoryVisFlash()
        {
            gc2.Clear(BackColor);
            gc2.DrawImage(new Bitmap(path + "/Picture/bedroom.jpg"), 0, 0);
            gc2.FillRectangle(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), 250, 400, 1000, 270);
            gc2.DrawImage(Role2, 0, 200);
            gc2.DrawString("啊，今天天气真好啊~\nhahahahahaaahahahaha\nkkkkkkkkkkk\nDDDDDD", new Font("宋体", 25, FontStyle.Regular), new SolidBrush(Color.White), 400, 430);

        }
    }

    public class story
    {
        public string Backgroundimage;
        public string EnemyCheck;
        public string EnemySay;
        public int EnemyMaxHp;
        public int EnemyAttack;
        public int EnemyArrackInterval;
        public int anotherway;
        public story next;
        public story another;

        public story(string srod, string emychk, string says, int hp, int atk, int interval, int way)
        {
            this.Backgroundimage = srod;
            this.EnemySay = says;
            this.EnemyCheck = emychk;
            this.EnemyMaxHp = hp;
            this.EnemyAttack = atk;
            this.EnemyArrackInterval = interval;
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


    }
}
