using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.DTO;
namespace Application
{
    public interface IUserRepository
    {
        //  Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<users>> GetAllAsync();
        //Task<int> AddAsync(T entity);
        //Task<int> UpdateAsync(T entity);
        //Task<int> DeleteAsync(int id);
    }
}
