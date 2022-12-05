using P01.Stream_Progress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamableFile streamableFile;

       
        public StreamProgressInfo(IStreamableFile file)
        {
            this.streamableFile = file;
        }

        public string CalculateCurrentPercent()
        {
            return $"{this.streamableFile.Name} - {(this.streamableFile.BytesSent * 100) / this.streamableFile.Length:f2}%";
        }
    }
}
