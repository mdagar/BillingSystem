using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillingSystem.Models;
using BillingSystem.Repository;
using Utility;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace BillingSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        UserRepository _allusers = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var users = _allusers.UserInformationDetailsGetByAll();
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, UserModels mode)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            if (mode != null && ModelState.IsValid)
            {
                mode.ActionId = 0;
                mode.IsActive = true;
                mode.CreatedBy = SessionWrapper.User.UniqueID;
                var modelCreate = _allusers.UserInformationInsertUpdateDelete(mode);
            }
            return Json(new[] { mode }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, UserModels mode)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            if (mode != null && ModelState.IsValid)
            {
                mode.ActionId = 1;
                mode.IsActive = true;
                mode.CreatedBy = SessionWrapper.User.UniqueID;
                var modelCreate = _allusers.UserInformationInsertUpdateDelete(mode);
            }

            return Json(new[] { mode }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, UserModels mode)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            if (mode != null && ModelState.IsValid)
            {
                mode.ActionId = -1;
                mode.IsActive = mode.IsActive ? false : true;
                mode.CreatedBy = SessionWrapper.User.UniqueID;
                var modelCreate = _allusers.UserInformationInsertUpdateDelete(mode);
            }
            return Json(new[] { mode }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult LoadPartialUserDetailsView(long UniqueID = 0)
        {
            var users = _allusers.UserInformationDetailsGetByAll().Where(x => x.UniqueID == UniqueID).FirstOrDefault();
            return View("~/Views/User/PartialViews/_loadEditUserDetailView.cshtml", users);
        }

        public ActionResult LoadCreateUserPartialView()
        {
            var model = new UserModels();
            return View("~/Views/User/PartialViews/_loadAddUserDetailView.cshtml", model);
        }

        public ActionResult UpdateUserDetails(UserModels comp)
        {
            comp.ActionId = 1;
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allusers.UserInformationInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUserDetails(UserModels comp)
        {
            comp.ActionId = 0;
            comp.IsActive = true;
            comp.CreatedBy = SessionWrapper.User.UniqueID;
            comp.CreatedOn = DateTime.Now;
            var modelCreate = _allusers.UserInformationInsertUpdateDelete(comp);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateUserDetails()
        {
            var users = _allusers.UserInformationDetailsGetByAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivateDeActivateUserDetails(long UniqueID = 0, int flag = 0)
        {
            var mode = new UserModels();
            mode.ActionId = -1;
            mode.UniqueID = UniqueID;
            mode.IsActive = flag==1 ? false : true;
            mode.CreatedBy = SessionWrapper.User.UniqueID;
            var modelCreate = _allusers.UserInformationInsertUpdateDelete(mode);
            return Json(modelCreate, JsonRequestBehavior.AllowGet);
        }
    }
}
