using System;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
             SandwichMenu menu = new SandwichMenu();
            menu["Lukanka"] = new Sandwich("Pitka", "Lukanchica", "Kashkavalche", "");
            menu["Shunka"] = new Sandwich("Pitka", "Shunka", "TopenoSirence", "Domatche");
            menu["Salam"] = new Sandwich("Pitka", "Salamche", "Kashkavalche", "Kartofche");
            
            
            menu["Diuner"] = new Sandwich("Arabska pitka", "Mesce", "Sirence", "Purjeno kartofche");

            Sandwich sandwich1 = (Sandwich)menu["Lukanka"].Clone();


        }
    }
}
