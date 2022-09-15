using Domains.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<UserLoginEntity> Login(string name, string password);
    }
}
