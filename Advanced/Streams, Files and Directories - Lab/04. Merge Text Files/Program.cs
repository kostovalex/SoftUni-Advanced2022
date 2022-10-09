using System.IO;
using System.Text;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                {
                    StringBuilder sb = new StringBuilder();

                    while (true)
                    {
                        if (firstReader.EndOfStream && secondReader.EndOfStream)
                        {
                            break;
                        }
                        if (!firstReader.EndOfStream)
                        {
                            sb.AppendLine(firstReader.ReadLine());

                        }
                        if (!secondReader.EndOfStream)
                        {
                            sb.AppendLine(secondReader.ReadLine());
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        writer.WriteLine(sb);
                    }
                }
            }
        }
    }
}
