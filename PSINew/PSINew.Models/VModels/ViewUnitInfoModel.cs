using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// ViewUnitInfos视图的实体类
    /// </summary>
    [Table("ViewUnitInfos")]
    [PrimaryKey("UnitId")]
    public class ViewUnitInfoModel
    {
        /// <summary>
        /// UnitId
        /// </summary>		
        public int UnitId { get; set; }
        /// <summary>
        /// UnitName
        /// </summary>		
        public string UnitName { get; set; }
        /// <summary>
        /// UnitPYNo
        /// </summary>		
        public string UnitPYNo { get; set; }
        /// <summary>
        /// UTypeId
        /// </summary>		
        public int UTypeId { get; set; }
        /// <summary>
        /// UTypeName
        /// </summary>		
        public string UTypeName { get; set; }
        /// <summary>
        /// UnitProperties
        /// </summary>		
        public string UnitProperties { get; set; }
        /// <summary>
        /// RegionId
        /// </summary>		
        public int RegionId { get; set; }
        /// <summary>
        /// Address
        /// </summary>		
        public string Address { get; set; }
        /// <summary>
        /// FullAddress
        /// </summary>		
        public string FullAddress { get; set; }
        /// <summary>
        /// UnitNo
        /// </summary>		
        public string UnitNo { get; set; }
        /// <summary>
        /// ContactPerson
        /// </summary>		
        public string ContactPerson { get; set; }
        /// <summary>
        /// IsNoVail
        /// </summary>
        public int IsNoVail { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public int IsDeleted { get; set; }
    }
}
