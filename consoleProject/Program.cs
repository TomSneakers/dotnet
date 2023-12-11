namespace consoleProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of values separated by commas:");

        // Lecture des valeurs à partir de l'entrée standard
        string input = Console.ReadLine() ?? string.Empty;

        // Séparation des valeurs en utilisant la virgule comme séparateur
        string[] valueStrings = input.Split(',');

        // Conversion des valeurs en objets et ajout à la liste
        List<object> values = new List<object>();
        foreach (string valueString in valueStrings)
        {
            if (int.TryParse(valueString, out int intValue))
            {
                values.Add(intValue);
            }
            else
            {
                Console.WriteLine("Invalid value: " + valueString);
            }
        }

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