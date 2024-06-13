namespace TournamentPlanner.Data
{
    public class TournamentTeam
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}