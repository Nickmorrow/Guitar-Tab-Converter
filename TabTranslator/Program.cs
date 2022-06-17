using System;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TabTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\..\JSONFiles";

            //Defining instrument

            MusicString GString0 = new MusicString();
            GString0.Tuning = RootNotes.E;
            MusicString GString1 = new MusicString();
            GString1.Tuning = RootNotes.B;
            MusicString GString2 = new MusicString();
            GString2.Tuning = RootNotes.G;
            MusicString GString3 = new MusicString();
            GString3.Tuning = RootNotes.D;
            MusicString GString4 = new MusicString();
            GString4.Tuning = RootNotes.A;
            MusicString GString5 = new MusicString();
            GString5.Tuning = RootNotes.E;

            List<MusicString> StandardTunings = new List<MusicString>(); //string list is reverse of normal to match json data
            StandardTunings.Add(GString0);
            StandardTunings.Add(GString1);
            StandardTunings.Add(GString2);
            StandardTunings.Add(GString3);
            StandardTunings.Add(GString4);
            StandardTunings.Add(GString5);

            StringInstrument SixStringGuitar = new StringInstrument();

            SixStringGuitar.Name = "AcousticGuitar";
            SixStringGuitar.FretCount = 30;
            SixStringGuitar.MusicStrings = StandardTunings;


            List<SongsterrSong> Songs = GetJsonSongs(path);

            List<MusicalNote> songNotes = GetSongNotes(Songs[3], SixStringGuitar);

            // **TESTS**

            List<List<string>> TabLines = Tab.GetTabLines(Songs[3], SixStringGuitar);
            FillTablines(TabLines, songNotes);


            //foreach (List<string> Tabline in FinalTab)
            //{
            //    foreach (string Measure in Tabline)
            //    {
            //        Console.Write(Measure);
            //    }
            //    Console.Write($"\n");
            //}
            //Console.ReadLine();

            List<string> tabOne = TabLines[0];
            int tabLength = tabOne.Count;
            int measuresPerLine = 10;
            int tabLineStartPoint = 0;
            int tabLineEndPoint = measuresPerLine;

            while (tabLineStartPoint < tabLength)
            {
                int remainingMeasures = tabLength - tabLineEndPoint;
                for (int i = 0; i < TabLines.Count; i++)
                {
                    List<string> tabLine = TabLines[i];
                    for (int h = tabLineStartPoint; h < tabLineEndPoint; h++)
                    {
                        string measure = tabLine[h];
                        int dashCount = measure.Length;

                        for (int k = 0; k < dashCount; k++)
                        {
                            Console.Write(measure[k]);
                        }
                    }
                    Console.Write($"\n");
             //       File.AppendAllText(@"c:\test.txt", "lol");
                }
                tabLineStartPoint += 10;
                if (remainingMeasures >= 10)
                {
                    tabLineEndPoint += 10;
                }
                else
                {
                    tabLineEndPoint = tabLength;
                }
                Console.Write($"\n");
            }



        }
        /// <summary>
        /// inserts songnotes fretnumbers into tab structure
        /// </summary>
        /// <param name="TabLines"></param>
        /// <param name="Notes"></param>
        /// <returns>List<List<string>> (final tab) </returns>
        public static void FillTablines(List<List<string>> TabLines, List<MusicalNote> Notes)
        {
            int tablinesCount = 0;
            int noteCount;
        //    List<List<string>> Tabs = new List<List<string>>();

            foreach (List<string> TabLine in TabLines)
            {
                noteCount = 0;
                for (int tabLineIndex = 1; tabLineIndex < TabLine.Count; tabLineIndex++)
                {
                    for (int dashCount = 1; dashCount < TabLine[tabLineIndex].Length; dashCount++)
                    {
                        if (Notes[noteCount].FingerPosition.FretNr != null && Notes[noteCount].FingerPosition.StringNum == tablinesCount)
                        {
                            TabLine[tabLineIndex] = TabLine[tabLineIndex].Remove(dashCount, 1);
                            TabLine[tabLineIndex] = TabLine[tabLineIndex].Insert(dashCount, Notes[noteCount].FingerPosition.FretNr.ToString());
                        }

                        dashCount = dashCount + Convert.ToInt32(Notes[noteCount].Duration16ths) - 1;
                        noteCount++;

                    }
                }
           //     Tabs.Add(TabLine);
                tablinesCount++;
            }

          //  return Tabs;
        }
        /// <summary>
        /// Gets the notes, duration. and octave from songster json
        /// </summary>
        /// <param name="song"></param>
        /// <param name="stringInstrument"></param>
        /// <returns>list of MusicalNotes</returns>
        public static List<MusicalNote> GetSongNotes(SongsterrSong song, StringInstrument stringInstrument)
        {

            List<MusicalNote> notes = new List<MusicalNote>();

            for (int i = 0; i < song.Measures.Count(); i++)
            {
                for (int j = 0; j < song.Measures[i].Voices.Count(); j++)
                {
                    for (int k = 0; k < song.Measures[i].Voices[j].Beats.Count(); k++)
                    {
                        for (int l = 0; l < song.Measures[i].Voices[j].Beats[k].Notes.Count(); l++)
                        {
                            MusicalNote note = new MusicalNote();
                            note.FingerPosition.StringNum = song.Measures[i].Voices[j].Beats[k].Notes[l].String;
                            note.FingerPosition.FretNr = song.Measures[i].Voices[j].Beats[k].Notes[l].Fret;
                            note.SongsterrDuration = song.Measures[i].Voices[j].Beats[k].Duration[1];
                            note.Duration16ths = MusicalNote.Get16ths(note.SongsterrDuration);
                            note.RootNote = MusicalNote.GetRootNote(note.FingerPosition, stringInstrument.MusicStrings[Convert.ToInt32(note.FingerPosition.StringNum)]);
                            note.Octave = MusicalNote.GetOctave(note.FingerPosition);
                            note.NullableBool = song.Measures[i].Voices[j].Beats[k].Notes[l].Rest;
                            note.IsRest = MusicalNote.GetRestNote(note.NullableBool);
                            notes.Add(note);
                        }
                    }
                }
            }

            return notes;
        }

        /// <summary>
        /// Converts directory of json files into list of objects
        /// </summary>
        /// <param name="dPath"></param>
        /// <returns>List of objects</returns>
        public static List<SongsterrSong> GetJsonSongs(string dPath)
        {
            List<SongsterrSong> Songs = new List<SongsterrSong>();
            DirectoryInfo dir = new DirectoryInfo(dPath);
            string[] fPaths = Directory.GetFiles(dPath);
            string json = "";
            int fileNum = fPaths.Count();

            for (int i = 0; i < fileNum; i++)
            {
                json = File.ReadAllText(fPaths[i]);
                SongsterrSong song = JsonConvert.DeserializeObject<SongsterrSong>(json);
                Songs.Add(song);
            }

            return Songs;
        }

    }
}