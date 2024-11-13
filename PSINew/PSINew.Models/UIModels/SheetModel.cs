using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.UIModels
{
    public  class SheetModel
    {
        public int ShTypeId { get; set; }
        public string ShTypeName { get; set; }
        public int ParentId { get; set; }
    }
}
