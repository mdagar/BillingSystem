using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class ClientModels
    {
        public long UniqueID { get; set; }
        public string ClientName { get; set; }
        public string GSTNumber { get; set; }
        public string BillingAddress { get; set; }
        public string BillingStateCode { get; set; }
        public string BillingStateName { get; set; }
        public string BillingCityName { get; set; }
        public string BillingPinCode { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingStateName { get; set; }
        public string ShippingStateCode { get; set; }
        public string ShippingCityName { get; set; }
        public string ShippingPinCode { get; set; }
        public long ParentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }

    }
}