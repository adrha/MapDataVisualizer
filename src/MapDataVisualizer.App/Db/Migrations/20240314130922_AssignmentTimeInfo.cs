using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapDataVisualizer.App.Db.Migrations
{
    /// <inheritdoc />
    public partial class AssignmentTimeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AssignmentEnd",
                table: "SensorSoldierAssignments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignmentStart",
                table: "SensorSoldierAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentEnd",
                table: "SensorSoldierAssignments");

            migrationBuilder.DropColumn(
                name: "AssignmentStart",
                table: "SensorSoldierAssignments");
        }
    }
}
