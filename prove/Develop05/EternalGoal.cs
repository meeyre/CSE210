using System;
using System.IO;

class EternalGoal : Goal
{
    public EternalGoal()
    {
    }
    public EternalGoal(string line) : base(line) //custom constructor if loading from a file
    {
    }
    public override void DisplayGoal()
    {

        Console.WriteLine($"[∞] {GetPointValue()} points >> {GetGoalName()} : {GetGoalDes()}");
        //Instead of showing a completion, an infinity symbol (∞) is shown in the checkbox
    }
    public override int CompleteGoal()
    {
        return GetPointValue();
        //this never turns _isCompleted to true
    }
    public override string SaveGoal()
    {
        return $"+{base.SaveGoal()}";
        //custom return so when loading we know what kind of goal it is
    }
}