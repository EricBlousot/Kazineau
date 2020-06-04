using System;
using System.Collections.Generic;
using System.Text;

namespace Kazineau
{
    class CL_player
    {
        public PlayerType_Enum Type;
        public int Points;
        public string Name;
        public CL_cards Cards;

        public bool HasSameSuits()
        {
            CardSuit_Enum suit = this.Cards.Cards[0].Suit;
            for (int i = 1; i < this.Cards.Cards.Count; i++)
            {
                if(this.Cards.Cards[i].Suit != suit)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsBankAndHasSimilarCards()
        {
            if(this.Type != PlayerType_Enum.Bank)
            {
                return false;
            }
            else
            {
                int refValue = this.Cards.Cards[0].Value;
                for (int i = 1; i < this.Cards.Cards.Count; i++)
                {
                    if(this.Cards.Cards[i].Value!= refValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public CL_player(PlayerType_Enum type, string name)
        {
            this.Points = 0;
            this.Name = name;
            this.Cards = new CL_cards(new List<Card>());
            this.Type = type;
        }
        public CL_player(PlayerType_Enum type, string name, CL_cards cards)
        {
            this.Points = 0;
            this.Name = name;
            this.Cards = cards;
            this.Type = type;
        }

        public List<Card> TakeCards()
        {
            List<Card> Result = this.Cards.Cards;
            this.Cards = new CL_cards(new List<Card>());
            return Result;
        }

        public void GiveCards(List<Card> cards)
        {
            if(cards.Count != 2 && this.Type == PlayerType_Enum.Person)
            {
                throw new System.ArgumentException("The player is a person : it is supposed to have 2 cards");
            }
            else if(cards.Count != 3 && this.Type == PlayerType_Enum.Bank)
            {
                throw new System.ArgumentException("The player is a bank : it is supposed to have 3 cards");
            }
            else
            {
                this.Cards = new CL_cards(cards);
            }
        }

    }
}
