using System.IO;
using System.Linq;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;

            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                sum += file.Length;
            }

            sum = sum / 1024 ;

            File.WriteAllText(outputFilePath, sum.ToString());

        }
    }
}
