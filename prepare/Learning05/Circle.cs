using System;
using System.IO;

class Circle : Shape
{
    private double _radius;
    public Circle(){}
    public Circle(double radius){
        _radius = radius;
    }
    public void SetRadius(double radius)
    {
        _radius = radius;
    }
    public double GetRadius()
    {
        return _radius;
    }
    public override double GetArea(){
        return _radius * _radius * 3.1415926;
    }
}