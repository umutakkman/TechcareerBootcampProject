﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;

#nullable disable

namespace TechcareerBootcampFest4Project.Migrations
{
    [DbContext(typeof(SiteContext))]
    partial class SiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CarCategory", b =>
                {
                    b.Property<int>("CarsCarID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriesCategoryID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarsCarID", "CategoriesCategoryID");

                    b.HasIndex("CategoriesCategoryID");

                    b.ToTable("CarCategory");
                });

            modelBuilder.Entity("TechcareerBootcampFest4Project.Entity.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RentPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("Seats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("CarID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TechcareerBootcampFest4Project.Entity.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TechcareerBootcampFest4Project.Entity.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarCategory", b =>
                {
                    b.HasOne("TechcareerBootcampFest4Project.Entity.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechcareerBootcampFest4Project.Entity.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
