using System;
using System.Collections.Generic;
using System.Text;

namespace Kazineau
{
    class CL_cards
    {
        public CL_cards()
        {
            this.batch = new List<Card>();
            for(int i = 1; i <= 1; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    this.batch.Add(new Card(i,(CardSuit_Enum)j));
                }
            }
        }

        public List<Card> Draw(int number)
        {
            List<Card> Result = new List<Card>();
            for(int i = 0; i < number; i++)
            {
                Result.Add(batch[0]);
                this.batch.RemoveAt(0);
            }
            return Result;
        }

        public void Insert(Card card)
        {
            this.batch.Add(card);
        }

        public void Shuffle()
        {
            Random rdm = new Random();
            int position = 0;
            List<Card> NewBatch = new List<Card>();
            while (this.batch.Count > 0)
            {
                position = rdm.Next() % this.batch.Count;
                NewBatch.Add(this.batch[position]);
                this.batch.RemoveAt(position);
            }
            this.batch = NewBatch;
        }

        public void Display()
        {
            for(int i = 0; i < this.batch.Count;i++)
            {
                this.batch[i].Display();
            }
        }

        private List<Card> batch;
    }
}
