using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Data.MainMigrations
{
    /// <inheritdoc />
    public partial class AddEmp24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRecruitment_emp2_emp2Id",
                table: "EmployeeRecruitment");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRecruitment_emp2Id",
                table: "EmployeeRecruitment");

            migrationBuilder.DropColumn(
                name: "emp2Id",
                table: "EmployeeRecruitment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "emp2Id",
                table: "EmployeeRecruitment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRecruitment_emp2Id",
                table: "EmployeeRecruitment",
                column: "emp2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRecruitment_emp2_emp2Id",
                table: "EmployeeRecruitment",
                column: "emp2Id",
                principalTable: "emp2",
                principalColumn: "Id");
        }
    }
}
