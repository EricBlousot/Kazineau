using System;
using System.Collections.Generic;

namespace Kazineau
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2000; i++)
            {
                Program.playGame();
            }

            Console.WriteLine("Number of game: " + Program.gamesCount);
            Console.WriteLine("Number of game the bank winned: " + Program.bankWin);
            Console.WriteLine("% Of bank win: " + (Program.bankWin * 100) / Program.gamesCount + "%");
        }

        static int gamesCount = 0;
        static int bankWin = 0;

        static void playGame()
        {
            CL_cards cards = new CL_cards();
            CL_croupier croupier = new CL_croupier(cards);
            CL_player bank = new CL_player(PlayerType_Enum.Bank, "Bank");
            CL_player player1 = new CL_player(PlayerType_Enum.Person, "Eric");
            CL_player player2 = new CL_player(PlayerType_Enum.Person, "Tybo");
            croupier.GiveCards(bank);
            croupier.GiveCards(player1);
            croupier.GiveCards(player2);

            List<CL_player> list = new List<CL_player>();
            list.Add(bank);
            list.Add(player1);
            list.Add(player2);

            int winnerIndex = croupier.WhoWins(list);
            CL_player winner = list[winnerIndex];
            if (winner.Type == PlayerType_Enum.Bank)
            {
                Program.bankWin++;
            }
            Program.gamesCount++;
        }
    }
}
