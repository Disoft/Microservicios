using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class migration001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description in the product 1", "Product 1", 778m },
                    { 2, "Description in the product 2", "Product 2", 608m },
                    { 3, "Description in the product 3", "Product 3", 282m },
                    { 4, "Description in the product 4", "Product 4", 718m },
                    { 5, "Description in the product 5", "Product 5", 228m },
                    { 6, "Description in the product 6", "Product 6", 167m },
                    { 7, "Description in the product 7", "Product 7", 900m },
                    { 8, "Description in the product 8", "Product 8", 380m },
                    { 9, "Description in the product 9", "Product 9", 592m },
                    { 10, "Description in the product 10", "Product 10", 729m },
                    { 11, "Description in the product 11", "Product 11", 290m },
                    { 12, "Description in the product 12", "Product 12", 595m },
                    { 13, "Description in the product 13", "Product 13", 301m },
                    { 14, "Description in the product 14", "Product 14", 663m },
                    { 15, "Description in the product 15", "Product 15", 406m },
                    { 16, "Description in the product 16", "Product 16", 135m },
                    { 17, "Description in the product 17", "Product 17", 738m },
                    { 18, "Description in the product 18", "Product 18", 779m },
                    { 19, "Description in the product 19", "Product 19", 477m },
                    { 20, "Description in the product 20", "Product 20", 677m },
                    { 21, "Description in the product 21", "Product 21", 984m },
                    { 22, "Description in the product 22", "Product 22", 291m },
                    { 23, "Description in the product 23", "Product 23", 897m },
                    { 24, "Description in the product 24", "Product 24", 574m },
                    { 25, "Description in the product 25", "Product 25", 692m },
                    { 26, "Description in the product 26", "Product 26", 619m },
                    { 27, "Description in the product 27", "Product 27", 401m },
                    { 28, "Description in the product 28", "Product 28", 970m },
                    { 29, "Description in the product 29", "Product 29", 496m },
                    { 30, "Description in the product 30", "Product 30", 133m },
                    { 31, "Description in the product 31", "Product 31", 312m },
                    { 32, "Description in the product 32", "Product 32", 815m },
                    { 33, "Description in the product 33", "Product 33", 430m },
                    { 34, "Description in the product 34", "Product 34", 311m },
                    { 35, "Description in the product 35", "Product 35", 257m },
                    { 36, "Description in the product 36", "Product 36", 806m },
                    { 37, "Description in the product 37", "Product 37", 178m },
                    { 38, "Description in the product 38", "Product 38", 201m },
                    { 39, "Description in the product 39", "Product 39", 570m },
                    { 40, "Description in the product 40", "Product 40", 463m },
                    { 41, "Description in the product 41", "Product 41", 559m },
                    { 42, "Description in the product 42", "Product 42", 732m },
                    { 43, "Description in the product 43", "Product 43", 513m },
                    { 44, "Description in the product 44", "Product 44", 150m },
                    { 45, "Description in the product 45", "Product 45", 112m },
                    { 46, "Description in the product 46", "Product 46", 297m },
                    { 47, "Description in the product 47", "Product 47", 206m },
                    { 48, "Description in the product 48", "Product 48", 869m },
                    { 49, "Description in the product 49", "Product 49", 819m },
                    { 50, "Description in the product 50", "Product 50", 822m },
                    { 51, "Description in the product 51", "Product 51", 927m },
                    { 52, "Description in the product 52", "Product 52", 159m },
                    { 53, "Description in the product 53", "Product 53", 171m },
                    { 54, "Description in the product 54", "Product 54", 390m },
                    { 55, "Description in the product 55", "Product 55", 503m },
                    { 56, "Description in the product 56", "Product 56", 231m },
                    { 57, "Description in the product 57", "Product 57", 186m },
                    { 58, "Description in the product 58", "Product 58", 385m },
                    { 59, "Description in the product 59", "Product 59", 277m },
                    { 60, "Description in the product 60", "Product 60", 673m },
                    { 61, "Description in the product 61", "Product 61", 604m },
                    { 62, "Description in the product 62", "Product 62", 253m },
                    { 63, "Description in the product 63", "Product 63", 636m },
                    { 64, "Description in the product 64", "Product 64", 337m },
                    { 65, "Description in the product 65", "Product 65", 418m },
                    { 66, "Description in the product 66", "Product 66", 772m },
                    { 67, "Description in the product 67", "Product 67", 319m },
                    { 68, "Description in the product 68", "Product 68", 301m },
                    { 69, "Description in the product 69", "Product 69", 134m },
                    { 70, "Description in the product 70", "Product 70", 243m },
                    { 71, "Description in the product 71", "Product 71", 719m },
                    { 72, "Description in the product 72", "Product 72", 392m },
                    { 73, "Description in the product 73", "Product 73", 485m },
                    { 74, "Description in the product 74", "Product 74", 607m },
                    { 75, "Description in the product 75", "Product 75", 123m },
                    { 76, "Description in the product 76", "Product 76", 647m },
                    { 77, "Description in the product 77", "Product 77", 756m },
                    { 78, "Description in the product 78", "Product 78", 104m },
                    { 79, "Description in the product 79", "Product 79", 745m },
                    { 80, "Description in the product 80", "Product 80", 901m },
                    { 81, "Description in the product 81", "Product 81", 829m },
                    { 82, "Description in the product 82", "Product 82", 214m },
                    { 83, "Description in the product 83", "Product 83", 813m },
                    { 84, "Description in the product 84", "Product 84", 183m },
                    { 85, "Description in the product 85", "Product 85", 660m },
                    { 86, "Description in the product 86", "Product 86", 309m },
                    { 87, "Description in the product 87", "Product 87", 416m },
                    { 88, "Description in the product 88", "Product 88", 726m },
                    { 89, "Description in the product 89", "Product 89", 170m },
                    { 90, "Description in the product 90", "Product 90", 813m },
                    { 91, "Description in the product 91", "Product 91", 436m },
                    { 92, "Description in the product 92", "Product 92", 157m },
                    { 93, "Description in the product 93", "Product 93", 859m },
                    { 94, "Description in the product 94", "Product 94", 478m },
                    { 95, "Description in the product 95", "Product 95", 174m },
                    { 96, "Description in the product 96", "Product 96", 143m },
                    { 97, "Description in the product 97", "Product 97", 203m },
                    { 98, "Description in the product 98", "Product 98", 609m },
                    { 99, "Description in the product 99", "Product 99", 534m },
                    { 100, "Description in the product 100", "Product 100", 250m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 2, 14 },
                    { 3, 3, 19 },
                    { 4, 4, 8 },
                    { 5, 5, 14 },
                    { 6, 6, 14 },
                    { 7, 7, 6 },
                    { 8, 8, 18 },
                    { 9, 9, 2 },
                    { 10, 10, 2 },
                    { 11, 11, 1 },
                    { 12, 12, 11 },
                    { 13, 13, 14 },
                    { 14, 14, 3 },
                    { 15, 15, 3 },
                    { 16, 16, 12 },
                    { 17, 17, 9 },
                    { 18, 18, 9 },
                    { 19, 19, 12 },
                    { 20, 20, 14 },
                    { 21, 21, 17 },
                    { 22, 22, 14 },
                    { 23, 23, 15 },
                    { 24, 24, 13 },
                    { 25, 25, 12 },
                    { 26, 26, 9 },
                    { 27, 27, 14 },
                    { 28, 28, 10 },
                    { 29, 29, 15 },
                    { 30, 30, 7 },
                    { 31, 31, 5 },
                    { 32, 32, 9 },
                    { 33, 33, 1 },
                    { 34, 34, 15 },
                    { 35, 35, 14 },
                    { 36, 36, 17 },
                    { 37, 37, 4 },
                    { 38, 38, 14 },
                    { 39, 39, 15 },
                    { 40, 40, 15 },
                    { 41, 41, 7 },
                    { 42, 42, 8 },
                    { 43, 43, 3 },
                    { 44, 44, 12 },
                    { 45, 45, 18 },
                    { 46, 46, 14 },
                    { 47, 47, 2 },
                    { 48, 48, 5 },
                    { 49, 49, 9 },
                    { 50, 50, 3 },
                    { 51, 51, 18 },
                    { 52, 52, 4 },
                    { 53, 53, 10 },
                    { 54, 54, 10 },
                    { 55, 55, 4 },
                    { 56, 56, 5 },
                    { 57, 57, 9 },
                    { 58, 58, 8 },
                    { 59, 59, 7 },
                    { 60, 60, 2 },
                    { 61, 61, 2 },
                    { 62, 62, 3 },
                    { 63, 63, 9 },
                    { 64, 64, 4 },
                    { 65, 65, 17 },
                    { 66, 66, 11 },
                    { 67, 67, 9 },
                    { 68, 68, 6 },
                    { 69, 69, 7 },
                    { 70, 70, 11 },
                    { 71, 71, 12 },
                    { 72, 72, 3 },
                    { 73, 73, 1 },
                    { 74, 74, 8 },
                    { 75, 75, 7 },
                    { 76, 76, 4 },
                    { 77, 77, 12 },
                    { 78, 78, 8 },
                    { 79, 79, 13 },
                    { 80, 80, 19 },
                    { 81, 81, 2 },
                    { 82, 82, 7 },
                    { 83, 83, 19 },
                    { 84, 84, 10 },
                    { 85, 85, 14 },
                    { 86, 86, 15 },
                    { 87, 87, 7 },
                    { 88, 88, 13 },
                    { 89, 89, 14 },
                    { 90, 90, 18 },
                    { 91, 91, 14 },
                    { 92, 92, 1 },
                    { 93, 93, 17 },
                    { 94, 94, 0 },
                    { 95, 95, 12 },
                    { 96, 96, 1 },
                    { 97, 97, 5 },
                    { 98, 98, 11 },
                    { 99, 99, 19 },
                    { 100, 100, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
