using System.IO;
using System.Text;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(sourceFilePath);
               

                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {
                    using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                    {
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                partOne.Write(new byte[] { buffer[i] });
                            }
                            else
                            {
                                partTwo.Write(new byte[] { buffer[i] });
                            }
                        }
                    }
                }
                

            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open))
            {
                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    using (FileStream merged = new FileStream(joinedFilePath, FileMode.Create))
                    {
                        byte[] bufferOne = Encoding.UTF8.GetBytes(partOneFilePath);
                        byte[] bufferTwo = Encoding.UTF8.GetBytes(partTwoFilePath);

                        if (bufferOne.Length>=bufferTwo.Length)
                        {
                            for (int i = 0; i < bufferOne.Length; i++)
                            {                               
                                merged.Write(new byte[] { bufferOne[i] });

                                if (i<bufferTwo.Length)
                                {
                                    merged.Write(new byte[] { bufferTwo[i] });
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < bufferTwo.Length; i++)
                            {
                                merged.Write(new byte[] { bufferTwo[i] });

                                if (i < bufferOne.Length)
                                {
                                    merged.Write(new byte[] { bufferOne[i] });
                                }
                            }
                        }
                        
                    }
                }
            }
        }
    }
}
