namespace TournamentPlanner.Data
{
    public class TeamMatchScore
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Match Match { get; set; }
        public int Score { get; set; }
    }
}