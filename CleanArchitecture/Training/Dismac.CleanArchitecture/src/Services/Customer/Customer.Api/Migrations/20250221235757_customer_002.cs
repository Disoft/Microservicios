using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Api.Migrations
{
    /// <inheritdoc />
    public partial class customer_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Id",
                schema: "Customer",
                table: "Customers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Id",
                schema: "Customer",
                table: "Customers");
        }
    }
}
