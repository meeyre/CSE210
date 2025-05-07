using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class ListingActivity : Activities
{
    private List<string> _prompts = new List<string>();
    private List<string> _responses = new List<string>();
    public ListingActivity(int duration) : base("Listing Activity",
    duration,
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }
    public void DoList()
    { //presents prompt and saves responses to a list
        Random rnd = new Random();
        int x = rnd.Next(0, _prompts.Count);
        Console.Clear();
        DisplayActivityDetails();
        Console.WriteLine(_prompts[x]);
        Console.Write("Ponder ... ");
        PauseCountdown(5);
        ClearLine("Ponder ... ");
        while (!ActivityFinished())
        {
            Console.Write("> ");
            _responses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You entered {_responses.Count} responses!");
        Thread.Sleep(2500);
        Console.Clear();
        Console.WriteLine("Thank you for participating in LIST activity!");
        Thread.Sleep(3000);
        Console.Clear();


    }
}