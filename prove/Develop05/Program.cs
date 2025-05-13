using System;
using System.IO;
/*
EXCEEDING REQUIREMENTS:
I created a new type of goal called a Negative Goal, meant to represent bad habits. Completing this goal reduces your total points.
Similar to bad habits, this goal is not completed after one time, but each time that the bad habit is done, the points will be reduced.  
*/
class Program
{
    static void Main(string[] args)
    {   int points = 0;
        string userResponse = "";
        string fileName;
        List<Goal> goals = new List<Goal>();
        while(userResponse.ToLower() != "quit" && userResponse != "6"){
            Console.Clear();
            Console.WriteLine($"Points: {points}");
            Console.WriteLine("Menu:\n1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Complete Goal\n6. Quit");
            userResponse = Console.ReadLine();
            Console.Clear();
            switch(userResponse){
                case "1":
                    Console.WriteLine("Would you like to make a...\n1. Simple Goal\n2. Checklist Goal\n3. Eternal Goal\n4. Negative Goal\n5. Return to menu");
                    userResponse = Console.ReadLine();
                    Console.Clear();
                    switch(userResponse){
                        case"1":goals.Add(new Goal());break;
                        case"2":goals.Add(new ChecklistGoal());break;
                        case"3":goals.Add(new EternalGoal());break;
                        case"4":goals.Add(new NegativeGoal());break;
                        default:break;
                    }
                    break;
                case "2":
                    foreach(Goal goal in goals){
                        goal.DisplayGoal();
                        
                    }
                    Console.WriteLine("Hit Enter to continue");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Please input a file name: ");
                    fileName = Console.ReadLine();
                    using(StreamWriter outputFile = new StreamWriter(fileName)){
                        outputFile.WriteLine(points);
                        foreach(Goal goal in goals){
                        outputFile.WriteLine(goal.SaveGoal());
                        }
                    }
                    break;
                case "4":
                    Console.Write("Please input a file name: ");
                    fileName = Console.ReadLine();
                    string[] l = System.IO.File.ReadAllLines(fileName);
                    List<string> lines = new List<string>();
                        foreach(string line in l){
                            lines.Add(line);
                        }
                        points = int.Parse(lines[0]);
                        lines.RemoveAt(0);
                        foreach(string line in lines){
                            string[] sublines = line.Split("~");
                            if(sublines[0] == ""){
                                goals.Add(new Goal(sublines[1]));
                            }
                            else if(sublines[0] == "+"){
                                goals.Add(new EternalGoal(sublines[1]));
                            }
                            else if(sublines[0] == "-"){
                                goals.Add(new NegativeGoal(sublines[1]));
                            }
                            else{
                                goals.Add(new ChecklistGoal(sublines[0], sublines[1]));
                            }
                        }
                    break;
                case "5":
                    int i = 1;
                    foreach(Goal goal in goals){
                        Console.Write($"{i}. ");
                        goal.DisplayGoal();
                        i++;
                    }
                    Console.Write("\nWhich Goal would you like to complete? ");
                    points += goals[int.Parse(Console.ReadLine())-1].CompleteGoal();
                    break;
                case "6":Console.WriteLine("Goodbye");break;
                default:Console.WriteLine("Invalid response, please try again");break;
            }
        }
    }
}