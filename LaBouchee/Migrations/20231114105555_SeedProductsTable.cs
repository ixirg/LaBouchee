using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaBouchee.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "Name", "Price", "isTrendingProduct" },
                values: new object[,]
                {
                    { 1, "Delicate layers of buttery, flaky pastry embrace a rich chocolate center, creating a blissful harmony of textures and flavors.", "https://i.postimg.cc/J0sq4xP1/Painauchocolat.jpg", "Pain au Chocolat", 3m, true },
                    { 2, " Handcrafted to golden buttery perfection, each layer unfolds with a crisp exterior and a soft, airy interior.", "https://i.postimg.cc/sg7Thnyx/Croissant.jpg", "Croissant", 2m, true },
                    { 3, "A symphony of flaky crust and velvety filling, our handcrafted quiches are a delightful blend of premium ingredients.", "https://i.postimg.cc/wvf2pZ5f/Quiche.jpg", "Quiche", 5m, true },
                    { 4, "Delicate choux pastry embraces a velvety center, each bite a symphony of textures and flavors.", "https://i.postimg.cc/tg4cKL8f/Eclair.jpg", "Eclair", 3m, true },
                    { 5, "Layers of flaky puff pastry and luscious pastry cream.", "https://i.postimg.cc/TYxt8zD9/Millefeuille.jpg", "Mille-Feuille", 3m, true },
                    { 6, "Savor the charm of our Madeleines — petite, shell-shaped cakes with a soft, buttery texture.", "https://i.postimg.cc/vHv3G07d/Madeleines.jpg", "Madeleines", 1m, true },
                    { 7, "These delicate almond meringue cookies, with a crisp exterior and a luscious filling, promise a burst of flavor in every bite.", "https://i.postimg.cc/c1wFbxrC/Macarons.jpg", "Macaron", 3m, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
