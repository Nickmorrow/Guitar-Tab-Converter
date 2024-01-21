using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace TabTranslator
{
    public class UIMethods
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to TabConverter");
        }
        public static bool TopSearchedYN()
        {
            Console.WriteLine("\nPress S to see the top searched tabs, press any other key to search for a tab ");
            bool topSearched = Console.ReadKey().Key == ConsoleKey.S;            
            Console.Clear();
            return topSearched;
        }
        public static bool SearchOrExit(List<AppJson> SongJson)
        {
            int counter = 0;
            foreach (AppJson A in SongJson)
            {
                Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");
                counter++;
            }
            Console.WriteLine("\nPress Enter to move on to selection, press any other key to exit");
            bool moveOn = Console.ReadKey().Key == ConsoleKey.Enter;
            Console.Clear();
            return moveOn;

        }
        public static int SongSelected(List<AppJson> SongJson, List<string> SearchedSongs)
        {           
            int songNum = 0;
            bool inputIsValid = false;
            string input = "";
            while (!inputIsValid)
            {
                int counter = 0;
                foreach (AppJson A in SongJson)
                {
                    Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");
                    counter++;
                }                       
                Console.WriteLine("\nEnter the number of the song");
                input = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(input, out songNum))
                {
                    if (songNum > SongJson.Count() || songNum < 1)
                    {
                        Console.WriteLine("Number exceeds songs in list, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        inputIsValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Number is invalid, press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }                             
            }                       
            Console.Clear();
            return songNum;
        }

        public static string UserSearchInput()
        {
            Console.WriteLine("Enter an artist, song title, or key word to search for tabs");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        public static void NoSearchResults()
        {
            Console.WriteLine("No results found, press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


        public static int GetTrackIndex(AppJson appJson)
        {
            int counter = 0;
            Console.WriteLine("Enter the number of a track\n");
            foreach (Track T in appJson.meta.current.tracks)
            {
                counter++;
                if (T.isBassGuitar || T.isGuitar)
                {
                    Console.WriteLine($"{counter}. {T.instrument}-{T.name}");
                }
            }
            int trackIndex = Int32.Parse(Console.ReadLine());
            Console.Clear();
            return trackIndex;
        }

        public static void ContinueOrExit(bool isOpen)
        {
            Console.WriteLine("Press Enter to continue searching, press any other key to exit");
            isOpen = Console.ReadKey().Key == ConsoleKey.Enter;
            Console.Clear();
            
        }

        public static bool ConvertYorN()
        {
            bool answered = false;
            bool isYes = false;
            while (!answered)
            {
                Console.WriteLine("Would you like to convert this tab to another instrument? y/n");
                string answer = Console.ReadLine().ToUpper();
                Console.Clear();
                if (answer == "N")
                {
                    answered = true;  
                }
                if (answer == "Y")
                {
                    isYes = true;
                    answered = true;
                }
                else
                {
                    continue;
                }                               
            }
            return isYes;
        }

        public static StringInstrument InstChoice(List<StringInstrument> StringInstruments)
        {
            StringInstrument InstChoice = StringInstruments[0];
            int counter = 0;
            List<int> instNumList = new List<int>();
            bool InstNumInList;
            int instNum;
            bool choiceMade = false;
            while (!choiceMade)
            {
                Console.WriteLine("Enter the number of an Instrument \n");

                foreach (StringInstrument S in StringInstruments)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {S.Name}");
                    instNumList.Add(counter);
                }
                //Console.WriteLine("\nIf you would like to go back, Press Esc");
                //bool goBack = Console.ReadKey().Key == ConsoleKey.Escape;
                //if (goBack)
                //{
                //    break;
                //}
                instNum = Int32.Parse(Console.ReadLine())-1;
                if (instNumList.Contains(instNum))
                {
                    InstChoice = StringInstruments[instNum];
                    choiceMade = true;
                }
                else
                {
                    continue;
                }
                Console.Clear();
            }
            return InstChoice;
        }
    }
}
