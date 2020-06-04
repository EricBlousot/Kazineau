using System;
using System.Collections.Generic;
using System.Text;

namespace Kazineau
{
    class CL_cards
    {
        public List<Card> Cards;
        public CL_cards()
        {
            this.Cards = new List<Card>();
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.Cards.Add(new Card(i, (CardSuit_Enum)j));
                }
            }
        }
        public CL_cards(List<Card> cards)
        {
            this.Cards = cards;
        }

        public List<Card> Draw(int number)
        {
            List<Card> Result = new List<Card>();
            for (int i = 0; i < number; i++)
            {
                Random random = new Random();
                int index = random.Next(0, Cards.Count);
                Result.Add(Cards[index]);
                this.Cards.RemoveAt(index);
            }
            return Result;
        }

        public void Insert(Card card)
        {
            this.Cards.Add(card);
        }

        public void Shuffle()
        {
            Random rdm = new Random();
            int position = 0;
            List<Card> NewBatch = new List<Card>();
            while (this.Cards.Count > 0)
            {
                position = rdm.Next() % this.Cards.Count;
                NewBatch.Add(this.Cards[position]);
                this.Cards.RemoveAt(position);
            }
            this.Cards = NewBatch;
        }

        public void Display()
        {
            for(int i = 0; i < this.Cards.Count;i++)
            {
                this.Cards[i].Display();
            }
        }

    }
}
