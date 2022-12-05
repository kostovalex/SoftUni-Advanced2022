using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Anton", new List<string> { "1", "2", "3", "4", "5", "6", });
            Employee employee = new Employee("Obshtak");
            Employee employee2 = new Employee("Obshtak2");
            Employee employee3 = new Employee("Obshtak3");
            Employee employee4 = new Employee("Obshtak4");
            
            IList<IPrintable> printableList = new List<IPrintable>() { manager, employee, employee2, employee3, employee4 };

            DetailsPrinter printer = new DetailsPrinter(printableList);

            printer.PrintDetails();

        }
    }
}
