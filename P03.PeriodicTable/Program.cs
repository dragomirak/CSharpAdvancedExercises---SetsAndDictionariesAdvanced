namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in input)
                {
                    elements.Add(s);
                }
                                 
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}