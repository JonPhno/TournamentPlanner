using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedMapGameMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapGameMode_GameModes_GameModeId",
                table: "MapGameMode");

            migrationBuilder.DropForeignKey(
                name: "FK_MapGameMode_Maps_MapId",
                table: "MapGameMode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapGameMode",
                table: "MapGameMode");

            migrationBuilder.RenameTable(
                name: "MapGameMode",
                newName: "MapGameModes");

            migrationBuilder.RenameIndex(
                name: "IX_MapGameMode_MapId",
                table: "MapGameModes",
                newName: "IX_MapGameModes_MapId");

            migrationBuilder.RenameIndex(
                name: "IX_MapGameMode_GameModeId",
                table: "MapGameModes",
                newName: "IX_MapGameModes_GameModeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapGameModes",
                table: "MapGameModes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapGameModes_GameModes_GameModeId",
                table: "MapGameModes",
                column: "GameModeId",
                principalTable: "GameModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapGameModes_Maps_MapId",
                table: "MapGameModes",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapGameModes_GameModes_GameModeId",
                table: "MapGameModes");

            migrationBuilder.DropForeignKey(
                name: "FK_MapGameModes_Maps_MapId",
                table: "MapGameModes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapGameModes",
                table: "MapGameModes");

            migrationBuilder.RenameTable(
                name: "MapGameModes",
                newName: "MapGameMode");

            migrationBuilder.RenameIndex(
                name: "IX_MapGameModes_MapId",
                table: "MapGameMode",
                newName: "IX_MapGameMode_MapId");

            migrationBuilder.RenameIndex(
                name: "IX_MapGameModes_GameModeId",
                table: "MapGameMode",
                newName: "IX_MapGameMode_GameModeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapGameMode",
                table: "MapGameMode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapGameMode_GameModes_GameModeId",
                table: "MapGameMode",
                column: "GameModeId",
                principalTable: "GameModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapGameMode_Maps_MapId",
                table: "MapGameMode",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
