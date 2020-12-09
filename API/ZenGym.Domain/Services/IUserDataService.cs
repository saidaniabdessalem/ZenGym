using System.Threading.Tasks;
using ZenGym.Domain.Entities;

namespace ZenGym.Domain.Services
{
    public interface IUserDataService : IDataService<User>
    {
        Task<User> GetByUsername(string username);
        Task<bool> IsUserExist(string username);
    }


}