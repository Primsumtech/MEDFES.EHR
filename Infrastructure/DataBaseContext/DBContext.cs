using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Domains.Entities;


namespace Infrastructure.DataBaseContext
{
    public partial class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _hospitalDBconnectionString;
        private readonly string _patientDBconnectionString;
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _hospitalDBconnectionString = _configuration.GetConnectionString("HospitalDB");
            _patientDBconnectionString = _configuration.GetConnectionString("PatientDB");
        }

        public IDbConnection HospitalDBConnectionCreate()
            => new NpgsqlConnection(_hospitalDBconnectionString);

        public IDbConnection PatientDBConnectionCreate()
           => new NpgsqlConnection(_patientDBconnectionString);



      
    }
}
