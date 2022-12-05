namespace Telephony.Core
{
    using System;
    
    using Interefaces;
    using Telephony.IO.Interfaces;
    using Telephony.Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ");
            string[] urls = this.reader.ReadLine().Split(' ');

            SmartPhone smart = new SmartPhone();
            StationaryPhone stat = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        this.writer.WriteLine(smart.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        this.writer.WriteLine(stat.Call(number));
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    this.writer.WriteLine(smart.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }
    }
}
