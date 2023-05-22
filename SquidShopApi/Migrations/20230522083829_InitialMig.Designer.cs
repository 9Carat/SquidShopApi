﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SquidShopApi.Data;

#nullable disable

namespace SquidShopApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230522083829_InitialMig")]
    partial class InitialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SquidShopApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Toys",
                            Details = "Play things"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Tools",
                            Details = "Work things"
                        });
                });

            modelBuilder.Entity("SquidShopApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_UserId")
                        .HasColumnType("int");

                    b.Property<bool>("OrderStatus")
                        .HasColumnType("bit");

                    b.HasKey("OrderId");

                    b.HasIndex("FK_UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SquidShopApi.Models.OrderList", b =>
                {
                    b.Property<int>("OrderListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderListId"));

                    b.Property<int>("FK_OrderId")
                        .HasColumnType("int");

                    b.Property<int>("FK_ProductId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderListId");

                    b.HasIndex("FK_OrderId");

                    b.HasIndex("FK_ProductId");

                    b.ToTable("OrderLists");
                });

            modelBuilder.Entity("SquidShopApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("DiscountUnitPrice")
                        .HasColumnType("float");

                    b.Property<int>("FK_CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("FK_CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Discount = 0m,
                            DiscountUnitPrice = 0.0,
                            FK_CategoryId = 1,
                            ImageName = "No URL",
                            InStock = 10,
                            ProductName = "Jonny Boy",
                            UnitPrice = 199.0
                        },
                        new
                        {
                            ProductId = 2,
                            Discount = 0m,
                            DiscountUnitPrice = 0.0,
                            FK_CategoryId = 1,
                            ImageName = "No URL",
                            InStock = 29,
                            ProductName = "After the laughter comes tears",
                            UnitPrice = 149.0
                        });
                });

            modelBuilder.Entity("SquidShopApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FK_UsersId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Forest",
                            City = "There",
                            FirstName = "Sven",
                            LastName = "Knutsson",
                            PostalCode = "20211"
                        });
                });

            modelBuilder.Entity("SquidShopApi.Models.Order", b =>
                {
                    b.HasOne("SquidShopApi.Models.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("FK_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SquidShopApi.Models.OrderList", b =>
                {
                    b.HasOne("SquidShopApi.Models.Order", "Orders")
                        .WithMany("OrderLists")
                        .HasForeignKey("FK_OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SquidShopApi.Models.Product", "Products")
                        .WithMany("OrderLists")
                        .HasForeignKey("FK_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("SquidShopApi.Models.Product", b =>
                {
                    b.HasOne("SquidShopApi.Models.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("FK_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("SquidShopApi.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SquidShopApi.Models.Order", b =>
                {
                    b.Navigation("OrderLists");
                });

            modelBuilder.Entity("SquidShopApi.Models.Product", b =>
                {
                    b.Navigation("OrderLists");
                });

            modelBuilder.Entity("SquidShopApi.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
