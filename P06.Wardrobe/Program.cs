using System;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new();

            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(" -> ");
                string color = data[0];
                string[] items = data[1].Split(",");

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in items)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 1);
                    }
                    else
                    {
                        clothes[color][item]++;
                    }
                }
            }

            string[] clothToFind = Console.ReadLine().Split(" ");
            string clothColor = clothToFind[0];
            string cloth = clothToFind[1];

            foreach (var (color, dresses) in clothes)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (dress, number) in dresses)
                {
                    if (cloth == dress && clothColor == color)
                    {
                        Console.Write($"* {dress} - {number} (found!)");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"* {dress} - {number}");
                    }
                }
            }
        }
    }
}