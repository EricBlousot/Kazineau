using System;
using System.Collections.Generic;

namespace Kazineau
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("initialisation du paquet");
            CL_cards paquet = new CL_cards();
            paquet.Display();

            Console.WriteLine("tirer une carte");
            Card carte = paquet.Draw(1)[0];
            carte.Display();

            Console.WriteLine("melanger le paquet");
            paquet.Shuffle();
            paquet.Display();

            Console.WriteLine("remettre la carte");
            paquet.Insert(carte);
            paquet.Display();

            //List<string> s = new List<string>();
            //s.Add("un");
            //s.Add("deux");
            //s.Add("trois");
            //s.Add("quatre");
            //for(int i = 0; i < s.Count; i++)
            //{
            //    Console.WriteLine(s[i]);
            //}
            //s.RemoveAt(1);
            //for (int i = 0; i < s.Count; i++)
            //{
            //    Console.WriteLine(s[i]);
            //}
        }
    }
}
