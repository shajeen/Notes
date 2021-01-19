using System;

namespace RectangleApplication
{
    class Rectangle
    {
        double length;
        double width;

        public void AcceptDetails()
        {
            length = 3.4;
            width = 5.1;
        }

        public double GetArea()
        {
            return length * width;
        }

        public void displayValues()
        {
            Console.WriteLine("length {0}", length);
            Console.WriteLine("width {0}", width);
            Console.WriteLine("Area {0}", GetArea());
        }
    }

    class ExecutableRectangle {
        static void Main(string[] args) {
            Rectangle r = new Rectangle();
            r.AcceptDetails();
            r.displayValues();
        }
    }
}