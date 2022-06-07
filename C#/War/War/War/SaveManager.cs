using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace War
{
    /// <summary>
    /// Used For saving and loading the players' names inbetween games.
    /// </summary>
    public static class SaveManager
    {
        private const string savesFilePath = "../../../saves/player.csv";

        /// <summary>
        /// Saves the players to the file so they can be read later.
        /// </summary>
        /// <param name="players">List of players to be saved</param>
        public static void SaveGame(IList<Player> players)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(savesFilePath))
                {
                    sw.WriteLine(players[0].Name);
                    sw.WriteLine(players[1].Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Reads the save file and returns a list of players so that the game can re-initialize them back into the game.
        /// </summary>
        /// <returns>Returns a list of two players.</returns>
        public static List<Player> LoadGame()
        {
            string? name1;
            string? name2;
            List<Player> players = new List<Player>();
            try
            {
                using (StreamReader sr = new StreamReader(savesFilePath))
                {
                    name1 = sr.ReadLine();
                    name2 = sr.ReadLine();
                    if (name1 == null || name2 == null)
                        return StartNewGame();
                    players.Add(new Player(name1));
                    players.Add(new Player(name2));
                    return players;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Load. Starting new game.");
                Console.WriteLine(ex.Message);
                return StartNewGame();
            }
            

        }

        /// <summary>
        /// Gets input from the User to make names for player 1 and 2 and saves them to the saves file.
        /// </summary>
        /// <returns></returns>
        public static List<Player> StartNewGame()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player(Interaction.InputBox("Player 1 name: ", "War")));
            players.Add(new Player(Interaction.InputBox("Player 2 name: ", "War")));
            SaveGame(players);
            return players;
        }
    }
}
