using Core.DbContexts.Entities_Configurations;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core.DbContexts
{
    public class CourseDbContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePolicy> CoursePolicies { get; set; }
        public DbSet<LecturerCoursePolicyDetail> LecturerCoursePolicyDetails { get; set; }
        public DbSet<CoursePolicyDetail> CoursePolicyDetails { get; set; }
        public DbSet<LecturerCoursePolicy> LecturerCoursePolicies { get; set; }
        public DbSet<Grading> Gradings { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SemesterCourse> SemesterCourses { get; set; }
        public DbSet<SemesterStudent> SemesterStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public CourseDbContext(DbContextOptions<CourseDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);   

            modelBuilder.ApplyConfiguration(new CoursePolicyConfigurations());  
            modelBuilder.ApplyConfiguration(new SemesterCourseConfigurations());    
            modelBuilder.ApplyConfiguration(new SemesterStudentConfigurations());  

        }
    }

    public class CourseDbContextFactory : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseMySql("server=localhost;database=NuCourse;user=root;password=yoursql");

            return new CourseDbContext(optionsBuilder.Options);
        }
    }
}