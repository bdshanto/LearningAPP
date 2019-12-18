using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Library.Migrations
{
    public partial class purchaseorderadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    RefNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchesOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchesOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchesOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchesOrderItems_PurchesOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "PurchesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchesOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchesOrderItems_OrderId",
                table: "PurchesOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchesOrderItems_ProductId",
                table: "PurchesOrderItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchesOrderItems");

            migrationBuilder.DropTable(
                name: "PurchesOrders");
        }
    }
}
