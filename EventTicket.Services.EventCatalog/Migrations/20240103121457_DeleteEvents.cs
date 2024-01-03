using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventTicket.Services.EventCatalog.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Events",
            keyColumn: "EventId",
            keyValues: new object[]
            {
                new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Events",
              columns: new[] { "EventId", "Artist", "CategoryId", "City", "Date", "Description", "ImageUrl", "Name", "Price" },
              values: new object[,]
              {
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "Test 2", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Nis", new DateTime(2024, 9, 28, 14, 46, 53, 823, DateTimeKind.Local).AddTicks(4543), "Test 2", "https://example.com/image2.jpg", "Test 2", 85 },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "Test", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Belgrade", new DateTime(2024, 6, 28, 14, 46, 53, 823, DateTimeKind.Local).AddTicks(4265), "Test", "https://example.com/image1.jpg", "Test", 65 }
              });
        }
    }
}
