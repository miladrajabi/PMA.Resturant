using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMA.Services.Product.API.Migrations
{
    public partial class Modify_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MidifyDate",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidifyDate",
                table: "Products");
        }
    }
}
