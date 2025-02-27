using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class catalog_001 : Migration
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
                    { 1, "Description in the product 1", "Product 1", 656m },
                    { 2, "Description in the product 2", "Product 2", 149m },
                    { 3, "Description in the product 3", "Product 3", 533m },
                    { 4, "Description in the product 4", "Product 4", 251m },
                    { 5, "Description in the product 5", "Product 5", 285m },
                    { 6, "Description in the product 6", "Product 6", 510m },
                    { 7, "Description in the product 7", "Product 7", 288m },
                    { 8, "Description in the product 8", "Product 8", 156m },
                    { 9, "Description in the product 9", "Product 9", 466m },
                    { 10, "Description in the product 10", "Product 10", 463m },
                    { 11, "Description in the product 11", "Product 11", 328m },
                    { 12, "Description in the product 12", "Product 12", 834m },
                    { 13, "Description in the product 13", "Product 13", 791m },
                    { 14, "Description in the product 14", "Product 14", 109m },
                    { 15, "Description in the product 15", "Product 15", 154m },
                    { 16, "Description in the product 16", "Product 16", 399m },
                    { 17, "Description in the product 17", "Product 17", 628m },
                    { 18, "Description in the product 18", "Product 18", 328m },
                    { 19, "Description in the product 19", "Product 19", 195m },
                    { 20, "Description in the product 20", "Product 20", 421m },
                    { 21, "Description in the product 21", "Product 21", 390m },
                    { 22, "Description in the product 22", "Product 22", 846m },
                    { 23, "Description in the product 23", "Product 23", 219m },
                    { 24, "Description in the product 24", "Product 24", 169m },
                    { 25, "Description in the product 25", "Product 25", 179m },
                    { 26, "Description in the product 26", "Product 26", 401m },
                    { 27, "Description in the product 27", "Product 27", 245m },
                    { 28, "Description in the product 28", "Product 28", 301m },
                    { 29, "Description in the product 29", "Product 29", 656m },
                    { 30, "Description in the product 30", "Product 30", 694m },
                    { 31, "Description in the product 31", "Product 31", 345m },
                    { 32, "Description in the product 32", "Product 32", 815m },
                    { 33, "Description in the product 33", "Product 33", 688m },
                    { 34, "Description in the product 34", "Product 34", 777m },
                    { 35, "Description in the product 35", "Product 35", 166m },
                    { 36, "Description in the product 36", "Product 36", 961m },
                    { 37, "Description in the product 37", "Product 37", 449m },
                    { 38, "Description in the product 38", "Product 38", 189m },
                    { 39, "Description in the product 39", "Product 39", 791m },
                    { 40, "Description in the product 40", "Product 40", 390m },
                    { 41, "Description in the product 41", "Product 41", 140m },
                    { 42, "Description in the product 42", "Product 42", 870m },
                    { 43, "Description in the product 43", "Product 43", 113m },
                    { 44, "Description in the product 44", "Product 44", 177m },
                    { 45, "Description in the product 45", "Product 45", 787m },
                    { 46, "Description in the product 46", "Product 46", 423m },
                    { 47, "Description in the product 47", "Product 47", 650m },
                    { 48, "Description in the product 48", "Product 48", 598m },
                    { 49, "Description in the product 49", "Product 49", 242m },
                    { 50, "Description in the product 50", "Product 50", 415m },
                    { 51, "Description in the product 51", "Product 51", 250m },
                    { 52, "Description in the product 52", "Product 52", 389m },
                    { 53, "Description in the product 53", "Product 53", 823m },
                    { 54, "Description in the product 54", "Product 54", 646m },
                    { 55, "Description in the product 55", "Product 55", 114m },
                    { 56, "Description in the product 56", "Product 56", 901m },
                    { 57, "Description in the product 57", "Product 57", 570m },
                    { 58, "Description in the product 58", "Product 58", 515m },
                    { 59, "Description in the product 59", "Product 59", 915m },
                    { 60, "Description in the product 60", "Product 60", 106m },
                    { 61, "Description in the product 61", "Product 61", 208m },
                    { 62, "Description in the product 62", "Product 62", 374m },
                    { 63, "Description in the product 63", "Product 63", 788m },
                    { 64, "Description in the product 64", "Product 64", 623m },
                    { 65, "Description in the product 65", "Product 65", 176m },
                    { 66, "Description in the product 66", "Product 66", 292m },
                    { 67, "Description in the product 67", "Product 67", 343m },
                    { 68, "Description in the product 68", "Product 68", 728m },
                    { 69, "Description in the product 69", "Product 69", 790m },
                    { 70, "Description in the product 70", "Product 70", 191m },
                    { 71, "Description in the product 71", "Product 71", 543m },
                    { 72, "Description in the product 72", "Product 72", 472m },
                    { 73, "Description in the product 73", "Product 73", 986m },
                    { 74, "Description in the product 74", "Product 74", 575m },
                    { 75, "Description in the product 75", "Product 75", 521m },
                    { 76, "Description in the product 76", "Product 76", 360m },
                    { 77, "Description in the product 77", "Product 77", 278m },
                    { 78, "Description in the product 78", "Product 78", 591m },
                    { 79, "Description in the product 79", "Product 79", 635m },
                    { 80, "Description in the product 80", "Product 80", 418m },
                    { 81, "Description in the product 81", "Product 81", 720m },
                    { 82, "Description in the product 82", "Product 82", 906m },
                    { 83, "Description in the product 83", "Product 83", 382m },
                    { 84, "Description in the product 84", "Product 84", 158m },
                    { 85, "Description in the product 85", "Product 85", 555m },
                    { 86, "Description in the product 86", "Product 86", 944m },
                    { 87, "Description in the product 87", "Product 87", 997m },
                    { 88, "Description in the product 88", "Product 88", 629m },
                    { 89, "Description in the product 89", "Product 89", 403m },
                    { 90, "Description in the product 90", "Product 90", 172m },
                    { 91, "Description in the product 91", "Product 91", 768m },
                    { 92, "Description in the product 92", "Product 92", 445m },
                    { 93, "Description in the product 93", "Product 93", 219m },
                    { 94, "Description in the product 94", "Product 94", 445m },
                    { 95, "Description in the product 95", "Product 95", 638m },
                    { 96, "Description in the product 96", "Product 96", 762m },
                    { 97, "Description in the product 97", "Product 97", 287m },
                    { 98, "Description in the product 98", "Product 98", 550m },
                    { 99, "Description in the product 99", "Product 99", 432m },
                    { 100, "Description in the product 100", "Product 100", 557m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 19 },
                    { 2, 2, 10 },
                    { 3, 3, 5 },
                    { 4, 4, 3 },
                    { 5, 5, 15 },
                    { 6, 6, 12 },
                    { 7, 7, 10 },
                    { 8, 8, 3 },
                    { 9, 9, 9 },
                    { 10, 10, 12 },
                    { 11, 11, 15 },
                    { 12, 12, 1 },
                    { 13, 13, 5 },
                    { 14, 14, 5 },
                    { 15, 15, 5 },
                    { 16, 16, 8 },
                    { 17, 17, 1 },
                    { 18, 18, 3 },
                    { 19, 19, 16 },
                    { 20, 20, 18 },
                    { 21, 21, 11 },
                    { 22, 22, 3 },
                    { 23, 23, 2 },
                    { 24, 24, 5 },
                    { 25, 25, 4 },
                    { 26, 26, 9 },
                    { 27, 27, 11 },
                    { 28, 28, 9 },
                    { 29, 29, 12 },
                    { 30, 30, 13 },
                    { 31, 31, 18 },
                    { 32, 32, 18 },
                    { 33, 33, 16 },
                    { 34, 34, 15 },
                    { 35, 35, 14 },
                    { 36, 36, 4 },
                    { 37, 37, 13 },
                    { 38, 38, 2 },
                    { 39, 39, 12 },
                    { 40, 40, 17 },
                    { 41, 41, 14 },
                    { 42, 42, 9 },
                    { 43, 43, 8 },
                    { 44, 44, 17 },
                    { 45, 45, 13 },
                    { 46, 46, 13 },
                    { 47, 47, 18 },
                    { 48, 48, 7 },
                    { 49, 49, 2 },
                    { 50, 50, 1 },
                    { 51, 51, 12 },
                    { 52, 52, 9 },
                    { 53, 53, 19 },
                    { 54, 54, 4 },
                    { 55, 55, 4 },
                    { 56, 56, 19 },
                    { 57, 57, 0 },
                    { 58, 58, 0 },
                    { 59, 59, 4 },
                    { 60, 60, 4 },
                    { 61, 61, 9 },
                    { 62, 62, 18 },
                    { 63, 63, 16 },
                    { 64, 64, 8 },
                    { 65, 65, 3 },
                    { 66, 66, 19 },
                    { 67, 67, 2 },
                    { 68, 68, 4 },
                    { 69, 69, 0 },
                    { 70, 70, 14 },
                    { 71, 71, 1 },
                    { 72, 72, 11 },
                    { 73, 73, 16 },
                    { 74, 74, 15 },
                    { 75, 75, 1 },
                    { 76, 76, 15 },
                    { 77, 77, 6 },
                    { 78, 78, 19 },
                    { 79, 79, 2 },
                    { 80, 80, 14 },
                    { 81, 81, 14 },
                    { 82, 82, 14 },
                    { 83, 83, 16 },
                    { 84, 84, 2 },
                    { 85, 85, 6 },
                    { 86, 86, 16 },
                    { 87, 87, 1 },
                    { 88, 88, 0 },
                    { 89, 89, 2 },
                    { 90, 90, 3 },
                    { 91, 91, 13 },
                    { 92, 92, 9 },
                    { 93, 93, 17 },
                    { 94, 94, 9 },
                    { 95, 95, 19 },
                    { 96, 96, 4 },
                    { 97, 97, 5 },
                    { 98, 98, 1 },
                    { 99, 99, 11 },
                    { 100, 100, 14 }
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
