using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please input your grade precentage: ");
        int x = int.Parse(Console.ReadLine());
        string letter;

        if (x>=90)
        {
            letter = "A";
        }
        else if (x>=80)
        {
            letter = "B";
        }
        else if (x>=70)
        {
            letter = "C";
        }
        else if (x>=60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade was \"{letter}\"");
        if (x>=70)
        {
            Console.WriteLine("You passed! Great job!");
        }
        else
        {
            Console.WriteLine("You didn't pass, better luck next time!");
        }
    }
}