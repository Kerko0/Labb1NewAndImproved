long sum = 0;
string input;

do
{
    Console.WriteLine("Please input a random string of numbers and letters.");
    input = Console.ReadLine();
            
} while (string.IsNullOrEmpty(input));

for (int i = 0; i < input.Length; i++)
{
    char numToMatch =  input[i];
    string substringToSearch = input.Substring(i+1, input.Length-i-1);
            
    int matchingNumIndexOf = substringToSearch.IndexOf(numToMatch);
    if (matchingNumIndexOf != -1)
    {
        int startIndex = i;
        int length = matchingNumIndexOf + 2;
                
        if (input.Substring(startIndex, length).Any(Char.IsLetter))
        {
            continue;
        }
                
        for (int j = 0; j < input.Length; j++)
        {
            if (Enumerable.Range(startIndex, length).Contains(j))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(input[j]);
        }
        
        Console.WriteLine();
        
        sum += Convert.ToInt64(input.Substring(startIndex, length));      
    }
}

Console.WriteLine($"Sum of all numbers marked in red: {sum}");