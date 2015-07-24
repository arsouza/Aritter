using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Mail;
using Aritter.Manager.Web.Core.Extensions;
using Aritter.Manager.Web.Models;
using System;
using System.Net.Mail;
using System.Security.Authentication;
using System.Web.Mvc;
using System.Web.Security;

namespace Aritter.Manager.Web.Controllers
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
				var authenticatedUserId = userAppService.AuthenticateUser(model.Username, model.Password);

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
			var user = userAppService.GetUserBySecurityToken(token);

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
				userAppService.ChangePassword(model.UserId, model.CurrentPassword, model.NewPassword);
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
				var result = userAppService.ResetPassword(model.MailAddress);

				if (result != null)
				{
					SendChangePasswordMailMessage(result);
					ModelState.AddModelStateInfo("Verifique em sua caixa de e-mail as instruções para alteração da sua senha.");
				}
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

		private void SendChangePasswordMailMessage(ResetPasswordResult resetPasswordResult)
		{
			var mailConfig = ApplicationSettings.Mail;

			if (Request.Url == null)
				return;

			var link = Url.Action("ChangePassword", "Account", new { token = resetPasswordResult.Token }, Request.Url.Scheme);

			if (link == null)
				return;

			var mailMessage = new MailMessage
			{
				From = new MailAddress(mailConfig.UserName, mailConfig.DisplayName),
				Subject = "Manager Reset Password",
				IsBodyHtml = true,
				Body = link
			};

			mailMessage.To.Add(new MailAddress(resetPasswordResult.UserMailAddress, resetPasswordResult.DisplayName));

			var client = new MailClient();
			client.Send(mailMessage);
		}

		#endregion Methods
	}
}