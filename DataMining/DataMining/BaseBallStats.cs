using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DataMining
{

    public class BaseBallPlayer : IEquatable<BaseBallPlayer>, IComparable<BaseBallPlayer>
    {

        public string PlayerId { set; get; }
        public string Year { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Team { set; get; }
        public string League { set; get; }

        public int gamesPlayed { set; get; }
        public int points { set; get; }

        public float efficiency { set; get; }
        public int mintues { set; get; }
        public BaseBallPlayer()
        {

        }
        public BaseBallPlayer(string PlayerId, string Year, string FirstName, string LastName, string Team, string League, int gamesPlayed, int points, float efficiency, int mintues)
        {
            this.PlayerId = PlayerId;
            this.Year = Year;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Team = Team;
            this.League = League;
            this.gamesPlayed = gamesPlayed;
            this.points = points;
            this.efficiency = efficiency;
            this.mintues = mintues;

        }

        public override bool Equals(object otherObject)
        {
            if (Object.ReferenceEquals(null, otherObject)) return false;
            if (Object.ReferenceEquals(this, otherObject)) return true;

            if (this.GetType() != otherObject.GetType()) return false;

            BaseBallPlayer otherPlayer = otherObject as BaseBallPlayer;

            return isEqual(otherPlayer);

        }




        private bool isEqual(BaseBallPlayer otherPlayer)
        {
            return (this.PlayerId == otherPlayer.PlayerId && this.efficiency == otherPlayer.efficiency);
        }





        public bool Equals(BaseBallPlayer otherPlayer)
        {
            if (Object.ReferenceEquals(null, otherPlayer)) return false;
            if (Object.ReferenceEquals(this, otherPlayer)) return true;
            return isEqual(otherPlayer);

        }

        public override int GetHashCode()
        {
            int hash = 23;
            hash = this.efficiency.GetHashCode() * hash + this.PlayerId.GetHashCode() * hash;
            return hash;

        }


        public int CompareTo(BaseBallPlayer otherPlayer)
        {
            if (this.efficiency == otherPlayer.efficiency)
                return 0;
            else if (this.efficiency > otherPlayer.efficiency)
                return 1;
            else
                return -1;
        }


    }


    /*----------------------------------------------------------------------------------------------------------------------------*/
    class BaseBallStats
    {

        static void Main(string[] args)
        {
            string directoryPath = getDirectory(args);

            if (string.IsNullOrEmpty(directoryPath)) exitProgram("Data Source folder not specified ");


            printMessage("Enter FileName", ConsoleColor.Green);

            string fileName = Console.ReadLine();

            if (invalidFileName(fileName)) exitProgram("FileName not specified ");

            string path = Path.Combine(directoryPath, fileName);

            printMessage("input file name :" + path, ConsoleColor.Magenta);


            List<BaseBallPlayer> playersList = GetBaseBallPlayersList(path);

            //Print the efficiency of top 50 players 

            PlayersWithMaxEfficiency(playersList);

            //Print top 5 players with highest mintues
            PlayerswithMostMintues(playersList);
            //Print top 5  players with maximum games played
            PlayersWithMaxGamesPlayed(playersList);
            //Print top 5  players with total points
            PlayersWithMostPoints(playersList);

            Console.WriteLine("End of Program");
            Console.ReadKey();
        }

        
       

        private static void PlayersWithMaxEfficiency(List<BaseBallPlayer> playersList)
        {
            int size = playersList.Count() > 50 ? 50 : playersList.Count();
            var topNList = playersList.Select(p => p).OrderByDescending(p => p);

            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            printMessage(String.Format("{0,-20}{1,-15}{2,-15}{3,-10}{4,-15}{5,-15}", "Player Name", "GamesPlayed", "Year", "Team", "Efficiency", "Mintues"),
                         ConsoleColor.Green);

            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);

            foreach (BaseBallPlayer player in topNList.Take(size))
                printMessage(String.Format("{0,-20}{1,-15}{2,-15}{3,-10}{4,-15}{5,-15}", player.FirstName + " " + player.LastName,
                                             player.gamesPlayed, player.Year, player.Team, player.efficiency, player.mintues), ConsoleColor.Yellow);

            //printMessage(String.Empty.PadRight(120, '*'), ConsoleColor.White);
        }

        private static void PlayerswithMostMintues(List<BaseBallPlayer> playersList)
        {
            //LINQ query that uses group by 
            var player_MaxMintues = (from player in playersList
                                     group player.mintues by new { player.PlayerId, player.LastName, player.FirstName } into p
                                     select new
                                     {
                                         playerId = p.Key.PlayerId,
                                         playerLastName = p.Key.LastName,
                                         playerFirstName = p.Key.FirstName,
                                         totalmintues = p.Sum()
                                     }).Where(p => p.totalmintues > 0).OrderByDescending(p => p.totalmintues).ToList();


            int size = player_MaxMintues.Count() > 5 ? 5 : player_MaxMintues.Count();
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            printMessage(String.Format("{0,-20}{1,-30}{2,-15}", "Player's LastName", "Player's FirstName", "Total Mintues"), ConsoleColor.Green);
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            foreach (var item in player_MaxMintues.Take(size))
            {
                Console.WriteLine("{0,-20}{1,-30}{2,-15}", item.playerLastName, item.playerFirstName, item.totalmintues);
            }

        }


        private static void PlayersWithMaxGamesPlayed(List<BaseBallPlayer> playersList)
        {
            var players_MaxGames = (from player in playersList
                                    group player.gamesPlayed by new { player.PlayerId, player.LastName, player.FirstName } into p
                                    select new
                                    {
                                        playerId = p.Key.PlayerId,
                                        playerLastName = p.Key.LastName,
                                        playerFirstName = p.Key.FirstName,
                                        totalGames = p.Sum()
                                    }
                                         ).Where(p => p.totalGames > 0).OrderByDescending(p=>p.totalGames);

            int size = players_MaxGames.Count() > 5 ? 5 : players_MaxGames.Count();
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            printMessage(String.Format("{0,-20}{1,-30}{2,-30}", "Player's LastName", "Player's FirstName", "Total GamesPlayed"), ConsoleColor.Green);
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            foreach (var item in players_MaxGames.Take(size))
            {
                Console.WriteLine("{0,-20}{1,-30}{2,-30}", item.playerLastName, item.playerFirstName, item.totalGames);
            }
        }


        private static void PlayersWithMostPoints(List<BaseBallPlayer> playersList)
        {
            var players_MostPoints = (from player in playersList
                                    group player.points by new { player.PlayerId, player.LastName, player.FirstName } into p
                                    select new
                                    {
                                        playerId = p.Key.PlayerId,
                                        playerLastName = p.Key.LastName,
                                        playerFirstName = p.Key.FirstName,
                                        totalPoints = p.Sum()
                                    }
                                        ).Where(p => p.totalPoints > 0).OrderByDescending(p => p.totalPoints);

            int size = players_MostPoints.Count() > 5 ? 5 : players_MostPoints.Count();
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            printMessage(String.Format("{0,-20}{1,-30}{2,-30}", "Player's LastName", "Player's FirstName", "Total Points"), ConsoleColor.Green);
            printMessage(String.Empty.PadRight(120, '-'), ConsoleColor.White);
            foreach (var item in players_MostPoints.Take(size))
            {
                Console.WriteLine("{0,-20}{1,-30}{2,-30}", item.playerLastName, item.playerFirstName, item.totalPoints);
            }
        }


        private static List<BaseBallPlayer> GetBaseBallPlayersList(string path)
        {
            string line = default(string);
            List<BaseBallPlayer> playersList = new List<BaseBallPlayer>();
            using (FileStream inputStream = File.OpenRead(path))
            using (TextReader inputReader = new StreamReader(inputStream))
            {



                while ((line = inputReader.ReadLine()) != null)
                {
                    if (line.IndexOf("ilkid,year,firstname", StringComparison.OrdinalIgnoreCase) != -1)
                        continue;

                    string[] tokens = line.Split(',');

                    int gamesplayed = getInteger(tokens[6]);


                    int mintues = getInteger(tokens[7]);
                    int pts = getInteger(tokens[8]);
                    int oreb = getInteger(tokens[9]);
                    int dreb = getInteger(tokens[10]);
                    int reb = getInteger(tokens[11]);
                    int asts = getInteger(tokens[12]);
                    int stl = getInteger(tokens[13]);
                    int blk = getInteger(tokens[14]);
                    int turnover = getInteger(tokens[15]);

                    int pf = getInteger(tokens[16]);
                    int fga = getInteger(tokens[17]);
                    int fgm = getInteger(tokens[18]);
                    int fta = getInteger(tokens[19]);
                    int ftm = getInteger(tokens[20]);
                    int tpa = getInteger(tokens[21]);
                    int tpm = getInteger(tokens[22]);

                    float efficiency = gamesplayed != 0 ? (pts + reb + asts + stl + blk) - ((fga - fgm) + (fta - ftm) + turnover) / gamesplayed : 0;
                    playersList.Add(new BaseBallPlayer(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], gamesplayed, pts, efficiency, mintues));

                }

            }

            return playersList;

        }

        private static int getInteger(string token)
        {
            int outValue = 0;
            if (int.TryParse(token, out outValue))
                return outValue;
            else
                return default(int);
        }

        private static void exitProgram(string message)
        {
            printMessage(message, ConsoleColor.Red);
            Console.ReadKey();
            Environment.Exit(1);
        }

        private static string getDirectory(string[] args)
        {
            if (validArguments(args))
            {
                return args[0];
            }
            else
            {
                return string.Empty;
            }

        }

        private static bool invalidFileName(string fileName)
        {
            return string.IsNullOrEmpty(fileName);
        }

        private static bool validArguments(string[] args)
        {
            if (args.Length == 0)
            {

                printMessage("Data Source folder not specified ", ConsoleColor.Red);

                return false;
            }
            return true;
        }

        private static void printMessage(string message)
        {

            Console.WriteLine(message);
        }
        private static void printMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
