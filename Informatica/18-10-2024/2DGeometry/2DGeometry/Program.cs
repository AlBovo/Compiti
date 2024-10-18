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
        public override double Perimeter() => 0;
    }

    class Rectangle : Polygon
    {
        private Point a, b, c, d;
        protected double width, height;

        public Rectangle(string name, double width, double height) : base(name)
        {
            a = new Point(0, 0);
            b = new Point(a.x + width, a.y);
            c = new Point(a.x + width, a.y + height);
            d = new Point(a.x, a.y + height);
            this.width = width;
            this.height = height;
        }

        public override double Area() => width * height;
        public override double Perimeter() => width * 2 + height * 2;
    }

    class Square : Rectangle
    {
        public Square(string name, double side) : base(name, side, side) { }

        public override double Area() => width * width;
        public override double Perimeter() => base.Perimeter();
    }

    class Rhombus : Square
    {
        public Rhombus(string name) : base(name, 0) { }
        // TODO : finish
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
