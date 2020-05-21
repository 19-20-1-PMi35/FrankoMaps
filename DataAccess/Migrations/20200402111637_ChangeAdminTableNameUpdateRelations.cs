using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeAdminTableNameUpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distances_Admins_AdminId",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Admins_AdminId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Admins_AdminId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Distances_DistanceId",
                table: "Points");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Points_AdminId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_DistanceId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Maps_AdminId",
                table: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Distances_AdminId",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "DistanceId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Distances");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Points",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Points",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Maps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromPointId",
                table: "Distances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToPointId",
                table: "Distances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Distances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "FromPointId",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "ToPointId",
                table: "Distances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Distances");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Points",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistanceId",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Distances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Distances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "To",
                table: "Distances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
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
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_AdminId",
                table: "Points",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_DistanceId",
                table: "Points",
                column: "DistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_AdminId",
                table: "Maps",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Distances_AdminId",
                table: "Distances",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distances_Admins_AdminId",
                table: "Distances",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Admins_AdminId",
                table: "Maps",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Admins_AdminId",
                table: "Points",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Distances_DistanceId",
                table: "Points",
                column: "DistanceId",
                principalTable: "Distances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
