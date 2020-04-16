using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Retro_Living.Migrations
{
    public partial class creating_all_controllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    p_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paid_amount = table.Column<double>(nullable: false),
                    time_paid = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    inv_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_time = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: true),
                    payp_id = table.Column<int>(nullable: true),
                    bookb_id = table.Column<int>(nullable: true),
                    Paymentp_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.inv_id);
                    table.ForeignKey(
                        name: "FK_Invoice_Payment_Paymentp_id",
                        column: x => x.Paymentp_id,
                        principalTable: "Payment",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Book_bookb_id",
                        column: x => x.bookb_id,
                        principalTable: "Book",
                        principalColumn: "b_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Payment_payp_id",
                        column: x => x.payp_id,
                        principalTable: "Payment",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Book",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    b_id = table.Column<int>(nullable: false),
                    p_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Book", x => new { x.p_id, x.b_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_User_Book_Book_b_id",
                        column: x => x.b_id,
                        principalTable: "Book",
                        principalColumn: "b_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Book_Payment_p_id",
                        column: x => x.p_id,
                        principalTable: "Payment",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Book_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Paymentp_id",
                table: "Invoice",
                column: "Paymentp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_bookb_id",
                table: "Invoice",
                column: "bookb_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_payp_id",
                table: "Invoice",
                column: "payp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_user_id",
                table: "Invoice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Book_b_id",
                table: "User_Book",
                column: "b_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Book_user_id",
                table: "User_Book",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "User_Book");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
