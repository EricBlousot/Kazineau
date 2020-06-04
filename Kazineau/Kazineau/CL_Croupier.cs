using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kazineau
{
    class CL_croupier
    {
        public CL_croupier(CL_cards cards)
        {
            this.Cards = cards;
        }

        public CL_cards Cards;

        public void WhoWins(List<CL_player> players)
        {
            List<CL_player> banks = players.Select(x => x).Where(x => x.Type == PlayerType_Enum.Bank).ToList();
            if (banks.Count != 1)
            {
                throw new ArgumentException("The list has to contains exactly one Bank");
            }
            if(banks[0].IsBankAndHasSimilarCards())
            {
                banks[0].Points++;
            }

            List<int> scores = new List<int>();
            for(int i = 0; i < players.Count; i++)
            {
                scores.Add(GetScore(players[i]));
            }
            players[scores.IndexOf(scores.Max(x=>x))].Points++;
        }

        public bool BankWon(List<CL_player> players)
        {
            List<CL_player> banks = players.Select(x => x).Where(x=>x.Type == PlayerType_Enum.Bank).ToList();
            if (banks.Count != 1)
            {
                throw new ArgumentException("The list has to contains exactly one Bank");
            }

            if (banks[0].IsBankAndHasSimilarCards())
            {
                return true;
            }

            List<int> scores = new List<int>();
            for (int i = 0; i < players.Count; i++)
            {
                scores.Add(GetScore(players[i]));
            }
            return players[scores.IndexOf(scores.Max(x => x))].Type == PlayerType_Enum.Bank;
        }

        public int GetScore(CL_player player)
        {
            int score = 0;
            if (player.HasSameSuits())
            {
                if (player.Type == PlayerType_Enum.Person)
                {
                    score += 20;
                }
                else if (player.Type == PlayerType_Enum.Bank)
                {
                    score += 35;
                }
            }
            for (int i = 0; i < player.Cards.Cards.Count; i++)
            {
                score += player.Cards.Cards[i].Value;
            }
            return score;
        }
        public void GiveCards(CL_player player) {
            if(player.Type == PlayerType_Enum.Bank)
            {
                player.GiveCards(this.Cards.Draw(3));
            }
            else if(player.Type == PlayerType_Enum.Person)
            {
                player.GiveCards(this.Cards.Draw(2));
            }
        }
    }
}
