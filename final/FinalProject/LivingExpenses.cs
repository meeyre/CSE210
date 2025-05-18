using System;
using System.IO;

class LivingExpenses : Expenditure
{
    private float _groceries;
    private float _services;
    public LivingExpenses()
    {
        
    }
    public LivingExpenses(string name, string cost, string value) : base(cost, value)
    {
    
    }
    public override string Save()
    {
        return $"5,Living Expenses," + base.Save();
    }
    public override float UserCost()
    {
        _groceries = 4 * GetFloatInput("How much do you spend weekly on groceries? $");
        _services = GetFloatInput("How much do you spend monthly on bills? $");
        base.SetCost(_groceries + _services);
        return _groceries + _services;
    }
    public override float UserValue()
    {
        base.SetValue(0);
        return 0;
    }
    public override string Display()
    {
        return $"Living Expenses:\nMonthly Cost: {GetCost()}";
    }
}