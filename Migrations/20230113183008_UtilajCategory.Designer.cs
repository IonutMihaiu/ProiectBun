﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectBun.Data;

#nullable disable

namespace ProiectBun.Migrations
{
    [DbContext(typeof(ProiectBunContext))]
    [Migration("20230113183008_UtilajCategory")]
    partial class UtilajCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectBun.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ProiectBun.Models.Marca", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("MarcaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("ProiectBun.Models.Sofer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("SoferName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sofer");
                });

            modelBuilder.Entity("ProiectBun.Models.Utilaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("NumeUtilaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SoferID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MarcaID");

                    b.HasIndex("SoferID");

                    b.ToTable("Utilaj");
                });

            modelBuilder.Entity("ProiectBun.Models.UtilajCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("UtilajID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UtilajID");

                    b.ToTable("UtilajCategory");
                });

            modelBuilder.Entity("ProiectBun.Models.Utilaj", b =>
                {
                    b.HasOne("ProiectBun.Models.Marca", "Marca")
                        .WithMany("Utilaje")
                        .HasForeignKey("MarcaID");

                    b.HasOne("ProiectBun.Models.Sofer", "Sofer")
                        .WithMany("Utilaje")
                        .HasForeignKey("SoferID");

                    b.Navigation("Marca");

                    b.Navigation("Sofer");
                });

            modelBuilder.Entity("ProiectBun.Models.UtilajCategory", b =>
                {
                    b.HasOne("ProiectBun.Models.Category", "Category")
                        .WithMany("UtilajCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectBun.Models.Utilaj", "Utilaj")
                        .WithMany("UtilajCategories")
                        .HasForeignKey("UtilajID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Utilaj");
                });

            modelBuilder.Entity("ProiectBun.Models.Category", b =>
                {
                    b.Navigation("UtilajCategories");
                });

            modelBuilder.Entity("ProiectBun.Models.Marca", b =>
                {
                    b.Navigation("Utilaje");
                });

            modelBuilder.Entity("ProiectBun.Models.Sofer", b =>
                {
                    b.Navigation("Utilaje");
                });

            modelBuilder.Entity("ProiectBun.Models.Utilaj", b =>
                {
                    b.Navigation("UtilajCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
