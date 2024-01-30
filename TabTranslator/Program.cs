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
            string mainSourceHTML = HttpGet("https://www.songsterr.com");
            string songSourceHTML = "";
            bool isOpen = true;        
            while (isOpen)
            {
                UIMethods.Welcome();
                bool seeTopSearched = UIMethods.TopSearchedYN();
                List<string> TopSearchedSongs;
                List<AppJson> TopSongJson;
                int topSongIndex;
                List<string> UserSearchedSongs;
                List<AppJson> UserSearchedJson;
                int userSearchedIndex;
                if (seeTopSearched)
                {
                    TopSearchedSongs = GetSongUrls(mainSourceHTML);
                    TopSongJson = GetSearchedSongs(TopSearchedSongs);                      
                    topSongIndex = UIMethods.SongSelected(TopSongJson, TopSearchedSongs);
                    songSourceHTML = HttpGet($"https://www.songsterr.com{TopSearchedSongs[topSongIndex-1]}");
                }
                else
                {
                    bool isSearching = true;
                    string userSearch = "";
                    string userSearchedHTML = "";
                    while (isSearching)
                    {
                        userSearch = $"/?pattern={UIMethods.UserSearchInput()}";
                        userSearchedHTML = HttpGet($"https://www.songsterr.com{userSearch}");
                        UserSearchedSongs = GetSongUrls(userSearchedHTML);
                        if (UserSearchedSongs.Count == 0)
                        {
                            UIMethods.NoSearchResults();
                            continue;
                        }
                        else
                        {
                            UserSearchedJson = GetSearchedSongs(UserSearchedSongs);
                            bool searchSuccess = UIMethods.SearchOrExit(UserSearchedJson);
                            if(searchSuccess)
                            {
                                userSearchedIndex = UIMethods.SongSelected(UserSearchedJson, UserSearchedSongs);
                                songSourceHTML = HttpGet($"https://www.songsterr.com{UserSearchedSongs[userSearchedIndex - 1]}");
                                isSearching = false;
                            }
                            else
                            {
                                continue;
                            }                           
                        }
                    }
                }               
                List<string> OSFilePaths = GetFilePathsForOS();     //allows me to work on mac or pc
                string trackJsonPath = OSFilePaths[0];
                string tabTextPath = OSFilePaths[1];

                AppJson appJson = GetJsonSongInfo(songSourceHTML);

                int trackIndex = UIMethods.GetTrackIndex(appJson);      //Test UI

                string urlParts = GetUrl(songSourceHTML, appJson, trackIndex);
                string trackJSON = HttpGet(urlParts);

                File.WriteAllText(@"..\..\..\..\JSONFiles\trackJSON.txt", $"{trackJSON}");

                List<StringInstrument> stringInstruments = InstObjects.DefStrInstruments();     //list of string instruments

                // **TESTS**

                List<SongsterrSong> Songs = GetJsonTracks(trackJsonPath);
                List<MusicalBeat> songBeats = GetSongBeats(Songs[0], stringInstruments[0], stringInstruments);
                StringInstrument stringInstrument = stringInstruments[0];
                
                bool converted = UIMethods.ConvertYorN();
                if(converted)
                {
                    stringInstrument = UIMethods.InstChoice(stringInstruments); //Method to choose intrument
                    songBeats = GetSongBeats(Songs[0], stringInstrument, stringInstruments);
                }
                var tab = new Tab(Songs[0], stringInstrument, songBeats, appJson, converted);

                List<string> tabOne = tab.TabLines[0];
                int tabLength = tabOne.Count;
                int measuresPerLine = 5;
                int tabLineStartPoint = 0;
                int tabLineEndPoint = measuresPerLine;

                //Console.WriteLine($"{tab.TitleOfSong}\n{tab.InstrumentString}");
                File.WriteAllText(tabTextPath, $"{tab.ArtistName}\n{tab.TitleOfSong}\n{tab.InstrumentString}\n");

                foreach (RootNotes tuning in tab.Tuning.Reverse<RootNotes>())
                {
                    //Console.Write(tuning.ToString());
                    File.AppendAllText(tabTextPath, $"{tuning.ToString()}");
                }
                //foreach (MusicString S in stringInstrument.MusicStrings.Reverse<MusicString>())
                //{
                //    //Console.Write(tuning.ToString());
                //    File.AppendAllText(tabTextPath, $"{stringInstrument.MusicStrings.MusicString.Tuning.ToString()}");
                //}
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
                UIMethods.ContinueOrExit(isOpen);
            }
        }
        /// <summary>
        /// Gets the notes, duration. and octave from songster json
        /// </summary>
        /// <param name="song"></param>
        /// <param name="stringInstrument"></param>
        /// <returns>list of MusicalNotes</returns>
        public static List<MusicalBeat> GetSongBeats(SongsterrSong song, StringInstrument stringInstrument, List<StringInstrument> stringInstruments)
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
                            long ogStringNum = Convert.ToInt64(song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].String);
                            long ogFretNum = Convert.ToInt64(song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Fret);

                            if (stringInstrument != stringInstruments[0])
                            {
                                note.FingerPositions = note.GetFingerPositions(song, stringInstrument.MusicStrings, ogStringNum, ogFretNum); // list of all possible fingerings for note, starts at the lowest fret                                                                                                            
                                note.FingerPosition = note.FingerPositions[0];                                                               
                                note.RootNote = note.GetRootNote(note.FingerPosition, stringInstrument.MusicStrings[Convert.ToInt32(note.FingerPosition.StringNum)]);
                                note.Octave = note.GetOctave(note.FingerPosition);
                                note.NullableBoolRest = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Rest;
                                note.IsRest = note.GetRestNote(note.NullableBoolRest);
                                note.NullableBoolDead = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Dead;
                                note.Dead = note.GetDeadNote(note.NullableBoolDead);

                            }
                            else
                            {
                                note.FingerPosition.StringNum = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].String;
                                note.FingerPosition.FretNr = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Fret;
                                note.RootNote = note.GetRootNote(note.FingerPosition, stringInstrument.MusicStrings[Convert.ToInt32(note.FingerPosition.StringNum)]);
                                note.Octave = note.GetOctave(note.FingerPosition);
                                note.NullableBoolRest = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Rest;
                                note.IsRest = note.GetRestNote(note.NullableBoolRest);
                                note.NullableBoolDead = song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes[noteNum].Dead;
                                note.Dead = note.GetDeadNote(note.NullableBoolDead);

                            }
                            notes.Add(note);
                        }
                        // method to find fingerposition duplicates, use list of strings.count compare fingerpos.stringnum if dup, push to next highest dup string in list, also need condition if all strings are filled

                        for (int selectedNote = 0; selectedNote < song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes.Count(); selectedNote++)
                        {
                            for (int comparedNote = 0; comparedNote < song.Measures[measureNum].Voices[voiceNum].Beats[beatNum].Notes.Count(); comparedNote++) // compares finger positions between notes
                            {
                                if (selectedNote == comparedNote)
                                {
                                    continue;
                                }
                                else
                                {
                                    if (notes[selectedNote].FingerPosition == notes[comparedNote].FingerPosition)  // removes problem duplicate finger position
                                    {
                                        List<FingerPosition> removed = new List<FingerPosition>();

                                        removed.Add(notes[selectedNote].FingerPosition);
                                        notes[selectedNote].FingerPositions.RemoveAt(0);

                                        for (int sF = 0; sF < notes[selectedNote].FingerPositions.Count; sF++)  // finds and selects finger position with next lowest fretnr and removes the rest  
                                        {
                                            for (int cF = 0; cF < notes[selectedNote].FingerPositions.Count; cF++)
                                            {
                                                if (notes[selectedNote].FingerPositions[sF].FretNr < notes[selectedNote].FingerPositions[cF].FretNr)
                                                {
                                                    removed.Add(notes[selectedNote].FingerPositions[cF]);
                                                    notes[selectedNote].FingerPositions.RemoveAt(cF);
                                                }
                                            }
                                        }
                                        notes[selectedNote].FingerPosition = notes[selectedNote].FingerPositions[0]; // new finger position is the last remaining

                                        for (int R = 0; R < removed.Count; R++)
                                        {
                                            notes[selectedNote].FingerPositions.Add(removed[R]); // adds removed fingerpos behind chosen one in list
                                        }
                                    }
                                }
                            }
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
        private static string HttpGet(string url)
        {
            string content = null;
            var wc = new MyWebClient();
            content = wc.DownloadString(url);
            return content;
        }
        /// <summary>
        /// Parses source html for json info and deserializes to object
        /// </summary>
        /// <param name="songUrl"></param>
        /// <param name="filePath"></param>
        /// <returns>AppJson Object</returns>
        public static AppJson GetJsonSongInfo(string songUrl)
        {
            List<string> resultList = new List<string>();
            try
            {
                Regex regexObj = new Regex(@"<script id=\Dstate\D type=\Dapplication/json\D>(?<applicationjson>.*?)</script>");
                Match matchResult = regexObj.Match(songUrl);
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
            AppJson result = JsonConvert.DeserializeObject<AppJson>(resultList[0]);
            return result;
        }

        public static string GetUrl(string url, AppJson appJson, int trackIndex)
        {
            List<string> resultList = new List<string>();

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
            string cloudFrontServer = resultList[0];    //changed from [3]

            // second part of url (songid)
            string songId = appJson.meta.songId.ToString();

            // third part url (revisionId)
            string revisionId = appJson.meta.current.revisionId.ToString();

            // fourth part url (image)
            string imageName = appJson.meta.current.image;

            // fifth part json file          
            trackIndex--;
            string trackNum = trackIndex.ToString();
            string jsonFile = $"{trackNum}.json";
            string finalUrl = $"https:{cloudFrontServer}{songId}/{revisionId}/{imageName}/{jsonFile}";

            return finalUrl;
        }

        public static List<string> GetSongUrls(string html)
        {
            List<string> resultList = new List<string>();
            try
            {                
                Regex regexObj = new Regex(@"<a.*?href=\D(/a/wsa/.*?)\D\s");
                Match matchResult = regexObj.Match(html);
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
            //List<int> distinct = arr1.Distinct().ToList();
            resultList = resultList.Distinct().ToList();
            return resultList;
        }

        public static List<string> GetFilePathsForOS()
        {
            string trackJsonPath = "";
            string tabTextPath = "";
            List<string> resultList = new List<string>();
            var isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (isWindows)
            {
                //File.WriteAllText(@"..\..\..\..\JSONFiles\trackUrl.txt", $"{trackUrl}");
                trackJsonPath = @"..\..\..\..\JSONFiles";
                tabTextPath = @"..\..\..\..\TabTxtFiles\Test.txt";
            }
            var isOSX = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            if (isOSX)
            {
                //File.WriteAllText(@"/Users/Nick/Documents/TabTranslatorWebPath/trackUrl.txt", $"{trackUrl}");
                trackJsonPath = "/Users/Nick/Documents/TabTranslatorWebPath";
                tabTextPath = "/Users/Nick/Documents/TabTranslatorTextFiles/Test.txt";
            }
            resultList.Add(trackJsonPath);
            resultList.Add(tabTextPath);
            return resultList;
        }

        public static List<AppJson> GetSearchedSongs(List<string> searchedSongs)
        {            

            List<AppJson> SongJson = new List<AppJson>();
            AppJson Song = new AppJson();
            string songSourceHTML;
            int counter = 0;

            foreach (String s in searchedSongs)
            {
                if (s.Contains("chord"))
                    continue;
                //Console.WriteLine(s);
                songSourceHTML = HttpGet($"https://www.songsterr.com{s}");
                Song = GetJsonSongInfo(songSourceHTML);
                SongJson.Add(Song);
                Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");
                counter++;
                //Thread.Sleep(1000);
                //Console.Clear();
            }
            return SongJson;
        }
    }


}
