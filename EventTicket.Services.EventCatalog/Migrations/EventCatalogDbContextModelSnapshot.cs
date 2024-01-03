﻿// <auto-generated />
using System;
using EventTicket.Services.EventCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventTicket.Services.EventCatalog.Migrations
{
    [DbContext(typeof(EventCatalogDbContext))]
    partial class EventCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventTicket.Services.EventCatalog.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            Name = "Plays"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Name = "Conferences"
                        });
                });

            modelBuilder.Entity("EventTicket.Services.EventCatalog.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            Artist = "Test",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            City = "Belgrade",
                            Date = new DateTime(2024, 7, 3, 13, 14, 57, 569, DateTimeKind.Local).AddTicks(5853),
                            Description = "Test",
                            ImageUrl = "https://example.com/image1.jpg",
                            Name = "Test",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            Artist = "Test 2",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            City = "Nis",
                            Date = new DateTime(2024, 10, 3, 13, 14, 57, 569, DateTimeKind.Local).AddTicks(5937),
                            Description = "Test 2",
                            ImageUrl = "https://example.com/image2.jpg",
                            Name = "Test 2",
                            Price = 85
                        });
                });

            modelBuilder.Entity("EventTicket.Services.EventCatalog.Entities.Event", b =>
                {
                    b.HasOne("EventTicket.Services.EventCatalog.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EventTicket.Services.EventCatalog.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
