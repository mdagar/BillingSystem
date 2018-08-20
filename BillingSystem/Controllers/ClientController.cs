using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillingSystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BillingSystem.Repository;
using Utility;

namespace BillingSystem.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        ClientRepository _allclient = new ClientRepository();
        public ActionResult Index()
        {
            var model = new ClientModels();
            return View(model);
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var results = _allclient.ClientInformationDetailsGetByAll();
            return Json(results.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateClientDetails()
        {
            var results = _allclient.ClientInformationDetailsGetByAll();
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPartialClientDetailsView(long UniqueID, string ClientName, string GSTNumber, string BillingAddress, string BillingStateCode, string BillingStateName,
            string BillingCityName, string BillingPinCode, string ShippingAddress, string ShippingStateCode, string ShippingStateName, string ShippingCityName, string ShippingPinCode)
        {
            var model = new ClientModels();
            model.UniqueID = UniqueID;
            model.ClientName = ClientName;
            model.GSTNumber = GSTNumber;
            model.BillingAddress = BillingAddress;
            model.BillingStateCode = BillingStateCode;
            model.BillingStateName = BillingStateName;
            model.BillingCityName = BillingCityName;
            model.BillingPinCode = BillingPinCode;
            model.ShippingAddress = ShippingAddress;
            model.ShippingStateCode = ShippingStateCode;
            model.ShippingStateName = ShippingStateName;
            model.ShippingCityName = ShippingCityName;
            model.ShippingPinCode = ShippingPinCode;
            return View("~/Views/Client/PartialViews/_loadEditClientDetailView.cshtml", model);
        }

        public ActionResult UpdateClientDetails(ClientModels comp)
        {
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allclient.ClientInformationDetailsInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadCreateClientPartialView()
        {
            var model = new ClientModels();
            return View("~/Views/Client/PartialViews/_loadAddClientDetailView.cshtml", model);
        }

        public ActionResult AddClientDetails(ClientModels comp)
        {
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allclient.ClientInformationDetailsInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

    }
}
