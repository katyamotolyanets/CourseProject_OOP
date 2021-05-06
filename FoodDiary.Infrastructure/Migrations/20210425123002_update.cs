using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersHistories_Meals_IDMeal",
                table: "UsersHistories");

            migrationBuilder.DropTable(
                name: "MealsSets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_UsersHistories_IDMeal",
                table: "UsersHistories");

            migrationBuilder.DropColumn(
                name: "IDMeal",
                table: "UsersHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "IDProductSet",
                table: "UsersHistories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProductSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDProductSet",
                table: "UsersHistories",
                column: "IDProductSet");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersHistories_ProductSets_IDProductSet",
                table: "UsersHistories",
                column: "IDProductSet",
                principalTable: "ProductSets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersHistories_ProductSets_IDProductSet",
                table: "UsersHistories");

            migrationBuilder.DropIndex(
                name: "IX_UsersHistories_IDProductSet",
                table: "UsersHistories");

            migrationBuilder.DropColumn(
                name: "IDProductSet",
                table: "UsersHistories");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProductSets");

            migrationBuilder.AddColumn<Guid>(
                name: "IDMeal",
                table: "UsersHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MealsSets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDMeal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductSet = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsSets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MealsSets_Meals_IDMeal",
                        column: x => x.IDMeal,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealsSets_ProductSets_IDProductSet",
                        column: x => x.IDProductSet,
                        principalTable: "ProductSets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDMeal",
                table: "UsersHistories",
                column: "IDMeal");

            migrationBuilder.CreateIndex(
                name: "IX_MealsSets_IDMeal",
                table: "MealsSets",
                column: "IDMeal");

            migrationBuilder.CreateIndex(
                name: "IX_MealsSets_IDProductSet",
                table: "MealsSets",
                column: "IDProductSet");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersHistories_Meals_IDMeal",
                table: "UsersHistories",
                column: "IDMeal",
                principalTable: "Meals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
