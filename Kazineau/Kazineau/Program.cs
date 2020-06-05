using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kazineau
{
    class Program
    {
        static void Main(string[] args)
        {
            playGame(1000000);
        }


        static void playGame(int RoundsNumber)
        {
            Task<int>[] taskArray = new Task<int>[10];

            for (int i = 0; i< taskArray.Length; i++)
            {
                taskArray[i] = Task<int>.Factory.StartNew(() => {
                    CL_player bank = new CL_player(PlayerType_Enum.Bank, "Bank");
                    CL_player player1 = new CL_player(PlayerType_Enum.Person, "Eric");
                    CL_player player2 = new CL_player(PlayerType_Enum.Person, "Tybo");

                    for (int j = 0; j < RoundsNumber; j++)
                    {
                        Program.playRound(bank, player1, player2);
                    }
                    return bank.Points;
                });
            }
            Task.WaitAll(taskArray);
            int sum = 0;
            for (int i = 0; i < taskArray.Length; i++)
            {

                sum += taskArray[i].Result;
            }
            Console.WriteLine("Resultat " + (sum / taskArray.Length)/(RoundsNumber/100));
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

            croupier.WhoWins(list);
        }
    }
}
