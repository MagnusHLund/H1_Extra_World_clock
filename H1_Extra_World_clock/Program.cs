namespace H1_Extra_World_clock
{
    internal class Program
    {
        static void Main()
        {
            // Runs the Quit method, on another thread
            Task.Run(() => { Quit(); });

            // Array containing the 15 cities
            string[] cities =
            {   "", // Empty string, so user input becomes 1-7, instead of 0-6
                "Paris",
                "London",
                "New york",
                "Perth",
                "Santiago",
                "Salt lake city",
                "Copenhagen",
            };

            // Writes in console and creates a line space
            Console.WriteLine("Pick one or more cities, to see the current time of");
            Console.WriteLine();

            // Makes a char array for user input
            char[] input;

            // Infinite loop, to handle player input
            while (true)
            {
                for (int i = 0; i < cities.Length; i++)
                {
                    // Changes the color every line between white and dark gray.
                    if (i % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    // Skip the empty string, in the array and writes out the rest of the cities, as well as the input to select the city.
                    if (i != 0)
                        Console.WriteLine($"{i}    {cities[i]}");
                }

                //  Creates a space between the cities and user input
                Console.WriteLine();

                // input becomes whatever the user writes, to char array.
                input = Console.ReadLine().ToCharArray();

                // If its not valid characters or if its empty, then output error
                if (!IsValidCharacters(input) || input.Length == 0)
                {
                    // Outputs an error and waits for additional user input to progress. Clears the console and repeats the loop.
                    Console.WriteLine("Only write numbers between 1-7! \npress enter to continue!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                // Breaks out of the while loop, because user input was valid
                break;
            }

            // User input becomes a string with spaces between each char from the input
            string choseCitiesStr = string.Join(" ", input);

            // The string gets split up to ints, inside an int array.
            int[] chosenCities = choseCitiesStr.Split(" ").Select(x => Convert.ToInt32(x)).ToArray();

            // Clears the console
            Console.Clear();

            // Runs an infinite loop
            while (true)
            {
                // Tells the user that they can end the program, by pressing escape.
                Console.WriteLine("Press Esc to exit!");

                // Runs a for loop, as many times as the int array "chosenCities" length
                for (int i = 0; i < chosenCities.Length; i++)
                {
                    // Creates a DateTimeOffset, to figure out the timezone differences
                    DateTimeOffset cityTimeOffset;

                    // Puts each city instead a new string called "location", so its easier to read the following if statement
                    string location = cities[chosenCities[i]].ToString();

                    // Checks the location name, if it matches then create an offset, for the appropriate location
                    if (location == "London")
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/London");
                    else if (location == "New york")
                    {
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Eastern Standard Time");
                    }
                    else if (location == "Perth")
                    {
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "W. Australia Standard Time");
                    }
                    else if (location == "Santiago")
                    {
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Pacific SA Standard Time");
                    }
                    else if (location == "Salt lake city")
                    {
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Central America Standard Time");
                    }
                    else // Else would be "Paris" and "Copenhagen", which share the same timezone
                        cityTimeOffset = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Romance Standard Time");

                    // Puts the offset into a string and then removes the end of it, which shows which timezone its in
                    string remove = cityTimeOffset.ToString();
                    string cityTime = remove.Remove(remove.Length-7, 7);

                    // Displays city name and current time
                    Console.WriteLine($"{cities[chosenCities[i]]}: {cityTime}");
                }

                // The main thread sleeps for 1 second and the console clears
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        static bool IsValidCharacters(char[] input)
        {
            // Creates a string containing each of the allowed characters
            string allowedCharacters = "1234567";

            // Runs through each character in the user input
            foreach (char c in input)
            {
                // If any of the characters arent 0-9, then it return false
                if (!allowedCharacters.Contains(c.ToString()))
                {
                    return false;
                }
            }

            // If the foreach finishes, then it returns true
            return true;
        }

        static void Quit()
        {
            // Always reads the keys pressed
            ConsoleKeyInfo info = Console.ReadKey(true);
            
            // Checks if the key pressed is the Escape key
            if (info.Key == ConsoleKey.Escape)
            {
                // Quits the program
                Environment.Exit(0);
            }
        }
    }
}