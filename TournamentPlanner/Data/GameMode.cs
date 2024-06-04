namespace TournamentPlanner.Data
{
    public class GameMode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlayerPerTeamCount { get; set; }
        public int TeamCount { get; set; }
        public Game Game { get; set; }
        public List<MapGameMode> MapGameModes { get; set; }
    }
}