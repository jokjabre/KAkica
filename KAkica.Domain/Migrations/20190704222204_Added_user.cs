using Microsoft.EntityFrameworkCore.Migrations;

namespace KAkica.Domain.Migrations
{
    public partial class Added_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Owner");

            migrationBuilder.AddColumn<string>(
                name: "KakicaUserRef",
                table: "Owner",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_KakicaUserRef",
                table: "Owner",
                column: "KakicaUserRef",
                unique: true,
                filter: "[KakicaUserRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Users_KakicaUserRef",
                table: "Owner",
                column: "KakicaUserRef",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Users_KakicaUserRef",
                table: "Owner");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Owner_KakicaUserRef",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "KakicaUserRef",
                table: "Owner");

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Owner",
                nullable: false,
                defaultValue: 0);
        }
    }
}
