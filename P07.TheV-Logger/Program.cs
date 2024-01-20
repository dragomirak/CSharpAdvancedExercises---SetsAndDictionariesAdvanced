using System;
using System.Linq;

namespace P07.TheV_Logger
{
    class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Following = new List<string>();
            Followers = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Following { get; set; }
        public List<string> Followers { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ");
                string vloggerName = tokens[0];
                string action = tokens[1];
                string secondVlogger = tokens[2];

                if (action == "joined")
                {
                    if (vloggers.Any(v => v.Name == vloggerName) == true)
                    {
                        continue;
                    }
                    else
                    {
                        Vlogger vlogger = new Vlogger(vloggerName);
                        vloggers.Add(vlogger);
                    }
                }
                else if (action == "followed")
                {
                    if (vloggers.Any(v => v.Name == vloggerName) == false ||
                        vloggers.Any(v => v.Name == secondVlogger) == false)
                    {
                        continue;
                    }
                    else
                    {
                        Vlogger currentVlogger = vloggers.FirstOrDefault(v => v.Name == vloggerName);
                        if (vloggerName == secondVlogger || currentVlogger.Following.Contains(secondVlogger))
                        {
                            continue;
                        }
                        else
                        {
                            currentVlogger.Following.Add(secondVlogger);
                        }

                        Vlogger actionedVlogger = vloggers.FirstOrDefault(v => v.Name == secondVlogger);
                        actionedVlogger.Followers.Add(vloggerName);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            List<Vlogger> orderedVloggers = vloggers.OrderByDescending(v => v.Followers.Count).ThenBy(v => v.Following.Count).ToList();

            Console.WriteLine($"1. {orderedVloggers[0].Name} : {orderedVloggers[0].Followers.Count} followers, {orderedVloggers[0].Following.Count} following");
            if (orderedVloggers[0].Followers.Count > 0)
            {
                var orderedFollowers = orderedVloggers[0].Followers.OrderBy(f => f).ToList();
                foreach (var v in orderedFollowers)
                {
                    Console.WriteLine($"*  {v}");
                }
            }

            orderedVloggers.Remove(orderedVloggers[0]);
            int count = 2;
            foreach (var v in orderedVloggers)
            {
                Console.WriteLine($"{count}. {v.Name} : {v.Followers.Count} followers, {v.Following.Count} following");
                count++;
            }
        }
    }
}