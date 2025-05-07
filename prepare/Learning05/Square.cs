using System;
using System.IO;

class Square : Shape
{
    private double _side;
    public Square(){}
    public Square(double side){
        _side = side;
    }
    public void SetSide(double side){
        _side = side;
    }
    public double GetSide()
    {
        return _side;
    }
    public override double GetArea(){
        return _side * _side;
    }
}