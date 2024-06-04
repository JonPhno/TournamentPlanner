using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Games_GameId",
                table: "Maps");

            migrationBuilder.DropTable(
                name: "GameGameMode");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameModes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_GameId",
                table: "GameModes",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Games_GameId",
                table: "GameModes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Games_GameId",
                table: "Maps",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Games_GameId",
                table: "GameModes");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Games_GameId",
                table: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_GameModes_GameId",
                table: "GameModes");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameModes");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Maps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_GameGameMode_GameId",
                table: "GameGameMode",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameMode_GameModeId",
                table: "GameGameMode",
                column: "GameModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Games_GameId",
                table: "Maps",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
