using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class FixManyToManys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutputTeamEntities_Blocks_BlockId",
                table: "OutputTeamEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputTeamEntities_Tournaments_TournamentId",
                table: "OutputTeamEntities");

            migrationBuilder.DropIndex(
                name: "IX_OutputTeamEntities_BlockId",
                table: "OutputTeamEntities");

            migrationBuilder.DropIndex(
                name: "IX_OutputTeamEntities_TournamentId",
                table: "OutputTeamEntities");

            migrationBuilder.AddColumn<int>(
                name: "InputTeamsEntityId",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutpuTeamsEntityId",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_TournamentId",
                table: "Blocks",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Tournaments_TournamentId",
                table: "Blocks",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Tournaments_TournamentId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_TournamentId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "InputTeamsEntityId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "OutpuTeamsEntityId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Blocks");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTeamEntities_BlockId",
                table: "OutputTeamEntities",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTeamEntities_TournamentId",
                table: "OutputTeamEntities",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputTeamEntities_Blocks_BlockId",
                table: "OutputTeamEntities",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputTeamEntities_Tournaments_TournamentId",
                table: "OutputTeamEntities",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
