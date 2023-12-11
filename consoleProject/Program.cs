namespace consoleProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine("Press A to exit.");
        while (Console.ReadKey().Key != ConsoleKey.A)
        {
            Console.WriteLine("Non recognized key. Press A to exit.");
        }

    }
}
