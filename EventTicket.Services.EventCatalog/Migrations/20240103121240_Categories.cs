using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventTicket.Services.EventCatalog.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6c0"), "Cooking" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6c1"), "Tech" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6c2"), "Sport" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6c3"), "Art" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6c4"), "Fashion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValues: new object[]
                {
                new Guid("6313179f-7837-473a-a4d5-a5571b43e6c0"), // Cooking
                new Guid("6313179f-7837-473a-a4d5-a5571b43e6c1"), // Tech
                new Guid("6313179f-7837-473a-a4d5-a5571b43e6c2"), // Sport
                new Guid("6313179f-7837-473a-a4d5-a5571b43e6c3"), // Art
                new Guid("6313179f-7837-473a-a4d5-a5571b43e6c4")  // Fashion
                });
        }
    }
}
