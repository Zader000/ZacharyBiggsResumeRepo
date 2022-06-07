using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    /// <summary>
    /// Custom UserControl that has the main information for the game.
    /// It shows the cards that were played and the names and scores of 
    /// the two players.
    /// </summary>
    public partial class GamePanel : UserControl
    {
        public Player Player1 { get; set; }
        public Player ComputerPlayer { get; set; }

        private IList<Card> pot = new List<Card>(); 

        public GamePanel()
        {
            InitializeComponent();
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {
            

        }

        private void lblPlayer1Card_Click(object sender, EventArgs e)
        {

        }
    }
}
