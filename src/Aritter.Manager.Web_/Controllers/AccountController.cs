using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Exceptions;
using Aritter.Manager.Infrastructure.Mail;
using Aritter.Manager.Web.Core.Extensions;
using Aritter.Manager.Web.Models;
using System;
using System.Net.Mail;
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
					? this.RedirectToHome()
					: this.RedirectToUrl(returnUrl);

			this.ViewBag.ReturnUrl = returnUrl;
			return this.View();
		}

		[HttpPost, AllowAnonymous]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			if (!this.ModelState.IsValid)
				return this.View(model);

			try
			{
				var authenticatedUserId = this.userAppService.AuthenticateUser(model.Username, model.Password);

				FormsAuthentication.SetAuthCookie(authenticatedUserId.ToString(), model.RememberMe);
				return this.RedirectToUrl(returnUrl);
			}
			catch (ManagerException ex)
			{
				this.ModelState.AddModelStateError(ex.Message);
			}
			catch (Exception)
			{
				this.ModelState.AddModelStateError("Não foi possível efetuar o login. Por favor contate o administrador.");
			}

			this.ViewBag.ReturnUrl = returnUrl;
			return this.View(model);
		}

		[AllowAnonymous]
		public ActionResult ForgotPassword(string returnUrl)
		{
			this.ViewBag.ReturnUrl = returnUrl;
			return this.View();
		}

		[AllowAnonymous]
		public ActionResult ChangePassword(string token)
		{
			var user = this.userAppService.GetUserToChangePassword(token);

			if (user == null)
			{
				this.ModelState.AddModelStateError("O token de segurança não é válido.");
				return this.View();
			}

			var model = new ChangePasswordViewModel
			{
				UserId = user.Id,
				UserName = user.FirstName
			};

			return this.View(model);
		}

		[HttpPost, AllowAnonymous]
		public ActionResult ChangePassword(ChangePasswordViewModel model)
		{
			if (!this.ModelState.IsValid)
				return this.View(model);

			try
			{
				this.userAppService.ChangePassword(model.UserId, model.CurrentPassword, model.NewPassword);
			}
			catch (ManagerException ex)
			{
				this.ModelState.AddModelStateError(ex.Message);
			}
			catch (Exception)
			{
				this.ModelState.AddModelStateError("Não foi possível alterar a sua senha. Por favor contate o administrador.");
			}

			return this.View(model);
		}

		[HttpPost, AllowAnonymous]
		public ActionResult ForgotPassword(ForgotPasswordViewModel model, string returnUrl)
		{
			if (!this.ModelState.IsValid)
				return this.View(model);

			try
			{
				var result = this.userAppService.ResetPassword(model.MailAddress);

				if (result != null)
				{
					this.SendChangePasswordMailMessage(result);
					this.ModelState.AddModelStateInfo("Verifique em sua caixa de e-mail as instruções para alteração da sua senha.");
				}
			}
			catch (ManagerException ex)
			{
				this.ModelState.AddModelStateError(ex.Message);
			}
			catch (Exception)
			{
				this.ModelState.AddModelStateError("Não foi possível recuperar a sua senha. Por favor contate o administrador.");
			}

			this.ViewBag.ReturnUrl = returnUrl;
			return this.View(model);
		}

		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return this.RedirectToHome();
		}

		private void SendChangePasswordMailMessage(ResetPasswordResult resetPasswordResult)
		{
			var mailConfig = ApplicationSettings.Mail;
			var link = Url.Action("ChangePassword", "Account", new { token = resetPasswordResult.Token }, protocol: Request.Url.Scheme);

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