using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Patient;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataBaseContext;

namespace Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<DBContext>();
            services.AddTransient<IUserRepository,UsersRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
        }

    }
}
