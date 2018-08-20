using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Resources;

namespace BillingSystem.Repository
{
    public class UserRepository
    {
        DBConnections db = new DBConnections();
        public string Login(string login, string password)
        {
            object[] objParam = { login, password };
            var d = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.ValidUserLoginCheck_USP, objParam);
            return Convert.ToString(d);
        }

        public List<UserModels> UserInformationDetailsGetByAll()
        {
            object[] objParam = { };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.UserInformationDetailsGetByAll_USP, objParam);
            return ConvertList.TableToList<UserModels>(d.Tables[0]);
        }

        public long UserInformationInsertUpdateDelete(UserModels mode)
        {
            object[] objParam = { mode.ActionId, mode.UniqueID, mode.UserName, mode.EmailID, mode.Password, mode.IsActive, mode.CreatedBy };
            var d = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.UserInformationInsertUpdateDelete_USP, objParam);
            return Convert.ToInt64(d);
        }
    }
}