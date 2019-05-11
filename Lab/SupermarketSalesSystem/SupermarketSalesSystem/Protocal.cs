using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSalesSystem
{
    enum Protocal: Int32
    {
        Sale,
        Check,
        Update
    }

    // Sale
    // 4 int 协议
    // 4 int 货物ip
    // 4 int 销售数量

    // Check
    // 4 int 协议
    // 8 int64 版本号 

    // Update
    // 4 int 协议
    // 4 int 当前包号
    // 1016 数据流
}
