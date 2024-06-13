using System.ComponentModel.DataAnnotations;

namespace TournamentPlanner.Data
{
    public class TeamMatchScore
    {
        [Key]
        public int Id { get; set; }
        public Team? Team { get; set; }
        public Match Match { get; set; }
        public int Score { get; set; }
        public int MatchFlowId { get; set; }
    }
}