using System;
using System.IO;

class Equiptment : Expenditure
{
    private int _repairPeriod;
    private int _aveRepairCost;
    private bool _isPaidOff;
    private float _monthlyNote;
    public override float UserCost()
    {
        return base.UserCost();
    }
    public override float UserValue()
    {
        return base.UserValue();
    }
}