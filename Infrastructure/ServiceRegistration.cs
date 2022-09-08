using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DBContext;

namespace Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddTransient<IUserRepository,UsersRepository>();
        }

    }
}
