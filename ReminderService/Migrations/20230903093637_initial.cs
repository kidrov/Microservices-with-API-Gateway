using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderCreationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ReminderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminders");
        }
    }
}
