using PraceticeBackend.Interfaces;
using PraceticeBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace PraceticeBackend.Infrasturcture
{

    public class SchoolContext : DbContext
    {
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {

    }

        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

            // Add any model configuration here
            // For example, to configure the one-to-one relationship between UserProfile and Address:
            //modelBuilder.Entity<School>()
            //               .HasOne(s => s.Address)
            //               .WithMany()
            //               .HasForeignKey(s => s.AddressId);

            //modelBuilder.Entity<City>()
            //    .HasOne(c => c.State)
            //    .WithMany()
            //    .HasForeignKey(c => c.StateId);

            //modelBuilder.Entity<Address>()
            //    .HasMany(a => a.UserEntities)
            //    .WithOne(u => u.AddressId);

            //modelBuilder.Entity<Course>().HasOne(c => c.Teacher);

            //modelBuilder.Entity<Student>()
            //    .HasMany(s => s.Courses);

            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.Courses);


            // Configure the relationship between School and Department entities
            modelBuilder.Entity<School>()
                .HasMany(s => s.Departments);

            // Configure the relationship between Department and Course entities
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);

            // Configure the relationship between Department and Teacher entities
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId);

            // Configure the relationship between Course and Student entities
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // Configure the relationship between Course and Teacher entities
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            // Configure the relationship between Teacher and UserProfile entities
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.UserEntities)
                .WithOne(u => u.Teacher)
                .HasForeignKey<UserProfile>(u => u.TeacherId);

            // Configure the relationship between Student and UserProfile entities
            modelBuilder.Entity<Student>()
                .HasOne(s => s.UserEntities)
                .WithOne(u => u.Student)
                .HasForeignKey<UserProfile>(u => u.StudentId);

            // Configure the relationship between Address and UserProfile entities
            modelBuilder.Entity<Address>()
                .HasMany(a => a.UserEntities)
                .WithOne(u => u.Address)
                .HasForeignKey(u => u.AddressId);

            // Configure the relationship between City and Address entities
            modelBuilder.Entity<City>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);

            // Configure the relationship between State and City entities
            modelBuilder.Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.State);

        }
    }

}
