using System;
class Assignment
{
    private string _studentName;
    private string _topic;
    public Assignment(string name, string topic){
        _studentName = name;
        _topic = topic;
    }
    public string GetSummary(){
        return $"{_studentName} - {_topic}";
    }
    public string GetName(){
        return _studentName;
    }
}

class WritingAssignment : Assignment
{   
    private string _title;
    public WritingAssignment(string name, string topic , string title) : base(name, topic){
        _title = title;
    }
    public string GetWritingInfo(){
        return $"{GetSummary()}\n{_title} by {GetName()}";
    }
}

class MathAssignment : Assignment
{   
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string name, string topic, string textbookSection, string problems) : base(name, topic){
        _textbookSection = textbookSection;
        _problems = problems;
    }
    public string GetHomework(){
        return $"{GetSummary()}\n{_textbookSection} : {_problems}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        WritingAssignment writingHW = new WritingAssignment("Bob", "European History", "Mideaval Castles");
        MathAssignment mathHW = new MathAssignment("Bill", "Fractions", "7.3-7.4", "45-47");
        Console.WriteLine(writingHW.GetWritingInfo());
        Console.WriteLine(mathHW.GetHomework());
    }
}