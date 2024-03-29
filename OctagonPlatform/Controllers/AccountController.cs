﻿using OctagonPlatform.Models.FormsViewModels;
using OctagonPlatform.Models.InterfacesRepository;
using System.Web.Mvc;
using System.Web.Security;

namespace OctagonPlatform.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel viewModel)
        {
            if (Session["tries"] != null)
            {
                viewModel.TriesToLogin = int.Parse(Session["tries"].ToString());
            }
            var userToLogin = _accountRepository.Login(viewModel);
            if (userToLogin.IsLocked)
            {

                if (Session["tries"] != null) Session["tries"] = 0;
                ViewBag.Message = "User Locked, please call the Administrator";
                return View(userToLogin);
                
            }
            
            if (userToLogin.Partner == null)
            {
                ViewBag.Message = "Invalid User";
                Session["tries"] = userToLogin.TriesToLogin;
                return View(userToLogin);
            }
            FormsAuthentication.SetAuthCookie(userToLogin.UserName, false);
            Session["logo"] = userToLogin.Partner.Logo;
            Session["partnerId"] = userToLogin.Partner.Id;
            Session["businessName"] = userToLogin.Partner.BusinessName;
            if (Session["tries"] != null) Session["tries"] = 0;
            return RedirectToAction("Index", "Dashboard");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            _accountRepository.Logout();
            return RedirectToAction("Index", "Home");
        }

        //Implementacion
    }
}