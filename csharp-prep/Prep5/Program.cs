using System;

class Program
{
    static void DisplayWelcome()
    {
    Console.WriteLine("Welcome to the program!");
    }
    static string GetName()
    {
    Console.Write("Please input your name: ");
    return Console.ReadLine();
    }
    static int GetNumber()
    {
    Console.Write("Please input your favorite number: ");
    return int.Parse(Console.ReadLine());
    }
    static int SquareUserNumber(int number)
    {
        return number * number;
    }
    static void DisplayData(string name, int number)
    {
    
    Console.WriteLine($"{name}, the square of your favorite number is {SquareUserNumber(number)}");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayData(GetName(), GetNumber());
    }
}