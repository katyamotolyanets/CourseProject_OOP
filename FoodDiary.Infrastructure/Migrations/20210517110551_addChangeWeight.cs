using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDiary.Infrastructure.Migrations
{
    public partial class addChangeWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ChangesWeight_IDUser",
                table: "ChangesWeight",
                column: "IDUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangesWeight");
        }
    }
}
