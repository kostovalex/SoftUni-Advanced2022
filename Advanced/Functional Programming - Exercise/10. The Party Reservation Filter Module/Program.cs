using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string[] command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Print")
            {

                string filter = command[1];
                string value = command[2];

                
                if (command[0] == "Add filter")
                {
                    filters.Add(filter+value, GetPredicate(filter,value));
                }
                else //remove filter
                {
                    filters.Remove(filter+value);
                }

                command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            if (filters.Count>0)
            {
                foreach (var filter in filters)
                {
                    guests.RemoveAll(filter.Value);
                }
            }

            Console.WriteLine(string.Join(" ", guests));
            
            
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return null;                    
            }
        }
    }
}
