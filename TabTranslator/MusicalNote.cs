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

            List<RootNotes> rootnotesOct1 = new List<RootNotes>();
            rootnotesOct1.Add(RootNotes.C);
            rootnotesOct1.Add(RootNotes.Cs);
            rootnotesOct1.Add(RootNotes.D);
            rootnotesOct1.Add(RootNotes.Ds);
            rootnotesOct1.Add(RootNotes.E);
            rootnotesOct1.Add(RootNotes.F);
            rootnotesOct1.Add(RootNotes.Fs);
            rootnotesOct1.Add(RootNotes.G);
            rootnotesOct1.Add(RootNotes.Gs);
            rootnotesOct1.Add(RootNotes.A);
            rootnotesOct1.Add(RootNotes.As);
            rootnotesOct1.Add(RootNotes.B);

            List<RootNotes> rootnotesOct2 = new List<RootNotes>();
            rootnotesOct2.Add(RootNotes.C2);
            rootnotesOct2.Add(RootNotes.Cs2);
            rootnotesOct2.Add(RootNotes.D2);
            rootnotesOct2.Add(RootNotes.Ds2);
            rootnotesOct2.Add(RootNotes.E2);
            rootnotesOct2.Add(RootNotes.F2);
            rootnotesOct2.Add(RootNotes.Fs2);
            rootnotesOct2.Add(RootNotes.G2);
            rootnotesOct2.Add(RootNotes.Gs2);
            rootnotesOct2.Add(RootNotes.A2);
            rootnotesOct2.Add(RootNotes.As2);
            rootnotesOct2.Add(RootNotes.B2);

            List<RootNotes> rootnotesOct3 = new List<RootNotes>();
            rootnotesOct3.Add(RootNotes.C3);
            rootnotesOct3.Add(RootNotes.Cs3);
            rootnotesOct3.Add(RootNotes.D3);
            rootnotesOct3.Add(RootNotes.Ds3);
            rootnotesOct3.Add(RootNotes.E3);
            rootnotesOct3.Add(RootNotes.F3);
            rootnotesOct3.Add(RootNotes.Fs3);
            rootnotesOct3.Add(RootNotes.G3);
            rootnotesOct3.Add(RootNotes.Gs3);
            rootnotesOct3.Add(RootNotes.A3);
            rootnotesOct3.Add(RootNotes.As3);
            rootnotesOct3.Add(RootNotes.B3);

            if (musicString.Tuning == rootnotesOct1[0])
            {
                endNote = rootnotesOct1[fretNr];        
            }
            else
            {

                List<RootNotes> removedNotes = new List<RootNotes>();

                for (int i = 0; i < rootnotesOct1.Count; i++)
                {
                    if (musicString.Tuning == rootnotesOct1[i])
                    {
                        s = Convert.ToInt32(rootnotesOct1[i]);
                        break;
                    }
                    
                }
                for (int i = 0;i < s; i++)
                {
                    removedNotes.Add(rootnotesOct1[i]);
                }
                for (int i = 0; i < s; i++) //removing incorrect notes!!
                {
                    rootnotesOct1.RemoveAt(0);

                }
                for (int i = 0;i < removedNotes.Count(); i++)
                {
                    rootnotesOct1.Add(removedNotes[i]);
                }
                //rootNotes.AddRange(removedNotes);
                endNote = rootnotesOct1[fretNr];
            }

            return endNote;
        }

    }

    

    
}
