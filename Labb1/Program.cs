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
        Console.WriteLine("Please input a random string of numbers and letters.");
        string input = Console.ReadLine();
        
        IndexedString indexedString = new IndexedString(input);

        indexedString.PrintAndColor();
        Console.WriteLine($"Total sum of numbers marked in red: {indexedString.TotalSum()}");
        
    }
}