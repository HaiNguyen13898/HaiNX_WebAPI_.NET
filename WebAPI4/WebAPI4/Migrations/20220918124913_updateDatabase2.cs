using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI4.Migrations
{
    public partial class updateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateBirth",
                table: "Employees",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateBirth",
                table: "Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
