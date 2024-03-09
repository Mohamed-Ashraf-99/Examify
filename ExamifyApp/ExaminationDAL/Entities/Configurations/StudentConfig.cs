using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(e => e.StId);

        builder.ToTable("Student");

        builder.Property(e => e.StId)
            .ValueGeneratedNever()
            .HasColumnName("st_id");
        builder.Property(e => e.DeptId).HasColumnName("dept_id");
        builder.Property(e => e.StAddress)
            .HasMaxLength(50)
            .HasColumnName("st_address");
        builder.Property(e => e.StImg)
            .HasMaxLength(100)
            .HasColumnName("st_img");

        builder.HasOne(d => d.Dept).WithMany(p => p.Students)
            .HasForeignKey(d => d.DeptId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Student_Department");

        builder.HasOne(d => d.St).WithOne(p => p.Student)
            .HasForeignKey<Student>(d => d.StId)
            .HasConstraintName("FK_Student_Users");

        builder.HasMany(d => d.Crs).WithMany(p => p.Sts)
            .UsingEntity<Dictionary<string, object>>(
                "Study",
                r => r.HasOne<Course>().WithMany()
                    .HasForeignKey("CrsId")
                    .HasConstraintName("FK_Studies_Course"),
                l => l.HasOne<Student>().WithMany()
                    .HasForeignKey("StId")
                    .HasConstraintName("FK_Studies_Student"),
                j =>
                {
                    j.HasKey("StId", "CrsId");
                    j.ToTable("Studies");
                    j.IndexerProperty<int>("StId").HasColumnName("st_id");
                    j.IndexerProperty<int>("CrsId").HasColumnName("crs_id");
                });
    }
}