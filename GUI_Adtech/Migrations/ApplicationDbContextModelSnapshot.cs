﻿// <auto-generated />
using System;
using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GUI_Adtech.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GUI_Adtech.Models.AdtechComponent", b =>
                {
                    b.Property<int>("ComponentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponentID"));

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ComponentID");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("GUI_Adtech.Models.AdtechConfig", b =>
                {
                    b.Property<int>("Seq_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Seq_Id"));

                    b.Property<DateTime>("ModifiesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ParameterValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Seq_Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("GUI_Adtech.Models.AdtechSystem", b =>
                {
                    b.Property<int>("SystemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemID"));

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SystemID");

                    b.ToTable("Systems");
                });
#pragma warning restore 612, 618
        }
    }
}
