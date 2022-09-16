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
        public static int GetTrackIndex(AppJson appJson)
        {
            Console.WriteLine($"Tracks:{appJson.meta.current.tracks.Count().ToString()}");
            Console.WriteLine("Select track");
            int trackIndex = Int32.Parse(Console.ReadLine());
            return trackIndex;
        }
    }
}
