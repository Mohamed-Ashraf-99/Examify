using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class IncludeConfig : IEntityTypeConfiguration<Include>
{
    public void Configure(EntityTypeBuilder<Include> builder)
    {
        builder.HasKey(e => new { e.ExId, e.QsId }).HasName("PK_Contains");

        builder.Property(e => e.ExId).HasColumnName("ex_id");
        builder.Property(e => e.QsId).HasColumnName("qs_id");
        builder.Property(e => e.StAnswer).HasColumnName("st_answer");

        builder.HasOne(d => d.Ex).WithMany(p => p.Includes)
            .HasForeignKey(d => d.ExId)
            .HasConstraintName("FK_Contains_Exam");

        builder.HasOne(d => d.Qs).WithMany(p => p.Includes)
            .HasForeignKey(d => d.QsId)
            .HasConstraintName("FK_Contains_Question");
    }
}