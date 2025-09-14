using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Context;
using SchoolApp.Infrastructure.InfrastructureBases;

namespace SchoolApp.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion
        #region Constructors
        public InstructorRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            instructors = dbcontext.Set<Instructor>();
        }
        #endregion
        #region Handle Functions

        #endregion

    }
}
