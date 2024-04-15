using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace winery_backend.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80b30685-8cb8-413f-aa8c-57b5bce77778");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdd26241-a936-48de-a250-af6fd69adadd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "015b7f93-57ff-438d-b07c-38802e56a3bf", null, "Driver", "DRIVER" },
                    { "0f66807c-9ba7-422a-adca-865d01395827", null, "Administrator", "ADMININISTRATOR" },
                    { "1789c37c-871b-42a5-aeac-f037c795f1e8", null, "SalesManager", "SALES_MANAGER" },
                    { "2d55c54a-b9d4-4a15-88a9-a4bd6d41e2e5", null, "Logistician", "LOGISTICIAN" },
                    { "4a856567-a81f-48b9-81d5-b7497fa4965b", null, "Warehouseman", "WAREHOUSEMAN" },
                    { "5371a127-49c0-482c-bf68-991f29534d96", null, "Customer", "CUSTOMER" },
                    { "88284388-05b4-4bb0-b20e-946fb6e0baf9", null, "Technologist", "TECHNOLOGIST" },
                    { "8ac79c14-e80e-4fe2-b7b5-302df3ef5674", null, "MarketingManager", "MARKETING_MANAGER" },
                    { "8f110a3e-b085-456d-858f-325d0e90161d", null, "TourGuide", "TOUR_GUIDE" },
                    { "c32a3c59-567a-4c3e-beb2-4c2dbd59a207", null, "Owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "015b7f93-57ff-438d-b07c-38802e56a3bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f66807c-9ba7-422a-adca-865d01395827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1789c37c-871b-42a5-aeac-f037c795f1e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d55c54a-b9d4-4a15-88a9-a4bd6d41e2e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a856567-a81f-48b9-81d5-b7497fa4965b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5371a127-49c0-482c-bf68-991f29534d96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88284388-05b4-4bb0-b20e-946fb6e0baf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac79c14-e80e-4fe2-b7b5-302df3ef5674");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f110a3e-b085-456d-858f-325d0e90161d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32a3c59-567a-4c3e-beb2-4c2dbd59a207");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80b30685-8cb8-413f-aa8c-57b5bce77778", null, "Customer", "CUSTOMER" },
                    { "bdd26241-a936-48de-a250-af6fd69adadd", null, "Administrator", "ADMININISTRATOR" }
                });
        }
    }
}
