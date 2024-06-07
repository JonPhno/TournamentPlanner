using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data
{
    public class ListManipulation: IOutputTeamLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int InputTeamsEntityAId { get; set; }
        public int InputTeamsEntityBId { get; set; }
        public int OutputTeamEnityId { get; set; }
        public Tournament Tournament { get; set; }
        public ListManipulationType ListManipulationType { get; set; }

        public List<List<Team>> GetOutputTeams()
        {
            throw new NotImplementedException();
        }
    }
}
