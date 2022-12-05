using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace _08.Threeuple
{
    public class Tuple<T,V,U>
    {
        public T item1 { get; set; }

        public V item2 { get; set; }

        public U item3 { get; set; }

        public override string ToString()
        {           
            string output = $"{item1.ToString()} -> {item2.ToString()} -> {item3.ToString()}";
                        
            return output;
        }
    }
 

}
