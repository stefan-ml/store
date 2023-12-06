﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Service.Product.DbContexts;

#nullable disable

namespace Store.Service.Product.Migrations
{
    [DbContext(typeof(ProductCatalogDbContext))]
    partial class ProductCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Service.Product.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            Date = new DateTime(2024, 6, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4590),
                            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                            Name = "John Egbert Live",
                            Price = 65
                        },
                        new
                        {
                            ProductId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            Date = new DateTime(2024, 9, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4675),
                            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                            Name = "The State of Affairs: Michael Live!",
                            Price = 85
                        },
                        new
                        {
                            ProductId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            Date = new DateTime(2024, 4, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4692),
                            Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                            Name = "Clash of the DJs",
                            Price = 85
                        },
                        new
                        {
                            ProductId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            Date = new DateTime(2024, 4, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4705),
                            Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                            Name = "Spanish guitar hits with Manuel",
                            Price = 25
                        },
                        new
                        {
                            ProductId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            Date = new DateTime(2024, 10, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4759),
                            Description = "The best tech conference in the world",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                            Name = "Techorama 2021",
                            Price = 400
                        },
                        new
                        {
                            ProductId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            Date = new DateTime(2024, 8, 6, 12, 41, 34, 182, DateTimeKind.Local).AddTicks(4778),
                            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                            Name = "To the Moon and Back",
                            Price = 135
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
