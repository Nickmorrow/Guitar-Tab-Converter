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
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
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
            long targetMidiNum = 0;
            RootNotes targetNote = 0;
            FingerPosition fingerPos = new FingerPosition();
            List<FingerPosition> fingerPositions = new List<FingerPosition>();
            List<FingerPosition> removedFingerPositions = new List<FingerPosition>();
            List<RootNotes> MidiNums = Midi.DefineMidiNotes();

            if (ogFretNr != null)
            {               
                int fretCounter = 0;
                for (long midiIndex = Song.Tuning[Convert.ToInt32(ogStringNr)]; midiIndex < MidiNums.Count; midiIndex++) // finds target note 
                {
                    if (fretCounter == ogFretNr)
                    {
                        targetNote = MidiNums[Convert.ToInt32(midiIndex)];
                        targetMidiNum = midiIndex;
                        break;
                    }
                    fretCounter++;
                }
                for (int stringIndex = 0; stringIndex < musicStrings.Count; stringIndex++) // finds finger position of each string on target instrument and places in list || todo: if ogfretnr < 12 && fretCounter > 12 fretnr - 12 loop for lower tunings
                {
                    if (musicStrings[stringIndex].MidiNum <= targetMidiNum) //if tuning of string is less than target note
                    {
                        fretCounter = 0;
                        for (long midiIndex = musicStrings[stringIndex].MidiNum; midiIndex < MidiNums.Count; midiIndex++)
                        {
                            if (MidiNums[Convert.ToInt32(midiIndex)] == targetNote)
                            {
                                FingerPosition convertedFingPos = new FingerPosition();
                                convertedFingPos.MidiNum = targetMidiNum;
                                convertedFingPos.MidiNote = targetNote;
                                convertedFingPos.StringNum = stringIndex;
                                convertedFingPos.FretNr = fretCounter;
                                fingerPositions.Add(convertedFingPos);
                                break;
                            }
                            fretCounter++;
                        }
                    }
                    else
                    {
                        long targetMidiNumHigh = targetMidiNum;
                        RootNotes targetNoteHigh = 0;
                        for (long midiIndex = musicStrings[stringIndex].MidiNum; midiIndex < MidiNums.Count; midiIndex++) //if tuning of string is higher than target note moves up target note in octaves until it is higher than tuning
                        {
                            if (musicStrings[stringIndex].MidiNum > targetMidiNumHigh)
                            {
                                targetMidiNumHigh = targetMidiNumHigh + 12;
                                targetNoteHigh = MidiNums[Convert.ToInt32(targetMidiNumHigh)];
                            }
                            else
                            {
                                break;
                            }
                        }
                        fretCounter = 0;
                        for (long midiIndex = musicStrings[stringIndex].MidiNum; midiIndex < MidiNums.Count; midiIndex++)
                        {
                            if (MidiNums[Convert.ToInt32(midiIndex)] == targetNoteHigh)
                            {
                                FingerPosition convertedFingPos = new FingerPosition();
                                convertedFingPos.MidiNum = targetMidiNumHigh;
                                convertedFingPos.MidiNote = targetNoteHigh;
                                convertedFingPos.StringNum = stringIndex;
                                convertedFingPos.FretNr = fretCounter;
                                fingerPositions.Add(convertedFingPos);
                                break;
                            }
                            fretCounter++;
                        }
                    }
                    var orderedFingerPositions = fingerPositions.OrderBy(x => x.MidiNum).ThenBy(x => x.FretNr).ToList();
                    fingerPositions = orderedFingerPositions;
                }                
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
            rootnotes.Add(RootNotes.CsDb);
            rootnotes.Add(RootNotes.D);
            rootnotes.Add(RootNotes.DsEb);
            rootnotes.Add(RootNotes.E);
            rootnotes.Add(RootNotes.F);
            rootnotes.Add(RootNotes.FsGb);
            rootnotes.Add(RootNotes.G);
            rootnotes.Add(RootNotes.GsAb);
            rootnotes.Add(RootNotes.A);
            rootnotes.Add(RootNotes.AsBb);
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
