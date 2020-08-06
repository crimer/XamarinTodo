using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<bool> Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(email))
            {
                await Task.Delay(2000);
                return true;
            }
            else
            {
                return false;
            }


        }

        public Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
