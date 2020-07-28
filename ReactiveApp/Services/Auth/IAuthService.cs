using System.Threading.Tasks;

namespace ReactiveApp.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);
        Task<bool> Register(string email, string password);
    }
}
