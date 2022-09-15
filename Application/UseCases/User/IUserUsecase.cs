using Application.DTO.User;
using Domains.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User
{
    public interface IUserUsecase
    {
        Task<UserEntity> AddUserAsync(AddUserParameterDto parameters);
       
        Task<UserEntity> GetUserAsync(string name);
    }
}
