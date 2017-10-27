using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExampleGroup
{
    public class Player
    {
        Guid _id;
        private int xp;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Xp
        {
            get { return xp; }
            set { xp = value; }
        }


        public Guid Id
        {
            get { return _id; }

            set { _id = value; }
        }

        public int MyProperty { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", this.Id, this.Name, this.Xp);
        }
    }


    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player {Id = Guid.NewGuid(), Name = "Peter Parker", Xp=100 },
            new Player {Id = Guid.NewGuid(), Name = "John Smith", Xp=50 },
            new Player {Id = Guid.NewGuid(), Name = "Pat Johnson", Xp=170 }
        };

        static void Main()
        {
            Player found = players.FirstOrDefault(p => p.Name == "Peter Parker");
            if(found != null)
                Console.WriteLine("{0}", found.ToString());
            else
                Console.WriteLine("Not found");

            Console.WriteLine();

            //Return first occurence of the same records
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Peter"));
            if (found != null)
                Console.WriteLine("First found: {0}", found1.ToString());
            else
                Console.WriteLine("Not found");


            Console.WriteLine();

            // Return all those with XP of over 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if(topPlayers.Count > 0)
                foreach (var item in topPlayers)
                    Console.WriteLine("{0}", item.ToString());
            else
                Console.WriteLine("No match found");


            Console.WriteLine("\n*** Top Scorers ***");

            // Produce a scoreboard of Player names and scores
            var ScoreBoard = players.OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in ScoreBoard)
                Console.WriteLine("{0,-15} {1,-15}", item.Name, item.Xp);



            Console.ReadKey();
        }
    }   
    
}
