using Microsoft.AspNetCore.Identity;

namespace IdentityApi1.Services
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.HashPassword(null, password);
        }
    }
}
