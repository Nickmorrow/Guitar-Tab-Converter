using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class MusicalNote
    {
        public RootNotes RootNote { get; set; }
        int Octave;
        public long Duration16ths;
        public long SongsterrDuration;
        public FingerPosition FingerPosition = new FingerPosition();

        public static long Get16ths(long SongsterrDuration)
        {
            long Duration16ths = 16 / SongsterrDuration;
            return Duration16ths;
        }

        public static RootNotes GetRootNote(FingerPosition fingerPosition, MusicString musicString)
        {
            List<RootNotes> rootNotes = new List<RootNotes>();
            rootNotes.Add(RootNotes.C);
            rootNotes.Add(RootNotes.Cs);
            rootNotes.Add(RootNotes.D);
            rootNotes.Add(RootNotes.Ds);
            rootNotes.Add(RootNotes.E);
            rootNotes.Add(RootNotes.F);
            rootNotes.Add(RootNotes.Fs);
            rootNotes.Add(RootNotes.G);
            rootNotes.Add(RootNotes.Gs);
            rootNotes.Add(RootNotes.A);
            rootNotes.Add(RootNotes.As);
            rootNotes.Add(RootNotes.B);
            
            for (int i = 0; i < rootNotes.Count; i++)
            {
                if (musicString.Tuning == rootNotes[i])
                {
                    
                }
            }
            
        }

    }

    

    
}
