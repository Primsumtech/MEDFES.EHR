using Application.Repositories;
using Dapper;
using Domains.Entities.Users;
using Infrastructure.DataBaseContext;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.User
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly DBContext _userDBContext;

        private readonly ILogger<UserLoginRepository> _logger;

        public UserLoginRepository(DBContext userDBContext, ILogger<UserLoginRepository> logger)
        {
            _userDBContext = userDBContext;
            _logger = logger;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity parameters)
        {

            string query = @"INSERT INTO MEDFESUSERS (FirstName, LastName,MiddleName,Email,PhoneNumber,Address,Address1,City,States,Country,CountryCode,RoleId,Passwordhash,Passwordsalt)
                                               VALUES(@FirstName, @LastName,@MiddleName,@Email,@PhoneNumber,@Address,@Address1,@City,@State,@Country,@CountryCode,@RoleId,@Passwordhash,@Passwordsalt)";



            using (var connection = _userDBContext.HospitalDBConnectionCreate())
            {
                connection.Open();

                var insertedOrder = connection.QueryFirstOrDefault<UserEntity>(query, param: parameters);
              //  return insertedOrder;

                var res = await connection.ExecuteAsync(query, parameters);

                return parameters;
            }
        }

        public async Task<RoleEntity> GetRoleById(int roleId)
        {
            RoleEntity role = null;

            string query = "SELECT * FROM ROLES";
            using (var connection = _userDBContext.HospitalDBConnectionCreate())
            {
                connection.Open();
                List<RoleEntity> result = (List<RoleEntity>)await connection.QueryAsync<RoleEntity>(query);

                if (result != null && result.Any())

                    role = result.FirstOrDefault(r => r.RoleId == roleId);

                return role ?? new RoleEntity();
            }
        }

        public async Task<UserEntity> GetUserAsync(string name)
        {
            UserEntity userEntity = null;

            string query = $"SELECT * FROM MEDFESUSERS WHERE EMAIL = '{name}'";

            using (var connection = _userDBContext.HospitalDBConnectionCreate())
            {
                connection.Open();
                List<UserEntity> result = (List<UserEntity>)await connection.QueryAsync<UserEntity>(query);

                if (result != null && result.Any())

                    userEntity = result.FirstOrDefault(u => u.Email.Equals(name, StringComparison.OrdinalIgnoreCase));

                return userEntity ?? new UserEntity();
            }
        }
    }
}
