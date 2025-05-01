using System;
using System.IO;

/*
EXCEEDING REQUIREMENTS:
I felt like the prompts were good, but when I was testing my program I didn't feel like answering the
prompts was actually journaling. So, I added some extra elements to my Entry class, so in each entry the 
user would need to respond to 3 extra questons about events in the morning, noon, and night, so that
they could actually doccument their day a bit. I then modified the Save, Load, and Display functions so 
that the new responses and static prompts would be displayed correctly along with the original prompt. 
*/

class PromptGenerator //This class is used to generate a random prompt for the journal entry
{
    public List<String> _prompts = new List<string> { //List of random prompts
        "Take a task that you’ve been dreading and break it up into the smallest possible steps.",
        "The world would be a lot better if..",
        "Think about the last time you cried. How did it make you feel?",
        "What are some small things that other people have done that really make your day?",
        "What do you need to give yourself more credit for?",
        "Is it ever okay to lie? Why do you think so?",
        "If and when I raise children, I'll never..",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"};
    public string ReturnRandomPrompt() //returns a random prompt from the above list
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }
}

class Entry //instances are individual journal entries
{
    public string _journalEntry; // stored user entry
    public string _journalPrompt; // stored prompt

    // Every entry will respond to these 3 questions, and their responses will be stored below
    public string _morningPrompt = "What was one memorable event this morning?"; 
    public string _morning;
    public string _noonPrompt = "What was one memorable event around midday today?";
    public string _noon;
    public string _nightPrompt = "What was one memorable event this evening?";
    public string _night;
    public DateTime _theCurrentTime = DateTime.Now; // contains the date at the time when the entry is created

    public PromptGenerator _promptsinstance = new PromptGenerator(); //creates an instance of PromptGenerator to be used

    public void DisplayRandomPrompt(){ // Uses Promptgenerator and saves the result in _journalPrompt, as well as printing it to the user
        _journalPrompt = _promptsinstance.ReturnRandomPrompt();
        Console.WriteLine($"{_journalPrompt}");
    }
    
    public string GetEntry(){ //Gets and returns user input
        Console.Write(">>");
        return Console.ReadLine();
    }
}
class Journal
{
    public List<Entry> _unsavedEntries = new List<Entry>(); //List of all unsaved Entries, when loading entries from a file this list is cleared
    public List<string> _loadedEntries = new List<string>(); //List of strings loaded from file
    public string _fileName; //filename variable to be used
    

    public Entry NewEntry(){ //creates instance of Entry, displays prompts, gets, and saves user input
        Entry entryInstance = new Entry();
        entryInstance.DisplayRandomPrompt();
        entryInstance._journalEntry = entryInstance.GetEntry();
        Console.WriteLine(entryInstance._morningPrompt);
        entryInstance._morning = entryInstance.GetEntry();
        Console.WriteLine(entryInstance._noonPrompt);
        entryInstance._noon = entryInstance.GetEntry();
        Console.WriteLine(entryInstance._nightPrompt);
        entryInstance._night = entryInstance.GetEntry();
        return entryInstance;
    }
    public void Display(){ // prints loaded and unsaved entries to console
        foreach (string line in _loadedEntries){
            Console.WriteLine(line);
        }
        foreach (Entry jEntry in _unsavedEntries){
            Console.WriteLine($"\n{jEntry._theCurrentTime.ToShortDateString()}\n{jEntry._journalPrompt}\n>>{jEntry._journalEntry}");
            Console.WriteLine($"{jEntry._morningPrompt}\n>>{jEntry._morning}\n{jEntry._noonPrompt}\n>>{jEntry._noon}");
            Console.WriteLine($"{jEntry._nightPrompt}\n>>{jEntry._night}\n");
        }
    }
    public void Save(){ // Appends each entry to a file
        Console.Write("Pleae input a filename: ");
        _fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(_fileName, true)){
            foreach (Entry _jEntry in _unsavedEntries){
                outputFile.WriteLine(_jEntry._theCurrentTime.ToShortDateString());
                outputFile.WriteLine(_jEntry._journalPrompt);
                outputFile.WriteLine(">>"+_jEntry._journalEntry);
                outputFile.WriteLine(_jEntry._morningPrompt);
                outputFile.WriteLine(">>"+_jEntry._morning);
                outputFile.WriteLine(_jEntry._noonPrompt);
                outputFile.WriteLine(">>"+_jEntry._noon);
                outputFile.WriteLine(_jEntry._nightPrompt);
                outputFile.WriteLine(">>"+_jEntry._night);
                outputFile.WriteLine();
            }
        }
    }
    public void Load(){ //Reads the file into _loadedEntries
        Console.Write("Pleae input a filename: ");
        _fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach(string line in lines){
            _loadedEntries.Add(line);
        }
        _unsavedEntries.Clear();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Journal userJournal = new Journal();
        string userResponse = "";
        while (userResponse.ToLower() != "quit" && userResponse != "5"){ //menu
            Console.WriteLine("Plese choose a menu option: ");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            userResponse = Console.ReadLine();

            switch (userResponse){

                case "1":
                    userJournal._unsavedEntries.Add(userJournal.NewEntry());
                    break;
                case "2":
                    userJournal.Display();
                    break;
                case "3":
                    userJournal.Load();
                    break;
                case "4":
                    userJournal.Save();
                    break;
                case "5":
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid response, please try again.");
                    break;
            }

        }
    }
}