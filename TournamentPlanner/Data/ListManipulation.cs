using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public IOutputTeamLists InputTeamsEntityA { get; set; }
        [NotMapped]
        public IOutputTeamLists InputTeamsEntityB { get; set; }

        public List<List<Team>> GetOutputTeams()
        {
            switch (ListManipulationType) {
                case ListManipulationType.Take4:
                    List<Team> teams = new List<Team>();

                    foreach (var teamList in InputTeamsEntityA.GetOutputTeams())
                    {
                        teams.AddRange(teamList);
                    }
                    return new List<List<Team>>() { teams.Take(4).ToList() };
            }

            return new List<List<Team>>();
        }
    }
}
