using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    StringBuilder sb = new StringBuilder();
                    int lineNumber = 1;
                  
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        sb.Append($"{lineNumber}. ");
                        sb.AppendLine(line);
                        lineNumber++;

                    }
                        writer.WriteLine(sb);

                }
            }
        }
    }
}
