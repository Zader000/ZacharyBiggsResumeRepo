using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    /// <summary>
    /// Holds the cards in a queue structure to act like a small pile of cards that the player draws from
    /// and adds cards to the bottom.
    /// </summary>
    public class Hand
    {
        public Queue<Card> Cards { get; set; }
        public int Size { get; private set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }

        /// <summary>
        /// Adds the given card to the Hand
        /// </summary>
        /// <param name="c">A Card</param>
        public void AddToHand(Card c)
        {
            Cards.Enqueue(c);
        }

        /// <summary>
        /// Adds the given cards to the Hand
        /// </summary>
        /// <param name="cards">Any collection of cards that is enumerable</param>
        public void AddToHand(IEnumerable<Card> cards)
        {
            foreach (Card c in cards)
            {
                AddToHand(c);
            }
        }

        /// <summary>
        /// Removes the top card from the hand and returns it.
        /// </summary>
        /// <returns>Returns the top card from the hand</returns>
        public Card DrawCard()
        {
            return Cards.Dequeue();
        }
    }
}
