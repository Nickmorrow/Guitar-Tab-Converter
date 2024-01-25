using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class Tab
    {
        public string TitleOfSong;
        public string ArtistName;
        public string Difficulty;
        public StringInstrument Instrument;
        public string InstrumentString;
        public List<RootNotes> Tuning;
        public long Capo;
        public string Description;
        public string Lyrics;
        public List<List<string>> TabLines;




        public List<List<string>> GetTabLines(SongsterrSong Song, StringInstrument instrument)
        {

            int TSigNum = 0;
            string tuningString = "";

            List<List<string>> TabLines = new List<List<string>>(); //list of guitar strings measurelines

            foreach (MusicString Mstring in instrument.MusicStrings)
            {
                List<string> Measures = new List<string>(); //Measures per guitar string
                TSigNum = Convert.ToInt32(Song.Measures[0].Signature[0]);
                tuningString = Mstring.Tuning.ToString();
                Measures.Add(tuningString);

                for (int i = 0; i < Song.Measures.Count(); i++)
                {
                    string MeasureDashes = "";
                    MeasureDashes += "|";
                    for (int iDashCnt = 0; iDashCnt < TSigNum; iDashCnt++)
                    {
                        MeasureDashes += "- ";
                        MeasureDashes += "- ";
                        MeasureDashes += "- ";
                        MeasureDashes += "- ";
                    }
                    Measures.Add(MeasureDashes);
                }
                TabLines.Add(Measures);
            }
            return TabLines;
        }
        public string GetFretNrString(MusicalNote Note)
        {
            string FretNr = Note.FingerPosition.FretNr.ToString();
            return FretNr;
        }
        /// <summary>
        /// inserts songnotes fretnumbers into tab structure
        /// </summary>
        /// <param name="TabLines"></param>
        /// <param name="Beats"></param>
        public void FillTablines(List<List<string>> TabLines, List<MusicalBeat> Beats, SongsterrSong Song)
        {
            for (int idxTabLine = 0; idxTabLine < TabLines.Count; idxTabLine++)
            {
                List<string> TabLine = TabLines[idxTabLine];
                int beatCount = 0;
                for (int tabLineIndex = 1; tabLineIndex < TabLine.Count; tabLineIndex++)  //for each (output) measure
                {
                    int dashCount = 1;
                    while (dashCount < TabLine[tabLineIndex].Length)
                    {
                        // break if current noteCount exceeds actual count -> should not happen
                        if (beatCount >= Beats.Count - 1)
                        {
                            break;
                        }

                        // replace parts with current FretNr or skip if is rest
                        var currentBeat = Beats[beatCount];

                        for (int noteCount = 0; noteCount < currentBeat.MusicalNotes.Count; noteCount++)
                        {
                            var currentNote = currentBeat.MusicalNotes[noteCount];
                            if (currentNote.FingerPosition.FretNr != null && currentNote.FingerPosition.StringNum == idxTabLine)
                            {
                                if (currentNote.Dead == true)
                                {
                                    TabLine[tabLineIndex] = TabLine[tabLineIndex].Remove(dashCount, 1);
                                    TabLine[tabLineIndex] = TabLine[tabLineIndex].Insert(dashCount, "X");
                                }
                                else
                                {
                                    var fretNrLength = 1; // add condition where if fretnumber is over 10 fretnumberlength is 2
                                    //if (currentNote.FingerPosition.FretNr > 9)
                                    //{
                                    //    fretNrLength = 2;
                                    //}
                                    TabLine[tabLineIndex] = TabLine[tabLineIndex].Remove(dashCount, fretNrLength);
                                    TabLine[tabLineIndex] = TabLine[tabLineIndex].Insert(dashCount, currentNote.FingerPosition.FretNr.ToString());
                                }      
                            }
                        }
                        dashCount += Convert.ToInt32(currentBeat.Duration16ths);
                        beatCount++;
                    }
                }
            }
        }

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

        public Tab(SongsterrSong Song, StringInstrument Instrument, List<MusicalBeat> songBeats,AppJson appjson,bool converted)
        {
            ArtistName = appjson.meta.current.artist;
            TitleOfSong = appjson.meta.current.title;
            Instrument = Instrument;
            InstrumentString = Instrument.Name; //Song.Instrument;
            List<RootNotes> convertedTunings = new List<RootNotes>();

            if (!converted)
            {
                for (int i = 0; i < Song.Tuning.Count(); i++)
                {
                    RootNotes note = ConvertMidiNum(Song.Tuning[i]);
                    convertedTunings.Add(note);
                }
                Tuning = convertedTunings;
            }
            else
            {
                for (int i =0; i < Instrument.MusicStrings.Count; i++)
                {
                    RootNotes note = Instrument.MusicStrings[i].Tuning;
                    convertedTunings.Add(note);
                }
                Tuning = convertedTunings;
            }
                        
            Capo = Song.Capo;
            TabLines = GetTabLines(Song, Instrument);
            FillTablines(TabLines, songBeats, Song);
        }
    }
}
