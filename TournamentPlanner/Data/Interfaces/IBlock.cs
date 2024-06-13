namespace TournamentPlanner.Data.Interfaces
{
    public interface IBlock
    {
        int Id { get; }
        public List<Match> GenerateMatches(ApplicationDbContext context, List<Team> teams);
    }
}
