using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Context;
using SchoolApp.Infrastructure.InfrastructureBases;

namespace SchoolApp.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subject> subjects;
        #endregion
        #region Constructors
        public SubjectRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            subjects = dbcontext.Set<Subject>();
        }
        #endregion
        #region Handle Functions

        #endregion
    }
}
