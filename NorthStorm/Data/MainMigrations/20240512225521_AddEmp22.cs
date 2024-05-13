using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Data.MainMigrations
{
    /// <inheritdoc />
    public partial class AddEmp22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "emp2",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "CivilNumber",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "emp2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FourthName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "emp2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotherFirstName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherLastName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherMiddleName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "emp2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "emp2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "emp2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "emp2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "emp2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "emp2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "emp2",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_emp2_NationalityId",
                table: "emp2",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_emp2_RaceId",
                table: "emp2",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_emp2_ReligionId",
                table: "emp2",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_emp2_StateId",
                table: "emp2",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_emp2_StatusId",
                table: "emp2",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_Nationality_NationalityId",
                table: "emp2",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_Race_RaceId",
                table: "emp2",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_Religion_ReligionId",
                table: "emp2",
                column: "ReligionId",
                principalTable: "Religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_State_StateId",
                table: "emp2",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_Status_StatusId",
                table: "emp2",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp2_Nationality_NationalityId",
                table: "emp2");

            migrationBuilder.DropForeignKey(
                name: "FK_emp2_Race_RaceId",
                table: "emp2");

            migrationBuilder.DropForeignKey(
                name: "FK_emp2_Religion_ReligionId",
                table: "emp2");

            migrationBuilder.DropForeignKey(
                name: "FK_emp2_State_StateId",
                table: "emp2");

            migrationBuilder.DropForeignKey(
                name: "FK_emp2_Status_StatusId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_NationalityId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_RaceId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_ReligionId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_StateId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_StatusId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "CivilNumber",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "FourthName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "MotherFirstName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "MotherLastName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "MotherMiddleName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "emp2");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "emp2");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "emp2",
                newName: "Name");
        }
    }
}
