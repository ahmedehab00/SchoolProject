using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Service.Abstract;
using SchoolApp.Service.Implemantation;
using System.Reflection;

namespace SchoolApp.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Configuration of Auto Mapper
            services.AddAutoMapper((Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}

