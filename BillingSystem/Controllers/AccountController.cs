using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillingSystem.Models;
using BillingSystem.Repository;
using Utility;

namespace BillingSystem.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        UserRepository _allusers = new UserRepository();
        public ActionResult Index()
        {
            UserModels user = new UserModels();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(UserModels user)
        {
            var usr = _allusers.Login(user.EmailID, user.Password);
            if (usr != "0")
            {
                SessionWrapper.User = new UserModels();
                SessionWrapper.User.UniqueID = Convert.ToInt64(usr.Split(',')[0]);
                SessionWrapper.User.UserName = Convert.ToString(usr.Split(',')[1]);
                return RedirectToAction("ViewBills", "Billing");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
