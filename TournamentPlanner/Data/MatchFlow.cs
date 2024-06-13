using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentPlanner.Data
{
    public class MatchFlow
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        [NotMapped]
        public Match Parent { get; set; }
        public int MatchId { get; set; }
        [NotMapped]
        public Match Match { get; set; }
        public bool Winner { get; set; }
    }
}
