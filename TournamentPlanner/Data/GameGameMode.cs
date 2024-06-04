namespace TournamentPlanner.Data
{
    public class GameGameMode
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int GameModeId { get; set; }
        public Game Game { get; set; }
        public GameMode GameMode { get; set; }
    }
}