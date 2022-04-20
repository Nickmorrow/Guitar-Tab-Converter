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
        public string Description;
        public string Lyrics;

        //public Tab GetTitle(SongsterrSong Song)
        //{

        //}
        public static List <List<string[]>> GetTabLines(SongsterrSong Song, StringInstrument instrument)
        {

            int TSigNum = 0;

            string[] MeasureStringAr; //Measure
            List<string> MeasureDashes = new List<string>();
            List<string[]> Measures = new List<string[]>(); //Measures per guitar string
            List<List<string[]>> TabLines = new List<List<string[]>>(); //list of guitar strings measurelines

            foreach (MusicString Mstring in instrument.MusicStrings)
            {
                TSigNum = Convert.ToInt32(Song.Measures[0].Signature[0]);
                for (int i = 0; i < Song.Measures.Count(); i++)
                {
                    //if (Song.Measures[i].Signature[0] == null)
                    //{
                    //    TSigNum = TSigNum;
                    //}
                    //TSigNum = Convert.ToInt32(Song.Measures[i].Signature[0]);                   
                     
                    MeasureDashes.Add("|");
                    for (i = 0; i < TSigNum;i++)
                    {
                        MeasureDashes.Add("-");
                        MeasureDashes.Add("-");
                        MeasureDashes.Add("-");
                        MeasureDashes.Add("-");
                    }
                    MeasureStringAr = MeasureDashes.ToArray();
                    Measures.Add(MeasureStringAr);
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
