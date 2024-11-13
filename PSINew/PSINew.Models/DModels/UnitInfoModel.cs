using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 往来单位信息实体
    /// </summary>
    [Serializable]
    [Table("UnitInfos")]
    [PrimaryKey("UnitId")]
    public class UnitInfoModel
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
        /// UnitProperties
        /// </summary>		
        public string UnitProperties { get; set; }
        /// <summary>
        /// RegionId
        /// </summary>		
        public int RegionId{ get; set; }
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
        /// PhoneNumber
        /// </summary>		
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Telephone
        /// </summary>		
        public string Telephone { get; set; }
        /// <summary>
        /// Fax
        /// </summary>		
        public string Fax { get; set; }
        /// <summary>
        /// Email
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// PostalCode
        /// </summary>		
        public string PostalCode { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// IsNoVail
        /// </summary>		
        public int IsNoVail { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
    }
}
