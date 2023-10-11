﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestIlcsApi.Repositories;

#nullable disable

namespace TestIlcsApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestIlcsApi.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Char")
                        .HasColumnType("NVarchar(3)")
                        .HasColumnName("char");

                    b.Property<string>("Code")
                        .HasColumnType("NVarchar(10)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("m_country");
                });

            modelBuilder.Entity("TestIlcsApi.Entities.Harbour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Char")
                        .HasColumnType("NVarchar(3)")
                        .HasColumnName("char");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("m_harbour");
                });

            modelBuilder.Entity("TestIlcsApi.Entities.Ppn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Percent")
                        .HasColumnType("int")
                        .HasColumnName("percent");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("m_ppn");
                });

            modelBuilder.Entity("TestIlcsApi.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CodeProduct")
                        .HasColumnType("NVarchar(10)")
                        .HasColumnName("code_product");

                    b.Property<string>("Name")
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("name");

                    b.Property<long>("Price")
                        .HasColumnType("bigint")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("m_product");
                });

            modelBuilder.Entity("TestIlcsApi.Entities.Harbour", b =>
                {
                    b.HasOne("TestIlcsApi.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TestIlcsApi.Entities.Ppn", b =>
                {
                    b.HasOne("TestIlcsApi.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}