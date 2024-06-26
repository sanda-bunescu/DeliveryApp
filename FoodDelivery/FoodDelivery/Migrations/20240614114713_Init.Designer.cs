﻿// <auto-generated />
using System;
using FoodDelivery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodDelivery.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240614114713_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodDelivery.Models.Couriers", b =>
                {
                    b.Property<int>("CouriersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouriersId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CouriersId");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("FoodDelivery.Models.Items", b =>
                {
                    b.Property<int>("ItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenusID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemsId");

                    b.HasIndex("MenusID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FoodDelivery.Models.Menus", b =>
                {
                    b.Property<int>("MenusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenusID"));

                    b.Property<int>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("MenusID");

                    b.HasIndex("RestaurantsId")
                        .IsUnique();

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("FoodDelivery.Models.Orders", b =>
                {
                    b.Property<int>("OrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdersId"));

                    b.Property<int>("CouriersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId");

                    b.HasIndex("CouriersId");

                    b.HasIndex("RestaurantsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodDelivery.Models.Payments", b =>
                {
                    b.Property<int>("PaymentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentsId"));

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentAmount")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentsId");

                    b.HasIndex("OrdersId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FoodDelivery.Models.Restaurants", b =>
                {
                    b.Property<int>("RestaurantsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantsId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantsId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("FoodDelivery.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderItems", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FoodDelivery.Models.Items", b =>
                {
                    b.HasOne("FoodDelivery.Models.Menus", "Menu")
                        .WithMany("Items")
                        .HasForeignKey("MenusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("FoodDelivery.Models.Menus", b =>
                {
                    b.HasOne("FoodDelivery.Models.Restaurants", "Restaurant")
                        .WithOne("Menu")
                        .HasForeignKey("FoodDelivery.Models.Menus", "RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodDelivery.Models.Orders", b =>
                {
                    b.HasOne("FoodDelivery.Models.Couriers", "Courier")
                        .WithMany("Orders")
                        .HasForeignKey("CouriersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDelivery.Models.Restaurants", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDelivery.Models.Users", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courier");

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodDelivery.Models.Payments", b =>
                {
                    b.HasOne("FoodDelivery.Models.Orders", "Orders")
                        .WithOne("Payment")
                        .HasForeignKey("FoodDelivery.Models.Payments", "OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderItems", b =>
                {
                    b.HasOne("FoodDelivery.Models.Items", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodDelivery.Models.Orders", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDelivery.Models.Couriers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodDelivery.Models.Menus", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FoodDelivery.Models.Orders", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("FoodDelivery.Models.Restaurants", b =>
                {
                    b.Navigation("Menu");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodDelivery.Models.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
