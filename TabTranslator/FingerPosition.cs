using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class FingerPosition
    {
        //RootNotes Note;
        public long? StringNum;
        public long? FretNr;

        public long? GetFretNr(MusicString musicString, long? ogFretNr)
        {
            int index = 0;
            long? fretNr = null;

            if (ogFretNr != null)
            {
                List<RootNotes> notes = new List<RootNotes>();
                notes.Add(RootNotes.C);
                notes.Add(RootNotes.Cs);
                notes.Add(RootNotes.D);
                notes.Add(RootNotes.Ds);
                notes.Add(RootNotes.E);
                notes.Add(RootNotes.F);
                notes.Add(RootNotes.Fs);
                notes.Add(RootNotes.G);
                notes.Add(RootNotes.Gs);
                notes.Add(RootNotes.A);
                notes.Add(RootNotes.As);
                notes.Add(RootNotes.B);
                notes.Add(RootNotes.C);
                notes.Add(RootNotes.Cs);
                notes.Add(RootNotes.D);
                notes.Add(RootNotes.Ds);
                notes.Add(RootNotes.E);
                notes.Add(RootNotes.F);
                notes.Add(RootNotes.Fs);
                notes.Add(RootNotes.G);
                notes.Add(RootNotes.Gs);
                notes.Add(RootNotes.A);
                notes.Add(RootNotes.As);
                notes.Add(RootNotes.B);
                notes.Add(RootNotes.B);
                notes.Add(RootNotes.C);
                notes.Add(RootNotes.Cs);
                notes.Add(RootNotes.D);
                notes.Add(RootNotes.Ds);
                notes.Add(RootNotes.E);
                notes.Add(RootNotes.F);
                notes.Add(RootNotes.Fs);
                notes.Add(RootNotes.G);
                notes.Add(RootNotes.Gs);
                notes.Add(RootNotes.A);
                notes.Add(RootNotes.As);
                notes.Add(RootNotes.B);

                List<RootNotes> removedNotes = new List<RootNotes>();

                if (musicString.Tuning == notes[0] && ogFretNr == 0)
                {
                    fretNr = 0;
                }
                else
                {
                    for (int noteNum = 0; noteNum < notes.Count; noteNum++)
                    {
                        if (musicString.Tuning == notes[noteNum])
                        {
                            index = Convert.ToInt32(notes[noteNum]);
                            break;
                        }
                    }
                    for (int i = 0; i < index; i++)
                    {
                        removedNotes.Add(notes[i]);
                    }
                    for (int i = 0; i < index; i++) //removing incorrect notes!!
                    {
                        notes.RemoveAt(0);

                    }
                    for (int i = 0; i < removedNotes.Count(); i++)
                    {
                        notes.Add(removedNotes[i]);
                    }
                    for (int i = 0; i < notes.Count; i++)
                    {
                        if (musicString.Tuning == notes[i])
                        {
                            fretNr = Convert.ToInt64(notes[i]);
                        }
                    }
                }

            }
            return fretNr;
        }
    }

    
}
