using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalaryCalculator.API.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawBonusGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawBonusGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartTimePercents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTimePercents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartTimePercentId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalLevelId = table.Column<int>(type: "int", nullable: false),
                    ManagementLevelId = table.Column<int>(type: "int", nullable: false),
                    SeniorityYears = table.Column<int>(type: "int", nullable: false),
                    IsEligibleForLawBonus = table.Column<bool>(type: "bit", nullable: false),
                    LawBonusGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryCalculations_LawBonusGroups_LawBonusGroupId",
                        column: x => x.LawBonusGroupId,
                        principalTable: "LawBonusGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalaryCalculations_ManagementLevels_ManagementLevelId",
                        column: x => x.ManagementLevelId,
                        principalTable: "ManagementLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryCalculations_PartTimePercents_PartTimePercentId",
                        column: x => x.PartTimePercentId,
                        principalTable: "PartTimePercents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryCalculations_ProfessionalLevels_ProfessionalLevelId",
                        column: x => x.ProfessionalLevelId,
                        principalTable: "ProfessionalLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LawBonusGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "קבוצה א'" },
                    { 2, "קבוצה ב'" }
                });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ללא" },
                    { 2, "רמת ניהול 1" },
                    { 3, "רמת ניהול 2" },
                    { 4, "רמת ניהול 3" },
                    { 5, "רמת ניהול 4" }
                });

            migrationBuilder.InsertData(
                table: "PartTimePercents",
                columns: new[] { "Id", "Percent" },
                values: new object[,]
                {
                    { 1, 100 },
                    { 2, 75 },
                    { 3, 50 }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "מתחיל" },
                    { 2, "מנוסה" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryCalculations_LawBonusGroupId",
                table: "SalaryCalculations",
                column: "LawBonusGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryCalculations_ManagementLevelId",
                table: "SalaryCalculations",
                column: "ManagementLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryCalculations_PartTimePercentId",
                table: "SalaryCalculations",
                column: "PartTimePercentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryCalculations_ProfessionalLevelId",
                table: "SalaryCalculations",
                column: "ProfessionalLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryCalculations");

            migrationBuilder.DropTable(
                name: "LawBonusGroups");

            migrationBuilder.DropTable(
                name: "ManagementLevels");

            migrationBuilder.DropTable(
                name: "PartTimePercents");

            migrationBuilder.DropTable(
                name: "ProfessionalLevels");
        }
    }
}
