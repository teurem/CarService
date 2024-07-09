using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrdersUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersUser");

            migrationBuilder.AddColumn<string>(
                name: "AutoElectricianId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotoristId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PainterId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WalkerId",
                table: "Orders",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AutoElectricianId",
                table: "Orders",
                column: "AutoElectricianId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MechanicId",
                table: "Orders",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MotoristId",
                table: "Orders",
                column: "MotoristId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PainterId",
                table: "Orders",
                column: "PainterId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WalkerId",
                table: "Orders",
                column: "WalkerId");

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
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
                table: "Orders",
                column: "WalkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_WalkerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AutoElectricianId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MechanicId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MotoristId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PainterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WalkerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AutoElectricianId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MotoristId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PainterId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WalkerId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrdersUser",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "text", nullable: false),
                    OrdersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersUser", x => new { x.EmployeesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrdersUser_AspNetUsers_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersUser_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 10, 35, 1, 767, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.CreateIndex(
                name: "IX_OrdersUser_OrdersId",
                table: "OrdersUser",
                column: "OrdersId");
        }
    }
}
