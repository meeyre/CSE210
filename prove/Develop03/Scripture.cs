class Scripture
{
    private List<Word> _words = new List<Word>();
    private string _scriptureText;
    private Reference _scriptureRefrence;
    private Random _rnd = new Random();
    public Scripture(string refrence, string text){ //constructor, creates word list and reference
        _scriptureText = text;
        CreateWords();
        _scriptureRefrence = new Reference(refrence);
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