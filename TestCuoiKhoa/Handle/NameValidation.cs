using System.Globalization;
using System.Text.RegularExpressions;

namespace TestCuoiKhoa.Handle
{
	public class NameValidation
	{
		public static string IsValidatedName(string fullName)
		{
			TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
			string formattedName = textInfo.ToTitleCase(fullName.ToLower());
		    formattedName = Regex.Replace(formattedName, @"\s+", " ");
			return formattedName;
		}
	}
}
