﻿// <auto-generated />
using System;
using IceParlourApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IceParlourApp.Migrations
{
    [DbContext(typeof(BillingContext))]
    [Migration("20190514202112_IceParlourApp.Models.BillingContext")]
    partial class IceParlourAppModelsBillingContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IceParlourApp.Models.AddressMaster", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompleteAddress")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("ZipCode")
                        .HasMaxLength(6);

                    b.HasKey("AddressId");

                    b.ToTable("AddressMaster");
                });

            modelBuilder.Entity("IceParlourApp.Models.IceCreamMaster", b =>
                {
                    b.Property<int>("IceCreamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsToppings");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PriceId");

                    b.HasKey("IceCreamId");

                    b.HasIndex("PriceId");

                    b.ToTable("IceCreamMaster");

                    b.HasData(
                        new { IceCreamId = 1, IsToppings = false, Name = "Vanilla", PriceId = 1 },
                        new { IceCreamId = 2, IsToppings = false, Name = "Chocolate", PriceId = 2 },
                        new { IceCreamId = 3, IsToppings = false, Name = "Strawberry", PriceId = 3 },
                        new { IceCreamId = 4, IsToppings = false, Name = "Cookie and Cream", PriceId = 4 },
                        new { IceCreamId = 5, IsToppings = false, Name = "Hazel Nut ", PriceId = 5 },
                        new { IceCreamId = 6, IsToppings = true, Name = "Cookies", PriceId = 6 },
                        new { IceCreamId = 7, IsToppings = true, Name = "Fruits", PriceId = 7 },
                        new { IceCreamId = 8, IsToppings = true, Name = "Chocochips", PriceId = 8 },
                        new { IceCreamId = 9, IsToppings = true, Name = "Nuts", PriceId = 9 }
                    );
                });

            modelBuilder.Entity("IceParlourApp.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IceCreamId");

                    b.Property<int>("OrderNumber");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("IceCreamId");

                    b.HasIndex("OrderNumber");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("IceParlourApp.Models.OrderMaster", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CustomerName");

                    b.Property<bool>("IsPaid");

                    b.Property<int>("NumberOfScoop");

                    b.Property<string>("PaymentType");

                    b.Property<int>("Quantity");

                    b.Property<string>("Remarks");

                    b.Property<double>("TotalAmount");

                    b.HasKey("OrderNumber");

                    b.HasIndex("AddressId");

                    b.ToTable("OrderMaster");
                });

            modelBuilder.Entity("IceParlourApp.Models.PriceMaster", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.HasKey("PriceId");

                    b.ToTable("PriceMaster");

                    b.HasData(
                        new { PriceId = 1, Currency = "INR", Price = 16.0 },
                        new { PriceId = 2, Currency = "INR", Price = 17.0 },
                        new { PriceId = 3, Currency = "INR", Price = 18.0 },
                        new { PriceId = 4, Currency = "INR", Price = 19.0 },
                        new { PriceId = 5, Currency = "INR", Price = 20.0 },
                        new { PriceId = 6, Currency = "INR", Price = 0.0 },
                        new { PriceId = 7, Currency = "INR", Price = 0.0 },
                        new { PriceId = 8, Currency = "INR", Price = 0.0 },
                        new { PriceId = 9, Currency = "INR", Price = 0.0 }
                    );
                });

            modelBuilder.Entity("IceParlourApp.Models.IceCreamMaster", b =>
                {
                    b.HasOne("IceParlourApp.Models.PriceMaster", "PriceMaster")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IceParlourApp.Models.OrderDetail", b =>
                {
                    b.HasOne("IceParlourApp.Models.IceCreamMaster", "IceCreamMaster")
                        .WithMany()
                        .HasForeignKey("IceCreamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IceParlourApp.Models.OrderMaster", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IceParlourApp.Models.OrderMaster", b =>
                {
                    b.HasOne("IceParlourApp.Models.AddressMaster", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
