using System;
class Fraction
{
    private int _top;
    private int _bottom;
    public int GetTop(){
        return _top;
    }
    public void SetTop(int top){
        _top = top;
    }
    public int GetBottom(){
        return _bottom;
    }
    public void SetBottom(int bottom){
        _bottom = bottom;
    }
    public Fraction(){
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top){
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    public string GetFractionString(){
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue(){
        return (double)_top/(double)_bottom;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fraction test = new Fraction();
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());
        test.SetTop(3);
        test.SetBottom(4);
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());
        Fraction test2 = new Fraction(5);
        Fraction test3 = new Fraction(4,5);
        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());
        Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test3.GetDecimalValue());
    }
}