using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DbContexts.Entities_Configurations
{
    public class CoursePolicyConfigurations : IEntityTypeConfiguration<CoursePolicy>
    {
        public void Configure(EntityTypeBuilder<CoursePolicy> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}