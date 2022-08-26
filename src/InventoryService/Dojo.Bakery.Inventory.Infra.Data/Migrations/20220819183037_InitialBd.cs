using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dojo.Bakery.Inventory.Infra.Data.Migrations
{
    public partial class InitialBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "DocumentType",
                columns: new[] { "Id", "CreatedOn", "IsActive", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("4cb9413d-a0c1-4b29-bc78-015130b756d2"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "DNI", null },
                    { new Guid("cee1dce9-443f-4dac-a249-71889b4b8f93"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "NIT", null }
                });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedOn", "IsActive", "Name", "QRCode", "UnitId", "UpdatedOn" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Guid("3aad1a96-9d1a-432a-b867-09f27ccbc7ab"), new Guid("7c684031-2232-4c10-9c03-790db1c06bf4"), new DateTime(2022, 8, 19, 13, 30, 37, 457, DateTimeKind.Local).AddTicks(613), true, "Pan Ocanero", "1234", new Guid("ab994361-1dee-4667-9f91-e46a3641ed6e"), new DateTime(2022, 8, 19, 13, 30, 37, 457, DateTimeKind.Local).AddTicks(632) });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "Unit",
                columns: new[] { "Id", "CreatedOn", "IsActive", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("11be23ad-a119-4329-ab8c-daf91aa7d9e5"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kgs", null },
                    { new Guid("1cd6c37b-065b-41b8-b088-cd50bc6893a9"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tons", null },
                    { new Guid("a4d42316-b54d-4ad0-9006-667fa6e5fd6f"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pounds", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Inventory");
        }
    }
}
