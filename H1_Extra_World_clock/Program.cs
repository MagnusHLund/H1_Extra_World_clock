namespace H1_Extra_World_clock
{
    internal class Program
    {
        static void Main()
        {
            // Array containing the 15 cities
            string[] cities =
            {
                "Paris",
                "London",
                "New york",
                "Perth",
                "Santiago",
                "Salt lake city",
                "Copenhagen",
            };

            Console.WriteLine("Pick one or more cities, to see the current time of");
            Console.WriteLine();

            for(int i = 0; i < cities.Length; i++)
            {
                // Changes the color every line between white and dark gray.
                if (i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine($"{i}    {cities[i]}");
            }

            Console.WriteLine();
            string input = Console.ReadLine();

            while (true)
            {
                DateTime timeNow = DateTime.Now;

                Console.Clear();
                Console.WriteLine("Press Esc to exit!");
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }


                //Thread.Start(1000);
            }
        }
    }
}