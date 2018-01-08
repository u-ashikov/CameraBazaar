namespace CameraBazaar.Web.Infrastructure.Extensions
{
	public static class StringExtensions
    {
		private const string Controller = "Controller";

		public static string DashSeparate(this string input)
		{
			switch (input)
			{
				case "CenterWeighted":
					return "Center-Weighted";
				default:
					return input;
			}
		}

		public static string ToPrice(this decimal price)
		{
			return price.ToString("F2");
		}

		public static string GetElementName(this string controllerName)
		{
			var elementName = controllerName.Substring(0, controllerName.IndexOf(Controller));

			if (elementName.EndsWith("s"))
			{
				elementName = elementName.Substring(0, elementName.Length - 2);
			}

			return elementName;
		}
    }
}
