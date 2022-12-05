using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();

            GraphicEditor graphic = new GraphicEditor();
            graphic.DrawShape(square);
            graphic.DrawShape(rectangle);
            graphic.DrawShape(circle);
        }
    }
}
