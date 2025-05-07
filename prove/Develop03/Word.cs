class Word
{
    private string _word;
    private bool _wordNotCleared;
    private int _wordLength;
    public Word(string word)
    { //constructor, requires you to pass it a string when new instance is created
        _word = word;
        _wordNotCleared = true;
        _wordLength = _word.Length;
    }
    public void ClearWord()
    { // creates a string of "_" the length of the original word
        _word = new String('_', _wordLength);
        _wordNotCleared = false;
    }
    public bool GetWordNotCleared()
    { //returns true if the word is not cleared yet
        if (_wordNotCleared) { return true; }
        else { return false; }
    }
    public string GetWord()
    { //returns word
        return _word;
    }
}