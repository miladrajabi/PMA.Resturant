using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMA.Services.Product.API.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "CreationDate", "Description", "ImageUrl", "MidifyDate", "Name", "Price" },
                values: new object[] { 10, "Appetizer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is my product", "", null, "Samosa", 15.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "CreationDate", "Description", "ImageUrl", "MidifyDate", "Name", "Price" },
                values: new object[] { 11, "Mobile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is my product", "", null, "Iphone", 150.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
