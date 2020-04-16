using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Retro_Living.Migrations
{
    public partial class create_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bookb_id",
                table: "Room",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    b_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_time = table.Column<DateTime>(nullable: false),
                    check_in_time = table.Column<DateTime>(nullable: false),
                    check_out_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.b_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_Bookb_id",
                table: "Room",
                column: "Bookb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Book_Bookb_id",
                table: "Room",
                column: "Bookb_id",
                principalTable: "Book",
                principalColumn: "b_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Book_Bookb_id",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Room_Bookb_id",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Bookb_id",
                table: "Room");
        }
    }
}
