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
        public int Octave;
        public long Duration16ths;
        public long SongsterrDuration;
        public bool? NullableBoolRest;
        public bool? NullableBoolDead;
        public bool IsRest;
        public bool Dead;
        public FingerPosition FingerPosition = new FingerPosition();
        public List<FingerPosition> FingerPositions; // a list of all possible fingerings for note

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

        public List<FingerPosition> GetFingerPositions(SongsterrSong Song, List<MusicString> musicStrings, long? ogStringNr, long ogFretNr) // * change method to find string that has lowest fret number for note
        {
            long? stringNr = null;
            List<long?> stringNrs = new List<long?>();
            RootNotes midiNote;
            RootNotes ogTuning = 0;
            RootNotes targetNote = 0;
            var ogMidiNumTunings = new List<long>();
            var ogTunings = new List<RootNotes>();
            var fingerPos = new FingerPosition();
            var fingerPositions = new List<FingerPosition>();
            var removedFingerPositions = new List<FingerPosition>();

            if (ogFretNr != null)
            {
                for (int sT = 0; (sT < Song.Tuning.Count()); sT++) //converts original tuning midi numbers to rootnotes
                {
                    ogMidiNumTunings.Add(Song.Tuning[sT]);
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
                var notes = new List<RootNotes>();
                var removedNotes = new List<RootNotes>();

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
                    }
                }
                for (int rIndex = removedNotes.Count; rIndex > 0; rIndex--)
                {
                    notes.RemoveAt(0);
                }
                for (int notesIndex = notes.Count; notesIndex > 0; notesIndex--)
                {
                    notes.Add(removedNotes[0]);
                    removedNotes.RemoveAt(0);
                    if (removedNotes.Count == 0)
                    {
                        break;
                    }
                }
                for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++) // finds target note 
                {
                    if (notesIndex == ogFretNr)
                    {
                        targetNote = notes[notesIndex];
                    }
                }
                for (int tuningNum = 0; tuningNum < musicStrings.Count(); tuningNum++) // finds fretnr for each string in new instrument with target note }
                {
                    fingerPos = new FingerPosition();
                    fingerPositions.Add(fingerPos);
                    fingerPositions[tuningNum].StringNum = tuningNum;
                    for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++)
                    {
                        if (musicStrings[tuningNum].Tuning == notes[notesIndex]) // rearranges notes list to start at new instrument tuning
                        {
                            break;
                        }
                        else
                        {
                            removedNotes.Add(notes[notesIndex]);
                            //notes.RemoveAt(notesIndex);
                        }                       
                    }
                    for (int rIndex = removedNotes.Count; rIndex > 0; rIndex--)
                    {
                        notes.RemoveAt(0);
                    }
                    for (int notesIndex = notes.Count; notesIndex > 0; notesIndex--)
                    {
                        if (removedNotes.Count == 0)
                        {
                            break;
                        }
                        notes.Add(removedNotes[0]);
                        removedNotes.RemoveAt(0);                       
                    }
                    for (int notesIndex = 0; notesIndex < notes.Count; notesIndex++) // finds fretnr to arrive at target note, ads fingerposition to list
                    {
                        if (targetNote == notes[notesIndex])
                        {
                            fingerPositions[tuningNum].FretNr = notesIndex;
                            break;
                        }
                    }                                                                                                                                   // }
                }
                var newFingerPositions = fingerPositions.OrderBy(x => x.FretNr).ThenBy(x => x.StringNum).ToList(); //
                fingerPositions = newFingerPositions;
            }
            else
            {
                fingerPos.StringNum = null;
                fingerPos.FretNr = null;
                fingerPositions.Add(fingerPos);

            }
            return fingerPositions;   
        }

        public bool GetDeadNote(bool? NullableBoolDead)
        {
            bool actualBool = NullableBoolDead.GetValueOrDefault();
            return actualBool;

        }

        public bool GetRestNote(bool? NullableBoolRest)
        {
            bool actualBool = NullableBoolRest.GetValueOrDefault();
            return actualBool;

        }
        /// <summary>
        /// Gets duration of note
        /// </summary>
        /// <param name="SongsterrDuration"></param>
        /// <returns>long Duration16ths</returns>
        public long Get16ths(long SongsterrDuration)
        {
            long Duration16ths = 16 / SongsterrDuration;
            return Duration16ths;
        }
        /// <summary>
        /// Gets the octave of the note
        /// </summary>
        /// <param name="fingerPosition"></param>
        /// <returns>int octave</returns>
        public int GetOctave(FingerPosition fingerPosition)
        {
            int octave = 0;
            int fretNr = Convert.ToInt32(fingerPosition.FretNr);
            if (fretNr < 12)
            {
                octave = 1;
            }
            if (fretNr < 24 && fretNr > 11)
            {
                octave = 2;
            }
            if (fretNr > 23)
            {
                octave = 3;
            }
            return octave;
        }
        /// <summary>
        /// Gets the note from the string and fret number
        /// </summary>
        /// <param name="fingerPosition"></param>
        /// <param name="musicString"></param>
        /// <returns>enum rootnote</returns>
        public RootNotes GetRootNote(FingerPosition fingerPosition, MusicString musicString)
        {
            int strng = 0;
            int fretNr = 0;

            if (fretNr < 12)
            {
                fretNr = Convert.ToInt32(fingerPosition.FretNr);
            }
            if (fretNr < 24 && fretNr > 11)
            {
                fretNr = Convert.ToInt32(fingerPosition.FretNr) - 12;
            }
            if (fretNr > 23)
            {
                fretNr = Convert.ToInt32(fingerPosition.FretNr) - 24;
            }

            RootNotes endNote = new RootNotes();

            List<RootNotes> rootnotes = new List<RootNotes>();
            rootnotes.Add(RootNotes.C);
            rootnotes.Add(RootNotes.Cs);
            rootnotes.Add(RootNotes.D);
            rootnotes.Add(RootNotes.Ds);
            rootnotes.Add(RootNotes.E);
            rootnotes.Add(RootNotes.F);
            rootnotes.Add(RootNotes.Fs);
            rootnotes.Add(RootNotes.G);
            rootnotes.Add(RootNotes.Gs);
            rootnotes.Add(RootNotes.A);
            rootnotes.Add(RootNotes.As);
            rootnotes.Add(RootNotes.B);

            List<RootNotes> removedNotes = new List<RootNotes>();

            if (musicString.Tuning == rootnotes[0])
            {
                endNote = rootnotes[fretNr];        
            }
            else
            {

                for (int i = 0; i < rootnotes.Count; i++)
                {
                    if (musicString.Tuning == rootnotes[i])
                    {
                        strng = Convert.ToInt32(rootnotes[i]);
                        break;
                    }                    
                }
                for (int i = 0;i < strng; i++)
                {
                    removedNotes.Add(rootnotes[i]);
                }
                for (int i = 0; i < strng; i++) //removing incorrect notes!!
                {
                    rootnotes.RemoveAt(0);

                }
                for (int i = 0;i < removedNotes.Count(); i++)
                {
                    rootnotes.Add(removedNotes[i]);
                }
                //rootNotes.AddRange(removedNotes);
                endNote = rootnotes[fretNr];
            }

            return endNote;
        }

        public override string ToString()
        {
            return $"{RootNote} - FPos: {FingerPosition?.FretNr}/{FingerPosition?.StringNum} Dur: {Duration16ths}";
        }
    }

    

    
}
