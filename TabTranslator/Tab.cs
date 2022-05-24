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
        public long Capo;
        public string Description;
        public string Lyrics;


        //public Tab GetTitle(SongsterrSong Song)
        //{

        //}
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
    }
}
