namespace Labb1;

public class IndexedString
{
    private readonly string _inputString;
    private readonly List<Index> _indexes = new List<Index>();
    
    public IndexedString (string input)
    {
        _inputString = input;
        
        for (int i = 0; i < _inputString.Length; i++)
        {
            char currentChar =  _inputString[i];
            string substringToSearch = _inputString.Substring(i+1, _inputString.Length-i-1);
            
            int matchingCharIndexOf = substringToSearch.IndexOf(currentChar);
            if (matchingCharIndexOf != -1)
            {
                int startIndex = i;
                int length = matchingCharIndexOf + 2;
                
                if (_inputString.Substring(startIndex, length).Any(Char.IsLetter))
                {
                    continue;
                }
                
                _indexes.Add(new Index(startIndex, length));
            }
        }
    }

    public void PrintAndColor()
    {
        foreach (var index in _indexes)
        {
            for (int i = 0; i < _inputString.Length; i++)
            {
                
                if (Enumerable.Range(index.Start, index.Length).Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
            
                Console.Write(_inputString[i]);
        
            }
            
            Console.WriteLine();
            
        }
    }
    
    public long TotalSum()
    {
        return _indexes.Sum(index => Convert.ToInt64(_inputString.Substring(index.Start, index.Length)));
    }

    public string GetString()
    {
        return _inputString;
    }

    public List<Index> GetIndexes()
    {
        return _indexes;
    }
}