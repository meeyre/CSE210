using System;
using System.IO;

class BreathingActivity : Activities
{
    private int _breathTime;
    public BreathingActivity(int duration) : base("Breathing Activity",
    duration,
    "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breathTime = 5;
    }
    private void DisplayInhale()
    {  // displays the inhale
        Console.Write("Breathe in... ");
        PauseCountdown(_breathTime);
        ClearLine("Breathe in... ");
    }
    private void DisplayExhale()
    {
        Console.Write("Breathe out.. ");
        PauseCountdown(_breathTime);
        ClearLine("Breathe out.. ");
    }
    public void Breathe()
    { // loops between display inhale and display exhale
        Console.Clear();
        DisplayActivityDetails();
        Console.Write("Start breathing in ");
        PauseCountdown(3);
        ClearLine("Start breathing in ");
        while (!ActivityFinished())
        {
            DisplayInhale();
            if (ActivityFinished())
            {
                break;
            }
            DisplayExhale();
        }
        Console.Clear();
        Console.WriteLine("Thank you for participating in BREATHE activity!");
        Thread.Sleep(3000);
        Console.Clear();
    }
}