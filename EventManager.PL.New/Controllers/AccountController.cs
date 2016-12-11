using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.Facades;
using EventManager.PL.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EventManager.PL.Models;

namespace EventManager.PL.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        public UserFacade UserFacade { get; set; }
        public SignInManager SignInManager { get; set; }

        #region RegisterActionMethods

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Register", new UserRegistrationDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool success;
                    var accountId = UserFacade.RegisterUser(model, out success);
                    if (success == false)
                    {
                        ModelState.AddModelError("Password", "Account with this email address already exists");
                        return View("Register", model);
                    }

                    SignInManager.SignIn(accountId, false);

                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View("Register", model);
        }

        #endregion

        #region LogIn/OutActionMethods

        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Login", new UserLoginDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var accountId = UserFacade.AuthenticateUser(model);

                if (!accountId.Equals(Guid.Empty))
                {
                    SignInManager.SignIn(accountId, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
            }

            return View("Login", model);
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                SignInManager.SignOut();
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}