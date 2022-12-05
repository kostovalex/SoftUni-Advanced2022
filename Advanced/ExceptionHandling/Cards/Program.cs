using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card
    {
        private string face;
        private string suit;
        private HashSet<string> possibleFaces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private HashSet<string> possibleSuits = new HashSet<string> { "S", "H", "D", "C" };
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            set
            {
                if (!possibleFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            set
            {
                if (!possibleSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit = "\u2665";
                        break;
                    case "D":
                        suit = "\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] deck = Console.ReadLine().Split(", ");

            for (int i = 0; i < deck.Length; i++)
            {
                string[] cardInfo = deck[i].Split(" ");
                try
                {
                    Card card = new Card(cardInfo[0], cardInfo[1]);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
