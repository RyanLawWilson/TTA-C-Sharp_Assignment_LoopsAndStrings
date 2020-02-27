using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LoopsAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int globalDelayFactor = 100;     // Change how fast the program runs.  More than 100 = slower, Less than 100 = faster
            //I could have also made a delay method..

            /* 1. Create a one-dimensional Array of strings. Ask the user to input some text.
             *    Create a loop that goes through each string in the Array, adding the user’s text to the string.
             *    Then create a loop that prints off each string in the Array on a separate line. */
            string[] names = { "Bob", "Karen", "Ryan", "Joey" };
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            /* 5. Create a loop where the comparison used to determine whether to continue iterating the loop is a “<=” operator. */
            for (int i = 0; i <= names.Length - 1; i++)
            {
                names[i] += " " + lastName;
            }

            Console.WriteLine("I found some of your siblings!");
            foreach (string person in names)
            {
                Console.WriteLine(person);
                System.Threading.Thread.Sleep(2 * globalDelayFactor);
            }

            System.Threading.Thread.Sleep(10 * globalDelayFactor);

            /* 2. Create an infinite loop. */
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (true)
            {
                if (stopWatch.ElapsedMilliseconds < 5 * globalDelayFactor)
                {
                    Console.WriteLine("Oh no, we are in an infinite loop!");
                    System.Threading.Thread.Sleep(100);
                }
                else if (stopWatch.ElapsedMilliseconds < 20 * globalDelayFactor)
                {
                    Console.WriteLine("I'll fix the loop in 5 seconds!");
                    System.Threading.Thread.Sleep(1 * globalDelayFactor);
                }
                else
                {
                    /* 3. Fix the infinite loop so it will execute */

                    /* 4. Create a loop where the comparison used to determine whether to continue iterating the loop is a “<” operator. */
                    for (int i = 5; 0 < i; i--)
                    {
                        Console.WriteLine(i);
                        System.Threading.Thread.Sleep(10 * globalDelayFactor);
                    }
                    break;
                }
            }

            Console.WriteLine("That was close!  We were in that loop for " + ((float)stopWatch.ElapsedMilliseconds) / 1000 + " seconds.");
            stopWatch.Stop();

            System.Threading.Thread.Sleep(5 * globalDelayFactor);
            Console.WriteLine("Back to regularly scheduled programming...");
            System.Threading.Thread.Sleep(5 * globalDelayFactor);

            /* 6. Create a List of strings where each item in the list is unique. Ask the user to input text to search for in the List.
             *    Create a loop that iterates through the loop and then displays the index of the array that contains matching text on the screen.*/
            List<string> yourAmiibos = new List<string>() {
                "Link", "Jigglypuff", "King Dedede",
                "Zelda", "Pikachu", "Kirby",
                "Donkey Kong", "Marth", "Lucina",
                "Cloud", "Ganondorf", "Greninja" };

            bool invalidAmiibo = true;
            while (invalidAmiibo)
            {
                printFancyList(yourAmiibos, "Your Amiibos");

                Console.Write("I see that you have an Amiibo collection... What Amiibo is your favorite?  ");
                string amiibo = Console.ReadLine();
                int amiiboPosition = yourAmiibos.IndexOf(amiibo);

                // If a valid index (0 - length) is acquired, write it's position to the console.
                if (amiiboPosition >= 0)
                {
                    /* 8.Add code to that above loop that stops it from executing once a match has been found. */
                    invalidAmiibo = false;
                    Console.WriteLine("That Amiibo is in position " + amiiboPosition + " of the list\n");
                }
                else
                {
                    /* 7. Add code to that above loop that tells a user if they put in text that isn’t in the List. */
                    Console.WriteLine("You don't have an Amiibo called " + amiibo);
                }
            }

            System.Threading.Thread.Sleep(10 * globalDelayFactor);
            Console.WriteLine("Here is my list of amiibos");
            System.Threading.Thread.Sleep(5 * globalDelayFactor);

            /* 9. Create a List of strings that has at least two identical strings in the List. Ask the user to
             *    select text to search for in the List. Create a loop that iterates through the loop and then
             *    displays the indices of the array that contain matching text on the screen.*/
            List<string> myAmiibos = new List<string>() {
                "Link", "Link", "King Dedede",
                "Jigglypuff", "King Dedede", "King Dedede",
                "Jigglypuff", "Marth", "Jigglypuff",
                "Cloud", "King Dedede", "Jigglypuff" };

            invalidAmiibo = true;
            while (invalidAmiibo)
            {
                printFancyList(myAmiibos, "My Amiibos");

                Console.Write("Search for an Amiibo in my list!  ");
                string amiibo = Console.ReadLine();
                
                // Initializing variables
                List<int> amiiboIndecies = new List<int>();
                int currentIndex = 0;
                int amiiboPosition;

                // Keep checking for the Amiibo until we can't find any more of them.
                do
                {
                    amiiboPosition = myAmiibos.IndexOf(amiibo, currentIndex);
                    if (amiiboPosition >= 0)
                    {
                        currentIndex = amiiboPosition;
                        amiiboIndecies.Add(currentIndex);
                        currentIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true);

                // If there is an index in the List, write it and exit the loop.
                if (amiiboIndecies.Count > 0)
                {
                    invalidAmiibo = false;
                    Console.Write("That Amiibo is in position ");

                    // This for loop just makes the sentence structure for two or more Amiibos.
                    if (amiiboIndecies.Count >= 2)
                    {
                        for (int i = 0; i < amiiboIndecies.Count; i++)
                        {
                            if (i == amiiboIndecies.Count - 1)
                            {
                                Console.Write("and " + amiiboIndecies[i]);
                            }
                            else if (i == amiiboIndecies.Count - 2)
                            {
                                Console.Write(amiiboIndecies[i] + " ");
                            }
                            else
                            {
                                Console.Write(amiiboIndecies[i] + ", ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write(amiiboIndecies[0]);
                    }
                    
                    Console.WriteLine(" of the list\n");
                }
                else
                {
                    /* 10. Add code to that above loop that tells a user if they put in text that isn’t in the List. */
                    Console.WriteLine("You don't have an Amiibo called " + amiibo);
                }
            }

            System.Threading.Thread.Sleep(5 * globalDelayFactor);
            Console.WriteLine("This time I'll go through this list and see if there are any duplicates.");
            System.Threading.Thread.Sleep(10 * globalDelayFactor);

            /* 11. Create a List of strings that has at least two identical strings in the List. Create a foreach
             *     loop that evaluates each item in the list, and displays a message showing the string and whether
             *     or not it has already appeared in the list. */
            List<string> moreAmiibos = new List<string>() {
                "Link", "Zelda", "Ganon", "Samus", "Fox McCloud", "Sonic",
                "Dark Samus", "Zelda", "Ike", "Cloud Strife", "Mr. Game & Watch", "Midna",
                "Link", "Link", "King Dedede", "Jigglypuff", "King Dedede", "King Dedede",
                "Jigglypuff", "Marth", "Jigglypuff", "Cloud", "King Dedede", "Jigglypuff",
                "Link", "Jigglypuff", "King Dedede", "Zelda", "Kirby", "Kirby",
                "Donkey Kong", "Marth", "Lucina", "Cloud", "Ganondorf", "Greninja"};

            printFancyList(moreAmiibos, "Another Amiibo List");
            System.Threading.Thread.Sleep(5 * globalDelayFactor);

            Console.Write("Beginning Search... in ");
            // Countdown
            for (int i = 5; 0 < i; i--)
            {
                Console.Write(i + " ");
                System.Threading.Thread.Sleep(10 * globalDelayFactor);
            }
            Console.WriteLine();

            // Set's cannot contain duplicates.  I'm using this fact and the size of the set before and after
            // to determine if an Amiibo is already in the List.
            HashSet<string> testingSet = new HashSet<string>();     
            int lengthBefore, lengthAfter;      // The length of the set before and after I add the amiibo.
            foreach (string amiibo in moreAmiibos)
            {
                Console.Write(amiibo);

                lengthBefore = testingSet.Count;
                testingSet.Add(amiibo);
                lengthAfter = testingSet.Count;

                // Just for spacing
                if (amiibo.Length <= 6)
                {
                    Console.Write("\t\t");
                }
                if (amiibo.Length > 6 && amiibo.Length <= 12)
                {
                    Console.Write("\t");
                }

                // If the set didn't increase in size, the amiibo that was added was a duplicate.
                if (lengthBefore == lengthAfter)
                {
                    Console.Write("\tALREADY APPEARED      | duplicate\n");
                }
                // If the set grew, the amiibo is unique.
                else
                {
                    Console.Write("\tIs in your collection | unique\n");
                }

                System.Threading.Thread.Sleep(2 * globalDelayFactor);
            }

            Console.WriteLine("\nHave a nice day!");
            Console.ReadLine();
        }

        // Prints a table that represents the List
        static void printFancyList(List<string> items, string title)
        {
            Console.WriteLine("\n" + title.ToUpper());

            int maxSpacing = items[0].Length;   // Set maxSpacing to first element temporarily
            int missingSpacing;         // The spaces that need to be added to make the table flush.
            int columns = 4;           // The number of collumns per row.  Can be changed.

            // Find the longest string in the List to be the spacing.
            foreach (string item in items)
            {
                if (item.Length > maxSpacing)
                {
                    maxSpacing = item.Length + 2;
                }
            }

            // Make a row of =================
            for (int s = 0; s < maxSpacing * columns + 8; s++)
            {
                Console.Write("=");
            }
            Console.WriteLine();

            // Prints the List to the console.
            for (int i = 0; i < items.Count; i++)
            {
                missingSpacing = maxSpacing - items[i].Length;
                Console.Write("| " + items[i]);
                if (missingSpacing > 0)
                {
                    for (int j = 0; j < missingSpacing; j++)
                    {
                        Console.Write(" ");
                    }
                }

                // Every fourth iteration, make a new line
                if (i % columns == columns - 1)
                {
                    Console.WriteLine("|");
                }
            }

            // Make a row of =================
            for (int s = 0; s < maxSpacing * columns + 8; s++)
            {
                Console.Write("=");
            }
            Console.WriteLine("\n");
        }
    }
}
