using System.ComponentModel.DataAnnotations;

namespace TestCuoiKhoa.Handle
{
	public class EmailValidation
	{
		public static bool IsValidEmail(string email)
		{
			var checkEmail = new EmailAddressAttribute();
			return checkEmail.IsValid(email);
		}
	}
}
