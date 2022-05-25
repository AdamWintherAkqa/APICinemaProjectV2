using Microsoft.EntityFrameworkCore.Migrations;

namespace APICinemaProjectV2.DAL.Migrations
{
    public partial class _25_05_2022_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSeat_Seat_SeatsSeatID",
                table: "OrderSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Hall_HallID",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_HallID",
                table: "Seats",
                newName: "IX_Seats_HallID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "SeatID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSeat_Seats_SeatsSeatID",
                table: "OrderSeat",
                column: "SeatsSeatID",
                principalTable: "Seats",
                principalColumn: "SeatID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Hall_HallID",
                table: "Seats",
                column: "HallID",
                principalTable: "Hall",
                principalColumn: "HallID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSeat_Seats_SeatsSeatID",
                table: "OrderSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Hall_HallID",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallID",
                table: "Seat",
                newName: "IX_Seat_HallID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSeat_Seat_SeatsSeatID",
                table: "OrderSeat",
                column: "SeatsSeatID",
                principalTable: "Seat",
                principalColumn: "SeatID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Hall_HallID",
                table: "Seat",
                column: "HallID",
                principalTable: "Hall",
                principalColumn: "HallID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
