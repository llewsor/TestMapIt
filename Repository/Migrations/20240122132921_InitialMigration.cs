using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CustomerDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SalesItem = table.Column<bool>(type: "bit", nullable: false),
                    StockItem = table.Column<bool>(type: "bit", nullable: false),
                    PurchasedItem = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManageItemBy = table.Column<int>(type: "int", nullable: false),
                    MinimumInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ItemCode);
                });

            migrationBuilder.InsertData(
                table: "ItemMaster",
                columns: new[] { "ItemCode", "Active", "Barcode", "CustomerDescription", "DateCreated", "Description", "ImagePath", "ManageItemBy", "MaximumInventory", "MinimumInventory", "PurchasedItem", "Remarks", "SalesItem", "StockItem" },
                values: new object[,]
                {
                    { "c8413b69-8f44-49f7-a788-f", true, "070590708898824485667995070969", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.", new DateTime(2024, 1, 22, 14, 29, 20, 793, DateTimeKind.Local).AddTicks(8822), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.", "9e9ef54a-f995-4da1-95ee-3456414d28fb.png", 1, 100m, 0m, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus.", false, true },
                    { "d18912c0-ac67-470c-a83f-0", true, "070590708898824485667995070969", null, new DateTime(2024, 1, 22, 14, 29, 20, 793, DateTimeKind.Local).AddTicks(8813), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.", "58108b9a-e114-4d02-9967-f8a00e42ef59.png", 0, 100m, 0m, false, null, false, true },
                    { "e0d16ac6-1e4b-45f7-8e87-1", true, "070590708898824485667995070969", null, new DateTime(2024, 1, 22, 14, 29, 20, 793, DateTimeKind.Local).AddTicks(8688), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.", "374ad050-7773-4f42-86d2-fbb66273f13b.png", 0, 100m, 0m, false, null, false, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMaster");
        }
    }
}
