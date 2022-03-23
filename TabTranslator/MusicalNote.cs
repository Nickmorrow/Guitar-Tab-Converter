using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class MusicalNote
    {
        RootNotes RootNote { get; set; }
        int Octave;
        public long Duration16ths;
        public long SongsterrDuration;
        public FingerPosition FingerPosition;

        public static long Get16ths(long SongsterrDuration)
        {
            long Duration16ths = 16 / SongsterrDuration;
            return Duration16ths;
        }

    }

    

    
}
