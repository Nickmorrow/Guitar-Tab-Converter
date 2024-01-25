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

        public RootNotes ConvertMidiNum(long midiNum)
        {
            int convertedNum = Convert.ToInt32(midiNum);

            List<RootNotes> midiNotes = new List<RootNotes>();

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.Gs);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.As);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.Cs);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.Ds);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.Fs);
            midiNotes.Add(RootNotes.G);

            RootNotes midiNote = RootNotes.C;

            for (int i = 0; i < midiNotes.Count; i++)
            {

                if (convertedNum == i)
                {
                    midiNote = midiNotes[i];
                }
            }

            return midiNote;
        }

        public long? GetStringNr(SongsterrSong Song, List<MusicString> musicStrings, long? ogStringNr)
        {
            long? endStringNr = null;
            long? stringNr = null;
            List<long?> stringNrs = new List<long?>();
            RootNotes midiNote;
            List<RootNotes> convertedMidiNotes = new List<RootNotes>();

            for (int sT = 0; (sT < Song.Tuning.Count()); sT++) //converts original tuning midi numbers to rootnotes
            {
                midiNote = ConvertMidiNum(Song.Tuning[sT]);
                convertedMidiNotes.Add(midiNote);
                stringNr = Convert.ToInt64(sT);
                stringNrs.Add(stringNr);
            }
            for (int mT = 0; (mT < musicStrings.Count()); mT++)//sorts through new instrument tuning and checks if string tuning is the same as guitar, if so it will replace the guitar string number with the new instrument string number
            {
                MusicString musicString = new MusicString();
                musicString = musicStrings[mT];
                for(int cM = 0; (cM < convertedMidiNotes.Count()); cM++) //changes numbers in stringnumber list
                {
                    if (musicString.Tuning == convertedMidiNotes[cM])
                    {

                        stringNrs[mT] = cM;
                        
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; (i < stringNrs.Count()); i++)
            {
                if ( ogStringNr == i)
                {
                    endStringNr = stringNrs[i];
                }
                else
                {
                    endStringNr = ogStringNr;
                    
                }
                if (endStringNr > 3)
                {
                    endStringNr = endStringNr - 2;
                }
            }
            return endStringNr;
        }

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
