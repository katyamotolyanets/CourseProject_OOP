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
    [Migration("20210516104935_addPhotoSource")]
    partial class addPhotoSource
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDiary.Core.Models.Activity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ActivityTime")
                        .HasColumnType("real");

                    b.Property<Guid>("IDActivityType")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDActivityType");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.ActivityType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ActivityCalories")
                        .HasColumnType("real");

                    b.Property<string>("ActivityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ActivityTypes");
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

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ProductWeight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("IDProduct");

                    b.HasIndex("IDType");

                    b.ToTable("ProductSets");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDLifestyle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAge")
                        .HasColumnType("int");

                    b.Property<double>("UserCalories")
                        .HasColumnType("float");

                    b.Property<double>("UserHeight")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UserWeight")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDLifestyle");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.UserHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDActivity")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProductSet")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDActivity");

                    b.HasIndex("IDProductSet");

                    b.HasIndex("IDUser");

                    b.ToTable("UsersHistories");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.UserLifestyle", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Coefficient")
                        .HasColumnType("float");

                    b.Property<string>("LifestyleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserLifestyles");
                });

            modelBuilder.Entity("FoodDiary.Core.Models.Activity", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.ActivityType", "ActivityType")
                        .WithMany("Activities")
                        .HasForeignKey("IDActivityType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Core.Models.ProductSet", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.Product", "Product")
                        .WithMany("ProductSets")
                        .HasForeignKey("IDProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Core.Models.MealType", "MealType")
                        .WithMany("ProductSets")
                        .HasForeignKey("IDType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Core.Models.User", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.UserLifestyle", "UserLifestyle")
                        .WithMany("Users")
                        .HasForeignKey("IDLifestyle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Core.Models.UserHistory", b =>
                {
                    b.HasOne("FoodDiary.Core.Models.Activity", "Activity")
                        .WithMany("UserHistories")
                        .HasForeignKey("IDActivity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Core.Models.ProductSet", "ProductSet")
                        .WithMany("UserHistories")
                        .HasForeignKey("IDProductSet")
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
