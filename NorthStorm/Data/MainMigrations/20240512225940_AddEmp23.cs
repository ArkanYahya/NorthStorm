using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Data.MainMigrations
{
    /// <inheritdoc />
    public partial class AddEmp23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp2_Gender_GenderId",
                table: "emp2");

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
                name: "FK_emp2_Status_StatusId",
                table: "emp2");

            migrationBuilder.DropIndex(
                name: "IX_emp2_GenderId",
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
                name: "IX_emp2_StatusId",
                table: "emp2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_emp2_GenderId",
                table: "emp2",
                column: "GenderId");

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
                name: "IX_emp2_StatusId",
                table: "emp2",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_emp2_Gender_GenderId",
                table: "emp2",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_emp2_Status_StatusId",
                table: "emp2",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
