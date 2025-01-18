﻿// <auto-generated />
using System;
using Assignment.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations
{
    [DbContext(typeof(RDBMSDbContext))]
    partial class RDBMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Model.Domain.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Banani",
                            City = "Dhaka",
                            Country = "Bangladesh",
                            Phone = "+41023658"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Elm St",
                            City = "Anytown",
                            Country = "USA",
                            Phone = "+15551234"
                        },
                        new
                        {
                            Id = 3,
                            Address = "456 Oak Ave",
                            City = "London",
                            Country = "UK",
                            Phone = "+447911123456"
                        },
                        new
                        {
                            Id = 4,
                            Address = "789 Pine Ln",
                            City = "Sydney",
                            Country = "Australia",
                            Phone = "+61298765432"
                        },
                        new
                        {
                            Id = 5,
                            Address = "1011 Maple Dr",
                            City = "Madrid",
                            Country = "Spain",
                            Phone = "+34612345678"
                        });
                });

            modelBuilder.Entity("Assignment.Model.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Developer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Analyst"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Engineer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Designer"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Manager"
                        });
                });

            modelBuilder.Entity("Assignment.Model.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasFilter("[ContactId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Company = "Wunderman Thompson",
                            ContactId = 1,
                            FirstName = "Shibli",
                            LastName = "Arafat",
                            RoleId = 5,
                            Sex = "M"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Company = "Acme Corp",
                            ContactId = 2,
                            FirstName = "John",
                            LastName = "Doe",
                            RoleId = 1,
                            Sex = "M"
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Company = "Beta Industries",
                            ContactId = 3,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            RoleId = 2,
                            Sex = "F"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Company = "Gamma Solutions",
                            ContactId = 4,
                            FirstName = "Bob",
                            LastName = "Williams",
                            RoleId = 3,
                            Sex = "M"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Company = "Delta Group",
                            ContactId = 5,
                            FirstName = "Eva",
                            LastName = "Garcia",
                            RoleId = 4,
                            Sex = "F"
                        });
                });

            modelBuilder.Entity("Assignment.Model.Domain.User", b =>
                {
                    b.HasOne("Assignment.Model.Domain.Contact", "Contact")
                        .WithOne()
                        .HasForeignKey("Assignment.Model.Domain.User", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment.Model.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Contact");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
