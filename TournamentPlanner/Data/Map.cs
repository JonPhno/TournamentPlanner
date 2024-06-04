namespace TournamentPlanner.Data
{
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
        public GameModeListType GameModeListType { get; set; }
        public List<MapGameMode> MapGameModes { get; set; }

    }
}