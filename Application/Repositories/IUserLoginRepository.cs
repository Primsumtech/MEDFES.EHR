using Domains.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserLoginRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity parameters);
        Task<UserEntity> GetUserAsync(string name);
        Task<RoleEntity> GetRoleById(int id);
    }
}
