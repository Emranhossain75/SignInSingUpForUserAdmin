using LoginRegistrationForUserAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginRegistrationForUserAdmin.Controllers
{
    public class AccountController : Controller
    {
        SignInSignUpEntities db = new SignInSignUpEntities();
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login( SignUp sign)
        {
            using (var context = new SignInSignUpEntities())
            {
                FormsAuthentication.SetAuthCookie(sign.UserName, false);
                bool Isvalid = context.SignUps.Any(x => x.UserName == "arafatmollik" && x.Password == sign.Password);
                
                if (Isvalid) 
                { 

                    return RedirectToAction("Admin", "Home");

                }
                bool Isvalid1 = context.SignUps.Any(x => x.UserName == "User" && x.Password == sign.Password);
                if (Isvalid1)
                {

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid UserName And Password");
                return View();
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignUp model)
        {
            using (var context = new SignInSignUpEntities())
            {
                context.SignUps.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    
}
}
