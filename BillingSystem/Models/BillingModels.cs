using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class BillingModels
    {
        public long ActionId { get; set; }
        public long UniqueID { get; set; }
        public long ClientUniqueID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public long CompanyUniqueID { get; set; }
        public string CompanyGSTNumber { get; set; }
        public string CompanyAddress { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public string ClientGSTNumber { get; set; }
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
        public string ModeOfTransport { get; set; }
        public string VehicleNumber { get; set; }
        public string PlaceOfSupply { get; set; }
        public decimal FreightCharge { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public int BillTypeID { get; set; }
        public string BillType { get; set; }
        public string GSTType { get; set; }
        public int GSTTypeID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
        public List<BillingLineModels> BillLines { get; set; }
        public BillingLineModels Line { get; set; }
        public string CGSTWords { get; set; }
        public string SGSTWords { get; set; }
        public string IGSTWords { get; set; }
        public string TotalWords { get; set; }
        public decimal LoadingCharges { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal RoundOff { get; set; }
        public decimal TSC { get; set; }
        public decimal GrandTotal { get; set; }
    }
}