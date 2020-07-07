using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookingTickets.Migrations
{
    public partial class AddRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seance_SeanceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Movies_MovieId",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seance",
                table: "Seance");

            migrationBuilder.RenameTable(
                name: "Seance",
                newName: "Seances");

            migrationBuilder.RenameIndex(
                name: "IX_Seance_MovieId",
                table: "Seances",
                newName: "IX_Seances_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seances",
                table: "Seances",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_RoomId",
                table: "Seances",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seances_SeanceId",
                table: "Reservations",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Movies_MovieId",
                table: "Seances",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Rooms_RoomId",
                table: "Seances",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seances_SeanceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Movies_MovieId",
                table: "Seances");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Rooms_RoomId",
                table: "Seances");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seances",
                table: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Seances_RoomId",
                table: "Seances");

            migrationBuilder.RenameTable(
                name: "Seances",
                newName: "Seance");

            migrationBuilder.RenameIndex(
                name: "IX_Seances_MovieId",
                table: "Seance",
                newName: "IX_Seance_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seance",
                table: "Seance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seance_SeanceId",
                table: "Reservations",
                column: "SeanceId",
                principalTable: "Seance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Movies_MovieId",
                table: "Seance",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
