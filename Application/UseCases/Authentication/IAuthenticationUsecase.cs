using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.Entities.Users;

namespace Application.UseCases.Authentication
{
    public interface IAuthenticationUsecase
    {
        Task<UserLoginEntity> Login(string name, string password);
    }
}
