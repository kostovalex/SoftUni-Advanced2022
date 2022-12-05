using P01.Stream_Progress.Models;

namespace P01.Stream_Progress
{
    public class File : IStreamableFile
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get => name; set => name = value; }
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
