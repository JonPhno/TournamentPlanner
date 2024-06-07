using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTeamLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamLists");

            migrationBuilder.DropTable(
                name: "BlockTeamLists");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OutputTeamEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputTeamEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputTeamEntities_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputTeamEntities_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutputTeamEntities_BlockId",
                table: "OutputTeamEntities",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputTeamEntities_TournamentId",
                table: "OutputTeamEntities",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutputTeamEntities");

            migrationBuilder.DropTable(
                name: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blocks");

            migrationBuilder.CreateTable(
                name: "BlockTeamLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    ListType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockTeamLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockTeamLists_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputId = table.Column<int>(type: "int", nullable: false),
                    OutputId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLists_BlockTeamLists_InputId",
                        column: x => x.InputId,
                        principalTable: "BlockTeamLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLists_BlockTeamLists_OutputId",
                        column: x => x.OutputId,
                        principalTable: "BlockTeamLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLists_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockTeamLists_BlockId",
                table: "BlockTeamLists",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLists_InputId",
                table: "TeamLists",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLists_OutputId",
                table: "TeamLists",
                column: "OutputId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLists_TeamId",
                table: "TeamLists",
                column: "TeamId");
        }
    }
}
