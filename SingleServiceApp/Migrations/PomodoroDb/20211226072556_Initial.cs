using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingleServiceApp.Migrations.PomodoroDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pomodoros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestMinutes = table.Column<int>(type: "int", nullable: true),
                    RestHours = table.Column<int>(type: "int", nullable: true),
                    WorkMinutes = table.Column<int>(type: "int", nullable: true),
                    WorkHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pomodoros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pomodoros");
        }
    }
}
