namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int firstSetLength = setsLength[0];
            int secondSetLength = setsLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}