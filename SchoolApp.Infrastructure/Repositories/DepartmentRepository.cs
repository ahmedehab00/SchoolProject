using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Context;
using SchoolApp.Infrastructure.InfrastructureBases;

namespace SchoolApp.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;
        #endregion
        #region Constructors
        public DepartmentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            departments = dbcontext.Set<Department>();
        }
        #endregion
        #region Handle Functions

        #endregion
    }
}
