using System;
using System.IO;

class LiveStock : Expenditure
{
    private int _head;
    private float _feedPricePerLb;
    private float _feedQuantityPerHead;
    private float _livestockFreq;
    private float _sellPrice;
    private string _animalName;
    public LiveStock() : base()
    {
        
    }
    public LiveStock(string name, string cost, string value) : base(cost, value)
    {
        _animalName = name;
    }
    public override string Save()
    {
        return $"2,{_animalName}," + base.Save();
    }
    public override float UserCost()
    {
        Console.Write("What kind of animal? ");
        _animalName = Console.ReadLine();
        Console.Write("How many head of livestock do you have? ");
        _head = int.Parse(Console.ReadLine());
        _feedQuantityPerHead = 4 * GetFloatInput("How many lbs of feed per animal do you need weekly? ");
        _feedPricePerLb = GetFloatInput("How much does feed cost per lb? $");
        base.SetCost(_feedPricePerLb * _feedQuantityPerHead * _head);
        return _feedPricePerLb * _feedQuantityPerHead * _head;
    }
    public override float UserValue()
    {
        Console.Write("How many months until the livestock is fully grown? ");
        _livestockFreq = (float)1 / (float)int.Parse(Console.ReadLine());
        _sellPrice = GetFloatInput("How much will a fully grown animal sell for? $");
        base.SetValue(_head * _sellPrice * _livestockFreq);
        return _head * _sellPrice * _livestockFreq;
    }
    public override string Display()
    {
        return $"{_animalName}:\nMonthly Cost: ${GetCost()}\nMonthly Value: $${GetValue()}\nMonthly Profit: ${GetValue() - GetCost()}";
    }
}