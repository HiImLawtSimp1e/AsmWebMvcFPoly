using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_hungnqph19112_CS4.Migrations
{
    public partial class hung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Infomation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Orange" },
                    { 2, "Fresh Meat" },
                    { 3, "Vegetables" },
                    { 4, "Fastfood" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Infomation", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 3, "Măng tây được nuôi trồng tại Lâm Đồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sạch, chất lượng và an toàn với người dùng. Măng giòn, ngọt, hàm lượng dinh dưỡng cao nên thường được chế biên bằng hấp, luộc hoặc nướng để có thể giữ được độ tươi ngon.", "featured/mang-tay.jpg", "Giá trị dinh dưỡng của măng tây\r\nMăng tây là thực phẩm quý giá có chứa hàm lượng dinh dưỡng cao như: chất xơ, đạm, glucid, các vitamin K, C, A, pyridoxine (B6), riboflavin (B2), acid folic, canxi, sắt, kẽm…\r\nTrong 100g măng tây có 20.3 Kcal.\nTác dụng của măng tây đối với sức khỏe\r\nLàm đẹp da và ngăn ngừa lão hóa\r\nNgăn ngừa bệnh loãng xương\r\nNgăn ngừa bệnh ung thư\r\nTăng cường hệ miễn dịch\nCác món ăn ngon từ măng tây\r\nMăng tây thì bạn có thể chế biến thành nhiều món ăn khác nhau như: măng tây xào thịt bò, măng tây xào nấm, súp cá hồi phô mai măng tây, súp tôm măng tây,...\r\nCách bảo quản măng tây tươi ngon\r\nMăng tây nên được bảo quản trong ngăn mát tủ lạnh để giúp măng tây tươi ngon, giòn ngọt.", 27550m, "Măng tây Lâm Đồng 200g" },
                    { 2, 2, "None", "featured/feature-2.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 3, 3, "None", "featured/feature-3.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 4, 4, "None", "featured/feature-4.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 5, 1, "None", "featured/feature-5.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 6, 2, "None", "featured/feature-6.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 7, 3, "None", "featured/feature-7.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 8, 4, "None", "featured/feature-8.jpg", "No Infomation", 30000m, "Crab Pool Security" },
                    { 9, 1, "None", "featured/feature-5.jpg", "No Infomation", 30000m, "Crab Pool Security" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "details/mang-tay-1.jpg", 1 },
                    { 2, "details/mang-tay-2.jpg", 1 },
                    { 3, "details/mang-tay-3.jpg", 1 },
                    { 4, "details/mang-tay-4.jpg", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
