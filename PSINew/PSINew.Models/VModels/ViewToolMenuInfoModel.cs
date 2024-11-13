using Common.CustomAttributes;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// ViewToolMenuInfos视图的实体类
    /// </summary>
    [Table("ViewToolMenuInfos")]
    [PrimaryKey("TMenuId")]
    public class ViewToolMenuInfoModel:ToolMenuInfoModel
    {
        public string TGroupName { get; set; }
    }
}
