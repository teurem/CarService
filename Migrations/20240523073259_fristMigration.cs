using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class fristMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 23, 7, 32, 58, 752, DateTimeKind.Utc).AddTicks(7248));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3654));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 11, 8, 24, 786, DateTimeKind.Utc).AddTicks(3654));
        }
    }
}
