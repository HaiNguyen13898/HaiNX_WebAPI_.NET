using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI4.Migrations
{
    public partial class Update3Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Depart",
                principalColumn: "Id");
        }
    }
}
