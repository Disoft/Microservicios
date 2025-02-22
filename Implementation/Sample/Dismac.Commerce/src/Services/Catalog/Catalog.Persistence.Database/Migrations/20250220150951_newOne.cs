using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class newOne : Migration
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
                name: "ProductsInStock",
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
                    table.PrimaryKey("PK_ProductsInStock", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_ProductsInStock_Products_ProductId",
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
                    { 1, "Description in the product 1", "Product 1", 801m },
                    { 2, "Description in the product 2", "Product 2", 675m },
                    { 3, "Description in the product 3", "Product 3", 429m },
                    { 4, "Description in the product 4", "Product 4", 613m },
                    { 5, "Description in the product 5", "Product 5", 166m },
                    { 6, "Description in the product 6", "Product 6", 400m },
                    { 7, "Description in the product 7", "Product 7", 434m },
                    { 8, "Description in the product 8", "Product 8", 185m },
                    { 9, "Description in the product 9", "Product 9", 501m },
                    { 10, "Description in the product 10", "Product 10", 229m },
                    { 11, "Description in the product 11", "Product 11", 618m },
                    { 12, "Description in the product 12", "Product 12", 840m },
                    { 13, "Description in the product 13", "Product 13", 536m },
                    { 14, "Description in the product 14", "Product 14", 755m },
                    { 15, "Description in the product 15", "Product 15", 573m },
                    { 16, "Description in the product 16", "Product 16", 505m },
                    { 17, "Description in the product 17", "Product 17", 683m },
                    { 18, "Description in the product 18", "Product 18", 835m },
                    { 19, "Description in the product 19", "Product 19", 586m },
                    { 20, "Description in the product 20", "Product 20", 909m },
                    { 21, "Description in the product 21", "Product 21", 803m },
                    { 22, "Description in the product 22", "Product 22", 423m },
                    { 23, "Description in the product 23", "Product 23", 950m },
                    { 24, "Description in the product 24", "Product 24", 150m },
                    { 25, "Description in the product 25", "Product 25", 663m },
                    { 26, "Description in the product 26", "Product 26", 120m },
                    { 27, "Description in the product 27", "Product 27", 792m },
                    { 28, "Description in the product 28", "Product 28", 802m },
                    { 29, "Description in the product 29", "Product 29", 346m },
                    { 30, "Description in the product 30", "Product 30", 467m },
                    { 31, "Description in the product 31", "Product 31", 234m },
                    { 32, "Description in the product 32", "Product 32", 792m },
                    { 33, "Description in the product 33", "Product 33", 680m },
                    { 34, "Description in the product 34", "Product 34", 646m },
                    { 35, "Description in the product 35", "Product 35", 782m },
                    { 36, "Description in the product 36", "Product 36", 961m },
                    { 37, "Description in the product 37", "Product 37", 257m },
                    { 38, "Description in the product 38", "Product 38", 101m },
                    { 39, "Description in the product 39", "Product 39", 512m },
                    { 40, "Description in the product 40", "Product 40", 417m },
                    { 41, "Description in the product 41", "Product 41", 800m },
                    { 42, "Description in the product 42", "Product 42", 707m },
                    { 43, "Description in the product 43", "Product 43", 370m },
                    { 44, "Description in the product 44", "Product 44", 611m },
                    { 45, "Description in the product 45", "Product 45", 403m },
                    { 46, "Description in the product 46", "Product 46", 268m },
                    { 47, "Description in the product 47", "Product 47", 620m },
                    { 48, "Description in the product 48", "Product 48", 907m },
                    { 49, "Description in the product 49", "Product 49", 839m },
                    { 50, "Description in the product 50", "Product 50", 697m },
                    { 51, "Description in the product 51", "Product 51", 642m },
                    { 52, "Description in the product 52", "Product 52", 124m },
                    { 53, "Description in the product 53", "Product 53", 359m },
                    { 54, "Description in the product 54", "Product 54", 738m },
                    { 55, "Description in the product 55", "Product 55", 724m },
                    { 56, "Description in the product 56", "Product 56", 539m },
                    { 57, "Description in the product 57", "Product 57", 747m },
                    { 58, "Description in the product 58", "Product 58", 740m },
                    { 59, "Description in the product 59", "Product 59", 769m },
                    { 60, "Description in the product 60", "Product 60", 145m },
                    { 61, "Description in the product 61", "Product 61", 576m },
                    { 62, "Description in the product 62", "Product 62", 155m },
                    { 63, "Description in the product 63", "Product 63", 353m },
                    { 64, "Description in the product 64", "Product 64", 163m },
                    { 65, "Description in the product 65", "Product 65", 120m },
                    { 66, "Description in the product 66", "Product 66", 119m },
                    { 67, "Description in the product 67", "Product 67", 131m },
                    { 68, "Description in the product 68", "Product 68", 290m },
                    { 69, "Description in the product 69", "Product 69", 311m },
                    { 70, "Description in the product 70", "Product 70", 342m },
                    { 71, "Description in the product 71", "Product 71", 680m },
                    { 72, "Description in the product 72", "Product 72", 643m },
                    { 73, "Description in the product 73", "Product 73", 531m },
                    { 74, "Description in the product 74", "Product 74", 212m },
                    { 75, "Description in the product 75", "Product 75", 102m },
                    { 76, "Description in the product 76", "Product 76", 749m },
                    { 77, "Description in the product 77", "Product 77", 146m },
                    { 78, "Description in the product 78", "Product 78", 740m },
                    { 79, "Description in the product 79", "Product 79", 673m },
                    { 80, "Description in the product 80", "Product 80", 876m },
                    { 81, "Description in the product 81", "Product 81", 384m },
                    { 82, "Description in the product 82", "Product 82", 413m },
                    { 83, "Description in the product 83", "Product 83", 248m },
                    { 84, "Description in the product 84", "Product 84", 159m },
                    { 85, "Description in the product 85", "Product 85", 182m },
                    { 86, "Description in the product 86", "Product 86", 565m },
                    { 87, "Description in the product 87", "Product 87", 910m },
                    { 88, "Description in the product 88", "Product 88", 714m },
                    { 89, "Description in the product 89", "Product 89", 881m },
                    { 90, "Description in the product 90", "Product 90", 844m },
                    { 91, "Description in the product 91", "Product 91", 764m },
                    { 92, "Description in the product 92", "Product 92", 998m },
                    { 93, "Description in the product 93", "Product 93", 579m },
                    { 94, "Description in the product 94", "Product 94", 217m },
                    { 95, "Description in the product 95", "Product 95", 110m },
                    { 96, "Description in the product 96", "Product 96", 366m },
                    { 97, "Description in the product 97", "Product 97", 712m },
                    { 98, "Description in the product 98", "Product 98", 359m },
                    { 99, "Description in the product 99", "Product 99", 895m },
                    { 100, "Description in the product 100", "Product 100", 638m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "ProductsInStock",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 16 },
                    { 2, 2, 15 },
                    { 3, 3, 16 },
                    { 4, 4, 0 },
                    { 5, 5, 7 },
                    { 6, 6, 17 },
                    { 7, 7, 2 },
                    { 8, 8, 13 },
                    { 9, 9, 18 },
                    { 10, 10, 15 },
                    { 11, 11, 8 },
                    { 12, 12, 3 },
                    { 13, 13, 12 },
                    { 14, 14, 19 },
                    { 15, 15, 3 },
                    { 16, 16, 17 },
                    { 17, 17, 14 },
                    { 18, 18, 2 },
                    { 19, 19, 14 },
                    { 20, 20, 19 },
                    { 21, 21, 7 },
                    { 22, 22, 12 },
                    { 23, 23, 3 },
                    { 24, 24, 8 },
                    { 25, 25, 3 },
                    { 26, 26, 7 },
                    { 27, 27, 2 },
                    { 28, 28, 2 },
                    { 29, 29, 2 },
                    { 30, 30, 17 },
                    { 31, 31, 14 },
                    { 32, 32, 4 },
                    { 33, 33, 7 },
                    { 34, 34, 13 },
                    { 35, 35, 7 },
                    { 36, 36, 13 },
                    { 37, 37, 2 },
                    { 38, 38, 10 },
                    { 39, 39, 5 },
                    { 40, 40, 14 },
                    { 41, 41, 0 },
                    { 42, 42, 6 },
                    { 43, 43, 8 },
                    { 44, 44, 1 },
                    { 45, 45, 1 },
                    { 46, 46, 6 },
                    { 47, 47, 6 },
                    { 48, 48, 7 },
                    { 49, 49, 3 },
                    { 50, 50, 12 },
                    { 51, 51, 4 },
                    { 52, 52, 16 },
                    { 53, 53, 0 },
                    { 54, 54, 13 },
                    { 55, 55, 8 },
                    { 56, 56, 7 },
                    { 57, 57, 16 },
                    { 58, 58, 3 },
                    { 59, 59, 19 },
                    { 60, 60, 8 },
                    { 61, 61, 11 },
                    { 62, 62, 19 },
                    { 63, 63, 15 },
                    { 64, 64, 4 },
                    { 65, 65, 8 },
                    { 66, 66, 19 },
                    { 67, 67, 9 },
                    { 68, 68, 3 },
                    { 69, 69, 19 },
                    { 70, 70, 18 },
                    { 71, 71, 8 },
                    { 72, 72, 0 },
                    { 73, 73, 2 },
                    { 74, 74, 5 },
                    { 75, 75, 6 },
                    { 76, 76, 8 },
                    { 77, 77, 18 },
                    { 78, 78, 16 },
                    { 79, 79, 19 },
                    { 80, 80, 9 },
                    { 81, 81, 12 },
                    { 82, 82, 13 },
                    { 83, 83, 13 },
                    { 84, 84, 12 },
                    { 85, 85, 14 },
                    { 86, 86, 14 },
                    { 87, 87, 0 },
                    { 88, 88, 19 },
                    { 89, 89, 13 },
                    { 90, 90, 5 },
                    { 91, 91, 0 },
                    { 92, 92, 9 },
                    { 93, 93, 7 },
                    { 94, 94, 4 },
                    { 95, 95, 9 },
                    { 96, 96, 19 },
                    { 97, 97, 2 },
                    { 98, 98, 14 },
                    { 99, 99, 13 },
                    { 100, 100, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInStock_ProductId",
                schema: "Catalog",
                table: "ProductsInStock",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsInStock",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
