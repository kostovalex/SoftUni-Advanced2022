using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Models
{
    public interface IStreamableFile
    {
        string Name { get; }    
        int Length { get; }
        int BytesSent { get; }

    }
}
