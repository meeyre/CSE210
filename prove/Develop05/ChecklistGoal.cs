using System;
using System.IO;

class ChecklistGoal : Goal
{
    private int _bonus;
    private int _timesNeededForBounus;
    private int _timesDone;

    public ChecklistGoal(string line1, string line2) : base(line2) // constructor when loading from file
    {
        string[] lines = line1.Split("|");
        _bonus = int.Parse(lines[0]);
        _timesNeededForBounus = int.Parse(lines[1]);
        _timesDone = int.Parse(lines[2]);
    }
    public ChecklistGoal() : base() //if not loading from file, just use the new SetGoalData() method in the base constructor
    {
    }
    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }
    public void SetTimesNeeded(int times)
    {
        _timesNeededForBounus = times;
    }
    public override void SetGoalData()
    { //custom SetGoalData() method that also sets _bonus, _timesNeeded, and _timesDone
        SetIsCompleted(false);
        _timesDone = 0;
        Console.Write("What is the name of this goal? ");
        SetGoalName(Console.ReadLine());
        Console.Write("Please input a brief description: ");
        SetGoalDes(Console.ReadLine());
        Console.Write("How many points is this goal worth each time it is achieved? ");
        SetPointValue(int.Parse(Console.ReadLine()));
        Console.Write("How many times until a bonus for completion? ");
        SetTimesNeeded(int.Parse(Console.ReadLine()));
        Console.Write("How many points is the bonus? ");
        SetBonus(int.Parse(Console.ReadLine()));
    }
    public override int CompleteGoal()
    {
        _timesDone++;
        if (_timesDone == _timesNeededForBounus)
        { //gives you a bonus if you hit the goal ammount of times
            return base.CompleteGoal() + _bonus;
        }
        else
        {
            return GetPointValue();
        }
    }
    public override void DisplayGoal()
    {
        if (GetIsCompleted())
        { // two cases for if you have hit the goal amount of times or not
            Console.WriteLine($"{_timesDone}/{_timesNeededForBounus} [x] {GetPointValue()} points ({_bonus} bonus) >> {GetGoalName()} : {GetGoalDes()}");
        }
        else
        {
            Console.WriteLine($"{_timesDone}/{_timesNeededForBounus} [ ] {GetPointValue()} points ({_bonus} bonus) >> {GetGoalName()} : {GetGoalDes()}");
        }
    }
    public override string SaveGoal()
    {
        return $"{_bonus}|{_timesNeededForBounus}|{_timesDone}|{base.SaveGoal()}"; // custom save to get extra data that this class has
    }
}