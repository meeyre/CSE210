using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class ReflectingActivity : Activities
{
private List<string> _prompts = new List<string>();
private List<string> _questions = new List<string>(); 
public ReflectingActivity(int duration) : base("Reflecting Activity", //fills the _prompts and _questions lists
duration,
"This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
{
_prompts.Add("Think of a time when you stood up for someone else.");
_prompts.Add("Think of a time when you did something really difficult.");
_prompts.Add("Think of a time when you helped someone in need.");
_prompts.Add("Think of a time when you did something truly selfless.");

_questions.Add("Why was this experience meaningful to you? ");
_questions.Add("Have you ever done anything like this before? ");
_questions.Add("How did you get started? ");
_questions.Add("How did you feel when it was complete? ");
_questions.Add("What made this time different than other times when you were not as successful? ");
_questions.Add("What is your favorite thing about this experience? ");
_questions.Add("What could you learn from this experience that applies to other situations? ");
_questions.Add("What did you learn about yourself through this experience? ");
_questions.Add("How can you keep this experience in mind in the future? ");
}
public void Reflect(){ // presents random prompt, and then delays and presents random questions to ponder
    Console.Clear();
    Random rnd = new Random();
    DisplayActivityDetails();
    int y = rnd.Next(0,_prompts.Count);
    Console.WriteLine(_prompts[y]);
    Console.Write("Ponder...");
    PauseSpinning(5);
    ClearLine("Ponder...");
    Console.Write("\n");
    while(!ActivityFinished()){
        int x = rnd.Next(0,_questions.Count);
        Console.Write(_questions[x]);
        PauseSpinning(5);
        ClearLine(_questions[x]);
    }
    Console.Clear();
    Console.WriteLine("Thank you for participating in REFLECT activity!");
    Thread.Sleep(3000);
    Console.Clear();
}
}