using FysEtt.Models;
using FysEtt.Models.Entities;
using FysEtt.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FysEtt.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ActionResult result = null;

            if (ModelState.IsValid)
            {
                var memberService = new MemberService(_uow.UserRepository);
                var userAlreadyExists = memberService.DoesUserExist(model.Email);

                if (userAlreadyExists)
                {
                    ModelState.AddModelError("UserAlreadyExists", "Det finns redan en användare med samma email");
                    result = View(model);
                }
                else
                {
                    var user = new User
                    {
                        Email = model.Email,
                        Password = model.Password
                    };

                    _uow.UserRepository.Add(user);
                    _uow.SaveChanges();

                    result = RedirectToAction("Login");
                }

            }
            else
            {
                result = View(model);
            }

            return result;
        }

        public ActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel();
            model.ReturnUrl = string.IsNullOrEmpty(returnUrl) ? "/admin/index" : returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            ActionResult result = null;

            if (ModelState.IsValid)
            {
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    var user = _uow.UserRepository.FindByEmail(model.Email);
                    var memberService = new MemberService(_uow.UserRepository);

                    if (memberService.CheckIfValidUser(model.Email, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        result = Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("LoginFailed", "Fel email eller lösenord");
                        result = View(model);
                    }
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                result = View(model);
            }

            return result;
        }
    }
}
