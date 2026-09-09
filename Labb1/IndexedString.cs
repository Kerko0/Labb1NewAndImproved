namespace Labb1;

public class IndexedString
{
    private readonly string _inputString;
    private readonly List<Index> _indexes;
    
    public IndexedString (string input)
    {
        _inputString = input;
        _indexes = IndexString(input);
    }
    
    private List<Index> IndexString(string input)
    {
        List<Index> indexes = new List<Index>();
        
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar =  input[i];
            string substringToSearch = input.Substring(i+1, input.Length-i-1);
            
            int matchingCharIndexOf = substringToSearch.IndexOf(currentChar);
            if (matchingCharIndexOf != -1)
            {
                int startIndex = i;
                int length = matchingCharIndexOf + 2;
                
                if (input.Substring(startIndex, length).Any(Char.IsLetter))
                {
                    continue;
                }
                
                indexes.Add(new Index(startIndex, length));
            }
        }

        return indexes;
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
}