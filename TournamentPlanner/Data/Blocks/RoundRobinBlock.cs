using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data.Blocks
{
    public class RoundRobinBlock:Block, IBlock,IOutputTeamLists
    {

        public RoundRobinBlock(Block block)
        {
            this.Tournament = block.Tournament;
            this.Id = block.Id;
            this.Name = block.Name;
            this.Order = block.Order;
            this.OutputTeamsEntityId = block.OutputTeamsEntityId;
            this.InputTeamsEntityId = block.InputTeamsEntityId;
            this.BlockType = block.BlockType;
            this.Matches = block.Matches;
        }

        public new List<List<Team>> GetOutputTeams()
        {
            List<List<Team>> teams = new List<List<Team>>();
            if (Matches != null && Matches.Count > 0 && Matches.Count(m => !m.Played) == 0)
            {
                List<Team> ts = GetTeamSummaries().OrderBy(x => x.Victories).ThenBy(x => x.Scores).Select(x => Teams.FirstOrDefault(t => t.Id == x.TeamId)).ToList();
                teams.Add(ts);
            }
            else
            {
                teams.Add(new List<Team>());
            }
            return teams;
        }

        public List<Match> GenerateMatches(ApplicationDbContext context, List<Team> teams)
        {
            List<Match> matches = new List<Match>();

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i; j < teams.Count; j++)
                {
                    if(i == j) continue;

                    Match match = new Match();
                    match.BlockId = Id;

                    match.TeamMatchScores = new List<TeamMatchScore>();

                    TeamMatchScore tms = new TeamMatchScore() { Team = teams[i], Match = match };
                    match.TeamMatchScores.Add(tms);
                    tms = new TeamMatchScore() { Team = teams[j] , Match = match};
                    match.TeamMatchScores.Add(tms);

                    matches.Add(match);
                }
            }
            context.AddRange(matches);
            context.SaveChanges();
            return matches;
        }
    }
}
