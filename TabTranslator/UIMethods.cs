using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

        public static int TopSongSelected()
        {
            Console.WriteLine("Enter the number of the song");
            int songNum = Int32.Parse(Console.ReadLine()); 
            Console.Clear();
            return songNum;

        }
        public static void TopSongInvalidInput()
        {
            Console.WriteLine("Number is invalid, press any key to continue");
            Console.ReadKey();
            Console.Clear();
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
