using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoShop.Data;

public class GoShopDbContext : DbContext
{
    public DbSet<MobilePhoneEntity> MobilePhoneEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DbSet<MobilePhoneHardwareEntity> MobilePhoneHardwareEntities { get; set; }
    public DbSet<MobilePhoneSoftwareEntity> MobilePhoneSoftwareEntities { get; set; }

    public GoShopDbContext(DbContextOptions<GoShopDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Добавляем конфигурации для сущностей

        modelBuilder.Entity<MobilePhoneHardwareEntity>(builder =>
        {
            builder.HasOne(h => h.MobilePhone)
                   .WithOne(p => p.MobilePhoneHardware)
                   .HasForeignKey<MobilePhoneHardwareEntity>(h => h.MobilePhoneId);

            // Другие настройки для MobilePhoneHardwareEntity, если есть
        });

        modelBuilder.Entity<MobilePhoneSoftwareEntity>(builder =>
        {
            builder.HasOne(s => s.MobilePhone)
                   .WithOne(p => p.MobilePhoneSoftware)
                   .HasForeignKey<MobilePhoneSoftwareEntity>(s => s.MobilePhoneId);

            // Другие настройки для MobilePhoneSoftwareEntity, если есть
        });

        // Вызовите базовую реализацию
        base.OnModelCreating(modelBuilder);
    }
}
