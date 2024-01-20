namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> charsMap = new SortedDictionary<char, int>();

            foreach (char c in text)
            {
                if (!charsMap.ContainsKey(c))
                {
                    charsMap.Add(c, 0);
                }
                charsMap[c]++;
            }

            foreach (var c in charsMap)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }

        }
    }
}