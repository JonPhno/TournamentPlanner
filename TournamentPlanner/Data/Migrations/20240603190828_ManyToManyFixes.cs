using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Games_GameId",
                table: "GameModes");

            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Maps_MapId",
                table: "GameModes");

            migrationBuilder.DropIndex(
                name: "IX_GameModes_GameId",
                table: "GameModes");

            migrationBuilder.DropIndex(
                name: "IX_GameModes_MapId",
                table: "GameModes");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameModes");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "GameModes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GameModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GameGameMode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGameMode_GameModes_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameMode_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapGameMode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapGameMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapGameMode_GameModes_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapGameMode_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGameMode_GameId",
                table: "GameGameMode",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameMode_GameModeId",
                table: "GameGameMode",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MapGameMode_GameModeId",
                table: "MapGameMode",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MapGameMode_MapId",
                table: "MapGameMode",
                column: "MapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGameMode");

            migrationBuilder.DropTable(
                name: "MapGameMode");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GameModes");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameModes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "GameModes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_GameId",
                table: "GameModes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_MapId",
                table: "GameModes",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Games_GameId",
                table: "GameModes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Maps_MapId",
                table: "GameModes",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id");
        }
    }
}
