using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    /// <summary>
    /// A class that holds the image path for the card and that cards associated point value in the game of War.
    /// </summary>
    public class Card
    {
        public string ImagePath { get; set; }

        public int PointValue { get; }

        public Card(string imagePath, int pointValue)
        {
            ImagePath = imagePath;
            PointValue = pointValue;
        }


    }
}
