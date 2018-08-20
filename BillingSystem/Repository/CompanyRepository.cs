using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Resources;

namespace BillingSystem.Repository
{
    public class CompanyRepository
    {
        DBConnections db = new DBConnections();
        public string CompanyInformationDetailsInsertUpdateDelete(CompanyModels mode)
        {
            object[] objParam = { mode.UniqueID, mode.CompanyName, mode.GSTNumber, mode.CompanyAddress, mode.UploadFile, mode.StateName, mode.CityName, mode.PinCode, mode.ParentId, mode.ContactNo, mode.EmailID, mode.BankName, mode.AccountNumber, mode.IFSCCode, mode.IsActive, mode.CreatedBy };
            var d = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.CompanyInformationDetailsInsertUpdateDelete_USP, objParam);
            return Convert.ToString(d);
        }


        public List<CompanyModels> CompanyInformationDetailsGetByAll()
        {
            object[] objParam = { };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.CompanyInformationDetailsGetByAll_USP, objParam);
            return ConvertList.TableToList<CompanyModels>(d.Tables[0]);
        }
    }
}