namespace CameraBazaar.Web.Infrastructure.Filters
{
    using Common;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

    public class LogFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var time = DateTime.UtcNow;
			var ip = context.HttpContext.Connection.RemoteIpAddress;
			var user = context.HttpContext.User.Identity.IsAuthenticated ? context.HttpContext.User.Identity.Name : CameraBazaarConstants.User.AnnonymousUser;
			var controller = context.RouteData.Values["controller"].ToString();
			var action = context.RouteData.Values["action"].ToString();
			var exception = context.Exception;

			var logMessage = $"{time} – {ip} – {user} – {controller}.{action}";

			if (exception != null)
			{
				logMessage = $"[!] {logMessage} - {exception.GetType().Name} – {exception.Message}";
			}

			using (var writer = new StreamWriter("logs.txt",true))
			{
				writer.WriteLine(logMessage);
			}
		}
	}
}
