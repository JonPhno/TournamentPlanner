using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TournamentPlanner.Data.Blocks;
using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data
{
    public class Block : IOutputTeamLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<Match> Matches { get; set; }
        public BlockType BlockType { get; set; }
        public Tournament Tournament { get; set; }
        public int InputTeamsEntityId { get; set; }
        public int OutputTeamsEntityId { get; set; }

        //Single Elimination behaviour
        public List<List<Team>> GetOutputTeams()
        {
            List<List<Team>> teams = new List<List<Team>>();
            if (Matches != null && Matches.Count > 0 && Matches.Count(m => !m.Played) == 0)
            {
                //teams.Add(GetTeamSummaries().OrderBy(x=>x.Victories).ThenBy(x=>x.))
                Match lastMatch = Matches.FirstOrDefault(x => x.MatchChildren == null || x.MatchChildren.Count == 0);
                teams.Add(new List<Team>() { lastMatch.Winners[0] });
            }
            return teams;
        }

        public List<TeamMatchScoreSummary> GetTeamSummaries()
        {
            List<TeamMatchScoreSummary> tmss = new List<TeamMatchScoreSummary>();

            foreach (var match in Matches.Where(m => m.Played))
            {
                foreach (var tms in match.TeamMatchScores)
                {
                    if (!tmss.Any(x => x.TeamId == tms.Team.Id))
                    {
                        tmss.Add(new TeamMatchScoreSummary() { TeamId = tms.Team.Id, Scores = tms.Score, Victories = 0 });
                    }
                    else
                    {
                        tmss.FirstOrDefault(x => x.TeamId == tms.Team.Id).Scores += tms.Score;
                    }
                }

                int victoriousTeamId = match.TeamMatchScores.OrderByDescending(x => x.Score).FirstOrDefault().Team.Id;
                tmss.FirstOrDefault(x => x.TeamId == victoriousTeamId).Victories += 1;
            }

            return tmss;
        }

        [NotMapped]
        public List<Team> Teams {
            get {
                List<Team> teams = new List<Team>();

                if (Matches == null)
                    return teams;
                foreach (var match in Matches)
                {
                    teams.AddRange(match.Teams);
                }
                teams = teams.Distinct().ToList();
                return teams; }
        }


        public IOutputTeamLists GetBlockTyped()
        {
            switch (BlockType)
            {
                case BlockType.RoundRobin:
                    return new RoundRobinBlock(this);
                case BlockType.SingleElimination:
                    return new SingleEliminationBlock(this);
                case BlockType.DoubleElimination:
                    break;
                case BlockType.Split:
                    break;
                case BlockType.Knockout:
                    break;
                default:
                    break;
            }
            return this;
        }
    }

    public class TeamMatchScoreSummary
    {
        public int TeamId { get; set; }
        public int Victories { get; set; }
        public int Scores { get; set; }
    }
}
