using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedCreda.Mvc.Controllers
{
    public class DoctorController : Controller
    {
        /// <summary>
        /// If session expires, redirect to login
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ActionResult SessionView(string viewName) {
            if (string.IsNullOrEmpty(Session["Username"] as string)) {
                return RedirectToAction("Login", "Account");
            }
            return View(viewName);
        }

        public PartialViewResult InitiateVideoConference() {
            return PartialView("_VideoConference");
        }

        // GET: Doctor
        public ActionResult Dashboard()
        {
            //return this.SessionView("Dashboard");
            return View();
        }
    }
}