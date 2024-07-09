using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class SetDeleteBehaviorSetNullToOrdersUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AutoElectricianId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_MechanicId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_MotoristId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_PainterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
                table: "Orders");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AutoElectricianId",
                table: "Orders",
                column: "AutoElectricianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_MechanicId",
                table: "Orders",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_MotoristId",
                table: "Orders",
                column: "MotoristId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_PainterId",
                table: "Orders",
                column: "PainterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
                table: "Orders",
                column: "WalkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AutoElectricianId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_MechanicId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_MotoristId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_PainterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AutoElectricianId",
                table: "Orders",
                column: "AutoElectricianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_MechanicId",
                table: "Orders",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_MotoristId",
                table: "Orders",
                column: "MotoristId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_PainterId",
                table: "Orders",
                column: "PainterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
                table: "Orders",
                column: "WalkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
