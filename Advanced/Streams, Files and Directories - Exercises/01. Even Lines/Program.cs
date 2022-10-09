namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder sb = new StringBuilder();
                char[] symbols = { '-', ',', '.', '!', '?' };

                int row = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (row % 2 == 0)
                    {
                        
                        foreach (var element in symbols)
                        {
                            line = line.Replace(element, '@');
                        }

                        string[] array = line.Split(" ");
                        array = array.Reverse().ToArray();

                        sb.AppendLine(string.Join(" ",array));

                    }
                    row++;
                }
                string output = sb.ToString();
                return output;
            }
            
            
        }
    }
}

