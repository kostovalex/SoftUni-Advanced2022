using Formula1.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Formula1.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using(StreamWriter writer = new StreamWriter("../../../fileoutput.txt", true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../fileoutput.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
