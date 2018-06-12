using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTCD_System.Models
{
    public class StockM
    {
        public int StockId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int GradeId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainQuantity { get; set; }
        public int UOMId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}