using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventTicket.Services.EventCatalog.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Musicals" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Concerts" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Plays" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Conferences" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "City", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "Test 2", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Nis", new DateTime(2024, 9, 28, 14, 46, 53, 823, DateTimeKind.Local).AddTicks(4543), "Test 2", "https://example.com/image2.jpg", "Test 2", 85 },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "Test", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Belgrade", new DateTime(2024, 6, 28, 14, 46, 53, 823, DateTimeKind.Local).AddTicks(4265), "Test", "https://example.com/image1.jpg", "Test", 65 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
