using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

            teams = teams.Take(BiggestPowerOf2).ToList();

            for (int i = 0; i < teams.Count / 2; i++)
            {
                int j = teams.Count - 1 - i;
                Match match = new Match();
                match.TeamMatchScores = new List<TeamMatchScore>();
                TeamMatchScore tms = new TeamMatchScore() { Team = teams[i], Match = match };
                match.TeamMatchScores.Add(tms);
                tms = new TeamMatchScore() { Team = teams[j], Match = match };
                match.TeamMatchScores.Add(tms);
                match.BlockId = Id;
                matches.Add(match);
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
    }
}
