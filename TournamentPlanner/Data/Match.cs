using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TournamentPlanner.Components.Pages;

namespace TournamentPlanner.Data
{
    public class Match
    {
        public int Id { get; set; }
        public bool Played { get; set; }
        public List<TeamMatchScore> TeamMatchScores { get; set; }
        public MapGameMode? MapGameMode { get; set; }
        public int BlockId { get; set; }


        [NotMapped]
        public List<MatchFlow> MatchParents { get; set; }
        [NotMapped]
        public List<MatchFlow> MatchChildren { get; set; }

        [NotMapped]
        public List<Team> Teams
        {
            get { return TeamMatchScores?.Select(tms => tms.Team)?.ToList(); }
        }


        //Winners and loosers should be driver by the game mode settings
        //ex: smash knockout, winners = everyone but the last, loosers = the last only
        //ex2: smash split, take first 4 sa winners and last 4 has loosers

        [NotMapped]
        public List<Team> Winners
        {
            get { return TeamMatchScores.OrderByDescending(x=>x.Score).Take(TeamMatchScores.Count-1).Select(x=>x.Team).ToList(); }
        }

        [NotMapped]
        public List<Team> Loosers
        {
            get { return TeamMatchScores.OrderBy(x => x.Score).Take(1).Select(x => x.Team).ToList(); }
        }

    }

    
}