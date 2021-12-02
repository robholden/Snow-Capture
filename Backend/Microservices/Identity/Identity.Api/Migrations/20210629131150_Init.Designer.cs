﻿// <auto-generated />
using System;
using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Identity.Api.Migrations;

[DbContext(typeof(IdentityContext))]
[Migration("20210629131150_Init")]
partial class Init
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("Relational:MaxIdentifierLength", 128)
            .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        modelBuilder.Entity("Identity.Domain.AuthToken", b =>
            {
                b.Property<Guid>("AuthTokenId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Created")
                    .HasColumnType("datetime2");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.Property<string>("IdentityKey")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("IpAddress")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Platform")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("PlatformRaw")
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                b.Property<string>("RefreshToken")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<DateTime>("RefreshedAt")
                    .HasColumnType("datetime2");

                b.Property<int>("Refreshes")
                    .HasColumnType("int");

                b.Property<bool>("RememberIdentityForTwoFactor")
                    .HasColumnType("bit");

                b.Property<bool>("TwoFactorPassed")
                    .HasColumnType("bit");

                b.Property<DateTime?>("Updated")
                    .HasColumnType("datetime2");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("AuthTokenId");

                b.HasIndex("UserId");

                b.ToTable("AuthTokens");
            });

        modelBuilder.Entity("Identity.Domain.FailedLogin", b =>
            {
                b.Property<Guid>("FailedLoginId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Created")
                    .HasColumnType("datetime2");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("FailedLoginId");

                b.HasIndex("UserId");

                b.ToTable("FailedLogins");
            });

        modelBuilder.Entity("Identity.Domain.Password", b =>
            {
                b.Property<Guid>("PasswordId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<byte[]>("PasswordHash")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.Property<byte[]>("PasswordSalt")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("PasswordId");

                b.HasIndex("UserId");

                b.ToTable("Passwords");
            });

        modelBuilder.Entity("Identity.Domain.RecoveryCode", b =>
            {
                b.Property<Guid>("RecoveryCodeId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Created")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("UsedAt")
                    .HasColumnType("datetime2");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnType("nvarchar(500)");

                b.HasKey("RecoveryCodeId");

                b.HasIndex("UserId");

                b.ToTable("RecoveryCodes");
            });

        modelBuilder.Entity("Identity.Domain.TwoFactor", b =>
            {
                b.Property<int>("TwoFactorId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Code")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<long?>("TimeStamp")
                    .IsRequired()
                    .HasColumnType("bigint");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("TwoFactorId");

                b.HasIndex("UserId");

                b.ToTable("TwoFactors");
            });

        modelBuilder.Entity("Identity.Domain.User", b =>
            {
                b.Property<Guid>("UserId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Created")
                    .HasColumnType("datetime2");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                b.Property<int>("ExternalProvider")
                    .HasColumnType("int");

                b.Property<string>("ExternalProviderIdentifier")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ExternalProviderToken")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("LastActive")
                    .HasColumnType("datetime2");

                b.Property<string>("Mobile")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                b.Property<string>("TwoFactorSecret")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("TwoFactorType")
                    .HasColumnType("int");

                b.Property<int>("UserLevel")
                    .HasColumnType("int");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("UserId");

                b.HasIndex("Email")
                    .IsUnique();

                b.HasIndex("Username")
                    .IsUnique();

                b.ToTable("Users");
            });

        modelBuilder.Entity("Identity.Domain.UserKey", b =>
            {
                b.Property<Guid>("UserKeyId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Created")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("Expires")
                    .HasColumnType("datetime2");

                b.Property<bool>("Invalidated")
                    .HasColumnType("bit");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.Property<DateTime?>("UsedAt")
                    .HasColumnType("datetime2");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("UserKeyId");

                b.HasIndex("Key")
                    .IsUnique();

                b.HasIndex("UserId");

                b.ToTable("UserKeys");
            });

        modelBuilder.Entity("Identity.Domain.AuthToken", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany("AuthTokens")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.FailedLogin", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.Password", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany("Passwords")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.RecoveryCode", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany("RecoveryCodes")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.TwoFactor", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.UserKey", b =>
            {
                b.HasOne("Identity.Domain.User", "User")
                    .WithMany("UserKeys")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Identity.Domain.User", b =>
            {
                b.Navigation("AuthTokens");

                b.Navigation("Passwords");

                b.Navigation("RecoveryCodes");

                b.Navigation("UserKeys");
            });
#pragma warning restore 612, 618
    }
}
