using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityCalories = table.Column<float>(nullable: false),
                    IconSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.ID);
                });

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
                name: "UserLifestyles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LifestyleName = table.Column<string>(nullable: true),
                    Coefficient = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLifestyles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDActivityType = table.Column<Guid>(nullable: false),
                    ActivityTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_IDActivityType",
                        column: x => x.IDActivityType,
                        principalTable: "ActivityTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSets",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDType = table.Column<Guid>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserWeight = table.Column<double>(nullable: false),
                    UserHeight = table.Column<double>(nullable: false),
                    UserAge = table.Column<int>(nullable: false),
                    UserSex = table.Column<string>(nullable: true),
                    IDLifestyle = table.Column<Guid>(nullable: false),
                    UserCalories = table.Column<double>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PhotoSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_UserLifestyles_IDLifestyle",
                        column: x => x.IDLifestyle,
                        principalTable: "UserLifestyles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSetProducts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductSetID = table.Column<Guid>(nullable: false),
                    ProductWeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSetProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSetProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSetProducts_ProductSets_ProductSetID",
                        column: x => x.ProductSetID,
                        principalTable: "ProductSets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangesWeight",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDUser = table.Column<Guid>(nullable: false),
                    UserWeight = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangesWeight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChangesWeight_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDUser = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersHistories_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryActivities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityID = table.Column<Guid>(nullable: false),
                    UserHistoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryActivities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserHistoryActivities_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryActivities_UsersHistories_UserHistoryID",
                        column: x => x.UserHistoryID,
                        principalTable: "UsersHistories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryProductSets",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductSetID = table.Column<Guid>(nullable: false),
                    UserHistoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryProductSets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserHistoryProductSets_ProductSets_ProductSetID",
                        column: x => x.ProductSetID,
                        principalTable: "ProductSets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryProductSets_UsersHistories_UserHistoryID",
                        column: x => x.UserHistoryID,
                        principalTable: "UsersHistories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_IDActivityType",
                table: "Activities",
                column: "IDActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_ChangesWeight_IDUser",
                table: "ChangesWeight",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSetProducts_ProductID",
                table: "ProductSetProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSetProducts_ProductSetID",
                table: "ProductSetProducts",
                column: "ProductSetID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSets_IDType",
                table: "ProductSets",
                column: "IDType");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryActivities_ActivityID",
                table: "UserHistoryActivities",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryActivities_UserHistoryID",
                table: "UserHistoryActivities",
                column: "UserHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryProductSets_ProductSetID",
                table: "UserHistoryProductSets",
                column: "ProductSetID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryProductSets_UserHistoryID",
                table: "UserHistoryProductSets",
                column: "UserHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IDLifestyle",
                table: "Users",
                column: "IDLifestyle");

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDUser",
                table: "UsersHistories",
                column: "IDUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangesWeight");

            migrationBuilder.DropTable(
                name: "ProductSetProducts");

            migrationBuilder.DropTable(
                name: "UserHistoryActivities");

            migrationBuilder.DropTable(
                name: "UserHistoryProductSets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ProductSets");

            migrationBuilder.DropTable(
                name: "UsersHistories");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserLifestyles");
        }
    }
}
