using CsvApp.Services;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the Csv file.");
            return;
        }

        string filePath = args[0];
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        var data = CsvService.Read(filePath);

        foreach (var item in data)
        {
            item.IsRemote = true;
        }

        CsvService.Write(filePath, data);

        Console.WriteLine("Done!");
    }
}