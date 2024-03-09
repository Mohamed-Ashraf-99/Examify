using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class MultipleChoiceConfig : IEntityTypeConfiguration<MultipleChoice>
{
    public void Configure(EntityTypeBuilder<MultipleChoice> builder)
    {
        builder.HasKey(e => e.ChId);

        builder.ToTable("Multiple_choices");

        builder.Property(e => e.ChId).HasColumnName("ch_id");
        builder.Property(e => e.ChTitle)
            .HasMaxLength(10)
            .IsFixedLength()
            .HasColumnName("ch_title");
        builder.Property(e => e.QsId).HasColumnName("qs_id");

        builder.HasOne(d => d.Qs).WithMany(p => p.MultipleChoices)
            .HasForeignKey(d => d.QsId)
            .HasConstraintName("FK_Multiple_choices_Question");
    }
}