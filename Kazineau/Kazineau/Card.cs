using System;
using System.Collections.Generic;
using System.Text;

namespace Kazineau
{
    class Card
    {
        public Card(int value, CardSuit_Enum suit)
        {
            if(value < 1 || value > 13)
            {
                throw new System.ArgumentException("The value of the card has to be between 1 and 13");
                //value = (value % 13) + 1
            }
            this.Value = value;
            this.Suit = suit;
        }

        public int Value { get; }
        public CardSuit_Enum Suit { get; }

        public void Display()
        {
            Console.WriteLine(this.Value + " of " + this.Suit);
        }
    }
}
