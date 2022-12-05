using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace Basketball
{
    public class Team
    {
        private Dictionary<string, Player> players;
        public Team(string name, int openPositons, char group)
        {
            Name = name;
            OpenPositions = openPositons;
            Group = group;
            players = new Dictionary<string, Player>();
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count { get { return players.Count; } }
        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Position == null)
            {
                return "Invalid player's information.";
            } 
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating<80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                players.Add(player.Name, player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }
   
        public bool RemovePlayer(string name)
        {
            if (players.ContainsKey(name))
            {
                OpenPositions++;
                return players.Remove(name);
            }
            else
            {
                return false;
            }

        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            foreach (var item in players.Values)
            {
                if (item.Position == position)
                {
                    count++;
                }
            }
                       
            players = players.Where(p => p.Value.Position != position).ToDictionary(x => x.Key, x => x.Value);

            OpenPositions -= count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (players.ContainsKey(name))
            {
                players[name].Retired = true;
                return players[name];
            }
            else
            {
                return null;
            }
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list =   
    }
}
