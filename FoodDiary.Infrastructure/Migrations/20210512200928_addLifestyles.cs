using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class addLifestyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UserCalories",
                table: "Users",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<Guid>(
                name: "IDLifestyle",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_IDLifestyle",
                table: "Users",
                column: "IDLifestyle");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserLifestyles_IDLifestyle",
                table: "Users",
                column: "IDLifestyle",
                principalTable: "UserLifestyles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLifestyles_IDLifestyle",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserLifestyles");

            migrationBuilder.DropIndex(
                name: "IX_Users_IDLifestyle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IDLifestyle",
                table: "Users");

            migrationBuilder.AlterColumn<float>(
                name: "UserCalories",
                table: "Users",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
