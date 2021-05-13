using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IDActivity",
                table: "UsersHistories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "UserAge",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityCalories = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IDActivityType = table.Column<Guid>(nullable: false),
                    ActivityTime = table.Column<float>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_UsersHistories_IDActivity",
                table: "UsersHistories",
                column: "IDActivity");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_IDActivityType",
                table: "Activities",
                column: "IDActivityType");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersHistories_Activities_IDActivity",
                table: "UsersHistories",
                column: "IDActivity",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersHistories_Activities_IDActivity",
                table: "UsersHistories");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropIndex(
                name: "IX_UsersHistories_IDActivity",
                table: "UsersHistories");

            migrationBuilder.DropColumn(
                name: "IDActivity",
                table: "UsersHistories");

            migrationBuilder.DropColumn(
                name: "UserAge",
                table: "Users");
        }
    }
}
