using CleanArch.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configuration;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.OwnsOne(p => p.PersonalInfo, builder =>
        {
            builder.Property(i => i.SocialSecurityNumber).HasColumnName("SocialSecurityNumber");
            builder.Property(i => i.Email).HasColumnName("Email");
            builder.Property(i => i.PhoneNumber).HasColumnName("PhoneNumber");
        });

        builder.OwnsOne(p => p.Address, builder =>
        {
            builder.Property(i => i.Street).HasColumnName("Street");
            builder.Property(i => i.City).HasColumnName("City");
            builder.Property(i => i.State).HasColumnName("State");
            builder.Property(i => i.ZipCode).HasColumnName("ZipCode");
        });

        builder.Property(p => p.Salary).HasColumnType("money");
    }
}
