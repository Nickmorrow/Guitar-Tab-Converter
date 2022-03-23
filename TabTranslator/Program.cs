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
            string path = "E:/Projects/Programming/CSharp/RaketeMentoring/FinalProject/TabTranslator/JSONFiles";
            List<SongsterrSong> Songs = GetJsonSongs(path);
            List<MusicalNote> songNotes = GetSongNotes(Songs[5]);

        } 

        public static List<MusicalNote> GetSongNotes(SongsterrSong song)
        {
            MusicalNote note = new MusicalNote();
            List <MusicalNote>notes = new List<MusicalNote>();
            int measureNum = song.Measures.Count();
            int voiceNum;
            int beatNum;
            int noteNum;
            int durationNum;            

            for (int i = 0; i < measureNum+1; i++)
            {
                voiceNum = song.Measures[i].Voices.Count();

                for (int j = 0; j < voiceNum+1; j++)
                {
                    beatNum = song.Measures[i].Voices[j].Beats.Count();

                    for (int k = 0; k < beatNum+1; k++)
                    {
                        noteNum = song.Measures[i].Voices[j].Beats[k].Notes.Count();

                        for (int l = 0; l < noteNum+1; l++)
                        {
                            durationNum = song.Measures[i].Voices[j].Beats[k].Duration.Count();

                            note.FingerPosition.StringNum = song.Measures[i].Voices[j].Beats[k].Notes[l].String;
                            note.FingerPosition.FretNr = song.Measures[i].Voices[j].Beats[k].Notes[l].Fret;
                            note.SongsterrDuration = song.Measures[i].Voices[j].Beats[k].Duration[2];
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