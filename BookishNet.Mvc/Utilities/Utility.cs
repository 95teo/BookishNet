namespace BookishNet.Mvc.Utilities
{
    public class Utility
    {
        public static string Encryptpassword(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
            return hashedPassword;
        }

        public static bool CheckPassword(string enteredPassword, string hashedPassword)
        {
            var pwdHash = BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
            return pwdHash;
        }
    }
}