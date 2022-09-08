using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Dapper;
using Domains.DTO;
using Infrastructure.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog;
namespace Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {

        

        private readonly  DapperContext _configuration;

        private readonly ILogger<UsersRepository> _logger;
        public UsersRepository(DapperContext configuration,ILogger<UsersRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }

        //public async Task<int> AddAsync(users entity)
        //{
            
        //    var sql = "Insert into users (firstname,lastname,middlename,mobileno,address1) VALUES (@firstname,@lastname,@middlename,@mobileno,@address1)";
        //    _logger.LogInformation(sql);
        //    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, entity);
        //        _logger.LogDebug(result.ToString());
        //        return result;
        //    }
        //}

        //public async Task<int> DeleteAsync(int id)
        //{
        //    var sql = "DELETE FROM users WHERE userid = @Id";
        //    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, new { Id = id });
        //        return result;
        //    }
        //}

        public async Task<IReadOnlyList<users>> GetAllAsync()
        {
            var sql = "SELECT * FROM employee";
            using (var connection = _configuration.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<users>(sql);
                return result.ToList();
            }
        }

        //public async Task<users> GetByIdAsync(int id)
        //{
        //    var sql = "SELECT * FROM users WHERE userid = @Id";
        //    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<users>(sql, new { Id = id });
        //        return result;
        //    }
        //}

        //public async Task<int> UpdateAsync(users entity)
        //{
          
        //    var sql = "UPDATE Users SET firstname = @firstname,lastname = @lastname, middlename = @middlename, mobileno = @mobileno, address1 = @address1  WHERE userid = @Id";
        //    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, entity);
        //        return result;
        //    }
        //}
    }
}
