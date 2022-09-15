using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domains.Entities.Users;

namespace Infrastructure.Repository.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task<UserLoginEntity> Login(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
