using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentPlanner.Data
{
    public class OutputTeamEntity
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int BlockId { get; set; }
        public int ListManipulationId { get; set; }
    }
}