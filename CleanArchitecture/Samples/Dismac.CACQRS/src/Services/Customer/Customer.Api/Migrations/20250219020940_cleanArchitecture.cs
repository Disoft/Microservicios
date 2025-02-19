using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Customer.Api.Migrations
{
    /// <inheritdoc />
    public partial class cleanArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), "john.doe@example.com", "John Doe" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), "jane.doe@example.com", "Jane Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Id",
                schema: "Customer",
                table: "Customers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Customer");
        }
    }
}
