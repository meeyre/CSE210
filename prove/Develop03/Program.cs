using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
/*
EXCEEDING REQUIREMENTS:
Included with this file is a library of scriptures (book of mormon doctrinal mastery) in a text file. 
This program randomly selects a scripture from the file and desplays it to the user, for memorization. 
*/
class Program
{
    static void Main(string[] args)
    {
        string filename = "Scriptures.txt"; //turns a file into a list of Scripture instances (see file)
        string[] lines = System.IO.File.ReadAllLines(filename);
        List<Scripture> scriptures = new List<Scripture>();
        for (int i = 0; i < lines.Count(); i += 2)
        {
            scriptures.Add(new Scripture(lines[i], lines[i + 1]));
        }
        Random rnd = new Random(); // selects a random scripture
        Scripture s = scriptures[rnd.Next(0, scriptures.Count())];
        //test scripture and ref 
        // Refrence r = new Refrence("Moroni 1:5-9");   
        // Scripture s = new Scripture("1 Nephi 3:7", "I will go and do the things which the Lord hath commanded");
        Console.Clear();
        Console.WriteLine(s.GetScripture()); //writes the original scripture
        Console.Write("Hit the Enter key to continue, or type \"quit\" to quit: ");
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                Environment.Exit(1); //kills if user types quit
            }
            Console.Clear();
            s.ClearRandomWords(); // clears 3 words (or if less than 3 words remain, clears those words)
            Console.WriteLine(s.GetScripture()); // prints the new scripture (parts cleared)
            Console.Write("Hit the Enter key to continue, or type \"quit\" to quit: ");
        }
    }
}