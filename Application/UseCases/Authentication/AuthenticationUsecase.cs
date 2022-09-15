using Application.Helper.Comman;
using Application.Repositories;
using Domains.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Authentication
{
    public class AuthenticationUsecase : IAuthenticationUsecase
    {
        private IUserLoginRepository _userRepository;

        public AuthenticationUsecase(IUserLoginRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginEntity> Login(string name, string password)
        {
            UserLoginEntity userLoginEntity = new UserLoginEntity();
            UserEntity userEntity = await _userRepository.GetUserAsync(name);
            RoleEntity role = await _userRepository.GetRoleById(userEntity.RoleId);
            if (userEntity == null || userEntity.UserId <= 0)
            {
                throw new Exception($"The user name or password is incorrect");
            }

            if(TokenHelper.VerifyPasswordHash(password,userEntity.Passwordhash,userEntity.Passwordsalt))
            {

                throw new Exception($"The user name or password is incorrect");

            }

            userLoginEntity.Token = TokenHelper.GetJWTToken(userEntity, role);

            return userLoginEntity ?? new UserLoginEntity();

        }
    }
}
