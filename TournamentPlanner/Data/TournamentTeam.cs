namespace TournamentPlanner.Data
{
    public class TournamentTeam
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public Team Team { get; set; }
    }
}