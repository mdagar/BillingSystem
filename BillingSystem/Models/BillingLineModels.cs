using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class BillingLineModels
    {
        public long UniqueID { get; set; }
        public long BillingUniqueID { get; set; }
        public string DescriptionOfGoods { get; set; }
        public string Description { get; set; }
        public string HSNCode { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
    }
}