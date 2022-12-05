using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
       
        Random random = new Random();
        public string RandomString()
        {
            int index = random.Next(this.Count);
            string randomString = this[index];

            this.RemoveAt(index);
            
            return randomString;

        }
    }
}
