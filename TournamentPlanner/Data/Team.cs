namespace TournamentPlanner.Data
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamPlayer> TeamPlayers { get; set; }
    }
}
