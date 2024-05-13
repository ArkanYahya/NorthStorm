using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Data.MainMigrations
{
    /// <inheritdoc />
    public partial class AddEmp25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp2_State_StateId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_StateId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "emp2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "emp2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "emp2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "emp2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "emp2",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_emp2_StateId",
                table: "emp2",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_State_StateId",
                table: "emp2",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }
    }
}
