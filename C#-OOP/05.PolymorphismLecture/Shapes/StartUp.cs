using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(4);
            Rectangle rec = new Rectangle(4.3, 5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(rec.CalculateArea());
            Console.WriteLine(rec.CalculatePerimeter());

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rec.Draw());
        }
    }
}
