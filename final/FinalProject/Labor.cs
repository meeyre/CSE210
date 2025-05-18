using System;
using System.IO;

class Labor : Expenditure
{
    private float _hourlyWage;
    private float _weeklyHours;
    private string _workerName;
    public Labor()
    {
        
    }
    public Labor(string name, string cost, string value) : base(cost, value)
    {
        _workerName = name;
    }
    public override string Save()
    {
        return $"3,{_workerName}," + base.Save();
    }
    public override float UserCost()
    {
        Console.Write("Input worker name: ");
        _workerName = Console.ReadLine();
        _hourlyWage = GetFloatInput($"What is {_workerName}'s hourly wage? $");
        _weeklyHours = GetFloatInput($"How many hours does {_workerName} work per week? ");
        base.SetCost(_hourlyWage * _weeklyHours * 4);
        return _hourlyWage * _weeklyHours * 4;
    }
    public override float UserValue()
    {
        base.SetValue(0);
        return 0;
    }
    public override string Display()
    {
       return $"{_workerName}:\nMonthly Cost: ${GetCost()}";
    }
}