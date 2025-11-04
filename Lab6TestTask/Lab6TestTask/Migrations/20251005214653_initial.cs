using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab6TestTask.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Berlin", "Warehouse 1" },
                    { 2, "Paris", "Warehouse 2" },
                    { 3, "Rome", "Warehouse 3" },
                    { 4, "Warsaw", "Warehouse 4" },
                    { 5, "Madrid", "Warehouse 5" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "Quantity", "ReceivedDate", "Status", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "Cement", 6.50m, 500, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, "Bricks", 0.45m, 10000, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, "Steel Rebars", 2.10m, 2000, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 4, "Timber Planks", 15.00m, 1500, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { 5, "Roof Tiles", 1.20m, 4000, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 6, "Paint Buckets", 25.00m, 600, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 7, "Hammer", 12.00m, 300, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 },
                    { 8, "Electric Drill", 80.00m, 150, new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 9, "Ladder", 60.00m, 100, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 },
                    { 10, "Wheelbarrow", 95.00m, 70, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_WarehouseId",
                table: "Products",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
