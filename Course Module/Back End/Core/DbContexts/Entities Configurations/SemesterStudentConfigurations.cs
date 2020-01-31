using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DbContexts.Entities_Configurations
{
    public class SemesterStudentConfigurations : IEntityTypeConfiguration<SemesterStudent>
    {
        public void Configure(EntityTypeBuilder<SemesterStudent> builder)
        {
            builder.HasKey(p => new { p.SemesterId, p.StudentId });
        }
    }
}