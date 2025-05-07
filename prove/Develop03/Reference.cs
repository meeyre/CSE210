class Reference // Takes a scripture refrence string, splits it up into a bunch of parts, and it can return it back as a string 
{
    private string _book;
    private int _chapter;
    private List<int> _verses = new List<int>();

    public Reference(string refText)
    { // splits up the refrence and makes a list of all the parts
        char[] splitters = [' ', ':'];
        string[] refSplit = refText.Split(splitters);
        List<string> rList = new List<string>();
        foreach (string text in refSplit)
        {
            rList.Add(text);
        }
        int garbage = 0; // there is probably a more effecent way to do this but I don't know what it is
        if (int.TryParse(rList[0], out garbage))
        { //checks if the first part is a number ( like "1" nephi) to add it to the book
            rList[0] = rList[0] + ' ' + rList[1];
            rList.RemoveAt(1);
        }

        _book = rList[0];
        _chapter = int.Parse(rList[1]);
        if (rList[2].Contains('–'))
        { // NOTE!! (very important) this (–) thing is different than the one on the keyboard (-), no idea where 
            string[] vSplit = rList[2].Split('–');// gospel library got it from. If you want to use the test scripture, you'll have to change
            for (int i = int.Parse(vSplit[0]); i <= int.Parse(vSplit[1]); i++)
            { // both of them otherwise it will break
                _verses.Add(i);
            }
        }
        else
        {
            _verses.Add(int.Parse(rList[2]));
        }
    }
    public string ReturnRefrence()
    {
        if (_verses.Count > 1)
        {
            return $"{_book} {_chapter}:{_verses[0]}-{_verses.Last()}"; //prints the refrence if it has >1 verse
        }
        else
        {
            return $"{_book} {_chapter}:{_verses[0]}"; // prints the ref if it has 1 verse
        }
    }
}