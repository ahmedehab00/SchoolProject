using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.InfrastructureBases;
using SchoolApp.Infrastructure.Repositories;

namespace SchoolApp.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }


    }
}
