using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoShop.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAndOrderLineEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22ca08b5-2403-4eec-8197-9834c85ce94a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2be14327-e257-4398-bf3c-0090be2e60ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e3f47f7-c98e-4454-b860-4072c0d0741e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("334f6548-c7d0-438e-bbdb-3f4fde6b642e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69f2e429-d6be-4125-ac4a-d2286a15ef26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79b7e0b3-28f9-46a6-8769-05730bb19982"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd257b0-e33a-4fbc-a8d4-ca98fb330857"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6fd6dc6-5781-430c-9c53-e26482e26607"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1673ae3-2a37-48ec-93c0-80aefd318e69"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c32a6579-a643-4cd2-afd0-ab5d90f44c0f"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("0a59022e-de98-41f2-ba0b-42233fab3664"), "This is Photo Nr 1 in our collection of photographs.", "https://picsum.photos/id/74/500", 202m, "Photo 1" },
                    { new Guid("1bd468db-58f9-4f7a-83cc-b7c75949c062"), "This is Photo Nr 9 in our collection of photographs.", "https://picsum.photos/id/58/500", 729m, "Photo 9" },
                    { new Guid("4efb9c99-0553-471c-a4ff-356e52f23dcc"), "This is Photo Nr 2 in our collection of photographs.", "https://picsum.photos/id/70/500", 593m, "Photo 2" },
                    { new Guid("560d86da-6cc7-48ab-aeed-9644170a0d55"), "This is Photo Nr 5 in our collection of photographs.", "https://picsum.photos/id/67/500", 665m, "Photo 5" },
                    { new Guid("6c44180e-44f6-41d6-b977-6e642b035f6e"), "This is Photo Nr 4 in our collection of photographs.", "https://picsum.photos/id/57/500", 911m, "Photo 4" },
                    { new Guid("98af687b-9d6c-449c-92db-8d924445a3c3"), "This is Photo Nr 6 in our collection of photographs.", "https://picsum.photos/id/83/500", 160m, "Photo 6" },
                    { new Guid("b755145f-728e-4652-8cba-70db836c9237"), "This is Photo Nr 3 in our collection of photographs.", "https://picsum.photos/id/80/500", 944m, "Photo 3" },
                    { new Guid("cdff9acc-728e-4340-b0ca-a868fbb42226"), "This is Photo Nr 8 in our collection of photographs.", "https://picsum.photos/id/72/500", 401m, "Photo 8" },
                    { new Guid("d3811ece-6e97-4b93-84be-fd64c968190e"), "This is Photo Nr 7 in our collection of photographs.", "https://picsum.photos/id/30/500", 524m, "Photo 7" },
                    { new Guid("dea1c565-d530-48c6-8f71-714a62bd2a1d"), "This is Photo Nr 10 in our collection of photographs.", "https://picsum.photos/id/16/500", 697m, "Photo 10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a59022e-de98-41f2-ba0b-42233fab3664"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1bd468db-58f9-4f7a-83cc-b7c75949c062"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4efb9c99-0553-471c-a4ff-356e52f23dcc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("560d86da-6cc7-48ab-aeed-9644170a0d55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c44180e-44f6-41d6-b977-6e642b035f6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98af687b-9d6c-449c-92db-8d924445a3c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b755145f-728e-4652-8cba-70db836c9237"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cdff9acc-728e-4340-b0ca-a868fbb42226"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d3811ece-6e97-4b93-84be-fd64c968190e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dea1c565-d530-48c6-8f71-714a62bd2a1d"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("22ca08b5-2403-4eec-8197-9834c85ce94a"), "This is Photo Nr 6 in our collection of photographs.", "https://picsum.photos/id/12/500", 191m, "Photo 6" },
                    { new Guid("2be14327-e257-4398-bf3c-0090be2e60ed"), "This is Photo Nr 1 in our collection of photographs.", "https://picsum.photos/id/41/500", 672m, "Photo 1" },
                    { new Guid("2e3f47f7-c98e-4454-b860-4072c0d0741e"), "This is Photo Nr 9 in our collection of photographs.", "https://picsum.photos/id/65/500", 751m, "Photo 9" },
                    { new Guid("334f6548-c7d0-438e-bbdb-3f4fde6b642e"), "This is Photo Nr 10 in our collection of photographs.", "https://picsum.photos/id/68/500", 91m, "Photo 10" },
                    { new Guid("69f2e429-d6be-4125-ac4a-d2286a15ef26"), "This is Photo Nr 3 in our collection of photographs.", "https://picsum.photos/id/11/500", 349m, "Photo 3" },
                    { new Guid("79b7e0b3-28f9-46a6-8769-05730bb19982"), "This is Photo Nr 8 in our collection of photographs.", "https://picsum.photos/id/40/500", 142m, "Photo 8" },
                    { new Guid("7bd257b0-e33a-4fbc-a8d4-ca98fb330857"), "This is Photo Nr 4 in our collection of photographs.", "https://picsum.photos/id/59/500", 810m, "Photo 4" },
                    { new Guid("a6fd6dc6-5781-430c-9c53-e26482e26607"), "This is Photo Nr 5 in our collection of photographs.", "https://picsum.photos/id/7/500", 964m, "Photo 5" },
                    { new Guid("c1673ae3-2a37-48ec-93c0-80aefd318e69"), "This is Photo Nr 2 in our collection of photographs.", "https://picsum.photos/id/45/500", 600m, "Photo 2" },
                    { new Guid("c32a6579-a643-4cd2-afd0-ab5d90f44c0f"), "This is Photo Nr 7 in our collection of photographs.", "https://picsum.photos/id/37/500", 363m, "Photo 7" }
                });
        }
    }
}
