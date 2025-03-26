using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068276a7-80e6-46ea-8bb6-ec3e5d5cb97e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64077a3b-252c-433d-9873-559ec47c60a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a33d16-5dfb-470b-a3c6-399aeba1ff38");

            migrationBuilder.AddColumn<string>(
                name: "PhotoLocation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "NoPhoto.jpg");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "438fc24c-9563-4f66-bd14-5434bd64b669", null, "Buyer", "BUYER" },
                    { "91cf25d2-4731-4067-8ac1-77904af21473", null, "Customer", "CUSTOMER" },
                    { "f650aef8-0825-46f7-ad63-aa626d098646", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438fc24c-9563-4f66-bd14-5434bd64b669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91cf25d2-4731-4067-8ac1-77904af21473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f650aef8-0825-46f7-ad63-aa626d098646");

            migrationBuilder.DropColumn(
                name: "PhotoLocation",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068276a7-80e6-46ea-8bb6-ec3e5d5cb97e", null, "Admin", "ADMIN" },
                    { "64077a3b-252c-433d-9873-559ec47c60a4", null, "Buyer", "BUYER" },
                    { "73a33d16-5dfb-470b-a3c6-399aeba1ff38", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
