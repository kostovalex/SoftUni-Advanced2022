using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] accInfo = input[i].Split("-", StringSplitOptions.RemoveEmptyEntries);

                int accNum = int.Parse(accInfo[0]);
                double sum = double.Parse(accInfo[1]);

                bankAccounts.Add(accNum, sum);
            }

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                try
                {
                    switch (commands[0])
                    {
                        case "Deposit":
                            if (CheckAccount(commands[1], bankAccounts))
                            {
                                int accNum = int.Parse(commands[1]);
                                double amount = double.Parse(commands[2]);

                                bankAccounts[accNum] += amount;
                                Console.WriteLine($"Account {accNum} has new balance: {bankAccounts[accNum]:f2}");
                            }
                            break;
                        case "Withdraw":
                            if (CheckAccount(commands[1], bankAccounts) && CheckBalance(commands[1], commands[2], bankAccounts))
                            {
                                int accNum = int.Parse(commands[1]);
                                double amount = double.Parse(commands[2]);

                                bankAccounts[accNum] -= amount;
                                Console.WriteLine($"Account {accNum} has new balance: {bankAccounts[accNum]:F2}");
                            }                            
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");

                    }
                }
                catch (ArgumentException ae )
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static bool CheckBalance(string account, string money, Dictionary<int, double> bankAccounts)
        {
            if (!double.TryParse(money, out double moneyToWithdraw))
            {
                throw new ArgumentException("Invalid command!");
            }
            int accNum = int.Parse(account);

            if (bankAccounts[accNum] < moneyToWithdraw)
            {
                throw new ArgumentException("Insufficient balance!");
            }
            return true;
        }

        private static bool CheckAccount(string acc, Dictionary<int, double> bankAccounts)
        {
            if (!int.TryParse(acc, out int accNum))
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!bankAccounts.ContainsKey(int.Parse(acc)))
            {
                throw new ArgumentException("Invalid account!");
            }
            return true;
        }
    }
}
