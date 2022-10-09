namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int lineCounter = 1;
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        int letterCount = 0;
                        int symbolCount = 0;
                        string line = reader.ReadLine();
                        
                        foreach (var ch in line)
                        {
                            if (char.IsLetter(ch))
                            {
                                letterCount++;
                            }
                            else if (char.IsPunctuation(ch))
                            {
                                symbolCount++;
                            }
                        }

                        sb.AppendLine($"Line {lineCounter}: {line} ({letterCount})({symbolCount})");
                        lineCounter++;
                        
                    }
                    writer.WriteLine(sb.ToString());
                }
            }  
            
            

        }
    }
}
