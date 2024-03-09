using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class QuestionConfig : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(e => e.QsId);

        builder.ToTable("Question");

        builder.Property(e => e.QsId).HasColumnName("qs_id");
        builder.Property(e => e.CrsId).HasColumnName("crs_id");
        builder.Property(e => e.ModelAnswer).HasColumnName("model_answer");
        builder.Property(e => e.QsDifficulty)
            .HasMaxLength(20)
            .HasColumnName("qs_difficulty");
        builder.Property(e => e.QsGrade)
            .HasColumnType("decimal(4, 2)")
            .HasColumnName("qs_grade");
        builder.Property(e => e.QsTitle)
            .HasMaxLength(100)
            .HasColumnName("qs_title");
        builder.Property(e => e.QsType)
            .HasMaxLength(20)
            .HasColumnName("qs_type");

        builder.HasOne(d => d.Crs).WithMany(p => p.Questions)
            .HasForeignKey(d => d.CrsId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Question_Course");
    }
}