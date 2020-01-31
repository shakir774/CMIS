using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DbContexts.Entities_Configurations
{
    public class SemesterCourseConfigurations : IEntityTypeConfiguration<SemesterCourse>
    {
        public void Configure(EntityTypeBuilder<SemesterCourse> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}