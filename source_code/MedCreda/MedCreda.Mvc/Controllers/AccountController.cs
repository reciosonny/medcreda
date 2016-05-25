using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MedCreda.Mvc.Models;

namespace MedCreda.Mvc.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        public ActionResult Login() {
            return View();
        }

        public void SaveSession(string name) {
            Session["Username"] = name;
        }
        

    }
}