namespace TournamentPlanner.Data
{
    public class MapGameMode
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public int GameModeId { get; set; }
        public GameMode GameMode { get; set; }
        public Map Map { get; set; }
    }
}
