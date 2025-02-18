using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class initialCatalog : Migration
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
                    { 1, "Description in the product 1", "Product 1", 721m },
                    { 2, "Description in the product 2", "Product 2", 584m },
                    { 3, "Description in the product 3", "Product 3", 952m },
                    { 4, "Description in the product 4", "Product 4", 948m },
                    { 5, "Description in the product 5", "Product 5", 969m },
                    { 6, "Description in the product 6", "Product 6", 131m },
                    { 7, "Description in the product 7", "Product 7", 416m },
                    { 8, "Description in the product 8", "Product 8", 464m },
                    { 9, "Description in the product 9", "Product 9", 639m },
                    { 10, "Description in the product 10", "Product 10", 523m },
                    { 11, "Description in the product 11", "Product 11", 444m },
                    { 12, "Description in the product 12", "Product 12", 901m },
                    { 13, "Description in the product 13", "Product 13", 307m },
                    { 14, "Description in the product 14", "Product 14", 797m },
                    { 15, "Description in the product 15", "Product 15", 586m },
                    { 16, "Description in the product 16", "Product 16", 425m },
                    { 17, "Description in the product 17", "Product 17", 511m },
                    { 18, "Description in the product 18", "Product 18", 270m },
                    { 19, "Description in the product 19", "Product 19", 100m },
                    { 20, "Description in the product 20", "Product 20", 279m },
                    { 21, "Description in the product 21", "Product 21", 714m },
                    { 22, "Description in the product 22", "Product 22", 613m },
                    { 23, "Description in the product 23", "Product 23", 717m },
                    { 24, "Description in the product 24", "Product 24", 596m },
                    { 25, "Description in the product 25", "Product 25", 355m },
                    { 26, "Description in the product 26", "Product 26", 241m },
                    { 27, "Description in the product 27", "Product 27", 334m },
                    { 28, "Description in the product 28", "Product 28", 337m },
                    { 29, "Description in the product 29", "Product 29", 907m },
                    { 30, "Description in the product 30", "Product 30", 547m },
                    { 31, "Description in the product 31", "Product 31", 545m },
                    { 32, "Description in the product 32", "Product 32", 210m },
                    { 33, "Description in the product 33", "Product 33", 481m },
                    { 34, "Description in the product 34", "Product 34", 289m },
                    { 35, "Description in the product 35", "Product 35", 844m },
                    { 36, "Description in the product 36", "Product 36", 893m },
                    { 37, "Description in the product 37", "Product 37", 771m },
                    { 38, "Description in the product 38", "Product 38", 816m },
                    { 39, "Description in the product 39", "Product 39", 659m },
                    { 40, "Description in the product 40", "Product 40", 144m },
                    { 41, "Description in the product 41", "Product 41", 777m },
                    { 42, "Description in the product 42", "Product 42", 656m },
                    { 43, "Description in the product 43", "Product 43", 869m },
                    { 44, "Description in the product 44", "Product 44", 906m },
                    { 45, "Description in the product 45", "Product 45", 764m },
                    { 46, "Description in the product 46", "Product 46", 583m },
                    { 47, "Description in the product 47", "Product 47", 414m },
                    { 48, "Description in the product 48", "Product 48", 387m },
                    { 49, "Description in the product 49", "Product 49", 593m },
                    { 50, "Description in the product 50", "Product 50", 101m },
                    { 51, "Description in the product 51", "Product 51", 510m },
                    { 52, "Description in the product 52", "Product 52", 395m },
                    { 53, "Description in the product 53", "Product 53", 143m },
                    { 54, "Description in the product 54", "Product 54", 188m },
                    { 55, "Description in the product 55", "Product 55", 805m },
                    { 56, "Description in the product 56", "Product 56", 255m },
                    { 57, "Description in the product 57", "Product 57", 293m },
                    { 58, "Description in the product 58", "Product 58", 143m },
                    { 59, "Description in the product 59", "Product 59", 520m },
                    { 60, "Description in the product 60", "Product 60", 540m },
                    { 61, "Description in the product 61", "Product 61", 452m },
                    { 62, "Description in the product 62", "Product 62", 299m },
                    { 63, "Description in the product 63", "Product 63", 236m },
                    { 64, "Description in the product 64", "Product 64", 580m },
                    { 65, "Description in the product 65", "Product 65", 622m },
                    { 66, "Description in the product 66", "Product 66", 274m },
                    { 67, "Description in the product 67", "Product 67", 990m },
                    { 68, "Description in the product 68", "Product 68", 410m },
                    { 69, "Description in the product 69", "Product 69", 780m },
                    { 70, "Description in the product 70", "Product 70", 901m },
                    { 71, "Description in the product 71", "Product 71", 902m },
                    { 72, "Description in the product 72", "Product 72", 127m },
                    { 73, "Description in the product 73", "Product 73", 515m },
                    { 74, "Description in the product 74", "Product 74", 894m },
                    { 75, "Description in the product 75", "Product 75", 934m },
                    { 76, "Description in the product 76", "Product 76", 952m },
                    { 77, "Description in the product 77", "Product 77", 752m },
                    { 78, "Description in the product 78", "Product 78", 223m },
                    { 79, "Description in the product 79", "Product 79", 946m },
                    { 80, "Description in the product 80", "Product 80", 660m },
                    { 81, "Description in the product 81", "Product 81", 990m },
                    { 82, "Description in the product 82", "Product 82", 448m },
                    { 83, "Description in the product 83", "Product 83", 198m },
                    { 84, "Description in the product 84", "Product 84", 811m },
                    { 85, "Description in the product 85", "Product 85", 581m },
                    { 86, "Description in the product 86", "Product 86", 569m },
                    { 87, "Description in the product 87", "Product 87", 999m },
                    { 88, "Description in the product 88", "Product 88", 720m },
                    { 89, "Description in the product 89", "Product 89", 665m },
                    { 90, "Description in the product 90", "Product 90", 538m },
                    { 91, "Description in the product 91", "Product 91", 529m },
                    { 92, "Description in the product 92", "Product 92", 505m },
                    { 93, "Description in the product 93", "Product 93", 625m },
                    { 94, "Description in the product 94", "Product 94", 860m },
                    { 95, "Description in the product 95", "Product 95", 777m },
                    { 96, "Description in the product 96", "Product 96", 979m },
                    { 97, "Description in the product 97", "Product 97", 503m },
                    { 98, "Description in the product 98", "Product 98", 409m },
                    { 99, "Description in the product 99", "Product 99", 323m },
                    { 100, "Description in the product 100", "Product 100", 624m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "ProductsInStock",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 2, 2, 9 },
                    { 3, 3, 0 },
                    { 4, 4, 3 },
                    { 5, 5, 18 },
                    { 6, 6, 2 },
                    { 7, 7, 11 },
                    { 8, 8, 11 },
                    { 9, 9, 17 },
                    { 10, 10, 18 },
                    { 11, 11, 9 },
                    { 12, 12, 11 },
                    { 13, 13, 8 },
                    { 14, 14, 3 },
                    { 15, 15, 16 },
                    { 16, 16, 17 },
                    { 17, 17, 6 },
                    { 18, 18, 11 },
                    { 19, 19, 5 },
                    { 20, 20, 0 },
                    { 21, 21, 2 },
                    { 22, 22, 18 },
                    { 23, 23, 19 },
                    { 24, 24, 7 },
                    { 25, 25, 7 },
                    { 26, 26, 10 },
                    { 27, 27, 14 },
                    { 28, 28, 12 },
                    { 29, 29, 0 },
                    { 30, 30, 9 },
                    { 31, 31, 12 },
                    { 32, 32, 12 },
                    { 33, 33, 5 },
                    { 34, 34, 12 },
                    { 35, 35, 19 },
                    { 36, 36, 16 },
                    { 37, 37, 5 },
                    { 38, 38, 1 },
                    { 39, 39, 13 },
                    { 40, 40, 18 },
                    { 41, 41, 2 },
                    { 42, 42, 11 },
                    { 43, 43, 0 },
                    { 44, 44, 15 },
                    { 45, 45, 16 },
                    { 46, 46, 5 },
                    { 47, 47, 15 },
                    { 48, 48, 14 },
                    { 49, 49, 19 },
                    { 50, 50, 16 },
                    { 51, 51, 6 },
                    { 52, 52, 14 },
                    { 53, 53, 18 },
                    { 54, 54, 9 },
                    { 55, 55, 19 },
                    { 56, 56, 19 },
                    { 57, 57, 2 },
                    { 58, 58, 2 },
                    { 59, 59, 2 },
                    { 60, 60, 8 },
                    { 61, 61, 14 },
                    { 62, 62, 18 },
                    { 63, 63, 15 },
                    { 64, 64, 14 },
                    { 65, 65, 17 },
                    { 66, 66, 17 },
                    { 67, 67, 15 },
                    { 68, 68, 2 },
                    { 69, 69, 1 },
                    { 70, 70, 4 },
                    { 71, 71, 15 },
                    { 72, 72, 0 },
                    { 73, 73, 17 },
                    { 74, 74, 14 },
                    { 75, 75, 12 },
                    { 76, 76, 10 },
                    { 77, 77, 0 },
                    { 78, 78, 7 },
                    { 79, 79, 8 },
                    { 80, 80, 10 },
                    { 81, 81, 14 },
                    { 82, 82, 18 },
                    { 83, 83, 1 },
                    { 84, 84, 14 },
                    { 85, 85, 17 },
                    { 86, 86, 17 },
                    { 87, 87, 7 },
                    { 88, 88, 9 },
                    { 89, 89, 13 },
                    { 90, 90, 3 },
                    { 91, 91, 10 },
                    { 92, 92, 13 },
                    { 93, 93, 3 },
                    { 94, 94, 8 },
                    { 95, 95, 7 },
                    { 96, 96, 6 },
                    { 97, 97, 3 },
                    { 98, 98, 0 },
                    { 99, 99, 8 },
                    { 100, 100, 15 }
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
