using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsJournal = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);



                if (!studentsJournal.ContainsKey(name))
                {
                    studentsJournal[name] = new List<decimal>();
                    studentsJournal[name].Add(grade);
                }
                else
                {
                    studentsJournal[name].Add(grade);
                }
            }

            foreach (var student in studentsJournal)
            {

                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                
                Console.Write($"(avg: {student.Value.Average():f2})");
                
                Console.WriteLine();
            }
        }
    }
}
