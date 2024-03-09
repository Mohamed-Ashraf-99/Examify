using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class TopicConfig : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topic");

        builder.HasIndex(e => e.TopicName, "UK_Topic_Name").IsUnique();

        builder.Property(e => e.TopicId).HasColumnName("topic_id");
        builder.Property(e => e.CrsId).HasColumnName("crs_id");
        builder.Property(e => e.TopicName)
            .HasMaxLength(50)
            .HasColumnName("topic_name");

        builder.HasOne(d => d.Crs).WithMany(p => p.Topics)
            .HasForeignKey(d => d.CrsId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Topic_Course");
    }
}