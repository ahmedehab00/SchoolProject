using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Data.Entities.Identity;

namespace SchoolApp.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(x => new { x.SubID, x.DID });
            modelBuilder.Entity<Ins_Subject>()
                .HasKey(x => new { x.SubId, x.InsId });
            modelBuilder.Entity<StudentSubject>()
                .HasKey(x => new { x.SubID, x.StudID });


            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>(entity =>
            {

                entity.HasKey(x => x.DID);

                entity.HasMany(x => x.Students)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DID)
                .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(x => x.Instructor)
                 .WithOne(x => x.departmentManager)
                 .HasForeignKey<Department>(x => x.InsManager)
                 .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<DepartmetSubject>(entity =>
            {

                entity.HasOne(x => x.Department)
                .WithMany(m => m.DepartmentSubjects)
                .HasForeignKey(d => d.DID);

                entity.HasOne(x => x.Subjects)
                .WithMany(m => m.DepartmetsSubjects)
                .HasForeignKey(d => d.SubID);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
