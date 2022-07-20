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
        public string Artist;
        public string Difficulty;
        public StringInstrument Instrument;
        public string InstrumentString;
        public long[] Tuning;
        public long Capo;
        public string Description;
        public string Lyrics;
        public List<List<string>> TabLines;




        public static List<List<string>> GetTabLines(SongsterrSong Song, StringInstrument instrument)
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
                    String MeasureDashes = "";
                    MeasureDashes += "|";
                    for (int iDashCnt = 0; iDashCnt < TSigNum; iDashCnt++)
                    {
                        MeasureDashes += "-";
                        MeasureDashes += "-";
                        MeasureDashes += "-";
                        MeasureDashes += "-";
                    }
                    Measures.Add(MeasureDashes);
                }
                TabLines.Add(Measures);
            }
            return TabLines;
        }
        public static string GetFretNrString(MusicalNote Note)
        {
            string FretNr = Note.FingerPosition.FretNr.ToString();
            return FretNr;
        }
        /// <summary>
        /// inserts songnotes fretnumbers into tab structure
        /// </summary>
        /// <param name="TabLines"></param>
        /// <param name="Beats"></param>
        public static void FillTablines(List<List<string>> TabLines, List<MusicalBeat> Beats, SongsterrSong Song)
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
                                TabLine[tabLineIndex] = TabLine[tabLineIndex].Remove(dashCount, 1);
                                TabLine[tabLineIndex] = TabLine[tabLineIndex].Insert(dashCount, currentNote.FingerPosition.FretNr.ToString());
                            }
                        }
                        dashCount += Convert.ToInt32(currentBeat.Duration16ths);
                        beatCount++;
                    }
                }
            }
        }
        public Tab(SongsterrSong Song, StringInstrument Instrument, List<MusicalBeat> songBeats)
        {
            TitleOfSong = Song.Name;
            Instrument = Instrument;
            InstrumentString = Song.Instrument;
            Tuning = Song.Tuning;
            Capo = Song.Capo;
            TabLines = GetTabLines(Song, Instrument);
            FillTablines(TabLines, songBeats, Song);
        }
    }
}
