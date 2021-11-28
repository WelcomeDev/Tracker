using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.Bll.Provider.MySql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pomodoros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RestHours = table.Column<int>(type: "int", nullable: false),
                    RestMinutes = table.Column<int>(type: "int", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    WorkMinutes = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pomodoros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pomodoros_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_UserId",
                table: "Pomodoros",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pomodoros");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
