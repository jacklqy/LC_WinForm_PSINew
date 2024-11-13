using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXPSIApp.FModels
{
    /// <summary>
    /// 主要用于列表页面向信息页面传值
    /// </summary>
    public class FInfoData
    {
        //操作类型标识值
        public int ActType { get; set; }
        //主键值
        public int FId { get; set; }
        //系统操作者账号
        public string UName { get; set; }
        //用于刷新列表页面的委托
        public Action ReLoad { get; set; }
    }
}
