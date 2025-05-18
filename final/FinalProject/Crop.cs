using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

class Crop : Expenditure
{
    private float _costSeed;
    private float _quantitySeed;
    private float _plants;
    private float _expectedYeald;
    private float _irrigationCost;
    private int _irrigationFreq;
    private float _valuePerPlant;
    private int _growthTimeframe;

    public Crop() : base()
    {

    }

    public override float UserCost()
    {
        _costSeed = GetFloatInput("Seed price per lb: $");
        _quantitySeed = GetFloatInput("lbs Seed: ");
        _irrigationCost = GetFloatInput("How much does it cost to irrigate the planted field? ");
        Console.Write("How many times will you need to irrigate per month? ");
        _irrigationFreq = int.Parse(Console.ReadLine());
        Console.Write("How many months will these seeds take to fully grow? ");
        _growthTimeframe = int.Parse(Console.ReadLine());
        base.SetValue(((_costSeed / (float)_growthTimeframe) + (_irrigationCost * _irrigationFreq)));
        return (_costSeed / (float)_growthTimeframe) + (_irrigationCost * _irrigationFreq);

    }
    private float GetPlants()
    {
        return _quantitySeed / (GetFloatInput("Seed Weight (oz): ") / 16);
    }
    public override float UserValue()
    {
        _valuePerPlant = GetFloatInput("How much income does each plant generate? $");
        _plants = GetPlants();
        _expectedYeald = GetFloatInput("Estimated precent yeild: %") / (float)100;
        base.SetValue(_plants * _expectedYeald * _valuePerPlant / _growthTimeframe);
        return _plants * _expectedYeald * _valuePerPlant / _growthTimeframe;
    }
}