using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Data.MainMigrations
{
    /// <inheritdoc />
    public partial class AddEmp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "emp2Id",
                table: "EmployeeRecruitment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "emp2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emp2_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRecruitment_emp2Id",
                table: "EmployeeRecruitment",
                column: "emp2Id");

            migrationBuilder.CreateIndex(
                name: "IX_emp2_GenderId",
                table: "emp2",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRecruitment_emp2_emp2Id",
                table: "EmployeeRecruitment",
                column: "emp2Id",
                principalTable: "emp2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRecruitment_emp2_emp2Id",
                table: "EmployeeRecruitment");

            migrationBuilder.DropTable(
                name: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRecruitment_emp2Id",
                table: "EmployeeRecruitment");

            migrationBuilder.DropColumn(
                name: "emp2Id",
                table: "EmployeeRecruitment");
        }
    }
}
