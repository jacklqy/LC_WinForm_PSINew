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
    /// ViewMenuInfos视图的实体类
    /// </summary>
    [Table("ViewMenuInfos")]
    [PrimaryKey("MId")]
    public class ViewMenuInfoModel:MenuInfoModel
    {
        public string ParentName { get; set; }
    }
}
