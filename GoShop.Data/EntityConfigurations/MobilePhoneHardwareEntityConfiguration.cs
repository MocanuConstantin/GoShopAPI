using GoShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoShop.Data.EntityConfigurations;

public class MobilePhoneHardwareEntityConfiguration : IEntityTypeConfiguration<MobilePhoneHardwareEntity>
{
    public void Configure(EntityTypeBuilder<MobilePhoneHardwareEntity> builder)
    {
        builder.ToTable("MobilePhoneHardware");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Processor).IsRequired().HasMaxLength(255);
        builder.Property(t => t.RAM).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Storage).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Display).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Battery).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Camera).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Dimensions).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Weight).IsRequired().HasMaxLength(255);

        builder.HasOne(t => t.MobilePhone)
           .WithOne(x => x.MobilePhoneHardware)
           .HasForeignKey<MobilePhoneHardwareEntity>(x => x.MobilePhoneId);
    }
}