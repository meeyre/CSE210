using System;
using System.IO;

class Activities
{
    private string _activityName;
    private int _duration;
    private string _description;
    private DateTime _endTime;

    public Activities(string name, int duration, string description)
    {
        _activityName = name;
        _duration = duration;
        _description = description;
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    public void PauseSpinning(int pauseTime)
    { // takes time imput, and spins until the time goes to 0
        DateTime end = DateTime.Now.AddSeconds(pauseTime);
        int i = 0;
        List<string> spinner = ["|", "/", "-", "\\"];
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }
    public void ClearLine(string s)
    { //I just kept having to do this so I decided to put it in the parent function to reuse
        Console.Write(new string('\b', s.Length));
        Console.Write(new string(' ', s.Length));
        Console.Write(new string('\b', s.Length));
    }
    public void PauseCountdown(int pauseTime)
    { //takes time imput, and counts down from that number
        DateTime end = DateTime.Now.AddSeconds(pauseTime);
        while (DateTime.Now < end)
        {
            Console.Write(pauseTime);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            pauseTime--;
        }
    }
    public void DisplayActivityDetails()
    { // prints activity details to the console
        Console.WriteLine($"Welcome to {_activityName}!\n");
        Console.WriteLine(_description);
        Console.Write("\n");
    }
    public bool ActivityFinished()
    { //returns true if the activity time has passed
        DateTime currentTime = DateTime.Now;
        if (_endTime < currentTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}