using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoShop.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityPropToOrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("200d5b92-d551-41d6-ba06-4f44b5355220"), "This is Photo Nr 9 in our collection of photographs.", "https://picsum.photos/id/63/500", 765m, "Photo 9" },
                    { new Guid("33eead55-b609-4a62-9b1e-01b46b6b9765"), "This is Photo Nr 10 in our collection of photographs.", "https://picsum.photos/id/35/500", 221m, "Photo 10" },
                    { new Guid("719d7d3f-9ab0-4d12-abaf-3db0fc837eec"), "This is Photo Nr 1 in our collection of photographs.", "https://picsum.photos/id/41/500", 473m, "Photo 1" },
                    { new Guid("76e2fd69-ed0f-473b-b681-6858dbde3ba9"), "This is Photo Nr 7 in our collection of photographs.", "https://picsum.photos/id/7/500", 623m, "Photo 7" },
                    { new Guid("7e047aeb-b436-40f6-adde-4e1dffe4e977"), "This is Photo Nr 8 in our collection of photographs.", "https://picsum.photos/id/34/500", 426m, "Photo 8" },
                    { new Guid("89c52d5c-a6ea-40e2-ae6a-bb89d98f29fa"), "This is Photo Nr 4 in our collection of photographs.", "https://picsum.photos/id/12/500", 557m, "Photo 4" },
                    { new Guid("8e9941f9-cee8-488d-9965-16eb4c79e623"), "This is Photo Nr 3 in our collection of photographs.", "https://picsum.photos/id/53/500", 626m, "Photo 3" },
                    { new Guid("99d5f1d0-4cf8-4635-ba6f-5750b9ae380e"), "This is Photo Nr 5 in our collection of photographs.", "https://picsum.photos/id/53/500", 936m, "Photo 5" },
                    { new Guid("c2aaa285-af90-4d5a-9e16-74859470d41e"), "This is Photo Nr 6 in our collection of photographs.", "https://picsum.photos/id/85/500", 426m, "Photo 6" },
                    { new Guid("c4858f61-9283-4fa3-914b-3ed496fdb304"), "This is Photo Nr 2 in our collection of photographs.", "https://picsum.photos/id/81/500", 530m, "Photo 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("200d5b92-d551-41d6-ba06-4f44b5355220"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33eead55-b609-4a62-9b1e-01b46b6b9765"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("719d7d3f-9ab0-4d12-abaf-3db0fc837eec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76e2fd69-ed0f-473b-b681-6858dbde3ba9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e047aeb-b436-40f6-adde-4e1dffe4e977"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89c52d5c-a6ea-40e2-ae6a-bb89d98f29fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e9941f9-cee8-488d-9965-16eb4c79e623"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99d5f1d0-4cf8-4635-ba6f-5750b9ae380e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c2aaa285-af90-4d5a-9e16-74859470d41e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c4858f61-9283-4fa3-914b-3ed496fdb304"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderLine");

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
        }
    }
}
