using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Equiptment : Expenditure
{
    private float _repairFreq;
    private float _aveRepairCost;
    private float _monthlyNote;
    private string _equiptmentName;
    public Equiptment() : base()
    {
        
    }
    public Equiptment(string name, string cost, string value) : base(cost, value)
    {
        _equiptmentName = name;
    }
    public override string Save()
    {
        return $"4,{_equiptmentName}," + base.Save();
    }
    public override float UserCost()
    {
        Console.Write("Input Equiptment name: ");
        _equiptmentName = Console.ReadLine();
        Console.Write($"Is the {_equiptmentName} paid off? (y/n) ");
        if (Console.ReadLine() == "n")
        {
            _monthlyNote = GetFloatInput("How much is the monthly note? $");
        }
        else
        {
            _monthlyNote = 0;
        }
        _repairFreq = (float)1 / GetFloatInput("On average, how many months between repairs? ");
        _aveRepairCost = GetFloatInput($"What is the average repair cost of the {_equiptmentName}? $");
        base.SetCost(_repairFreq * _aveRepairCost + _monthlyNote);
        return _repairFreq * _aveRepairCost + _monthlyNote;
    }
    public override float UserValue()
    {
        base.SetValue(0);
        return 0;
    }
    public override string Display()
    {
        return $"{_equiptmentName}:\nMonthly Cost: ${GetCost()}";
    }
}