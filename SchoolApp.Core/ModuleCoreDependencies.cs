using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Core.Behaviors;
using System.Reflection;

namespace SchoolApp.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Configuration of Auto Mapper
            services.AddAutoMapper((Assembly.GetExecutingAssembly()));

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

