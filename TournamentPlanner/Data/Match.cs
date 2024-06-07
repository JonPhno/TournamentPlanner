namespace TournamentPlanner.Data
{
    public class Match
    {
        public int Id { get; set; }
        public bool Played { get; set; }
        public List<TeamMatchScore> TeamMatchScores { get; set; }
        public MapGameMode MapGameMode { get; set; }

    }
}