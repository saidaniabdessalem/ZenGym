using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZenGym.Domain.Services
{
   public interface IDataService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id); 

    }
}
