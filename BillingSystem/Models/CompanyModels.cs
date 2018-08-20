using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class CompanyModels
    {
        public long UniqueID { get; set; }
        public string CompanyName { get; set; }
        public string GSTNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public long ParentId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
        public byte[] UploadFile { get; set; }
        public HttpPostedFileBase FileUpload { get; set; }

    }
}