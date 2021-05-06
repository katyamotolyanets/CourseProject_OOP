using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MealName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NameProduct = table.Column<string>(nullable: true),
                    EnergyValue = table.Column<float>(nullable: false),
                    Calories = table.Column<float>(nullable: false),
                    Proteins = table.Column<float>(nullable: false),
                    Fats = table.Column<float>(nullable: false),
                    Carbohydrates = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserWeight = table.Column<float>(nullable: false),
                    UserHeight = table.Column<float>(nullable: false),
                    UserCalories = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSets",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDType = table.Column<Guid>(nullable: false),
                    IDProduct = table.Column<Guid>(nullable: false),
                    ProductWeight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSets_MealTypes_IDType",
                        column: x => x.IDType,
                        principalTable: "MealTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSets_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealsSets",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDMeal = table.Column<Guid>(nullable: false),
                    IDProductSet = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UsersHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDUser = table.Column<Guid>(nullable: false),
                    IDMeal = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersHistories_Meals_IDMeal",
                        column: x => x.IDMeal,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersHistories_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSets_IDType",
                table: "ProductSets",
                column: "IDType");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSets_IDProduct",
                table: "ProductSets",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_MealsSets_IDMeal",
                table: "MealsSets",
                column: "IDMeal");

            migrationBuilder.CreateIndex(
                name: "IX_MealsSets_IDProductSet",
                table: "MealsSets",
                column: "IDProductSet");

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDMeal",
                table: "UsersHistories",
                column: "IDMeal");

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDUser",
                table: "UsersHistories",
                column: "IDUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSets");

            migrationBuilder.DropTable(
                name: "UsersHistories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MealTypes");
        }
    }
}
