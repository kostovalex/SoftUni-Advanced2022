﻿using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomlist = new RandomList() { "1", "2", "3", "4", "5", "6" };

            Console.WriteLine(randomlist.RandomString());
            Console.WriteLine(randomlist.RandomString());
            Console.WriteLine(randomlist.RandomString());
            Console.WriteLine(randomlist.RandomString());
        }
    }
}
