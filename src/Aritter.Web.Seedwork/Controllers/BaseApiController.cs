using Aritter.Web.Seedwork.Messages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aritter.Web.Seedwork.Controllers
{
	public class BaseApiController : Controller
	{
		public ApiResponse Success()
		{
			return new SuccessResponse();
		}

		public ApiResponse<TData> Success<TData>(TData data)
			where TData : class
		{
			return new SuccessResponse<TData>(data);
		}

		public ApiResponse Success(params string[] messages)
		{
			return new SuccessResponse(messages);
		}

		public ApiResponse<TData> Success<TData>(TData data, params string[] messages)
			where TData : class
		{
			return new SuccessResponse<TData>(data, messages);
		}

		public ApiResponse Error(params string[] messages)
		{
			return new ErrorResponse(messages);
		}

		public ApiResponse Error(ValidationResult error)
		{
			return new ErrorResponse(error.ErrorMessage);
		}
	}
}
