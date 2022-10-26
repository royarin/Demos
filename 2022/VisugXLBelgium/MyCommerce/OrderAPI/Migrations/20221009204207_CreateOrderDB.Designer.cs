﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderAPI.Data;

#nullable disable

namespace OrderAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20221009204207_CreateOrderDB")]
    partial class CreateOrderDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderAPI.Models.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("OrderAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"), 1L, 1);

                    b.Property<string>("DeliveryAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryPostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderAPI.Models.LineItem", b =>
                {
                    b.HasOne("OrderAPI.Models.Order", null)
                        .WithMany("LineItems")
                        .HasForeignKey("OrderNumber");
                });

            modelBuilder.Entity("OrderAPI.Models.Order", b =>
                {
                    b.Navigation("LineItems");
                });
#pragma warning restore 612, 618
        }
    }
}
