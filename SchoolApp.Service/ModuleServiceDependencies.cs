using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Service.Abstract;
using SchoolApp.Service.Implemantation;

namespace SchoolApp.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
