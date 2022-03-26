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
            int s = 0;
            int fretNr = Convert.ToInt32(fingerPosition.FretNr);
            RootNotes endNote = new RootNotes();

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
            rootNotes.Add(RootNotes.C2);
            rootNotes.Add(RootNotes.Cs2);
            rootNotes.Add(RootNotes.D2);
            rootNotes.Add(RootNotes.Ds2);
            rootNotes.Add(RootNotes.E2);
            rootNotes.Add(RootNotes.F2);
            rootNotes.Add(RootNotes.Fs2);
            rootNotes.Add(RootNotes.G2);
            rootNotes.Add(RootNotes.Gs2);
            rootNotes.Add(RootNotes.A2);
            rootNotes.Add(RootNotes.As2);
            rootNotes.Add(RootNotes.B2);
            rootNotes.Add(RootNotes.C3);
            rootNotes.Add(RootNotes.Cs3);
            rootNotes.Add(RootNotes.D3);
            rootNotes.Add(RootNotes.Ds3);
            rootNotes.Add(RootNotes.E3);
            rootNotes.Add(RootNotes.F3);
            rootNotes.Add(RootNotes.Fs3);
            rootNotes.Add(RootNotes.G3);
            rootNotes.Add(RootNotes.Gs3);
            rootNotes.Add(RootNotes.A3);
            rootNotes.Add(RootNotes.As3);
            rootNotes.Add(RootNotes.B3);

            if (musicString.Tuning == rootNotes[0])
            {
                endNote = rootNotes[fretNr];        
            }
            else
            {
                List<RootNotes> removedNotes = new List<RootNotes>();

                for (int i = 0; i < rootNotes.Count; i++)
                {
                    if (musicString.Tuning == rootNotes[i])
                    {
                        s = Convert.ToInt32(rootNotes[i]);
                    }
                }
                for (int i = 0;i < s; i++)
                {
                    removedNotes.Add(rootNotes[i]);
                }
                for (int i = 0; i < s; i++)
                {
                    rootNotes.RemoveAt(i);
                }
                rootNotes.AddRange(removedNotes);
                endNote = rootNotes[fretNr];
            }

            return endNote;
        }

    }

    

    
}
