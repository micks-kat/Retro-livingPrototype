using Microsoft.EntityFrameworkCore.Migrations;

namespace Retro_Living.Migrations
{
    public partial class create_controls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    h_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    h_name = table.Column<string>(nullable: true),
                    h_contacts = table.Column<string>(nullable: true),
                    h_email_address = table.Column<string>(nullable: true),
                    h_description = table.Column<string>(nullable: true),
                    h_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.h_id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    room_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_number = table.Column<string>(nullable: true),
                    room_type = table.Column<string>(nullable: true),
                    room_availability = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.room_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_first_name = table.Column<string>(nullable: true),
                    user_last_name = table.Column<string>(nullable: true),
                    user_gender = table.Column<string>(nullable: true),
                    user_dob = table.Column<string>(nullable: true),
                    user_nationality = table.Column<string>(nullable: true),
                    user_email_address = table.Column<string>(nullable: true),
                    user_contacts = table.Column<string>(nullable: true),
                    user_password = table.Column<string>(nullable: true),
                    user_address = table.Column<string>(nullable: true),
                    user_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_rooms",
                columns: table => new
                {
                    h_id = table.Column<int>(nullable: false),
                    room_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_rooms", x => new { x.room_id, x.h_id });
                    table.ForeignKey(
                        name: "FK_hotel_rooms_Hotel_h_id",
                        column: x => x.h_id,
                        principalTable: "Hotel",
                        principalColumn: "h_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotel_rooms_Room_room_id",
                        column: x => x.room_id,
                        principalTable: "Room",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Hotel",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    h_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Hotel", x => new { x.user_id, x.h_id });
                    table.ForeignKey(
                        name: "FK_User_Hotel_Hotel_h_id",
                        column: x => x.h_id,
                        principalTable: "Hotel",
                        principalColumn: "h_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Hotel_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotel_rooms_h_id",
                table: "hotel_rooms",
                column: "h_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Hotel_h_id",
                table: "User_Hotel",
                column: "h_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotel_rooms");

            migrationBuilder.DropTable(
                name: "User_Hotel");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
