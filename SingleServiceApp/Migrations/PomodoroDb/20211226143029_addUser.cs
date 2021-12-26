using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingleServiceApp.Migrations.PomodoroDb
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "Pomodoros",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "Pomodoros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Pomodoros");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "Pomodoros");
        }
    }
}
