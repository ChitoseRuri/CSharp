using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    enum Protocal : Int32
    {
        Sale,
        Check,
        UpdateBegin,
        Update,
        UpdateEnd,
        Same,
        Login
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

    // Login 客户端发送
    // 4 int 协议
    // 4 登录类型
    // 4 int 名称长度
    // string 名称
    // 4 int 密码长度
    // string 密码

    // Login 服务器发送
    // 4 int 协议
    // 1 bool 登录是否成功

    enum Character:Int32
    {
        Admin,
        Assistant
    }
}
