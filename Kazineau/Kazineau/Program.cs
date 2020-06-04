using System;
using System.Collections.Generic;

namespace Kazineau
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbBankWin = 0;
            int nbGames = 10000;
            for (int i = 0; i < nbGames; i++)
            {
                nbBankWin+=Program.playGame()?1:0;
            }

            Console.WriteLine("Number of game: " + nbGames);
            Console.WriteLine("Number of game the bank winned: " + nbBankWin);
            Console.WriteLine("% Of bank win: " + (nbBankWin * 100) / nbGames + "%");
        }

        //True if the bank won the game
        static bool playGame()
        {
            CL_cards cards = new CL_cards();
            CL_croupier croupier = new CL_croupier(cards);
            CL_player bank = new CL_player(PlayerType_Enum.Bank, "Bank");
            CL_player player1 = new CL_player(PlayerType_Enum.Person, "Eric");
            CL_player player2 = new CL_player(PlayerType_Enum.Person, "Tybo");
            croupier.Cards.Shuffle();
            croupier.GiveCards(bank);
            croupier.GiveCards(player1);
            croupier.GiveCards(player2);

            List<CL_player> list = new List<CL_player>();
            list.Add(bank);
            list.Add(player1);
            list.Add(player2);

            //Program.gamesCount++;
            return croupier.BankWon(list);
            //CL_player winner = list[winnerIndex];
            //if (winner.Type == PlayerType_Enum.Bank)
            //{
            //    Program.bankWin++;
            //}
        }
    }
}
