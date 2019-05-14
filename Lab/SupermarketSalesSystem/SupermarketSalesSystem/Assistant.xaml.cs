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
using CR;

namespace SupermarketSalesSystem
{
    /// <summary>
    /// Assistant.xaml 的交互逻辑
    /// </summary>
    public partial class Assistant : Window
    {
        private Socket m_Socket;
        private string m_ItemPath;
        private List<Item> m_Items;
        private int m_TotalPrice;
        public Assistant(Socket socket)
        {
            InitializeComponent();
            m_Socket = socket;
            Initial();
        }

        private void Initial()
        {
            m_TotalPrice = 0;
            m_ItemPath = "item.data";
            // 检查更新
            if (!File.Exists(m_ItemPath))
            {
                File.WriteAllLines(m_ItemPath, new string[]
                {
                    "0"//版本号
                });
            }
            var ft = File.OpenText(m_ItemPath);
            byte[] buffer = new byte[1024];
            Tools.AddToBytes(buffer, 0, (int)Protocal.Check);
            Tools.AddToBytes(buffer, 4, int.Parse(ft.ReadLine()));
            ft.Close();
            m_Socket.Send(buffer); // 检查版本号
            m_Socket.Receive(buffer);
            Protocal type = (Protocal)Tools.BytesToInt32(buffer, 0);
            switch (type)
            {
                case Protocal.UpdateBegin:
                    {
                        int fsize = Tools.BytesToInt32(buffer, 4);
                        int times = Tools.BytesToInt32(buffer, 8);
                        var fw = File.OpenWrite(m_ItemPath);
                        m_Socket.Receive(buffer);
                        while(--times != 0)
                        {
                            fw.Write(buffer, 8, 1016);
                            m_Socket.Receive(buffer);
                        }
                        fw.Write(buffer, 8, fsize % 1016);
                        fw.Close();
                    }
                    break;
            }
            // 装载货物列表
            m_Items = new List<Item>();
            ft = File.OpenText(m_ItemPath);
            ft.ReadLine();
            while(!ft.EndOfStream)
            {
                m_Items.Add(new Item(
                    int.Parse(ft.ReadLine()),
                    ft.ReadLine(),
                    int.Parse(ft.ReadLine()),
                    int.Parse(ft.ReadLine()),
                    int.Parse(ft.ReadLine())
                    ));
            }
            ft.Close();
        }

        private void M_AddItem_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(m_ItemIDText.Text, out id))
            {
                foreach (Item item in m_Items)
                {
                    if(item.id == id)
                    {
                        m_ListID.Items.Add(id);
                        m_ListName.Items.Add(item.name);
                        m_ListPrice.Items.Add(item.price);
                        m_TotalPrice += item.price;
                        m_TotalPriceLabel.Content = @"合计：" + m_TotalPrice.ToString();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("非法输入！", "ID错误");
            }
        }

        /// <summary>
        /// 结账按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(m_GetPriceText.Text,out int getPrice))
            {
                int returnPrice = getPrice - m_TotalPrice;
                if(returnPrice >= 0)
                {
                    MessageBox.Show(returnPrice.ToString(), @"找零");
                    m_ListID.Items.Clear();
                    m_ListName.Items.Clear();
                    m_ListPrice.Items.Clear();
                    m_GetPriceText.Text = "";
                    m_ItemIDText.Text = "";
                    m_TotalPriceLabel.Content = "0";
                }
                else
                {
                    MessageBox.Show("付款不足！");
                }
            }
            else
            {
                MessageBox.Show("错误的收款额！");
            }
        }
    }
}
