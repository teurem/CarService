using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace digitization.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientFIO = table.Column<string>(type: "text", nullable: false),
                    ClientPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CarBrand = table.Column<string>(type: "text", nullable: false),
                    CarModel = table.Column<string>(type: "text", nullable: false),
                    RepairInstructions = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    SpareParts = table.Column<string>(type: "text", nullable: true),
                    PointId = table.Column<long>(type: "bigint", nullable: false),
                    ReasonId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id");
                });

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
                name: "IX_Orders_PointId",
                table: "Orders",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReasonId",
                table: "Orders",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersUser_OrdersId",
                table: "OrdersUser",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersUser");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 101L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 102L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 103L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1001L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1002L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1003L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "RoadMaps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 5, 5, 51, 39, 388, DateTimeKind.Utc).AddTicks(6202));
        }
    }
}
