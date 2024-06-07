using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddListManipulations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutpuTeamsEntityId",
                table: "Blocks",
                newName: "OutputTeamsEntityId");

            migrationBuilder.AddColumn<int>(
                name: "ListManipulationId",
                table: "OutputTeamEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ListManipulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    InputTeamsEntityAId = table.Column<int>(type: "int", nullable: false),
                    InputTeamsEntityBId = table.Column<int>(type: "int", nullable: false),
                    OutputTeamEnityId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    ListManipulationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListManipulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListManipulations_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListManipulations_TournamentId",
                table: "ListManipulations",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListManipulations");

            migrationBuilder.DropColumn(
                name: "ListManipulationId",
                table: "OutputTeamEntities");

            migrationBuilder.RenameColumn(
                name: "OutputTeamsEntityId",
                table: "Blocks",
                newName: "OutpuTeamsEntityId");
        }
    }
}
