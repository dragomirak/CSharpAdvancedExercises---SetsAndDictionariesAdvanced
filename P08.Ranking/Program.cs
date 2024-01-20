namespace P08.Ranking
{
    internal class Program
    {
        class Intern
        {
            public Intern(string name)
            {
                Name = name;
                Contests = new Dictionary<string, int>();
            }

            public string Name { get; set; }
            public Dictionary<string, int> Contests { get; set; }


        }
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            List<Intern> interns = new List<Intern>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestsData = input.Split(":");
                string contestName = contestsData[0];
                string contestPassword = contestsData[1];
                contests.Add(contestName, contestPassword);
            }

            string data;
            while ((data= Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = data.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    continue;
                }
                else
                {
                    if (!interns.Any(i => i.Name == username))
                    {
                        Intern intern = new Intern(username);
                        interns.Add(intern);
                    }
                    else
                    {
                        Intern currentIntern = interns.FirstOrDefault(i => i.Name == username);
                        if (points > currentIntern.Contests[contest])
                        {
                            currentIntern.Contests[contest] = points;
                        }
                    }
                    
                }
                
            }

            Console.WriteLine(string.Join(" ", interns));
        }
    }
}