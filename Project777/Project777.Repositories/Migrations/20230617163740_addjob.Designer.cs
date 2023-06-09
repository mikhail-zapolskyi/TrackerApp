﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project777.Repositories;

#nullable disable

namespace Project777.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230617163740_addjob")]
    partial class addjob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project777.Models.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("ClosingDate")
                        .HasColumnType("date");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HiringManager")
                        .HasColumnType("text");

                    b.Property<Guid>("JobCategoryID")
                        .HasColumnType("uuid");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Referrer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Project777.Models.Entities.JobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("Project777.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project777.Models.Entities.Job", b =>
                {
                    b.HasOne("Project777.Models.Entities.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
