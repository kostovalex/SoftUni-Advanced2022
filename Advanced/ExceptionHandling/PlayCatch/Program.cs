using System;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int countOfExceptions = 0;
          
            while (countOfExceptions < 3)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                try
                {
                    switch (command[0])
                    {
                        case "Replace":
                            if (IndexChecker(command[1], array.Length) && VariableChecker(command[2]))
                            {
                                int index = int.Parse(command[1]);
                                string variable = command[2];
                                array[index] = variable;
                            }
                            break;
                        case "Print":
                            if (IndexChecker(command[1], array.Length) && IndexChecker(command[2], array.Length))
                            {
                                int startIndex = int.Parse(command[1]);
                                int endIndex = int.Parse(command[2]);

                                int counter = 0;
                                string[] subArray = new string[endIndex - startIndex + 1];

                                for (int i = startIndex; i <= endIndex; i++)
                                {
                                    subArray[counter] = array[i];
                                    counter++;
                                }

                                Console.WriteLine(string.Join(", ", subArray));
                            }
                            break;
                        case "Show":
                            if (IndexChecker(command[1], array.Length))
                            {
                                int index = int.Parse(command[1]);
                                Console.WriteLine(array[index]);
                            }
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    countOfExceptions++;
                    Console.WriteLine(ae.Message);
                }

            }

            Console.WriteLine(string.Join(", ", array));
        }

        private static bool VariableChecker(string variable)
        {
            if (!int.TryParse(variable, out int result))
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
            return true;

        }

        private static bool IndexChecker(string index, int length)
        {
            if (!int.TryParse(index, out int result))
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
            if (int.Parse(index) < 0 || int.Parse(index) >= length)
            {
                throw new ArgumentException("The index does not exist!");
            }
            return true;
        }
    }
}

