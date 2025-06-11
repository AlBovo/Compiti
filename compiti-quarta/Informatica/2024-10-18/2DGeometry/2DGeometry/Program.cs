namespace _2DGeometry
{
    struct Point
    {
        public double x;
        public double y;
    
        public Point(double x, double y) { this.x = x; this.y = y; }
    }

    abstract class Polygon
    {
        private string name;
        protected Polygon(string name) { this.name = name; }

        public abstract double Area();
        public abstract double Perimeter();
    }

    class Circle : Polygon
    {
        private Point center;
        private double radius;

        public Circle(string name, Point center, double radius) : base(name)
        {
            this.radius = Math.Abs(radius);
            this.center = center;
        }
        public Circle(string name, double x, double y, double radius) : base(name)
        {
            this.radius = Math.Abs(radius);
            center = new Point(x, y);
        }

        public override double Area() => Math.PI * Math.Pow(radius, 2);
        public override double Perimeter() => Math.PI * 2 * radius;
    }

    class Triangle : Polygon
    {
        /* Points of the rectangle
         *  
         *     a *
         *      / \
         *     /   \
         *  c *-----* b
         */
        private Point a, b, c;
        private double height, width;

        public Triangle(string name, double height, double width) : base(name)
        {
            a = new Point(0, 0);
            this.height = Math.Abs(height);
            this.width = Math.Abs(width);
            b = new Point(a.x + width / 2, a.y - this.height);
            c = new Point(a.x - width / 2, a.y - this.height);
        }

        public override double Area() => width * height / 2;
        public override double Perimeter()
        {
            double side1 = Math.Sqrt(Math.Pow(a.y - b.y, 2) + Math.Pow(b.x - a.x, 2)); // ab
            double side2 = Math.Sqrt(Math.Pow(a.y - c.y, 2) + Math.Pow(a.x - c.x, 2)); // ac
            double side3 = Math.Sqrt(Math.Pow(c.y - b.y, 2) + Math.Pow(c.x - b.x, 2)); // bc
            return side1 + side2 + side3;
        }
    }

    class Rectangle : Polygon
    {
        /* Points of the rectangle
         *  
         *  a *-------* b
         *    |       |
         *  d *-------* c
         */
        private Point a, b, c, d;
        protected double width, height;

        public Rectangle(string name, double width, double height) : base(name)
        {
            a = new Point(0, 0);
            b = new Point(a.x + width, a.y);
            c = new Point(a.x + width, a.y - height);
            d = new Point(a.x, a.y - height);
            this.width = width;
            this.height = height;
        }

        public override double Area() => width * height;
        public override double Perimeter() => width * 2 + height * 2;
    }

    class Square : Rectangle
    {       
        /* Points of the square
         *  
         *  a *---* b
         *    |   |
         *  d *---* c
         */
        public Square(string name, double side) : base(name, side, side) { }

        public override double Area() => width * width;
        public override double Perimeter() => base.Perimeter();
    }

    class Rhombus : Square
    {
        /* Points of the rhombus
         * 
         *      * a
         *     / \
         *    /   \
         * d *     * b
         *    \   /
         *     \ /
         *      * c
         */
        private Point a, b, c, d;
        private double diagonal1, diagonal2;

        public Rhombus(string name, double diagonal1, double diagonal2) : base(name, diagonal1)
        {
            this.diagonal1 = Math.Max(diagonal1, diagonal2);
            this.diagonal2 = Math.Min(diagonal1, diagonal2);

            a = new Point(0, 0);
            b = new Point(this.diagonal2 / 2, -this.diagonal1 / 2);
            c = new Point(0, -this.diagonal1);
            d = new Point(-this.diagonal2 / 2, -this.diagonal1 / 2);
        }

        public override double Area() => base.Area() / 2;
        public override double Perimeter() => Math.Sqrt(Math.Pow(diagonal1 / 2, 2) + Math.Pow(diagonal2 / 2, 2)) * 4;
    }

    class Trapeze : Polygon
    {
        /* Points of the trapeze
         * 
         *     a *-------* b
         *      /         \
         *     /           \
         *  d *-------------* c
         */

        private Point a, b, c, d;
        private double width1, width2, height;

        public Trapeze(string name, double width1, double width2, double height) : base(name)
        {
            this.width1 = Math.Max(width1, width2);
            this.width2 = Math.Min(width1, width2);
            
            a = new Point(0, 0);
            b = new Point(width2, 0);
            c = new Point(width2 + (width1 - width2) / 2, -height);
            d = new Point(-(width1 - width2) / 2, -height);
        }

        public override double Area() => (width1 + width2) * height / 2;
        public override double Perimeter() => width1 + width2 + Math.Sqrt(height * height + Math.Pow((width1 - width2) / 2, 2)) * 2;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
