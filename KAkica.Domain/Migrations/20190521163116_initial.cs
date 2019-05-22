using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KAkica.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poopers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poopers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserPoopers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false),
                    PooperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPoopers", x => new { x.PooperId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_AppUserPoopers_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserPoopers_Poopers_PooperId",
                        column: x => x.PooperId,
                        principalTable: "Poopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "mail1@test.com", "test", "user1" },
                    { 2, "mail2@test.com", "test", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Poopers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "pooper1" },
                    { 2, "pooper2" }
                });

            migrationBuilder.InsertData(
                table: "AppUserPoopers",
                columns: new[] { "PooperId", "AppUserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AppUserPoopers",
                columns: new[] { "PooperId", "AppUserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AppUserPoopers",
                columns: new[] { "PooperId", "AppUserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPoopers_AppUserId",
                table: "AppUserPoopers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserPoopers");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Poopers");
        }
    }
}
