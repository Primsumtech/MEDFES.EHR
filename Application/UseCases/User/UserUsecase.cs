using Domains.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Application.DTO.User;
using Application.Helper.Comman;

namespace Application.UseCases.User
{
    public class UserUsecase : IUserUsecase
    {
        private IUserLoginRepository _userRepository;

        public UserUsecase(Application.Repositories.IUserLoginRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> AddUserAsync(AddUserParameterDto parameters)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            UserEntity result = null;

           UserEntity newUserEntity = new UserEntity()
            {
                FirstName = parameters.FirstName,
                MiddleName = parameters.MiddleName,
                LastName = parameters.LastName,
                Email = parameters.Email,
                PhoneNumber = parameters.PhoneNumber,
                Address = parameters.Address,
                Address1 = parameters.Address1,
                City = parameters.City,
                State = parameters.State,
                Country = parameters.Country,
                CountryCode = parameters.Country,
                RoleId = parameters.Roleid
            };

            TokenHelper.CreatePasswordHash(parameters.Password, out passwordHash, out passwordSalt);
            newUserEntity.Passwordhash = passwordHash;
            newUserEntity.Passwordsalt = passwordSalt;

             result = await _userRepository.AddUserAsync(newUserEntity);

            if (result != null)
            {
                result.Passwordhash = null;
                result.Passwordsalt = null;

            }

            return result ?? new UserEntity();
        }

        public async Task<UserEntity> GetUserAsync(string name)
        {
            UserEntity userEntity = await _userRepository.GetUserAsync(name);
            return userEntity;
        }
    }
}
