using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.CrsId);

        builder.ToTable("Course");

        builder.Property(e => e.CrsId).HasColumnName("crs_id");
        builder.Property(e => e.CrsDuration).HasColumnName("crs_duration");
        builder.Property(e => e.CrsName)
            .HasMaxLength(50)
            .HasColumnName("crs_name");
    }
}