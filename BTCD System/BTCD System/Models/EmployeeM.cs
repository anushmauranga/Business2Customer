using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTCD_System.Models
{
    public class EmployeeM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public int LocationId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public string Email { get; set; }
        public string NICNo { get; set; }
        public string Dob { get; set; }
    }
}