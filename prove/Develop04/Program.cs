using System;
/*
EXCEEDING REQUIREMENTS:
On this assignment, I added a log that keeps track of times users have done each activity. 
The information is kept in a text file, and stored from use to use. 

LOG NOTES:
The Log contains the data of the times that I have run through the program, if you want to start from 
0, set all three numbers in Log.txt to 0, but it will work fine if you don't change the numbers, 
it will just increment them each time you do an activity. 
*/
class Program
{
    static void Main(string[] args)
    {   string fileName = "Log.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        

        string userResponse = "";
        int x = 0;
        Console.Clear();
            int breathe = int.Parse(lines[0]); // read log data
            int reflect = int.Parse(lines[1]);
            int listing = int.Parse(lines[2]);
        
        while(userResponse != "5"){ // menu
            

            Console.WriteLine("Welcome to Mindfulness Program!");
            Console.Write("Menu:\n1. Breathing Activity\n2. Reflecting Activity\n3. Listing Activity\n4. View Activity Log\n5. Quit\n> ");
            userResponse = Console.ReadLine();
            switch(userResponse){
                case "1":
                    Console.Write("How many seconds would you like to do Breathing Activity?\n> ");
                    x = int.Parse(Console.ReadLine());
                    Console.Clear();
                    new BreathingActivity(x).Breathe();
                    breathe++;
                    break;
                case "2":
                    Console.Write("How many seconds would you like to do Reflecting Activity?\n> ");
                    x = int.Parse(Console.ReadLine());
                    Console.Clear();
                    new ReflectingActivity(x).Reflect();
                    reflect++;
                    break;
                case "3":
                    Console.Write("How many seconds would you like to do Listing Activity?\n> ");
                    x = int.Parse(Console.ReadLine());
                    Console.Clear();
                    new ListingActivity(x).DoList();
                    listing++;
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("-----------Welcome to Activity Log!---------------");
                    Console.WriteLine("You have participated in the following activities:\n");
                    Console.WriteLine($"BREATHE: {breathe} times");
                    Console.WriteLine($"REFLECT: {reflect} times");
                    Console.WriteLine($"LIST:    {listing} times\n");
                    Console.WriteLine("Great Job! Hit enter to return to the menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(2000);
                    break;
                default:
                    Console.WriteLine("Invalid Response, please try again");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
            Console.Clear();
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(breathe);
                outputFile.WriteLine(reflect);
                outputFile.WriteLine(listing);
            }
        }
    }
}