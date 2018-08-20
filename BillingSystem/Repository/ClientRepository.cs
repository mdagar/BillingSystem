using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Resources;

namespace BillingSystem.Repository
{
    public class ClientRepository
    {
        DBConnections db = new DBConnections();
        public string ClientInformationDetailsInsertUpdateDelete(ClientModels mode)
        {
            object[] objParam = { mode.UniqueID, mode.ClientName, mode.GSTNumber, mode.BillingAddress,mode.BillingStateCode,mode.BillingStateName,mode.BillingCityName,
                                    mode.BillingPinCode,mode.ShippingAddress, mode.ShippingStateName, mode.ShippingStateCode,mode.ShippingCityName,mode.ShippingPinCode, mode.ParentId, mode.IsActive, mode.CreatedBy };
            var d = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.ClientInformationDetailsInsertUpdateDelete_USP, objParam);
            return Convert.ToString(d);
        }

        public List<ClientModels> ClientInformationDetailsGetByAll()
        {
            object[] objParam = { };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.ClientInformationDetailsGetByAll_USP, objParam);
            return ConvertList.TableToList<ClientModels>(d.Tables[0]);
        }
    }
}