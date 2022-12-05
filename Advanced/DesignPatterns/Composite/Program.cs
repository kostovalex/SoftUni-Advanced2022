using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GiftBase pechka = new SingleGift("Pechka", 299.99m);

            pechka.CalculateTotalPrice();
            Console.WriteLine();

            var box = new CompositeGift("Box", 0);
            var playingCards = new SingleGift("Cards", 2.50m);
            var smallBall = new SingleGift("Ball", 11.50m);
            box.Add(playingCards);
            box.Add(smallBall);

            box.CalculateTotalPrice();

        }
    }
}
