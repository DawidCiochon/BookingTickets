using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookingTickets.Migrations
{
    public partial class SeatDBChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Movies_MoviesId",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seance_MoviesId",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Seance");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Seats",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_MovieId",
                table: "Seance",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Movies_MovieId",
                table: "Seance",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Movies_MovieId",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seance_MovieId",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Seats",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Seance",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_MoviesId",
                table: "Seance",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Movies_MoviesId",
                table: "Seance",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
