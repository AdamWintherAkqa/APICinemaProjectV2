using Microsoft.EntityFrameworkCore.Migrations;

namespace APICinemaProjectV2.DAL.Migrations
{
    public partial class _25_05_2022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoyaltyPrograms",
                columns: table => new
                {
                    LoyaltyProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyPrograms", x => x.LoyaltyProgramID);
                    table.ForeignKey(
                        name: "FK_LoyaltyPrograms_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoyaltyPrograms_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyPrograms_CustomerID",
                table: "LoyaltyPrograms",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyPrograms_OrderID",
                table: "LoyaltyPrograms",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoyaltyPrograms");
        }
    }
}
