﻿using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configuration;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasIndex(i => i.UserName).IsUnique();

        builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
        builder.Property(p => p.LastName).HasColumnType("varchar(50)");
        builder.Property(p => p.UserName).HasColumnType("varchar(20)");
        builder.Property(p => p.Email).HasColumnType("varchar(MAX)");
    }
}
