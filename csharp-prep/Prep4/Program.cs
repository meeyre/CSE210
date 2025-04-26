using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int input = 0;
        List<int> numbers = new List<int>();
        int sum = 0;
        int av;
        int largest = 0;
        do{
            Console.Write(">> ");
            input = int.Parse(Console.ReadLine());
            if (input != 0){numbers.Add(input);}
        }while (input != 0);
        foreach (int number in numbers){
            sum += number;
            if (number > largest){largest = number;}
        }
        av = sum/numbers.Count;
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {av}");
        Console.WriteLine($"The largest is {largest}");
    }
}