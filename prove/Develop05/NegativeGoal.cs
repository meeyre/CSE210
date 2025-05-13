using System;
using System.IO;

class NegativeGoal : Goal
{
    public NegativeGoal(string line) : base(line)//custom constructor if loading from a file
    {
    }
    public NegativeGoal(){}
    public override void DisplayGoal()
    {
        
        Console.WriteLine($"[-] -{GetPointValue()} points >> {GetGoalName()} : {GetGoalDes()}");
        
    }
    public override int CompleteGoal()
    {
        return -GetPointValue(); //returns the negative so that way points are reduced
    }
    public override string SaveGoal()
    {
        return $"-{base.SaveGoal()}";
        //custom return so when loading we know what kind of goal it is
    }
    public override void SetGoalData(){
        SetIsCompleted(false);
        Console.Write("What is the name of this bad habit? ");
        SetGoalName(Console.ReadLine());
        Console.Write("Please input a brief description: ");
        SetGoalDes(Console.ReadLine());
        Console.Write("How many points should you lose each time you do this bad habit? ");
        SetPointValue(int.Parse(Console.ReadLine()));
    }
}