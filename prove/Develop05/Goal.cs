using System;
using System.IO;

class Goal
{
    private string _goalName;
    private string _goalDiscription;
    private int _pointValue;
    private bool _isCompleted;
    //    private string _typeName;

    public Goal()
    {
        SetGoalData();
    }
    public Goal(string line)
    { //custom constructor if loading from a file
        string[] parts = line.Split("|");
        _goalName = parts[0];
        _goalDiscription = parts[1];
        _pointValue = int.Parse(parts[2]);
        _isCompleted = Convert.ToBoolean(parts[3]);
    }
    public bool GetIsCompleted()
    { //I ended up needing a ton of getters and setters in this assignment
        return _isCompleted;
    }
    public void SetIsCompleted(bool isOrIsnt)
    {
        _isCompleted = isOrIsnt;
    }
    public virtual int CompleteGoal()
    {
        _isCompleted = true;
        return _pointValue;
    }
    public string GetGoalName()
    {
        return _goalName;
    }
    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }
    public string GetGoalDes()
    {
        return _goalDiscription;
    }
    public void SetGoalDes(string goalDes)
    {
        _goalDiscription = goalDes;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }
    public void SetPointValue(int pointValue)
    { // ^^ all getters and setters that I had to use
        _pointValue = pointValue;
    }
    public virtual void SetGoalData()
    { // Gets user input for a regular goal
        _isCompleted = false;
        Console.Write("What is the name of this goal? ");
        SetGoalName(Console.ReadLine());
        Console.Write("Please input a brief description: ");
        SetGoalDes(Console.ReadLine());
        Console.Write("How many points is this goal worth? ");
        SetPointValue(int.Parse(Console.ReadLine()));
    }
    public virtual string SaveGoal()
    { //standard save format
        return $"~{_goalName}|{_goalDiscription}|{_pointValue}|{_isCompleted}";
    }
    public virtual void DisplayGoal()
    { // two cases for completed and not completed
        if (_isCompleted)
        {
            Console.WriteLine($"[x] {_pointValue} points >> {_goalName} : {_goalDiscription}");
        }
        else
        {
            Console.WriteLine($"[ ] {_pointValue} points >> {_goalName} : {_goalDiscription}");
        }
    }

}