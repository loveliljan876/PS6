using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS6.Migrations
{
    public partial class AddedYearValidationResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "YearValidationResult",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "YearValidationResult",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "YearValidationResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "YearValidationResult");

            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "YearValidationResult");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "YearValidationResult",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
