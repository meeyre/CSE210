using System;
using System.IO;

class Rectangle : Shape
{
    private double _length;
    private double _width;
    public Rectangle(){}
    public Rectangle(double len, double wid){
        _length = len;
        _width = wid;
    }
    public void SetLength(double length){
        _length = length;
    }
    public double GetLength()
    {
        return _length;
    }
    public void SetWidth(double width){
        _width = width;
    }
    public double GetWidth()
    {
        return _width;
    }
    public override double GetArea(){
        return _length * _width;
    }
}