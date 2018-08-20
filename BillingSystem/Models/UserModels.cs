using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class UserModels
    {
        public long ActionId { get; set; }
        public long UniqueID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
        public int LoginAttempt { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
    }
}