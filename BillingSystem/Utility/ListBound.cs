using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillingSystem.Models;
using BillingSystem.Repository;
namespace Utility
{
    public class ListBound
    {
        public SelectList Company;
        public SelectList Client;
        
        public ListBound(object SLvalue, string type)
        {
            switch (type)
            {
                case "Company":
                    Company = new SelectList((new BillingRepository().GetCompanyDetailsByAll(0)), "UniqueID", "CompanyName");
                    break;
                case "Client":
                    Client = new SelectList((new BillingRepository().GetClientDetailsByAll(0)), "UniqueID", "ClientName");
                    break;
                default:
                    // commisionTypeSL = new SelectList(commisionType);
                    break;
            }
        }
    }

}
