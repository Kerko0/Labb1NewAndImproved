namespace Labb1;

class Program
{
    static void Main(string[] args)
    {
        new App().Run(args);

    }
}

class App
{
    public void Run(string[] args)
    {
        string input;
        do
        {
            Console.WriteLine("Please input a random string of numbers and letters.");
            input = Console.ReadLine();
            
        } while (string.IsNullOrEmpty(input));
        
        IndexedString indexedString = new IndexedString(input);

        indexedString.PrintAndColor();
        Console.WriteLine($"Total sum of numbers marked in red: {indexedString.TotalSum()}");
        
    }
}