namespace War
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Will start a new game when on the main menu and will prompt for a name for player 1 and player 2.
        /// Also functions as the go button, where cards are drawn and compared.
        /// Action listeners are the main for the game logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            if (btnLeft.Text == "New Player")
            {
                btnLeft.Text = "GO";
                btnRight.Text = "Save and Exit";
                InitGame(true);   
            }
            else
            {  
                player1Card = player1.Hand.DrawCard();
                player2Card = player2.Hand.DrawCard();
                pot.Add(player1Card);
                pot.Add(player2Card);
                if (player1Card.PointValue > player2Card.PointValue)
                {
                    player1.Hand.AddToHand(pot);
                }
                else if (player2Card.PointValue > player1Card.PointValue)
                {
                    player2.Hand.AddToHand(pot);
                }
                else if (player1Card.PointValue == player2Card.PointValue)
                {
                    player1.Hand.AddToHand(player1Card);
                    player2.Hand.AddToHand(player2Card);
                }
                pot.Clear();
                UpdatePlayerInfo();
            }
        }

        /// <summary>
        /// Will contiune the game when on the main menu or save and exit the game
        /// if in the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btnRight.Text == "Continuing Player")
            {
                btnRight.Text = "Save and Exit";
                btnLeft.Text = "GO";
                InitGame(false);
            }
            else
            {
                SaveManager.SaveGame(players);
                this.Close();
            }
        }

        /// <summary>
        /// Initializes the game based on if the user selected new game or continue.
        /// Initializes player 1 and 2 along with the deck.
        /// </summary>
        /// <param name="newGame"></param>
        private void InitGame(bool newGame)
        {
            this.tableLayoutPanel1.Controls.RemoveByKey("mainPanel1");
            this.tableLayoutPanel1.Controls.Add(this.gamePanel1, 0, 0);
            players = newGame ? SaveManager.StartNewGame() : SaveManager.LoadGame();
            player1 = players[0];
            player2 = players[1];
            Deck deck = new();
            deck.DealCards(player1, player2);
        }

        /// <summary>
        /// Updates the label with the players' points and shows the drawn cards.
        /// </summary>
        private void UpdatePlayerInfo()
        {
            gamePanel1.GetLblPlayer1Info().Text = $"{player1.Name} Cards: {player1.Hand.Cards.Count}";
            gamePanel1.GetLblPlayer2Info().Text = $"{player2.Name} Cards: {player2.Hand.Cards.Count}";
            gamePanel1.GetLblPlayer1Card().Image = Image.FromFile(player1Card.ImagePath);
            gamePanel1.GetLblPlayer2Card().Image = Image.FromFile(player2Card.ImagePath);
            this.Refresh();
        }
    }
}