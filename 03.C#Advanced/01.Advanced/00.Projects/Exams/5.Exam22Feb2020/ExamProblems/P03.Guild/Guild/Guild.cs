using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> data;
        private Guild()
        {
            this.data = new List<Player>();
        }
        public Guild(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.data
                .FirstOrDefault(pl => pl.Name == name);
            if (playerToRemove == null)
            {
                return false;
            }

            this.data.Remove(playerToRemove);
            return true;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = this.data
                .FirstOrDefault(p => p.Name == name);

            if (playerToPromote != null)
            {
                if (playerToPromote.Rank == "Trial")
                {
                    playerToPromote.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToDemote = this.data
                .FirstOrDefault(p => p.Name == name);

            if (playerToDemote != null)
            {
                if (playerToDemote.Rank == "Member")
                {
                    playerToDemote.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var playerToRemoved = this.data
                .Where(p => p.Class == @class)
                .ToArray();

            this.data.RemoveAll(p => p.Class == @class);

            return playerToRemoved;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.data)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
