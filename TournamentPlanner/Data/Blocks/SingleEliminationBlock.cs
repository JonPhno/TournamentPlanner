using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Linq;
using TournamentPlanner.Components.Pages;
using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data.Blocks
{
    public class SingleEliminationBlock : Block, IBlock, IOutputTeamLists
    {
        public SingleEliminationBlock(Block block)
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

        public List<Match> GenerateMatches(ApplicationDbContext context, List<Team> teams)
        {
            List<Match> matches = new List<Match>();
            int BiggestPowerOf2 = 2;
            for (int i = BiggestPowerOf2; i <= teams.Count; i = i * 2)
            {
                BiggestPowerOf2 = i;
            }


            int numberOfTeamToTrim = teams.Count - BiggestPowerOf2;
            List<Match> trimMatches = new List<Match>();


            if (numberOfTeamToTrim > 0) //more teams that need to be reduced
            {
                List<Team> lastTeams = ReorderTeams(teams.TakeLast(numberOfTeamToTrim * 2).ToList());

                for (int i = 0; i < lastTeams.Count; i += 2)
                {
                    int j = i + 1;
                    Match match = CreateMatchWithoutPredecessor(lastTeams[i], lastTeams[j]);
                    trimMatches.Add(match);
                }
            }
            /*if (teams.Count % 2 == 0)
            {
                teams = ReorderTeams(teams);
            }
            else
            {
                teams = ReorderTeams(teams.Take(teams.Count-1).ToList());
            }*/

            teams = ReorderTeams(teams.Take(BiggestPowerOf2).ToList());

            for (int i = 0; i < teams.Count; i += 2)
            {
                int j = i + 1;
                if (trimMatches.Count != 0
                   && (trimMatches.Any(m => m.TeamMatchScores.FirstOrDefault(x => x.Team.Id == teams[i].Id) != null)
                   || trimMatches.Any(m => m.TeamMatchScores.FirstOrDefault(x => x.Team.Id == teams[j].Id) != null))
                    )
                {
                    Match pre = trimMatches.FirstOrDefault(m => m.TeamMatchScores.FirstOrDefault(x => x.Team.Id == teams[i].Id) != null);
                    Team team = teams[j];

                    if (pre == null)
                    {
                        pre = trimMatches.FirstOrDefault(m => m.TeamMatchScores.FirstOrDefault(x => x.Team.Id == teams[j].Id) != null);
                        team = teams[i];
                    }

                    Match match = new Match();
                    match.BlockId = Id;

                    MatchFlow flow = new MatchFlow() { Match = match, MatchId = match.Id, Parent = pre, ParentId = pre.Id, Winner = true };

                    context.Add(flow);
                    context.SaveChanges();

                    TeamMatchScore tms = new TeamMatchScore() { Match = match, Team = team };
                    TeamMatchScore tms2 = new TeamMatchScore() { Match = match, MatchFlowId = flow.Id };

                    pre.MatchChildren = new List<MatchFlow>();
                    pre.MatchChildren.Add(flow);

                    match.TeamMatchScores = new List<TeamMatchScore> { tms, tms2 };

                    match.MatchParents = new List<MatchFlow>();
                    match.MatchParents.Add(flow);

                    matches.Add(match);
                }
                else
                {
                    Match match = CreateMatchWithoutPredecessor(teams[i], teams[j]);
                    matches.Add(match);
                }
            }

            int numberOfRounds = (int)Math.Log2(BiggestPowerOf2);

            List<List<Match>> rounds = new List<List<Match>>();
            rounds.Add(matches);
            for (int i = 0; i < numberOfRounds - 1; i++)
            {
                List<Match> rMatches = new List<Match>();
                for (int j = 0; j < rounds[i].Count; j = j + 2)
                {
                    Match match = new Match();
                    match.BlockId = Id;
                    Match m1, m2;

                    //parentMatches from previous round
                    m1 = rounds[i][j];
                    m2 = rounds[i][j + 1];

                    MatchFlow flow = new MatchFlow() { Match = match, MatchId = match.Id, Parent = m1, ParentId = m1.Id, Winner = true };
                    MatchFlow flow2 = new MatchFlow() { Match = match, MatchId = match.Id, Parent = m2, ParentId = m2.Id, Winner = true };

                    context.Add(flow);
                    context.Add(flow2);
                    context.SaveChanges();

                    TeamMatchScore tms = new TeamMatchScore() { Match = match, MatchFlowId = flow.Id };
                    TeamMatchScore tms2 = new TeamMatchScore() { Match = match, MatchFlowId = flow2.Id };

                    m1.MatchChildren = new List<MatchFlow>();
                    m1.MatchChildren.Add(flow);
                    m2.MatchChildren = new List<MatchFlow>();
                    m2.MatchChildren.Add(flow2);


                    match.TeamMatchScores = new List<TeamMatchScore> { tms, tms2 };

                    match.MatchParents = new List<MatchFlow>();
                    match.MatchParents.Add(flow);
                    match.MatchParents.Add(flow2);

                    rMatches.Add(match);
                }
                rounds.Add(rMatches);
            }


            Matches = new List<Match>();

            Matches.AddRange(trimMatches);

            foreach (var round in rounds)
            {
                Matches.AddRange(round);
            }

            context.AddRange(Matches);
            context.SaveChanges();

            foreach (var match in Matches)
            {
                if (match.MatchChildren != null)
                {
                    foreach (var mc in match.MatchChildren)
                    {
                        mc.ParentId = mc.Parent.Id;
                        mc.MatchId = mc.Match.Id;
                    }
                    context.UpdateRange(match.MatchChildren);
                }
            }
            context.SaveChanges();
            return Matches;
        }

        private List<Team> ReorderTeams(List<Team> teams)
        {
            List<Team> result = new List<Team>();
            List<Team> result2 = new List<Team>();

            bool alternate = true;

            while (teams.Count > 0)
            {

                Team teamA = teams.First();
                Team teamB = teams.Last();

                if (alternate)
                {
                    result.Add(teamA);
                    result.Add(teamB);
                }
                else
                {
                    result2.Add(teamA);
                    result2.Add(teamB);
                }

                teams.Remove(teamA);
                teams.Remove(teamB);
                alternate = !alternate;
            }

            for (int i = result2.Count - 1; i >= 0; i--)
            {
                result.Add(result2[i]);
            }


            return result;
        }

        private Match CreateMatchWithoutPredecessor(Team teamA, Team teamB)
        {
            Match match = new Match();
            match.TeamMatchScores = new List<TeamMatchScore>();
            TeamMatchScore tms = new TeamMatchScore() { Team = teamA, Match = match };
            match.TeamMatchScores.Add(tms);
            tms = new TeamMatchScore() { Team = teamB, Match = match };
            match.TeamMatchScores.Add(tms);
            match.BlockId = Id;
            return match;
        }

        private Match CreateMatchWithPredecessor(Team teamA, Team teamB, Match m1, Match m2)
        {
            Match match = new Match();
            match.TeamMatchScores = new List<TeamMatchScore>();
            TeamMatchScore tms = new TeamMatchScore() { Team = teamA, Match = match };
            match.TeamMatchScores.Add(tms);
            tms = new TeamMatchScore() { Team = teamB, Match = match };
            match.TeamMatchScores.Add(tms);
            match.BlockId = Id;
            return match;
        }
    }
}
