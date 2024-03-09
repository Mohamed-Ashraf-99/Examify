using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationDAL.Entities.Configurations;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(e => e.DeptId);

        builder.ToTable("Department");

        builder.Property(e => e.DeptId).HasColumnName("dept_id");
        builder.Property(e => e.DeptDesc)
            .HasMaxLength(50)
            .HasColumnName("dept_desc");
        builder.Property(e => e.DeptLocation)
            .HasMaxLength(30)
            .HasColumnName("dept_location");
        builder.Property(e => e.DeptMgrId).HasColumnName("dept_mgr_id");
        builder.Property(e => e.DeptName)
            .HasMaxLength(50)
            .HasColumnName("dept_name");
        builder.Property(e => e.MgrHireDate).HasColumnName("mgr_hire_date");

        builder.HasOne(d => d.DeptMgr).WithMany(p => p.Departments)
            .HasForeignKey(d => d.DeptMgrId)
            .HasConstraintName("FK_Department_Instructor");
    }
}