using Microsoft.EntityFrameworkCore.Migrations;

namespace KAkica.Domain.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Poopers_PooperId",
                table: "Activities");

            migrationBuilder.AlterColumn<long>(
                name: "PooperId",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Poopers_PooperId",
                table: "Activities",
                column: "PooperId",
                principalTable: "Poopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Poopers_PooperId",
                table: "Activities");

            migrationBuilder.AlterColumn<long>(
                name: "PooperId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Poopers_PooperId",
                table: "Activities",
                column: "PooperId",
                principalTable: "Poopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
