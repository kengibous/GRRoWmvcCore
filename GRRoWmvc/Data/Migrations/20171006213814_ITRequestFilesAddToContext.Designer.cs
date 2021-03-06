﻿// <auto-generated />
using GRRoWmvc.Data;
using GRRoWmvc.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GRRoWmvc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171006213814_ITRequestFilesAddToContext")]
    partial class ITRequestFilesAddToContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GRRoWmvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GRRoWmvc.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("AdoptionDate");

                    b.Property<double>("AdoptionFee");

                    b.Property<string>("Age")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("BridgeDate");

                    b.Property<string>("DogId")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int>("DogStatus");

                    b.Property<int>("EnergyLevel");

                    b.Property<int>("Gender");

                    b.Property<int>("InteractionWithCats");

                    b.Property<int>("InteractionWithDogs");

                    b.Property<int>("InteractionWithKids");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasMaxLength(250);

                    b.Property<DateTimeOffset?>("SurrenderDate");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("GRRoWmvc.Models.DogImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DogId");

                    b.Property<int>("Height");

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("ImageName");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.ToTable("DogImages");
                });

            modelBuilder.Entity("GRRoWmvc.Models.DogUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("CreateDate");

                    b.Property<int>("DogId");

                    b.Property<string>("Notes")
                        .HasMaxLength(1500);

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.ToTable("DogUpdates");
                });

            modelBuilder.Entity("GRRoWmvc.Models.ITRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompletedBy")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("CompletedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<int?>("ITRequestId");

                    b.Property<string>("RequestedBy")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("RequestedDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ITRequestId");

                    b.ToTable("ITRequests");
                });

            modelBuilder.Entity("GRRoWmvc.Models.ITRequestFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("FileData")
                        .IsRequired();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Height");

                    b.Property<int>("ITRequestId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("ITRequestId");

                    b.ToTable("ITRequestFiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GRRoWmvc.Models.DogImage", b =>
                {
                    b.HasOne("GRRoWmvc.Models.Dog", "Dog")
                        .WithMany("DogImages")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GRRoWmvc.Models.DogUpdate", b =>
                {
                    b.HasOne("GRRoWmvc.Models.Dog", "Dog")
                        .WithMany("DogUpdates")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GRRoWmvc.Models.ITRequest", b =>
                {
                    b.HasOne("GRRoWmvc.Models.ITRequest")
                        .WithMany("ITRequestFiles")
                        .HasForeignKey("ITRequestId");
                });

            modelBuilder.Entity("GRRoWmvc.Models.ITRequestFile", b =>
                {
                    b.HasOne("GRRoWmvc.Models.ITRequest", "ITRequest")
                        .WithMany()
                        .HasForeignKey("ITRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GRRoWmvc.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GRRoWmvc.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GRRoWmvc.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GRRoWmvc.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
