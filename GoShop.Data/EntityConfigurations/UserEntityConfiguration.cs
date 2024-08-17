using GoShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoShop.Data.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Email).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Password).IsRequired().HasMaxLength(255);
        builder.Property(t => t.UserName).IsRequired().HasMaxLength(255);

        //builder.HasMany(t => t.MobilePhones)
        //    .WithOne(x => x.User)
        //    .HasForeignKey(x => x.UserId);
    }
}
