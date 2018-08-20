using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Resources;
using System.Data;

namespace BillingSystem.Repository
{
    public class BillingRepository
    {
        DBConnections db = new DBConnections();
        public string BillingDetailsInsertUpdateDelete(BillingModels mode)
        {
            decimal TotalValue = 0;
            decimal LoadingCharges = 0;
            decimal TaxableAmount = 0;
            decimal CGST = 0;
            decimal SGST = 0;
            decimal IGST = 0;
            long GrandTotal = 0;
            if (mode.UniqueID > 0)
            {
                mode.ActionId = 1;
            }
            object[] objParamBill = { mode.ActionId, mode.UniqueID, "", mode.CompanyUniqueID, mode.ClientUniqueID,mode.BillingAddress,mode.BillingStateCode,mode.BillingStateName,mode.BillingCityName, mode.BillingPinCode,
                                        mode.ShippingAddress,mode.ShippingStateCode, mode.ShippingStateName, mode.ShippingCityName, mode.ShippingPinCode, DateTime.Now,mode.ModeOfTransport,mode.VehicleNumber,mode.PlaceOfSupply
                                    ,mode.FreightCharge,mode.BillTypeID,mode.GSTTypeID, mode.IsActive, mode.CreatedBy };
            var d = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.BillingDetailsInsertUpdateDelete, objParamBill);
            if (Convert.ToInt64(d) > 0)
            {
                foreach (var v in mode.BillLines)
                {
                    TotalValue = TotalValue + (v.Quantity * v.Rate);
                    if (v.UniqueID > 0)
                    {
                        mode.ActionId = v.UniqueID;
                        object[] objParamLines = { mode.ActionId, mode.UniqueID, Convert.ToInt64(d), v.DescriptionOfGoods, v.Description, v.HSNCode,v.Quantity,v.Unit
                                                 ,v.Rate, !v.IsActive, mode.CreatedBy };
                        var line = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.BillingLineDetailsInsertUpdateDelete, objParamLines);
                    }
                    else
                    {
                        if (!v.IsActive)
                        {
                            mode.ActionId = 0;
                            object[] objParamLines = { mode.ActionId, mode.UniqueID, Convert.ToInt64(d), v.DescriptionOfGoods, v.Description, v.HSNCode,v.Quantity,v.Unit
                                                 ,v.Rate, !v.IsActive, mode.CreatedBy };
                            var line = SqlHelper.ExecuteScalar(db.GetConnection(), Procedures.BillingLineDetailsInsertUpdateDelete, objParamLines);
                        }
                    }
                }

                TaxableAmount = TotalValue + mode.FreightCharge;
                string values = CalculateTotalValues(TaxableAmount);
                if (mode.GSTTypeID == 1)
                {
                    CGST = Convert.ToDecimal(values.Split('$')[0]);
                    SGST = Convert.ToDecimal(values.Split('$')[1]);
                    IGST = 0;
                    GrandTotal = Convert.ToInt64(Math.Round((Convert.ToDecimal(values.Split('$')[0]) + Convert.ToDecimal(values.Split('$')[1]) + Convert.ToDecimal(values.Split('$')[3])), 0));
                }
                else
                {
                    CGST = 0;
                    SGST = 0;
                    IGST = Convert.ToDecimal(values.Split('$')[2]);
                    GrandTotal = Convert.ToInt64(Math.Round((Convert.ToDecimal(values.Split('$')[2]) + Convert.ToDecimal(values.Split('$')[3])), 0));
                }
                CalculateTotalValuesUpdate(Convert.ToInt64(d), LoadingCharges, TaxableAmount, CGST, SGST, IGST, 0, 0, GrandTotal);
            }
            return Convert.ToString(d);
        }

        public string CalculateTotalValues(decimal Value)
        {
            var result = (decimal)(((decimal)(Value) * 9 / 100)) + "$" + (decimal)(((decimal)(Value) * 9 / 100)) + "$" + (decimal)(((decimal)(Value) * 18 / 100)) + "$" +
                Convert.ToDecimal(Value);
            return result;
        }

        public void CalculateTotalValuesUpdate(long BillingID, decimal LoadingCharges, decimal TaxableAmount, decimal CGST, decimal SGST, decimal IGST, decimal RoundOff, decimal TSC, long GrandTotal)
        {
            object[] objParam = { BillingID, LoadingCharges, TaxableAmount, CGST, SGST, IGST, RoundOff, TSC, GrandTotal };
            var ddd = SqlHelper.ExecuteDataset(db.GetConnection(), "CalculateTotalValues", objParam);
            //return Convert.ToInt64(ddd);
        }

        public List<CompanyModels> GetCompanyDetailsByAll(long UniqueID)
        {
            object[] objParam = { UniqueID };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.GetCompanyDetailsByAll, objParam);
            return ConvertList.TableToList<CompanyModels>(d.Tables[0]);
        }

        public List<ClientModels> GetClientDetailsByAll(long UniqueID)
        {
            object[] objParam = { UniqueID };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.GetClientDetailsByAll, objParam);
            return ConvertList.TableToList<ClientModels>(d.Tables[0]);
        }

        public List<BillingModels> BillingDetailsGetByAll()
        {
            object[] objParam = { };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.BillingDetailsGetByAll, objParam);
            return ConvertList.TableToList<BillingModels>(d.Tables[0]);
        }

        public List<BillingLineModels> BillingLineDetailsGetByAll(long UniqueID)
        {
            object[] objParam = { UniqueID };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.BillingLineDetailsGetByAll, objParam);
            return ConvertList.TableToList<BillingLineModels>(d.Tables[0]);
        }

        public List<BillingModels> GetBillTextDetailsByUniqueID(long UniqueID)
        {
            object[] objParam = { UniqueID };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.GetBillTextDetailsByUniqueID, objParam);
            return ConvertList.TableToList<BillingModels>(d.Tables[0]);
        }

        public List<BillingLineModels> GetBillLineTextDetailsByUniqueID(long UniqueID)
        {
            object[] objParam = { UniqueID };
            var d = SqlHelper.ExecuteDataset(db.GetConnection(), Procedures.GetBillLineTextDetailsByUniqueID, objParam);
            return ConvertList.TableToList<BillingLineModels>(d.Tables[0]);
        }
    }
}