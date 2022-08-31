using System;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace TabTranslator
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //string webPath = HttpGet("https://dqsljvtekg760.cloudfront.net/269/505252/jhkA0qMwaF7BX_5lhD99g/2.json");
                                     
            string mainUrl = HttpGet("https://www.songsterr.com/a/wsa/nirvana-smells-like-teen-spirit-tab-s269t2"); // original url, functions
            //string mainUrl = HttpGet("https://www.songsterr.com/a/wsa/bon-jovi-livin-on-a-prayer-tab-s3131");  //test url


            string appJsonPath = "";
            string trackJsonPath = "";
            string tabTextPath = "";

            //Allows me to work on either operating system

            var isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (isWindows)
            {
                //File.WriteAllText(@"..\..\..\..\JSONFiles\trackUrl.txt", $"{trackUrl}");
                trackJsonPath = @"..\..\..\..\JSONFiles";
                tabTextPath = @"..\..\..\..\TabTxtFiles\Test.txt";
                appJsonPath = @"..\..\..\..\AppJsonFiles";
            }
            var isOSX = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            if (isOSX)
            {               
                //File.WriteAllText(@"/Users/Nick/Documents/TabTranslatorWebPath/trackUrl.txt", $"{trackUrl}");
                trackJsonPath = "/Users/Nick/Documents/TabTranslatorWebPath";
                tabTextPath = "/Users/Nick/Documents/TabTranslatorTextFiles/Test.txt";
            }
           
            AppJson appJson = GetJsonSongInfo(mainUrl, appJsonPath);

            Console.WriteLine($"Tracks:{appJson.meta.current.tracks.Count().ToString()}");
            Console.WriteLine("Select track");
            int userTrackSelection = Int32.Parse(Console.ReadLine()); 

            string urlParts = GetUrl(mainUrl, appJson, userTrackSelection);
            string trackUrl = HttpGet(urlParts);
            File.WriteAllText(@"..\..\..\..\JSONFiles\trackUrl.txt", $"{trackUrl}");

            //Defining SixStringGuitar

            // Standard Tuning

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

            List<MusicString> StandardGuitarTunings = new List<MusicString>(); //string list is reverse of normal to match json data
            StandardGuitarTunings.Add(GString0);
            StandardGuitarTunings.Add(GString1);
            StandardGuitarTunings.Add(GString2);
            StandardGuitarTunings.Add(GString3);
            StandardGuitarTunings.Add(GString4);
            StandardGuitarTunings.Add(GString5);

            StringInstrument SixStringGuitar = new StringInstrument();

            SixStringGuitar.Name = "SixStringGuitar";
            SixStringGuitar.FretCount = 21;
            SixStringGuitar.MusicStrings = StandardGuitarTunings;

            // Defining BassGuitar

            // Standard Tuning

            MusicString BGString0 = new MusicString();
            BGString0.Tuning = RootNotes.G;
            MusicString BGString1 = new MusicString();
            BGString1.Tuning = RootNotes.D;
            MusicString BGString2 = new MusicString();
            BGString2.Tuning = RootNotes.A;
            MusicString BGString3 = new MusicString();
            BGString3.Tuning = RootNotes.E;

            List<MusicString> StandardBassGuitarTunings = new List<MusicString>();
            StandardBassGuitarTunings.Add(BGString0);
            StandardBassGuitarTunings.Add(BGString1);
            StandardBassGuitarTunings.Add(BGString2);
            StandardBassGuitarTunings.Add(BGString3);

            StringInstrument BassGuitar = new StringInstrument();

            BassGuitar.Name = "BassGuitar";
            BassGuitar.FretCount = 21;
            BassGuitar.MusicStrings = StandardBassGuitarTunings;

            // Defining Ukelele

            // Standard tuning

            MusicString UkString0 = new MusicString();
            UkString0.Tuning = RootNotes.A;
            MusicString UkString1 = new MusicString();
            UkString1.Tuning = RootNotes.E;
            MusicString UkString2 = new MusicString();
            UkString2.Tuning = RootNotes.C;
            MusicString UkString3 = new MusicString();
            UkString3.Tuning = RootNotes.G;

            List<MusicString> StandardUkeleleTunings = new List<MusicString>();
            StandardUkeleleTunings.Add(BGString0);
            StandardUkeleleTunings.Add(BGString1);
            StandardUkeleleTunings.Add(BGString2);
            StandardUkeleleTunings.Add(BGString3);

            StringInstrument Ukelele = new StringInstrument();

            Ukelele.Name = "Ukelele";
            Ukelele.FretCount = 12;
            Ukelele.MusicStrings = StandardUkeleleTunings;


            // **TESTS**

            //SongsterrSong webSong = GetJsonSong(wPath);
            List<SongsterrSong> Songs = GetJsonTracks(trackJsonPath);
            List<MusicalBeat> songBeats = GetSongBeats(Songs[0], SixStringGuitar);

            var tab = new Tab(Songs[0], SixStringGuitar, songBeats);

            List<string> tabOne = tab.TabLines[0];
            int tabLength = tabOne.Count;
            int measuresPerLine = 10;
            int tabLineStartPoint = 0;
            int tabLineEndPoint = measuresPerLine;

            //Console.WriteLine($"{tab.TitleOfSong}\n{tab.InstrumentString}");
            File.WriteAllText(tabTextPath, $"{tab.TitleOfSong}\n{tab.InstrumentString}\n");

            foreach (RootNotes tuning in tab.Tuning.Reverse<RootNotes>())
            {
                //Console.Write(tuning.ToString());
                File.AppendAllText(tabTextPath, $"{tuning.ToString()}");
            }
            if (tab.Capo == 0)
            {
                //Console.WriteLine("\nNo Capo\n");
                File.AppendAllText(tabTextPath, "\nNo Capo\n");
            }
            else
            {
                //Console.WriteLine($"\nCapo on Fret {tab.Capo.ToString()}\n");
                File.AppendAllText(tabTextPath, $"\nCapo on Fret {tab.Capo.ToString()}\n");
            }
            
            while (tabLineStartPoint < tabLength)
            {
                int remainingMeasures = tabLength - tabLineEndPoint;
                for (int i = 0; i < tab.TabLines.Count; i++)
                {
                    List<string> tabLine = tab.TabLines[i];
                    for (int h = tabLineStartPoint; h < tabLineEndPoint; h++)
                    { 
                        string measure = tabLine[h];
                        int dashCount = measure.Length;

                        for (int k = 0; k < dashCount; k++)
                        {
                            //Console.Write(measure[k]);
                            File.AppendAllText(tabTextPath, $"{measure[k]}");
                        }
                    }
                    //Console.Write($"\n");
                    File.AppendAllText(tabTextPath, $"\n");
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
                //Console.Write($"\n");
                File.AppendAllText(tabTextPath, $"\n");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Gets the notes, duration. and octave from songster json
        /// </summary>
        /// <param name="song"></param>
        /// <param name="stringInstrument"></param>
        /// <returns>list of MusicalNotes</returns>
        public static List<MusicalBeat> GetSongBeats(SongsterrSong song, StringInstrument stringInstrument)
        {
            List<MusicalBeat> beats = new List<MusicalBeat>();
            for (int measureNum = 0; measureNum < song.Measures.Count(); measureNum++)
            {
                for (int voiceNum = 0; voiceNum < song.Measures[measureNum].Voices.Count(); voiceNum++)
                {
                    for (int beatNum = 0; beatNum < song.Measures[measureNum].Voices[voiceNum].Beats.Count(); beatNum++)
                    {
                        MusicalBeat beat = new MusicalBeat();
                        List<MusicalNote> notes = new List<MusicalNote>();
                        beat.SongsterrDuration = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Duration[1];
                        beat.Duration16ths = beat.Get16ths(beat.SongsterrDuration);
                        beat.NullableBool = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Rest;
                        beat.IsRest = beat.GetRestBeat(beat.NullableBool);
                        for (int noteNum = 0; noteNum < song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes.Count(); noteNum++)
                        {
                            MusicalNote note = new MusicalNote();
                            note.FingerPosition.StringNum = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].String;
                            note.FingerPosition.FretNr = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Fret;
                            note.RootNote = note.GetRootNote(note.FingerPosition, stringInstrument.MusicStrings[Convert.ToInt32(note.FingerPosition.StringNum)]);
                            note.Octave = note.GetOctave(note.FingerPosition);
                            note.NullableBoolRest = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Rest;
                            note.IsRest = note.GetRestNote(note.NullableBoolRest);
                            note.NullableBoolDead = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Dead;
                            note.Dead = note.GetDeadNote(note.NullableBoolDead);
                            notes.Add(note);
                        }
                        beat.MusicalNotes = notes;
                        beats.Add(beat);
                    }
                }
            }
            return beats;
        }

        /// <summary>
        /// Converts directory of json files into list of objects
        /// </summary>
        /// <param name="dPath"></param>
        /// <returns>List of objects</returns>
        public static List<SongsterrSong> GetJsonTracks(string dPath)
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
        private static string HttpGet(string uri)
        {
            string content = null;
            var wc = new MyWebClient();
            content = wc.DownloadString(uri);
            return content;
        }
        /// <summary>
        /// Parses source html for json info and deserializes to object
        /// </summary>
        /// <param name="webPathTwo"></param>
        /// <param name="filePath"></param>
        /// <returns>AppJson Object</returns>
        public static AppJson GetJsonSongInfo(string webPathTwo, string filePath)
        {
            StringCollection resultList = new StringCollection();
            try
            {
                Regex regexObj = new Regex(@"<script id=\Dstate\D type=\Dapplication/json\D>(?<applicationjson>.*?)</script>");
                Match matchResult = regexObj.Match(webPathTwo);
                while (matchResult.Success)
                {
                    resultList.Add(matchResult.Groups[1].Value);
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            foreach (string str in resultList)
            {
                File.WriteAllText(@"..\..\..\..\AppJsonFiles\AppJson.txt", $"{str}");
            }
            DirectoryInfo dir = new DirectoryInfo(filePath);
            string[] paths = Directory.GetFiles(filePath);
            string appJsonText = "";
            int fileNum = paths.Count();
            AppJson result = new AppJson();
            for (int i = 0; i < fileNum; i++)
            {
                appJsonText = File.ReadAllText(paths[i]);
                result = JsonConvert.DeserializeObject<AppJson>(appJsonText);
            }           
            return result;
        }

        public static string GetUrl(string url, AppJson appJson, int trackSelection)
        {
            StringCollection resultList = new StringCollection();

            // first part of url (cloudfrontserver)
            try
            {
                Regex regexObj = new Regex(@"//.+\.cloudfront\.net/");
                Match matchResult = regexObj.Match(url);
                while (matchResult.Success)
                {
                    resultList.Add(matchResult.Value);
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            string firstPartUrl = resultList[3];

            // second part of url (songid)

            string secondPartUrl = appJson.meta.songId.ToString();

            // third part url (revisionId)

            string thirdPartUrl = appJson.meta.current.revisionId.ToString();

            // fourth part url (image)

            string fourthPartUrl = appJson.meta.current.image;
            
            // fifth part json file

            int minusOne = trackSelection - 1;
            string trackNum = minusOne.ToString();
            string fifthPartUrl = $"{trackNum}.json";

            string finalUrl = $"https:{firstPartUrl}{secondPartUrl}/{thirdPartUrl}/{fourthPartUrl}/{fifthPartUrl}";

            return finalUrl;

        }



    }


}
