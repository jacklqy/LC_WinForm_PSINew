using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXPSIApp.FModels
{
    /// <summary>
    /// 传入付款页面的实体
    /// </summary>
    public class PayModel
    {
        /// <summary>
        /// 收款或付款
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 收款或付款页面 
        /// </summary>
        public XtraForm FGet { get; set; }
        /// <summary>
        ///付款账户文本框付款信息
        /// </summary>
        public string StrPayFor { get; set; }
    }
}
