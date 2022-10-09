using System.IO;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream binaryStream = new FileStream(binaryFilePath, FileMode.Open))
            {

                using (FileStream bytesStream = new FileStream(bytesFilePath, FileMode.Open))
                {                    
                    byte[] binaryBuffer = System.Text.Encoding.UTF8.GetBytes(binaryFilePath);
                    
                    byte[] bytesBuffer = System.Text.Encoding.UTF8.GetBytes(binaryFilePath);

                    foreach (var element in bytesBuffer)
                    {
                        for (int i = 0; i < binaryBuffer.Length; i++)
                        {
                            if (binaryBuffer[i]==element)
                            {
                                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
                                {
                                    outputStream.Write(new byte[] { binaryBuffer[i] });

                                }

                            }
                        }
                    }
                }
            }
        }
    }
}