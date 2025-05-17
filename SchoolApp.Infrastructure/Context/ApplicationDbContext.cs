using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;

namespace SchoolApp.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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

            modelBuilder.Entity<Department>()
                .HasOne(x => x.Instructor)
                .WithOne(x => x.departmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
