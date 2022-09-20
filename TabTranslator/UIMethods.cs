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

        public static int TopSongSelected(List<AppJson> TopSongJson, StringCollection TopSearchedSongs)
        {           
            int songNum = 0;
            bool inputIsValid = false;
            string input = "";
            while (!inputIsValid)
            {
                int counter = 0;
                foreach (AppJson A in TopSongJson)
                {
                    Console.WriteLine($"{counter + 1}. {TopSongJson[counter].meta.current.artist}-{TopSongJson[counter].meta.current.title}");
                    counter++;
                }                       
                Console.WriteLine("Enter the number of the song");
                input = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(input, out songNum))
                {
                    if (songNum > TopSongJson.Count() || songNum < 1)
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
        public static int GetTrackIndex(AppJson appJson)
        {
            Console.WriteLine($"Tracks:{appJson.meta.current.tracks.Count().ToString()}");
            Console.WriteLine("Select track");
            int trackIndex = Int32.Parse(Console.ReadLine());
            return trackIndex;
        }
    }
}
