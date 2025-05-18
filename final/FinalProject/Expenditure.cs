using System;
using System.IO;

class Expenditure
{
    private float _cost;
    private float _value;

    public Expenditure()
    {
        UserCost();
        UserValue();
    }
    public float GetFloatInput(string prompt)
    {
        int x = 0;
        float y = 0;
        do
        {
            Console.Write(prompt);
            string line = Console.ReadLine();
            string[] lines = line.Split(".");
            if (lines.Count() == 2)
            {
                y = (float)int.Parse(lines[0]) + (float)int.Parse(lines[1]) / (float)(lines[1].Length * 10);
                x = 0;
            }
            else if (lines.Count() == 1)
            {
                y = (float)int.Parse(lines[0]);
                x = 0;
            }
            else
            {
                Console.WriteLine("Error, please try again.");
                x = 1;
            }
        } while (x == 1);
        return y;
    }

    public virtual float CalculateProfitPerTime()
    {
        return _value - _cost;
    }
    public virtual float UserCost()
    {
        _cost = GetFloatInput("what is the cost of this item?");
        return _cost;
    }
    public virtual float UserValue()
    {
        _value = GetFloatInput("what is the value of this item?");
        return _value;
    }
    public virtual void SetCost(float cost)
    {
        _cost = cost;
    }
    public virtual void SetValue(float value)
    {
        _value = value;
    }
}