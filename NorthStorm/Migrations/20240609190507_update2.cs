using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStorm.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferFrom",
                table: "JobTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransferTo",
                table: "JobTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferFrom",
                table: "JobTransfers");

            migrationBuilder.DropColumn(
                name: "TransferTo",
                table: "JobTransfers");
        }
    }
}
