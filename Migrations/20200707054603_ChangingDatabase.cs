using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTickets.Migrations
{
    public partial class ChangingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservationId",
                table: "Seance");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeanceId",
                table: "Reservations",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seance_SeanceId",
                table: "Reservations",
                column: "SeanceId",
                principalTable: "Seance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seance_SeanceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SeanceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "reservationId",
                table: "Seance",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
