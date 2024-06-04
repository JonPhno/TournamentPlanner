namespace TournamentPlanner.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameMode> GameModes { get; set; }
        public List<Map> Maps { get; set; }

    }
}
