using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    /// <summary>
    /// Makes a standard deck of 52 cards. Adds all 52 cards to the deck assigning their point values and
    /// their associated image.
    /// </summary>
    public class Deck
    {
        public Stack<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new Stack<Card>();
            int i, j;

            for (i = 0, j = 0; i < 52; i++)
            {
                if (i % 4 == 0)
                    j++;
                Cards.Push(new Card($"../../../assets/{i + 1}.png", j));
            }
            ShuffleDeck();
        }

        /// <summary>
        /// Takes the deck and shuffles all the cards in it in a random order. 
        /// </summary>
        public void ShuffleDeck()
        {
            Random random = new Random();
            //LINQ Requirement
            IList<Card> shuffledDeck = Cards.OrderBy(card => random.Next()).ToList();
            Cards.Clear();
            foreach (Card c in shuffledDeck)
            {
                Cards.Push(c);
            }
        }

        /// <summary>
        /// Evenly distributes the cards in the deck to the players' hands.
        /// </summary>
        /// <param name="p1">Player to distribute cards to.</param>
        /// <param name="p2">Second player to distribute cards to.</param>
        public void DealCards(Player p1, Player p2)
        {
            while(Cards.Count > 0)
            {
                p1.Hand.AddToHand(Cards.Pop());
                p2.Hand.AddToHand(Cards.Pop());
            }
        }
    }
}
