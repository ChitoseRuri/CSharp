using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalSystem
{
    enum Protocal : Int32
    {
        Sale,
        Check,
        UpdateBegin,
        Update, 
        UpdateEnd,
        Same
    }

    // Sale
    // 4 int 协议
    // 4 int 货物ip
    // 4 int 销售数量

    // Check
    // 4 int 协议
    // 8 int64 版本号 

    // UpdateBegin
    // 4 int 文件长度
    // 4 int 分包总数

    // Update
    // 4 int 协议
    // 4 int 当前包号
    // 1016 数据流

    class Item
    {
        public int ip;
        public string name;
        public int maxCount;
        public int saleCount;
        public int price;
        public Item(int _ip,string _name,int _maxCount,int _saleCount, int _price)
        {
            ip = _ip;
            name = _name;
            maxCount = _maxCount;
            saleCount = _saleCount;
            price = _price;
        }
    }
}
