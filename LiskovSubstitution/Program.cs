using System;
using static System.Console;

namespace LiskovSubstitution
{
    class Program
    {
        static int Area(Rectangle r) => r.Width * r.Height;
        
        static void Main(string[] args)
        {
            // According to the Liskov Substitution principle
            // an inherited class shall be assigned to it's base class
            // without losing it's functionality.
            
            // In this example we see a rectangle and square in which
            // square is inherited from rectangle. But in order for square
            // to work, we must ensure that width and height properties
            // attain the same functionality when said Square is assigned to a Rectangle

            Rectangle r = new Rectangle(4, 3);
            WriteLine($"{r} has area of {Area(r)}");

            Square sq = new Square();
            sq.Width = 5;
            WriteLine($"{sq} has area of {Area(sq)}");
            
            // Above example breaks L/S principle if we try to assign
            // SquareWrong to a Rectangle without marking Rectangle's properties
            // as virtual and newing them in Square instead of overriding.
            
            // In order to break L/S principle, change the Width and Height properties of
            // Rectangle to non-virtual properties and see how it breaks.
            Rectangle sqr = new Square();
            sqr.Width = 4;
            WriteLine($"{sqr} has area of {Area(sqr)}");
        }
    }
}