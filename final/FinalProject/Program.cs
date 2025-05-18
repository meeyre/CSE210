using System;
using System.IO;

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
            switch (userResponse)
            {
                case "1":
                    Console.WriteLine("What type of expenditure?\n1. Crop\n2. Livestock\n3. Labor\n4. Equiptment\n5. Living Expenses");
                    userResponse = Console.ReadLine();
                    Console.Clear();
                    switch (userResponse)
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
                    f.DisplayAll();
                    Console.Write("Hit Enter to Continune: ");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Plese input a filename: ");
                    fileName = Console.ReadLine();
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        foreach (string line in f.SaveData())
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