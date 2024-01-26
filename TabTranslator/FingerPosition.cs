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

        public FingerPosition GetFingerPos(SongsterrSong Song, List<MusicString> musicStrings, long? ogStringNr, long ogFretNr) // * change method to find string that has lowest fret number for note
        {
            long? stringNr = null;
            List<long?> stringNrs = new List<long?>();
            RootNotes midiNote;
            RootNotes ogTuning = 0;
            RootNotes targetNote = 0;
            List<RootNotes> ogTunings = new List<RootNotes>();
            FingerPosition fingerPos = new FingerPosition();
            List<FingerPosition> fingerPositions = new List<FingerPosition>();

            if (ogFretNr != null)
            {               
                for (int sT = 0; (sT < Song.Tuning.Count()); sT++) //converts original tuning midi numbers to rootnotes
                {
                    midiNote = ConvertMidiNum(Song.Tuning[sT]);
                    ogTunings.Add(midiNote);
                    stringNr = Convert.ToInt64(sT);
                    stringNrs.Add(stringNr);
                }

                for (int ogTuningIndex = 0; ogTuningIndex < ogTunings.Count; ogTuningIndex++) // gets tuning note of original string number
                {
                    if (ogStringNr == ogTuningIndex)
                    {
                        ogTuning = ogTunings[ogTuningIndex];
                    }
                }
                List<RootNotes> notes = new List<RootNotes>();
                List<RootNotes> removedNotes = new List<RootNotes>();

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

                for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++) // rearranges list of notes to start at original tuning 
                {
                    if (ogTuning == notes[notesIndex])
                    {
                        break;
                    }
                    else
                    {
                        removedNotes.Add(notes[notesIndex]);
                        notes.RemoveAt(notesIndex);
                    }
                }
                for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++) // finds target note 
                {
                    if (notesIndex == ogFretNr)
                    {
                        targetNote = notes[notesIndex];
                    }
                }
                for (int tuningNum = 0; tuningNum < musicStrings.Count(); tuningNum++) // finds fretnr for each string in new instrument with target note
                {
                    fingerPositions.Add(fingerPos);
                    fingerPositions[tuningNum].StringNum = tuningNum;
                    for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++)
                    {
                        if (musicStrings[notesIndex].Tuning == notes[notesIndex]) // rearranges notes list to start at new instrument tuning
                        {
                            break;
                        }
                        else
                        {
                            removedNotes.Add(notes[notesIndex]);
                            notes.RemoveAt(notesIndex);
                        }
                    }
                    for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++) // finds fretnr to arrive at target note
                    {
                        if (targetNote == notes[notesIndex])
                        {
                            fingerPositions[tuningNum].FretNr = notesIndex;
                        }
                    }
                }
                for (int fp = 0; fp < fingerPositions.Count; fp++) // finds finger position with lowest fretnr eliminates the rest
                {
                    for (int i = 0; i < fingerPositions.Count; i++)
                    {
                        if (fingerPositions[fp].FretNr < fingerPositions[i].FretNr)
                        {
                            fingerPositions.RemoveAt(i);
                        }
                    }
                }
                for (int fp = 0; fp < fingerPositions.Count; fp++)  // removes duplicates and prioritizes lowest string number
                {
                    for (int i = 0; i < fingerPositions.Count; i++)
                    {
                        if (fingerPositions[fp].StringNum < fingerPositions[i].StringNum)
                        {
                            fingerPositions.RemoveAt(i);
                        }
                    }
                }
                fingerPos = fingerPositions[0];
            }
            else
            {
                fingerPos.StringNum = null;
                fingerPos.FretNr = null;
            }
            return fingerPos;
        }
    }
}     
