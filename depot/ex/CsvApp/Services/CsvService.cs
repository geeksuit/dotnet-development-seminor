using System.Collections.Generic;
using System.IO;
using CsvApp.Models;

namespace CsvApp.Services
{
    public static class CsvService
    {
        public static List<Member> Read(string filePath)
        {
            var data = new List<Member>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length != 3)
                {
                    continue;
                }
                
                if (int.TryParse(values[1], out int age) && bool.TryParse(values[2], out bool isRemote))
                {
                    var item = new Member
                    {
                        Name = values[0],
                        Age = age,
                        IsRemote = isRemote
                    };
                    data.Add(item);
                }
                else
                {
                    continue;
                }
            }

            return data;
        }

        public static void Write(string filePath, List<Member> data)
        {
            var lines = new List<string>();

            foreach (var item in data)
            {
                lines.Add($"{item.Name},{item.Age},{item.IsRemote}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}