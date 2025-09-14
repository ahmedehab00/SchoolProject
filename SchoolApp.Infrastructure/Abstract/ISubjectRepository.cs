using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.InfrastructureBases;

namespace SchoolApp.Infrastructure.Abstract
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
    }
}
