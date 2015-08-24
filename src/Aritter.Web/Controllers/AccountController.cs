using Aritter.Domain.Aggregates;
using Aritter.Infra.CrossCutting.Configuration;
using Aritter.Web.Core.Extensions;
using Aritter.Web.Models;
using System;
using System.Security.Authentication;
using System.Web.Mvc;
using System.Web.Security;

namespace Aritter.Web.Controllers
{
    public class AccountController : DefaultController
    {
        #region Methods

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (ApplicationSettings.CurrentUser.IsAuthenticated)
                return string.IsNullOrEmpty(returnUrl)
                    ? RedirectToHome()
                    : RedirectToUrl(returnUrl);

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                //var authenticatedUserId = userManager.AuthenticateUser(model.Username, model.Password);
                var authenticatedUserId = 1;

                FormsAuthentication.SetAuthCookie(authenticatedUserId.ToString(), model.RememberMe);
                return RedirectToUrl(returnUrl);
            }
            catch (AuthenticationException ex)
            {
                ModelState.AddModelStateError(ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelStateError("Não foi possível efetuar o login. Por favor contate o administrador.");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult ChangePassword(string token)
        {
            //var user = userManager.GetUserBySecurityToken(token);
            var user = new User();

            if (user == null)
            {
                ModelState.AddModelStateError("O token de segurança não é válido.");
                return View();
            }

            var model = new ChangePasswordViewModel
            {
                UserId = user.Id,
                UserName = user.FirstName
            };

            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                //userManager.ChangePassword(model.UserId, model.CurrentPassword, model.NewPassword);
            }
            catch (AuthenticationException ex)
            {
                ModelState.AddModelStateError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelStateError(ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelStateError("Não foi possível alterar a sua senha. Por favor contate o administrador.");
            }

            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                //var result = userManager.ResetPassword(model.MailAddress);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelStateError(ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelStateError("Não foi possível recuperar a sua senha. Por favor contate o administrador.");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToHome();
        }

        #endregion Methods
    }
}