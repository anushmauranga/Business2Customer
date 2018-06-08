using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTCD_System.Models
{
    public class CustomerRequirmentM
    {
        public int RequirementId { get; set; }
        public int ItemId { get; set; }
        public int GradeId { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal RequiredQty { get; set; }
        public decimal RequiredPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}