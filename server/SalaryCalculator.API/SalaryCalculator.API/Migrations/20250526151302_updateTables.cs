using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryCalculator.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SeniorityYears",
                table: "SalaryCalculations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LevelValue",
                table: "ManagementLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ManagementLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "LevelValue",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ManagementLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "LevelValue",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ManagementLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "LevelValue",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ManagementLevels",
                keyColumn: "Id",
                keyValue: 4,
                column: "LevelValue",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ManagementLevels",
                keyColumn: "Id",
                keyValue: 5,
                column: "LevelValue",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelValue",
                table: "ManagementLevels");

            migrationBuilder.AlterColumn<int>(
                name: "SeniorityYears",
                table: "SalaryCalculations",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
