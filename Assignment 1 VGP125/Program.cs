namespace SimpleGame
{
    class StartPage
    {
        static void Main(string[] args)
        {
            string playerName;

            Console.WriteLine("██╗    ██╗███████╗ ██████╗██╗      ██████╗ ███╗   ███╗███████╗");
            Console.WriteLine("██║    ██║██╔════╝██╔════╝██║     ██╔═══██╗████╗ ████║██╔════╝");
            Console.WriteLine("██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  ");
            Console.WriteLine("██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("╚███╔███╔╝███████╗╚██████╗███████╗╚██████╔╝██║ ╚═╝ ██║███████╗");
            Console.WriteLine(" ╚══╝╚══╝ ╚══════╝ ╚═════╝╚══════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝");
            Console.WriteLine("                    ▄▄▄█████▓ ▓█████  ");
            Console.WriteLine("                    ▓  ██▓ ▓▓▓██   ██▓");
            Console.WriteLine("                      ▓██▓   ▓██   ██▓");
            Console.WriteLine("                      ▓██▓   ▓██   ██▓");
            Console.WriteLine("                      ▓██    ▓ ████▓▓▓");
            Console.WriteLine("                      ▓ ▓    ▓ ▓▓▓▓▓▓ ");
            Console.WriteLine("                        ▓      ▓ ▓  ▓ ");
            Console.WriteLine("                      ▓          ▓  ▓ ");
            Console.WriteLine("                 ██████╗ ██████╗ ███████╗");
            Console.WriteLine("                 ██╔══██╗██╔══██╗██╔════╝");
            Console.WriteLine("                 ██████╔╝██████╔╝███████╗");
            Console.WriteLine("                 ██╔══██╗██╔═══╝ ╚════██║");
            Console.WriteLine("                 ██║  ██║██║     ███████║");
            Console.WriteLine("                 ╚═╝  ╚═╝╚═╝     ╚══════╝");
            Console.Write("\nPlease enter player name: ");
            playerName = Console.ReadLine();
            Console.Clear(); //Clear screen

            //Console.Write("Enter your score: ");
            //string scoreInput = Console.ReadLine();
            //try
            //{
            //    playerScore = int.Parse(scoreInput); //To show and test Data Parsing
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Invalid input");
            //    playerScore = 0;
            //}

            GameCore game = new GameCore(playerName);
            game.Menu();
        }
    }

    class GameCore
    {
        private string playerName;
        private int playerScore;
        private bool gameRunning;

        public GameCore(string name)
        {
            playerName = name;
            playerScore = 0;
            gameRunning = true;
        }

        public void Menu()
        {
            while (gameRunning)
            {
                Console.WriteLine("=========Game Menu=========");
                Console.WriteLine("1. Start Game!");
                Console.WriteLine("2. Exit the Game");
                Console.WriteLine("===========================");
                string playerChoice = Console.ReadLine();

                if (playerChoice == "1")
                {
                    Console.Clear();
                    StartGame();
                }
                else if (playerChoice == "2")
                {
                    Console.WriteLine("Thank you for playing!");
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }

            }
        }

        private void StartGame()
        {
            Random random = new Random();

            Console.WriteLine("Weclome to Rock paper scissors!");
            while (gameRunning)
            {
                Console.WriteLine("\n===========================");
                Console.WriteLine("Please select: \n1. Rock \n2. Scissors \n3. Paper " +
                    "\n4. Exit the game");
                Console.WriteLine("===========================");
                string playerChoice = Console.ReadLine();
                int computerChoice = random.Next(1, 4); //range between 1-3

                if (playerChoice == "4")
                {
                    Console.WriteLine("Thank you for playing!");
                    gameRunning = false;
                    break;
                }

                string computerChoiceStr = ConvertChoiceToString(computerChoice);
                string result = DetermineWinner(playerChoice, computerChoiceStr);

                Console.WriteLine($"The computer player chose: {computerChoiceStr}");
                //$ means String Interpolation. Auto place the selection
                Console.WriteLine(result);

                if (result.Contains("Win!"))
                {
                    playerScore++;
                }
                else if (result.Contains("Lose!"))
                {
                    playerScore--;
                }

                Console.WriteLine($"{playerName}'s Current Score: {playerScore}");
            }
        }

        static string ConvertChoiceToString(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Scissors";
                case 3:
                    return "Paper";
                default:
                    return "You shouldn't see this";
            }
        }

        static string DetermineWinner(string playerChoice, string computerChoiceStr)
        {
            string playerChoiceStr = ConvertChoiceToString(int.Parse(playerChoice));

            if (playerChoiceStr == computerChoiceStr)
            {
                return "Tie!";
            }

            if ((playerChoice == "1" &&  computerChoiceStr == "Scissors") ||
                (playerChoice == "2" && computerChoiceStr == "Paper") ||
                (playerChoice == "3" && computerChoiceStr == "Rock"))
            {
                return "Win!";
            }
            else
            {
                return "Lose!";
            }
        }
    }
}