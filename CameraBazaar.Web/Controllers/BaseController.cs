namespace CameraBazaar.Web.Controllers
{
    using Common;
    using Infrastructure.Enums;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    using static Common.CameraBazaarConstants.TempDataKey;

    public abstract class BaseController : Controller
    {
		protected void GenerateOperationMessage(string message,Alert type)
		{
			this.TempData[Message] = message;
			this.TempData[AlertType] = type.ToString().ToLower();
		}

		protected IActionResult NonExistingElement(string id,string action, string controller = null)
		{
			var alertMessage = string.Format(CameraBazaarConstants.Message.NonExistingElement, this.GetType().Name.GetElementName(), id);

			this.GenerateOperationMessage(alertMessage, Alert.Danger);

			if (controller != null)
			{
				return RedirectToAction(action, controller);
			}

			return RedirectToAction(action);
		}
    }
}
