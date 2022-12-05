using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertTicketsBookingSystem.Migrations
{
    public partial class NewState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promoCodes_Concert_ConcertId",
                table: "promoCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Concert_ConcertId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "concerts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_concerts",
                table: "concerts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_promoCodes_concerts_ConcertId",
                table: "promoCodes",
                column: "ConcertId",
                principalTable: "concerts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_concerts_ConcertId",
                table: "tickets",
                column: "ConcertId",
                principalTable: "concerts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promoCodes_concerts_ConcertId",
                table: "promoCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_concerts_ConcertId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_concerts",
                table: "concerts");

            migrationBuilder.RenameTable(
                name: "concerts",
                newName: "Concert");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_promoCodes_Concert_ConcertId",
                table: "promoCodes",
                column: "ConcertId",
                principalTable: "Concert",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Concert_ConcertId",
                table: "tickets",
                column: "ConcertId",
                principalTable: "Concert",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
