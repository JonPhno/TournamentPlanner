
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TournamentPlanner.Components.Pages;
using TournamentPlanner.Data.Interfaces;

namespace TournamentPlanner.Data
{
    public class Tournament : IOutputTeamLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Game Game { get; set; }

        public List<Block> Blocks { get; set; }

        [NotMapped]
        public List<Team> Teams { get; set; } = new List<Team>();

        public List<List<Team>> GetOutputTeams()
        {
            List<List<Team>> Lists = [Teams];
            return Lists;
        }
    }
}
