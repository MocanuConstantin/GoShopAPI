using GoShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Data.EntityConfigurations;

public class MobilePhoneSoftwareEntityConfiguration : IEntityTypeConfiguration<MobilePhoneSoftwareEntity>
{
    public void Configure(EntityTypeBuilder<MobilePhoneSoftwareEntity> builder)
    {
        builder.ToTable("MobilePhoneSoftware");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.MobilePhoneId).IsRequired();
        builder.Property(t => t.OperatingSystem).IsRequired().HasMaxLength(255);
        builder.Property(t => t.OSVersion).IsRequired().HasMaxLength(255);
        builder.Property(t => t.FirmwareVersion).IsRequired().HasMaxLength(255);
        builder.Property(t => t.IsRootedOrJailbroken).IsRequired();
        builder.Property(t => t.LastSoftwareUpdate).IsRequired();

        builder.HasOne(t => t.MobilePhone)
           .WithOne(x => x.MobilePhoneSoftware)
           .HasForeignKey<MobilePhoneSoftwareEntity>(x => x.MobilePhoneId);
    }
}

