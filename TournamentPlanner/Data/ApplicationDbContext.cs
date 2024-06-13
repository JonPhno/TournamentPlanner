using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TournamentPlanner.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<MapGameMode> MapGameModes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamMatchScore> TeamMatchScores { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }
        public DbSet<OutputTeamEntity> OutputTeamEntities { get; set; }
        public DbSet<ListManipulation> ListManipulations { get; set; }
        public DbSet<MatchFlow> MatchFlows { get; set; }


    }

}
