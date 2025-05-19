using System;
using System.IO;
/*
INTRO:
This program uses all 4 aspects of Object Orented Programing

Abstraction: 
In this program, abstraction is shown by having all of the code wrapped into methods, so that the programmer when creating the menu, 
does not need to know how any of the functions work to use them, only the parameters and the output. An example of this that I used 
quite extensivly is the GetFloatInput() method. This program needed to be able to get a float input from the console quite often, and 
C# does not have a built in funtion to my knowledge that handles that. So in my expenditure parent class, I built one that later on in
the program, I did not need to remember the code, only that it takes a prompt as a parameter and returns a float as the output.

Encaputalation:
In this program, all member variables are private, set and provided using getters and setters. This is key for the Polymorphism section,
as those getter and setter methods had to change for different types of expendatures so that the cost variable could be set in different 
ways, depending on the data provided. 

Inheretance:
In this program, 5 different types of expneditures are child classes of the Expenditure class, folling the "is-a" rule. This allows the vast
majority of the code to be written only once in the Expenditure class, with only specifics needing to be written in the derrived classes.

Polymorphism:
There are 5 different kinds of expenditures, and each is claculated differently, however each has a cost, and some have a value while others have
a value of 0. So, by overriding the getters and setters, as well as the display funtions, allowing all of the differnet kinds of expendatures to 
function together in a list. 
*/
class Program
{

    static void Main(string[] args)
    {
        
        Farm f = new Farm();
        string fileName;
        string userResponse = "";
        while (userResponse != "6")
        {
            Console.Clear();
            Console.WriteLine("Farm Calculator");
            Console.WriteLine("Menu:\n1. New Expendature\n2. View Report\n3. Save Data\n4. Load Data\n5. Quit");
            userResponse = Console.ReadLine();
            Console.Clear();
            switch (userResponse) // menu
            {
                case "1":
                    Console.WriteLine("What type of expenditure?\n1. Crop\n2. Livestock\n3. Labor\n4. Equiptment\n5. Living Expenses");
                    userResponse = Console.ReadLine();
                    Console.Clear();
                    switch (userResponse) // menu to generate different kinds of expendatures
                    {
                        case "1": f.AddExpenditure(new Crop()); break;
                        case "2": f.AddExpenditure(new LiveStock()); break;
                        case "3": f.AddExpenditure(new Labor()); break;
                        case "4": f.AddExpenditure(new Equiptment()); break;
                        case "5": f.AddExpenditure(new LivingExpenses()); break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Expenditures\nDisplayed from most profitable to least profitable:\n");
                    f.DisplayAll(); // call display all
                    Console.Write("Hit Enter to Continune: ");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Plese input a filename: ");
                    fileName = Console.ReadLine();
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        foreach (string line in f.SaveData()) //funtion that displays the class data in a saveable format
                        {
                            outputFile.WriteLine(line);
                        }
                    }
                    break;
                case "4":
                    f.ClearList();
                    Console.Write("Plese input a filename: ");
                    fileName = Console.ReadLine();
                    string[] lines = System.IO.File.ReadAllLines(fileName);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(",");
                        switch (parts[0])
                        {
                            case "1": f.AddExpenditure(new Crop(parts[1],parts[2],parts[3])); break;
                            case "2": f.AddExpenditure(new LiveStock(parts[1],parts[2],parts[3])); break;
                            case "3": f.AddExpenditure(new Labor(parts[1],parts[2],parts[3])); break;
                            case "4": f.AddExpenditure(new Equiptment(parts[1],parts[2],parts[3])); break;
                            case "5": f.AddExpenditure(new LivingExpenses(parts[1],parts[2],parts[3])); break;
                        }
                    }
                    break;
                case "5": userResponse = "6"; Console.WriteLine("Goodbye"); break;
                default: Console.WriteLine("Invalid Response, please try again"); break;
            }
        }
    }
}