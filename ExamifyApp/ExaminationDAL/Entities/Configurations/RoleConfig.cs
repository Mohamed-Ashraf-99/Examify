using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.Property(e => e.RoleId).HasColumnName("role_id");
        builder.Property(e => e.RoleDesc)
            .HasMaxLength(50)
            .HasColumnName("role_desc");
        builder.Property(e => e.RoleName)
            .HasMaxLength(20)
            .HasColumnName("role_name");
    }
}