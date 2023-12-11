﻿namespace consoleProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("test function sum");

        // Création d'une liste de valeurs pour tester la fonction Sum
        List<object> values = new List<object> { 1, 2, 3, new List<object> { 4, 5 }, 6 };

        // Appel de la fonction Sum avec la liste de valeurs
        int result = Sum(values);

        // Affichage du résultat à l'écran
        Console.WriteLine("Sum: " + result);

        Console.WriteLine("Press A to exit.");
        while (Console.ReadKey().Key != ConsoleKey.A)
        {
            Console.WriteLine("Non recognized key. Press A to exit.");
        }

    }

    public static int Sum(IEnumerable<object> values)
    {
        int sum = 0;
        foreach (var value in values)
        {
            switch (value)
            {
                case 0:
                    break;
                case int val:
                    sum += val;
                    break;
                case IEnumerable<object> subList when subList.Any():
                    sum += Sum(subList);
                    break;

            }
        }
        return sum;
    }
}