using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddGamemodeOptionnalOnMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MapGameModes_MapGameModeId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MapGameModeId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MapGameModes_MapGameModeId",
                table: "Matches",
                column: "MapGameModeId",
                principalTable: "MapGameModes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MapGameModes_MapGameModeId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MapGameModeId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MapGameModes_MapGameModeId",
                table: "Matches",
                column: "MapGameModeId",
                principalTable: "MapGameModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
