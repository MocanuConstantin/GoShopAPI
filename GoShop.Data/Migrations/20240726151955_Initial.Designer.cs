﻿// <auto-generated />
using System;
using GoShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoShop.Data.Migrations
{
    [DbContext(typeof(GoShopDbContext))]
    [Migration("20240726151955_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoShop.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MobilePhoneEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("MobilePhones", (string)null);
                });

            modelBuilder.Entity("MobilePhoneHardwareEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Battery")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Camera")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("MobilePhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MobilePhoneId")
                        .IsUnique();

                    b.ToTable("MobilePhoneHardware", (string)null);
                });

            modelBuilder.Entity("MobilePhoneSoftwareEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirmwareVersion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsRootedOrJailbroken")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastSoftwareUpdate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MobilePhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OSVersion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OperatingSystem")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MobilePhoneId")
                        .IsUnique();

                    b.ToTable("MobilePhoneSoftware", (string)null);
                });

            modelBuilder.Entity("MobilePhoneEntity", b =>
                {
                    b.HasOne("GoShop.Domain.Entities.UserEntity", null)
                        .WithMany("MobilePhones")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("MobilePhoneHardwareEntity", b =>
                {
                    b.HasOne("MobilePhoneEntity", "MobilePhone")
                        .WithOne("MobilePhoneHardware")
                        .HasForeignKey("MobilePhoneHardwareEntity", "MobilePhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MobilePhone");
                });

            modelBuilder.Entity("MobilePhoneSoftwareEntity", b =>
                {
                    b.HasOne("MobilePhoneEntity", "MobilePhone")
                        .WithOne("MobilePhoneSoftware")
                        .HasForeignKey("MobilePhoneSoftwareEntity", "MobilePhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MobilePhone");
                });

            modelBuilder.Entity("GoShop.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("MobilePhones");
                });

            modelBuilder.Entity("MobilePhoneEntity", b =>
                {
                    b.Navigation("MobilePhoneHardware")
                        .IsRequired();

                    b.Navigation("MobilePhoneSoftware")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
