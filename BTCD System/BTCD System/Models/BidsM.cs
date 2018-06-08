using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTCD_System.Models
{
    public class BidsM
    {
        public int BidId { get; set; }
        public int StockId { get; set; }
        public int RequestedBy { get; set; }
        public decimal RequestedQty { get; set; }
        public decimal RequestedPrice { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}