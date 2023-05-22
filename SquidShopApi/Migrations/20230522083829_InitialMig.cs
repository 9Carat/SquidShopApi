using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SquidShopApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FK_UsersId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountUnitPrice = table.Column<double>(type: "float", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_FK_CategoryId",
                        column: x => x.FK_CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLists",
                columns: table => new
                {
                    OrderListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FK_ProductId = table.Column<int>(type: "int", nullable: false),
                    FK_OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLists", x => x.OrderListId);
                    table.ForeignKey(
                        name: "FK_OrderLists_Orders_FK_OrderId",
                        column: x => x.FK_OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLists_Products_FK_ProductId",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Details" },
                values: new object[,]
                {
                    { 1, "Toys", "Play things" },
                    { 2, "Tools", "Work things" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "FK_UsersId", "FirstName", "LastName", "PostalCode" },
                values: new object[] { 1, "Forest", "There", null, "Sven", "Knutsson", "20211" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Discount", "DiscountUnitPrice", "FK_CategoryId", "ImageName", "InStock", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 0m, 0.0, 1, "No URL", 10, "Jonny Boy", 199.0 },
                    { 2, 0m, 0.0, 1, "No URL", 29, "After the laughter comes tears", 149.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_FK_OrderId",
                table: "OrderLists",
                column: "FK_OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_FK_ProductId",
                table: "OrderLists",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_UserId",
                table: "Orders",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_CategoryId",
                table: "Products",
                column: "FK_CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
