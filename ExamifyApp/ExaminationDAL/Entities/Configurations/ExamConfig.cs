using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class ExamConfig : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(e => e.ExId);

        builder.ToTable("Exam");

        builder.Property(e => e.ExId).HasColumnName("ex_id");
        builder.Property(e => e.ExFinalGrade)
            .HasColumnType("decimal(5, 2)")
            .HasColumnName("ex_final_grade");
        builder.Property(e => e.ExName)
            .HasMaxLength(50)
            .HasColumnName("ex_name");
        builder.Property(e => e.StId).HasColumnName("st_id");

        builder.HasOne(d => d.St).WithMany(p => p.Exams)
            .HasForeignKey(d => d.StId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Exam_Student");
    }
}