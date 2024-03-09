using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PK_User");

        builder.HasIndex(e => e.EmailAddress, "UQ_User_email").IsUnique();

        builder.HasIndex(e => e.UserName, "UQ_User_userName").IsUnique();

        builder.Property(e => e.UserId).HasColumnName("user_id");
        builder.Property(e => e.EmailAddress)
            .HasMaxLength(50)
            .HasColumnName("email_address");
        builder.Property(e => e.Password)
            .HasMaxLength(50)
            .HasColumnName("password");
        builder.Property(e => e.RoleId).HasColumnName("role_id");
        builder.Property(e => e.UserFname)
            .HasMaxLength(20)
            .HasColumnName("user_fname");
        builder.Property(e => e.UserLname)
            .HasMaxLength(20)
            .HasColumnName("user_lname");
        builder.Property(e => e.UserName)
            .HasMaxLength(20)
            .HasColumnName("user_name");

        builder.HasOne(d => d.Role).WithMany(p => p.Users)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Users_Role");
    }
}