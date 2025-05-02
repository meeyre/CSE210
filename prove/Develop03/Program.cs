using System;
using System.IO;
using System.Security.Cryptography.X509Certificates; 
/*
EXCEEDING REQUIREMENTS:
Included with this file is a library of scriptures (book of mormon doctrinal mastery) in a text file. 
This program randomly selects a scripture from the file and desplays it to the user, for memorization. 
*/
class Word
{
    private string _word;
    private bool _wordNotCleared;
    private int _wordLength;
    public Word(string word){ //constructor, requires you to pass it a string when new instance is created
        _word = word; 
        _wordNotCleared = true;
        _wordLength = _word.Length;
    }
    public void ClearWord(){ // creates a string of "_" the length of the original word
        _word = new String( '_', _wordLength);
        _wordNotCleared = false;
    }
    public bool GetWordNotCleared(){ //returns true if the word is not cleared yet
        if(_wordNotCleared){return true;}
        else{return false;}
    }
    public string GetWord(){ //returns word
        return _word;
    }
}
class Scripture
{
    private List<Word> _words = new List<Word>();
    private string _scriptureText;
    private Refrence _scriptureRefrence;
    private Random _rnd = new Random();
    public Scripture(string refrence, string text){ //constructor, creates word list and reference
        _scriptureText = text;
        CreateWords();
        _scriptureRefrence = new Refrence(refrence);
    }
    public string GetScripture(){
        _scriptureText = ""; // clears the scripture variable
        foreach(Word word in _words){ // adds each word back (some might be cleared now)
            
            _scriptureText = _scriptureText + word.GetWord() + " ";
        }
        return $"{_scriptureRefrence.ReturnRefrence()}\n{_scriptureText}";
    }
    public void ClearRandomWords(){ 
        KillIfAllWordsCleared(); // ends program
        int i = 0;
        while(i<3){ //removes 3 words (and keeps going till 3 are removed if duplicates are chosen)
            if(CheckIfAllWordsCleared()){ // if less than 3 words are left, it will only remove the ones that are left
                break;
            }
            int x = _rnd.Next(0,_words.Count);
            if (_words[x].GetWordNotCleared()){ //checks if a word is cleared
                _words[x].ClearWord(); //if not, it clears it
                i+=1;
            }

        }
    }
    private void KillIfAllWordsCleared(){ //kills program if all words are cleared
        bool check = true;
        foreach(Word word in _words){
            if(word.GetWordNotCleared()){
                check = false;
            }
        }
        if(check){
            Environment.Exit(1);
        }
        
    }
    private bool CheckIfAllWordsCleared(){ // duplicate of above function but it just doesn't kill, just returns true if all words are cleared
        bool check = true;
        foreach(Word word in _words){
            if(word.GetWordNotCleared()){
                check = false;
            }
        }
        return check;
    }
    private void CreateWords(){ // Splits the scripture text into word strings, and makes Word instances out of them 
        string[] wArray = _scriptureText.Split(" ");
        foreach( string w in wArray){
            _words.Add(new Word(w));
        }
    }
}
class Refrence // Takes a scripture refrence string, splits it up into a bunch of parts, and it can return it back as a string 
{
    private string _book;
    private int _chapter;
    private List<int> _verses = new List<int>();

    public Refrence(string refText){ // splits up the refrence and makes a list of all the parts
        char[] splitters = [ ' ', ':'];
        string[] refSplit = refText.Split(splitters);
        List<string> rList = new List<string>();
        foreach(string text in refSplit){
            rList.Add(text);
        }
        int garbage = 0; // there is probably a more effecent way to do this but I don't know what it is
        if(int.TryParse(rList[0], out garbage)){ //checks if the first part is a number ( like "1" nephi) to add it to the book
            rList[0] = rList[0] +' '+ rList[1]; 
            rList.RemoveAt(1);
        }

        _book = rList[0];
        _chapter = int.Parse(rList[1]);
        if(rList[2].Contains('–')){ // NOTE!! (very important) this (–) thing is different than the one on the keyboard (-), no idea where 
            string[] vSplit = rList[2].Split('–');// gospel library got it from. If you want to use the test scripture, you'll have to change
            for(int i = int.Parse(vSplit[0]); i<=int.Parse(vSplit[1]); i++){ // both of them otherwise it will break
                _verses.Add(i);
            }
        }
        else{
            _verses.Add(int.Parse(rList[2]));
        }
    }
    public string ReturnRefrence(){
        if(_verses.Count >1){
            return $"{_book} {_chapter}:{_verses[0]}-{_verses.Last()}"; //prints the refrence if it has >1 verse
        }
        else{
            return $"{_book} {_chapter}:{_verses[0]}"; // prints the ref if it has 1 verse
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        string filename = "Scriptures.txt"; //turns a file into a list of Scripture instances (see file)
        string[] lines = System.IO.File.ReadAllLines(filename);
        List<Scripture> scriptures = new List<Scripture>();
        for(int i = 0; i <lines.Count(); i+=2){
            scriptures.Add(new Scripture(lines[i], lines[i+1]));
        }
        Random rnd = new Random(); // selects a random scripture
        Scripture s = scriptures[rnd.Next(0, scriptures.Count())];

        //test scripture and ref 
        // Refrence r = new Refrence("Moroni 1:5-9");   
        // Scripture s = new Scripture("1 Nephi 3:7", "I will go and do the things which the Lord hath commanded");

        Console.Clear();
        Console.WriteLine(s.GetScripture()); //writes the original scripture
        while(true){
            
            string input =Console.ReadLine().ToLower();
            if(input == "quit"){
                Environment.Exit(1); //kills if user types quit
            }
            Console.Clear();
            s.ClearRandomWords(); // clears 3 words (or if less than 3 words remain, clears those words)
            Console.WriteLine(s.GetScripture()); // prints the new scripture (parts cleared)

            
        }
        
    }
}