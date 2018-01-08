namespace CameraBazaar.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class TimerFilterAttribute : IActionFilter
	{
		private Stopwatch stopWatch = new Stopwatch();

		public void OnActionExecuting(ActionExecutingContext context)
		{
			stopWatch.Start();
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			stopWatch.Stop();

			using (var writer = new StreamWriter("action-times.txt",true))
			{
				var dateTime = DateTime.UtcNow;
				var controller = context.RouteData.Values["controller"].ToString();
				var action = context.RouteData.Values["action"].ToString();
				var elapsed = this.stopWatch.Elapsed;

				var result = $"{dateTime} – {controller}.{action} – {elapsed}";

				writer.WriteLine(result);
			}
		}
	}
}
