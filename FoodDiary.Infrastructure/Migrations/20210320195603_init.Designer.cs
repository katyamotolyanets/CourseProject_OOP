﻿// <auto-generated />
using System;
using FoodDiary.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDiary.Infrastructure.Migrations
{
    [DbContext(typeof(FoodDiaryContext))]
    [Migration("20210320195603_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDiary.Core.Models.Meal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDType")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDType");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.MealType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MealName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Calories")
                        .HasColumnType("real");

                    b.Property<float>("Carbohydrates")
                        .HasColumnType("real");

                    b.Property<float>("EnergyValue")
                        .HasColumnType("real");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<string>("NameProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.ProductSet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDMeal")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ProductWeight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("IDMeal");

                    b.HasIndex("IDProduct");

                    b.ToTable("ProductSets");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("UserHeight")
                        .HasColumnType("real");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UserWeight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.UserHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDMeal")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDMeal");

                    b.HasIndex("IDUser");

                    b.ToTable("UsersHistories");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.Meal", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.MealType", "MealType")
                        .WithMany("Meals")
                        .HasForeignKey("IDType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Core.Models.ProductSet", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.Meal", "Meal")
                        .WithMany("ProductSets")
                        .HasForeignKey("IDMeal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Core.Models.Product", "Product")
                        .WithMany("ProductSets")
                        .HasForeignKey("IDProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Core.Models.UserHistory", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.Meal", "Meal")
                        .WithMany("UserHistories")
                        .HasForeignKey("IDMeal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Core.Models.User", "User")
                        .WithMany("UserHistories")
                        .HasForeignKey("IDUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}