using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return roster.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var currentPlayer = roster.FirstOrDefault(x => x.Name == name);

            if (currentPlayer == null)
            {
                return false;
            }
            else
            {
                roster.Remove(currentPlayer);
                return true;
            }
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                var currentPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                currentPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                var currentPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                currentPlayer.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string _class)
        {
            var tempList = new List<Player>();

            foreach (var player in roster)
            {
                if (player.Class == _class)
                {
                    tempList.Add(player);
                }
            }

            Player[] array = tempList.ToArray();
            roster = roster.Where(x => x.Class != _class).ToList();
            return array;
        }
        
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString().TrimEnd());
            }

            return sb.ToString();
        }
    }
}
