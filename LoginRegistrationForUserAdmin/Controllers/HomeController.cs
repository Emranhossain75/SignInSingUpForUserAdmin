using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegistrationForUserAdmin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "arafatmollik")]
        // GET: Home
        public ActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "User,arafatmollik")]
        public ActionResult Index()
        {
            return View();
        }
    }
}