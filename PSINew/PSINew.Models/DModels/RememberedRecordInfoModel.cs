using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.DModels
{
    [Table("RememberedRecords")]
    [PrimaryKey("Id")]
    public  class RememberedRecordInfoModel
    {
        /// <summary>
        /// Id
        /// </summary>		

        public int Id { get; set; }

        /// <summary>
        /// LoginIP
        /// </summary>		
        public string LoginIP { get; set; }
        /// <summary>
        /// UserName
        /// </summary>		
        public string UserName { get; set; }
        /// <summary>
        /// UserRealPwd
        /// </summary>		
        public string UserRealPwd { get; set; }
        /// <summary>
        /// ReOrder
        /// </summary>		
        public int ReOrder { get; set; }
    }
}
