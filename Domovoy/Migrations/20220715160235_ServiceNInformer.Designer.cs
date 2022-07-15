﻿// <auto-generated />
using System;
using Domovoy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domovoy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220715160235_ServiceNInformer")]
    partial class ServiceNInformer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ApartmentApplicationUser", b =>
                {
                    b.Property<int>("ApartmentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ApartmentsId", "TenantsId");

                    b.HasIndex("TenantsId");

                    b.ToTable("ApartmentApplicationUser");
                });

            modelBuilder.Entity("Domovoy.Models.ActiveSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventInformerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventInformerId");

                    b.ToTable("ActiveSession");
                });

            modelBuilder.Entity("Domovoy.Models.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AparmentState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Area")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseEntranceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HouseEntranceId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Domovoy.Models.ApartmentHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResidentialComplexId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialComplexId");

                    b.ToTable("ApartmentHouses");
                });

            modelBuilder.Entity("Domovoy.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConstructionCompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MainApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionCompanyId");

                    b.HasIndex("MainApartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domovoy.Models.ConstructionCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConstructionCompanies");
                });

            modelBuilder.Entity("Domovoy.Models.EventInformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InformertId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNowActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EventInformer");
                });

            modelBuilder.Entity("Domovoy.Models.HouseEntrance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentHouseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnranceNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentHouseId");

                    b.ToTable("HouseEntrances");
                });

            modelBuilder.Entity("Domovoy.Models.Informer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventInformerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InformMeterId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastInform")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("EventInformerId")
                        .IsUnique();

                    b.HasIndex("InformMeterId")
                        .IsUnique();

                    b.ToTable("Informers");
                });

            modelBuilder.Entity("Domovoy.Models.InformMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InformertId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastInformedCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("InformMeter");
                });

            modelBuilder.Entity("Domovoy.Models.PermanentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoPay")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("PermanentServices");
                });

            modelBuilder.Entity("Domovoy.Models.ResidentialComplex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConstructionCompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionCompanyId");

                    b.ToTable("ResidentialComplexes");
                });

            modelBuilder.Entity("Domovoy.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Check")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasPaid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PermanentServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApartmentApplicationUser", b =>
                {
                    b.HasOne("Domovoy.Models.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domovoy.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("TenantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domovoy.Models.ActiveSession", b =>
                {
                    b.HasOne("Domovoy.Models.EventInformer", "EventInformer")
                        .WithMany("ActiveSessions")
                        .HasForeignKey("EventInformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInformer");
                });

            modelBuilder.Entity("Domovoy.Models.Apartment", b =>
                {
                    b.HasOne("Domovoy.Models.HouseEntrance", "HouseEntrance")
                        .WithMany("Apartments")
                        .HasForeignKey("HouseEntranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domovoy.Models.ApplicationUser", "Owner")
                        .WithMany("OwndedApartments")
                        .HasForeignKey("OwnerId");

                    b.Navigation("HouseEntrance");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domovoy.Models.ApartmentHouse", b =>
                {
                    b.HasOne("Domovoy.Models.ResidentialComplex", "ResidentialComplex")
                        .WithMany("ApartmentHouses")
                        .HasForeignKey("ResidentialComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResidentialComplex");
                });

            modelBuilder.Entity("Domovoy.Models.ApplicationUser", b =>
                {
                    b.HasOne("Domovoy.Models.ConstructionCompany", "ConstructionCompany")
                        .WithMany("Employees")
                        .HasForeignKey("ConstructionCompanyId");

                    b.HasOne("Domovoy.Models.Apartment", "MainApartment")
                        .WithMany("TenantsWhoMainThis")
                        .HasForeignKey("MainApartmentId");

                    b.Navigation("ConstructionCompany");

                    b.Navigation("MainApartment");
                });

            modelBuilder.Entity("Domovoy.Models.HouseEntrance", b =>
                {
                    b.HasOne("Domovoy.Models.ApartmentHouse", "ApartmentHouse")
                        .WithMany("HouseEntrances")
                        .HasForeignKey("ApartmentHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartmentHouse");
                });

            modelBuilder.Entity("Domovoy.Models.Informer", b =>
                {
                    b.HasOne("Domovoy.Models.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domovoy.Models.EventInformer", "EventInformer")
                        .WithOne("Informer")
                        .HasForeignKey("Domovoy.Models.Informer", "EventInformerId");

                    b.HasOne("Domovoy.Models.InformMeter", "InformMeter")
                        .WithOne("Informer")
                        .HasForeignKey("Domovoy.Models.Informer", "InformMeterId");

                    b.Navigation("Apartment");

                    b.Navigation("EventInformer");

                    b.Navigation("InformMeter");
                });

            modelBuilder.Entity("Domovoy.Models.PermanentService", b =>
                {
                    b.HasOne("Domovoy.Models.Service", "Service")
                        .WithOne("PermanentService")
                        .HasForeignKey("Domovoy.Models.PermanentService", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Domovoy.Models.ResidentialComplex", b =>
                {
                    b.HasOne("Domovoy.Models.ConstructionCompany", "ConstructionCompany")
                        .WithMany("ResidentialComplexes")
                        .HasForeignKey("ConstructionCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConstructionCompany");
                });

            modelBuilder.Entity("Domovoy.Models.Service", b =>
                {
                    b.HasOne("Domovoy.Models.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domovoy.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domovoy.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domovoy.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domovoy.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domovoy.Models.Apartment", b =>
                {
                    b.Navigation("TenantsWhoMainThis");
                });

            modelBuilder.Entity("Domovoy.Models.ApartmentHouse", b =>
                {
                    b.Navigation("HouseEntrances");
                });

            modelBuilder.Entity("Domovoy.Models.ApplicationUser", b =>
                {
                    b.Navigation("OwndedApartments");
                });

            modelBuilder.Entity("Domovoy.Models.ConstructionCompany", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("ResidentialComplexes");
                });

            modelBuilder.Entity("Domovoy.Models.EventInformer", b =>
                {
                    b.Navigation("ActiveSessions");

                    b.Navigation("Informer")
                        .IsRequired();
                });

            modelBuilder.Entity("Domovoy.Models.HouseEntrance", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("Domovoy.Models.InformMeter", b =>
                {
                    b.Navigation("Informer")
                        .IsRequired();
                });

            modelBuilder.Entity("Domovoy.Models.ResidentialComplex", b =>
                {
                    b.Navigation("ApartmentHouses");
                });

            modelBuilder.Entity("Domovoy.Models.Service", b =>
                {
                    b.Navigation("PermanentService");
                });
#pragma warning restore 612, 618
        }
    }
}
