using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IPrintable> employees;

        public DetailsPrinter(IList<IPrintable> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IPrintable employee in this.employees)
            {
                employee.Print();
            }
        }    
    }
}
