using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI4.Migrations
{
    public partial class Update6Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "departmentid");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depart_departmentid",
                table: "Employees",
                column: "departmentid",
                principalTable: "Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depart_departmentid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "departmentid",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departmentid",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depart_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Depart",
                principalColumn: "Id");
        }
    }
}
