using System.Threading.Tasks;
using ZenGym.Domain.Entities;

namespace ZenGym.Application.Authentication
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}