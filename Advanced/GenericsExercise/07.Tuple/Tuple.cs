using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T,V>
    {
        public T item1 { get; set; }

        public V item2 { get; set; }

        public override string ToString()
        {           
            string output = $"{item1.ToString()} -> {item2.ToString()}";
                        
            return output;
        }
    }
 

}
