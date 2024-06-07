using System.ComponentModel.DataAnnotations.Schema;
using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data
{
    public class Block: IOutputTeamLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<Match> Matches { get; set; }
        public BlockType BlockType { get; set; }
        public Tournament Tournament { get; set; }
        public int InputTeamsEntityId { get; set; }
        public int OutputTeamsEntityId { get; set; }

        public List<List<Team>> GetOutputTeams()
        {
            throw new NotImplementedException();
        }
    }
}
