using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentPlanner.Data
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        //[ForeignKey("Id")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
