using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reasons_ReasonId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReasonId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2146));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 8, 6, 42, 38, 299, DateTimeKind.Utc).AddTicks(2164));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReasonId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 12, 59, 32, 649, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReasonId",
                table: "Orders",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reasons_ReasonId",
                table: "Orders",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "Id");
        }
    }
}
