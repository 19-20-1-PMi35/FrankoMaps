using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DropUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distances_Users_UserId",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_UserId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Users_UserId",
                table: "Points");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Points_UserId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Maps_UserId",
                table: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Distances_UserId",
                table: "Distances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_UserId",
                table: "Points",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_UserId",
                table: "Maps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Distances_UserId",
                table: "Distances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distances_Users_UserId",
                table: "Distances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_UserId",
                table: "Maps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Users_UserId",
                table: "Points",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
