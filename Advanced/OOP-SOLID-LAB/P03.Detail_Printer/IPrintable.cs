using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public interface IPrintable
    {
        string Name { get; }
        virtual void Print() { }
    }
}
