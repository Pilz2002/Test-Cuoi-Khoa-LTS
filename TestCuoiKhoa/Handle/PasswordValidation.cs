namespace TestCuoiKhoa.Handle
{
	public class PasswordValidation
	{
		public static bool IsPasswordValid(string password)
		{
			if (!password.Any(char.IsDigit))
			{
				return false;
			}
			if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
			{
				return false;
			}
			return true;
		}
	}
}
