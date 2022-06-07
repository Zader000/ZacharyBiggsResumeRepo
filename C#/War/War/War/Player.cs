using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    /// <summary>
    /// A Class for defining a player in the war game.
    /// Each player has a name and a hand that they player their cards
    /// from.
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        /// <summary>
        /// Returns the name of the player as a string.
        /// </summary>
        /// <returns>Returns the name of the Player</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
