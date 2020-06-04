using System;
using System.Collections.Generic;
using System.Threading;

namespace Kazineau
{
    class Program
    {
        static void Main(string[] args)
        {
            int RoundsNumber = 10000; 
            Thread t1 = new Thread(() =>
            {
                playGame(RoundsNumber);
            });
            Thread t2 = new Thread(() =>
            {
                playGame(RoundsNumber);
            });
            Thread t3 = new Thread(() =>
            {
                playGame(RoundsNumber);
            });
            t1.Start();
            t2.Start();
            t3.Start();
            //playGame(RoundsNumber);
        }


        static void playGame(int RoundsNumber)
        {
            CL_player bank = new CL_player(PlayerType_Enum.Bank, "Bank");
            CL_player player1 = new CL_player(PlayerType_Enum.Person, "Eric");
            CL_player player2 = new CL_player(PlayerType_Enum.Person, "Tybo");

            for (int i = 0; i < RoundsNumber; i++)
            {
                Program.playRound(bank, player1, player2);
            }

            Console.WriteLine("Number of game: " + RoundsNumber);
            Console.WriteLine("Number of game the bank won: " + bank.Points);
            Console.WriteLine("Number of game the player 1 won: " + player1.Points);
            Console.WriteLine("Number of game the player 2 won: " + player2.Points);
            Console.WriteLine("% Of bank win: " + (bank.Points * 100) / RoundsNumber + "%");
        }
        //True if the bank won the game
        static void playRound(CL_player bank, CL_player player1, CL_player player2)
        {
            CL_cards cards = new CL_cards();
            CL_croupier croupier = new CL_croupier(cards);
            croupier.Cards.Shuffle();
            croupier.GiveCards(bank);
            croupier.GiveCards(player1);
            croupier.GiveCards(player2);

            List<CL_player> list = new List<CL_player>();
            list.Add(bank);
            list.Add(player1);
            list.Add(player2);

            //Program.gamesCount++;
            //return croupier.BankWon(list);

            croupier.WhoWins(list);
        }
    }
}
