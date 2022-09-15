using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Patient;
using Dapper;
using Domains.DTO.Patients;
using Infrastructure.DataBaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog;
namespace Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {

        

        private readonly  DBContext _configuration;

        private readonly ILogger<PatientRepository> _logger;
        public PatientRepository(DBContext configuration,ILogger<PatientRepository> logger)
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

        public async Task<IReadOnlyList<PatientDTO>> GetAllPatients()
        {
            //var sql = "SELECT firstname || ' ' || lastname as patientname,mobilenumber from public.patient";

            string commandText = $"SELECT * FROM public.patient";
            using (var connection = _configuration.PatientDBConnectionCreate())
            {
                connection.Open();
                var result = await connection.QueryAsync<PatientDTO>(commandText);
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
