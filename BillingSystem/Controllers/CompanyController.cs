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
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        CompanyRepository _allcomps = new CompanyRepository();
        public ActionResult Index()
        {
            var model = new CompanyModels();
            return View(model);
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var results = _allcomps.CompanyInformationDetailsGetByAll();
            return Json(results.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateCompanyDetails()
        {
            var results = _allcomps.CompanyInformationDetailsGetByAll();
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPartialCompanyDetailsView(long UniqueID, string CompanyName, string GSTNumber, string CompanyAddress, string StateName, string CityName, string PinCode, string BankName, string AccountNumber, string IFSCCode, string ContactNo, string EmailID)
        {
            var model = new CompanyModels();
            model.UniqueID = UniqueID;
            model.CompanyName = CompanyName;
            model.GSTNumber = GSTNumber;
            model.CompanyAddress = CompanyAddress;
            model.StateName = StateName;
            model.CityName = CityName;
            model.PinCode = PinCode;
            model.BankName = BankName;
            model.AccountNumber = AccountNumber;
            model.IFSCCode = IFSCCode;
            model.ContactNo = ContactNo;
            model.EmailID = EmailID;
            return View("~/Views/Company/PartialViews/_loadEditCompanyDetailView.cshtml", model);
        }

        public ActionResult UpdateCompanyDetails(CompanyModels comp)
        {
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allcomps.CompanyInformationDetailsInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadCreateCompanyPartialView()
        {
            var model = new CompanyModels();
            return View("~/Views/Company/PartialViews/_loadAddCompanyDetailView.cshtml", model);
        }

        public ActionResult AddCompanyDetails(CompanyModels comp)
        {
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allcomps.CompanyInformationDetailsInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Upload Files
        /// </summary>
        /// <param name="LineFileId"></param>
        /// <param name="LineItemId"></param>
        /// <param name="OpportunityId"></param>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Uploads(string UniqueID = "0")
        {
            var comp = new CompanyModels();
            comp.UniqueID = Convert.ToInt64(UniqueID);
            comp.UploadFile = Request.Files[0] == null ? new byte[0] : new byte[Request.Files[0].ContentLength];
            Request.Files[0].InputStream.Read(comp.UploadFile, 0, Request.Files[0].ContentLength);
            var modelCreate = _allcomps.CompanyInformationDetailsInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

    }
}
