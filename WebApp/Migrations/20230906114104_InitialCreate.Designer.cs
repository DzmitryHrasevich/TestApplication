﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906114104_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("WebApp.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApp.Data.Entities.Organisation", b =>
                {
                    b.Property<string>("OrganisationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine4")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrganisationNumber");

                    b.HasIndex("OrganisationNumber")
                        .IsUnique();

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("WebApp.Data.Entities.Employee", b =>
                {
                    b.HasOne("WebApp.Data.Entities.Organisation", "Organisation")
                        .WithMany("Employees")
                        .HasForeignKey("OrganisationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("WebApp.Data.Entities.Organisation", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}