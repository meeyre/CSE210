using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle(5));
        shapes.Add(new Square(3));
        shapes.Add(new Rectangle(2,3));
        shapes[0].SetColor("blue");
        shapes[1].SetColor("red");
        shapes[2].SetColor("green");
        foreach(Shape shape in shapes){
            Console.WriteLine(shape.GetArea());
            Console.WriteLine(shape.GetColor());
        }
        
    }
}