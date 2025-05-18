using System;
using System.IO;

class Farm
{
    private List<Expenditure> _expenditures;

    public Farm()
    {
        _expenditures = new List<Expenditure>();
    }
    public void ClearList()
    {
        _expenditures.Clear();
    }
    public void AddExpenditure(Expenditure expenditure)
    {
        _expenditures.Add(expenditure);
    }
    public void SortExpenditures()
    {
        for (int i = 0; i < _expenditures.Count(); i++)
        {
            for (int j = 0; j < _expenditures.Count() - 1; j++)
            {
                if (_expenditures[j].CalculateProfitPerTime() < _expenditures[j + 1].CalculateProfitPerTime())
                {
                    Expenditure temp = _expenditures[j];
                    _expenditures[j] = _expenditures[j + 1];
                    _expenditures[j + 1] = temp;
                }
            }
        }
    }
    public void DisplayAll()
    {
        SortExpenditures();
        foreach (Expenditure expenditure in _expenditures)
        {
            Console.WriteLine(expenditure.Display());
            Console.WriteLine();
        }
    }
    public List<string> SaveData()
    {
        List<string> lines = new List<string>();
        foreach (Expenditure expenditure in _expenditures)
        {
            lines.Add(expenditure.Save());
        }
        return lines;
    }
}