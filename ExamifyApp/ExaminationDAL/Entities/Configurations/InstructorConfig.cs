using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(e => e.InsId);

        builder.ToTable("Instructor");

        builder.Property(e => e.InsId)
            .ValueGeneratedNever()
            .HasColumnName("ins_id");
        builder.Property(e => e.InsDegree)
            .HasMaxLength(20)
            .HasColumnName("ins_degree");
        builder.Property(e => e.InsSalary)
            .HasColumnType("money")
            .HasColumnName("ins_salary");

        builder.HasOne(d => d.Ins).WithOne(p => p.Instructor)
            .HasForeignKey<Instructor>(d => d.InsId)
            .HasConstraintName("FK_Instructor_Users");

        builder.HasMany(d => d.Crs).WithMany(p => p.Ins)
            .UsingEntity<Dictionary<string, object>>(
                "Teach",
                r => r.HasOne<Course>().WithMany()
                    .HasForeignKey("CrsId")
                    .HasConstraintName("FK_Teaches_Course"),
                l => l.HasOne<Instructor>().WithMany()
                    .HasForeignKey("InsId")
                    .HasConstraintName("FK_Teaches_Instructor"),
                j =>
                {
                    j.HasKey("InsId", "CrsId");
                    j.ToTable("Teaches");
                    j.IndexerProperty<int>("InsId").HasColumnName("ins_id");
                    j.IndexerProperty<int>("CrsId").HasColumnName("crs_id");
                });

        builder.HasMany(d => d.Depts).WithMany(p => p.Ins)
            .UsingEntity<Dictionary<string, object>>(
                "WorksIn",
                r => r.HasOne<Department>().WithMany()
                    .HasForeignKey("DeptId")
                    .HasConstraintName("FK_Works_in_Department"),
                l => l.HasOne<Instructor>().WithMany()
                    .HasForeignKey("InsId")
                    .HasConstraintName("FK_Works_in_Instructor"),
                j =>
                {
                    j.HasKey("InsId", "DeptId");
                    j.ToTable("Works_in");
                    j.IndexerProperty<int>("InsId").HasColumnName("ins_id");
                    j.IndexerProperty<int>("DeptId").HasColumnName("dept_id");
                });
    }
}