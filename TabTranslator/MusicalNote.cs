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

        public static bool GetDeadNote(bool? NullableBoolDead)
        {
            bool actualBool = NullableBoolDead.GetValueOrDefault();
            return actualBool;

        }

        public static bool GetRestNote(bool? NullableBoolRest)
        {
            bool actualBool = NullableBoolRest.GetValueOrDefault();
            return actualBool;

        }
        /// <summary>
        /// Gets duration of note
        /// </summary>
        /// <param name="SongsterrDuration"></param>
        /// <returns>long Duration16ths</returns>
        public static long Get16ths(long SongsterrDuration)
        {
            long Duration16ths = 16 / SongsterrDuration;
            return Duration16ths;
        }
        /// <summary>
        /// Gets the octave of the note
        /// </summary>
        /// <param name="fingerPosition"></param>
        /// <returns>int octave</returns>
        public static int GetOctave(FingerPosition fingerPosition)
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
        public static RootNotes GetRootNote(FingerPosition fingerPosition, MusicString musicString)
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
