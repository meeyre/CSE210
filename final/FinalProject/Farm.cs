using System;
using System.IO;

class Farm
{
    private List<Expenditure> _expenditures;

    public Farm()
    {
        _expenditures = new List<Expenditure>();
    }
    public void AddExpenditure()
    {
        _expenditures.Add(new Expenditure());
    }
    public float CalculateBalance()
    {
        float balance = 0;
        foreach (Expenditure expenditure in _expenditures)
        {
            balance += expenditure.CalculateProfitPerTime();
        }
        return balance;
    }
}