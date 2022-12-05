using P01.Stream_Progress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Music : IStreamableFile
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get => $"{this.artist} - {this.album}"; } 
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
