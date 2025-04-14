using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) 
        {
            services.AddTransient<IStudentRepository,StudentRepository>();
            return services;
        }


    }
}
