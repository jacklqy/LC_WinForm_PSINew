using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.UIModels
{
        /// <summary>
        /// 审核下拉框项的实体
        /// </summary>
        public class CheckModel
        {
                /// <summary>
                /// 审核状态值
                /// </summary>
                public int CheckId { get; set; }
                /// <summary>
                /// 审核状态说明
                /// </summary>
                public string CheckState { get; set; }
        }
}
