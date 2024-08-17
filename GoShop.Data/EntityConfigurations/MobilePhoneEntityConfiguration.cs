using GoShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoShop.Data.EntityConfigurations;

public class MobilePhoneEntityConfiguration : IEntityTypeConfiguration<MobilePhoneEntity>
{
    public void Configure(EntityTypeBuilder<MobilePhoneEntity> builder)
    {
        builder.ToTable("MobilePhones");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Brand).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Model).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Condition).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(255);

        builder.HasOne(t => t.MobilePhoneHardware)
            .WithOne(h => h.MobilePhone)
            .HasForeignKey<MobilePhoneHardwareEntity>(h => h.MobilePhoneId)
            .IsRequired();

        builder.HasOne(t => t.MobilePhoneSoftware)
            .WithOne(s => s.MobilePhone)
            .HasForeignKey<MobilePhoneSoftwareEntity>(s => s.MobilePhoneId)
            .IsRequired();
    }
}

