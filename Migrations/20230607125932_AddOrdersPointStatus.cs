using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersPointStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdersPointStatuses",
                columns: table => new
                {
                    OrdersId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutorId = table.Column<string>(type: "text", nullable: false),
                    PointId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPointStatuses", x => new { x.OrdersId, x.ExecutorId });
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersPointStatuses");

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 7, 5, 30, 32, 139, DateTimeKind.Utc).AddTicks(7854));
        }
    }
}
