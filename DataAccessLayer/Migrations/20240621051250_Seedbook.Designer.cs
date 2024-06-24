﻿// <auto-generated />
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240621051250_Seedbook")]
    partial class Seedbook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelsLayer.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("float(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "123asd",
                            Price = 250.0,
                            Title = "Englist"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "1234asd",
                            Price = 300.0,
                            Title = "Urdu"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "12345asd",
                            Price = 2.0,
                            Title = "Pak Study"
                        },
                        new
                        {
                            BookId = 4,
                            ISBN = "123456asd",
                            Price = 1000.0,
                            Title = "Maths"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
