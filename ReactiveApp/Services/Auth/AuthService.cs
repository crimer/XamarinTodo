using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<bool> Login(string email, string password)
        {
            if (!(email.Length > 5)
                || !(Regex.Matches(email, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1))
            {
                return false;
            }
            if (string.IsNullOrEmpty(password) || !(password.Length >= 5))
            {
                return false;
            }
            await Task.Delay(5000);
            throw new Exception("test error");
            //return true;

        }

        public Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
