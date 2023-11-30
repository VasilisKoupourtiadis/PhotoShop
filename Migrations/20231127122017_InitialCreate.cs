using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
