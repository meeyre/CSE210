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
    public Expenditure(string cost, string value)
    {
        _cost = StringToFloat(cost);
        _value = StringToFloat(value);
    }
    public virtual string Save()
    {
        return $"{GetCost()},{GetValue()}";
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
                y = (float)int.Parse(lines[0]) + (float)int.Parse(lines[1]) / (float)Math.Pow(10,lines[1].Length);
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
    public float StringToFloat(string num)
    {
        string line = num;
        string[] lines = line.Split(".");
        if (lines.Count() == 2)
        {
            return (float)int.Parse(lines[0]) + (float)int.Parse(lines[1]) / (float)Math.Pow(10,lines[1].Length);
            
        }
        else
        {
            return (float)int.Parse(lines[0]);
            
        }
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
    public float GetCost() {
        return _cost;
    }
    public float GetValue()
    {
        return _value;
    }
    public virtual string Display()
    {
        return $"Cost: {_cost}\nValue: {_value}";
    }
}