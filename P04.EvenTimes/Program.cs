namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integersCount = int.Parse(Console.ReadLine());
            Dictionary<int, bool> numbers = new Dictionary<int, bool>();

            for (int i = 0; i < integersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, false);
                }
                else
                {
                    numbers[number] = !numbers[number];
                }
            }

            foreach (var number in numbers)
            {
                if (number.Value == true)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}