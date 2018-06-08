using BTCD_System.BTCD_DL.User;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace BTCD_System.Controllers
{
    public class HomeController : Controller
    {
        private clsU_User clsU_User = new clsU_User();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogIn l, string returnUrl = "")
        {
            #region Part 1 Code
            //emsUserU _emsUserU = clsU_User.GetUserByUsername(l.Username);

            //if (_emsUserU.Username==l.Username && _emsUserU.Password == l.Password)
            //{
            //    FormsAuthentication.SetAuthCookie(_emsUserU.Username,l.RememberMe);
            //    if (Url.IsLocalUrl(returnUrl))
            //    {
            //        return Redirect(returnUrl);
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            #endregion

            #region Part 2 Code
            //if (ModelState.IsValid)
            //{

            //    var isValidUser = Membership.ValidateUser(l.Username, l.Password);

            //    if (isValidUser)
            //    {
            //        emsUserU _emsUserU = clsU_User.GetUserByUsername(l.Username);

            //        TempData["FirstName"] = _emsUserU.FirstName;
            //        TempData["LastName"] = _emsUserU.LastName;

            //        FormsAuthentication.SetAuthCookie(l.Username, l.RememberMe);
            //        if (Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl); 
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //} 
            #endregion

            #region Part 4 Code

            if (ModelState.IsValid)
            {
                bool isValidUser = Membership.ValidateUser(l.Username, l.Password);
                if (isValidUser)
                {
                    UserU _emsUserU = null;
                    _emsUserU = clsU_User.GetUserByUsername(l.Username);

                    if (User != null)
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string data = js.Serialize(_emsUserU);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, _emsUserU.Username, DateTime.Now, DateTime.Now.AddMinutes(30), l.RememberMe, data);
                        string encToken = FormsAuthentication.Encrypt(ticket);

                        HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName,encToken);
                        Response.Cookies.Add(authCookies);
                        //return Redirect(returnUrl);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            #endregion

            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Lock", "Home");
        }


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}