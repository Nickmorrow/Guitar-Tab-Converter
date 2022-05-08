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

            List<MusicalNote> songNotes = GetSongNotes(Songs[7], SixStringGuitar);

            // **TESTS**

            List<List<string>> TabLines = Tab.GetTabLines(Songs[7], SixStringGuitar);
            List<List<string>> FinalTab = GetTab(TabLines, songNotes);


            //foreach (List<string> Measure in FinalTab)
            //{
            //    foreach (string Dashes in Measure)
            //    {
            //        Console.Write(Dashes);
            //    }
            //    Console.Write($"\n");
            //}
            //Console.ReadLine();

            for (int i = 0; i < FinalTab.Count; i++)
            {
                List<string> Measures = FinalTab[i];
                int mCount = Measures.Count;


                for (int h = 0; h < mCount; i++)
                {
                    string dashes = Measures[h];
                    int dCount = dashes.Length;

                    for (int k = 0; k < dCount; k++)
                    {
                        Console.Write(dashes[k]);
                    }
                }
            }


        }
        public static List<List<string>> GetTab(List<List<string>> TabLines, List<MusicalNote> Notes)
        {

            int stringCount = TabLines.Count;
            int noteCount;
            List<List<string>> Tab = new List<List<string>>();

            foreach (List<string> Measure in TabLines)
            {
                noteCount = 0;
                for (int dashIndex = 0; dashIndex < Measure.Count; dashIndex++)
                {
                    if (Measure[dashIndex].Length == 1)
                    {
                        continue;
                    }

                    for (int dashCount = 0; dashCount < Measure[dashIndex].Length; dashCount++)
                    {
                        if (dashCount == 0)
                        {
                            Measure[dashIndex] = Measure[dashIndex].Remove(1, 1);
                            Measure[dashIndex] = Measure[dashIndex].Insert(1, Notes[noteCount].FingerPosition.FretNr.ToString());
                            dashCount = Convert.ToInt32(Notes[noteCount].Duration16ths);
                        }
                        else
                        {
                            Measure[dashIndex] = Measure[dashIndex].Remove(dashCount, 1);
                            Measure[dashIndex] = Measure[dashIndex].Insert(dashCount, Notes[noteCount].FingerPosition.FretNr.ToString());
                            dashCount = dashCount + Convert.ToInt32(Notes[noteCount].Duration16ths) - 1;
                        }

                        noteCount++;
                    }
                    Measure.Add(Measure[dashIndex]);  //?? need that 
                }
                Tab.Add(Measure);
            }

            //for (int i = 0; i < stringCount; i++)
            //{
            //    List<string> Measures = TabLines[i];
            //    int mCount = Measures.Count;
            //    noteCount = 0;

            //    for (int j = 0; j < mCount; j++)
            //    {
            //        string dashes = Measures[j];
            //        int dCount = dashes.Length;
            //        if (dCount == 0)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            for (int k = 0; k < dCount; k++)
            //            {
            //                if (k == 0)
            //                {
            //                    dashes.Remove(k + 1);
            //                    dashes.Insert(k + 1, Notes[noteCount].FingerPosition.FretNr.ToString());
            //                    k = k + Convert.ToInt32(Notes[noteCount].Duration16ths);
            //                    noteCount++;
            //                }
            //                else
            //                {
            //                    dashes.Remove(k + 1);
            //                    dashes.Insert(k + 1, Notes[noteCount].FingerPosition.FretNr.ToString());
            //                    k = k + Convert.ToInt32(Notes[noteCount].Duration16ths);
            //                    noteCount++;
            //                }
            //            }
            //            Measures.Add(dashes);
            //        }
            //    }
            //    Tab.Add(Measures);
            //}
            return Tab;
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