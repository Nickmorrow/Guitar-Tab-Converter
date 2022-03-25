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
            List<SongsterrSong> Songs = GetJsonSongs(path);
            List<MusicalNote> songNotes = GetSongNotes(Songs[8]);

            for (int i = 0; i < songNotes.Count; i++)
            {

                Console.WriteLine($"{songNotes[i].FingerPosition.StringNum.ToString()}{songNotes[i].FingerPosition.FretNr.ToString()}");
            }
            
            

        } 

        public static List<MusicalNote> GetSongNotes(SongsterrSong song)
        {
            
            List <MusicalNote>notes = new List<MusicalNote>();

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