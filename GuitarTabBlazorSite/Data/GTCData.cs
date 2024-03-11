using GuitarTabConverter;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json;
using System.Linq;


namespace GuitarTabBlazorSite.Data
{
    public class GTCData
    {
        //public List<Track> guitarOnly;

        //public Track[] songTracks;

        //public bool converted;

        //public int trackIndex;

        //public string trackUrl;

        //public string trackHTML;

        //public string TrackHTML(string trackUrl)
        //{
        //    trackHTML = HttpGet(trackUrl);
        //    return trackHTML;
        //}

        public Tab tab;

        //public SongsterrSong selectedSong;
        
        //public StringInstrument selectedInstrument;

        public List<StringInstrument> InstrumentList = InstObjects.DefStrInstruments();

        //public List<MusicalBeat> songBeats;

        //public Track selectedTrack;

        //public bool IsRowExpanded { get; set; } = false;

        //public string ExpandableContent { get; set; }
        //public string searchItem { get; set; }

        //public string userSearchedHTML;
        //public string GetUserSearchedHTML(string searchItem)
        //{
        //    string userSearchedHTML = $"/?pattern={searchItem}";
        //    this.userSearchedHTML = HttpGet($"https://www.songsterr.com{userSearchedHTML}");
        //    return this.userSearchedHTML;
        //}

        //public List<string> SongUrls;

        //public AppJson songJson;

        //public AppJson SongJson(AppJson song)
        //{
        //    song = song;
        //    return song;
        //}

        //public List<AppJson> UserSearchedJson;

        //public List<AppJson> FilteredListJson;
        public string HttpGet(string url)
        {
            string content = null;
            var wc = new MyWebClient();
            content = wc.DownloadString(url);
            return content;
        }

        public async Task<string> HttpGetAsync(string url) //, CancellationToken cancellationToken
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url); //, cancellationToken
            }

        }
        public List<string> GetSongUrls(string html)
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

        public AppJson GetJsonSongInfo(string songUrl)
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

        public List<AppJson> SearchJson(string searchItem, List<AppJson> UserSearchedJson, List<string> songUrls)
        {
            bool containsSearchItem = false;

            if (UserSearchedJson != null)
            {
                if (UserSearchedJson.FirstOrDefault(s => s.meta.current.title.ToLower() == searchItem.ToLower() | s.meta.current.artist.ToLower() == searchItem.ToLower()) != null)
                {
                    containsSearchItem = true;
                }
            }            
            if (containsSearchItem == false )
            {
                if (UserSearchedJson == null)
                {
                    UserSearchedJson = new List<AppJson>();
                }
                AppJson Song = new AppJson();
                string songSourceHTML;

                for (int urlNum = 0; urlNum < songUrls.Count; urlNum++)
                {
                    if (songUrls[urlNum].Contains("chord")) //chord means that url is for chords - use later for diplaying chords                   
                        continue;
                    songSourceHTML = HttpGet($"https://www.songsterr.com{songUrls[urlNum]}");
                    Song = GetJsonSongInfo(songSourceHTML);
                    UserSearchedJson.Add(Song);
                    Thread.Sleep(1000);
                }               
            }
            return UserSearchedJson;
        }

        public string GetUrl(string url, AppJson appJson, int trackIndex)
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
            //trackIndex--;
            string trackNum = trackIndex.ToString();
            string jsonFile = $"{trackNum}.json";
            string finalUrl = $"https:{cloudFrontServer}{songId}/{revisionId}/{imageName}/{jsonFile}";

            return finalUrl;
        }

        public SongsterrSong GetSong(string trackHTML, SongsterrSong selectedSong)
        {
            string serializedSong = JsonConvert.SerializeObject(selectedSong);
            SongsterrSong song = JsonConvert.DeserializeObject<SongsterrSong>(serializedSong); //formerly trackHTML
            return selectedSong;
        }

        public List<MusicalBeat> GetSongBeats(SongsterrSong song, StringInstrument stringInstrument, List<StringInstrument> stringInstruments)
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
                        List<MusicalNote> bassNotes = new List<MusicalNote>();
                        List<long?> bassMidiNums = new List<long?>();
                        beat.MeasureNum = measureNum;
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
                                if (note.FingerPositions.Count == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    note.FingerPosition = note.FingerPositions[0];
                                    note.RootNote = note.GetRootNote(note.FingerPosition, stringInstrument.MusicStrings[Convert.ToInt32(note.FingerPosition.StringNum)]);
                                    note.Octave = note.GetOctave(note.FingerPosition);
                                }
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
                        if (stringInstrument.Name == "BassGuitar")
                        {
                            List<FingerPosition> bassMidis = new List<FingerPosition>();
                            for (int n = 0; n < notes.Count; n++)
                            {
                                FingerPosition bassMidi = new FingerPosition();
                                bassMidi = notes[n].FingerPosition;
                                bassMidis.Add(bassMidi);
                            }
                            var bassMidisOrdered = bassMidis.OrderBy(x => x.MidiNum).ToList();
                            for (int b = 0; b < bassMidis.Count; b++)
                            {
                                if (bassMidis[b] == bassMidisOrdered[0])
                                {
                                    notes[b].FingerPosition = bassMidisOrdered[0];
                                    bassNotes.Add(notes[b]);
                                    break;
                                }
                            }
                            beat.MusicalNotes = bassNotes;
                        }
                        else
                        {
                            beat.MusicalNotes = notes;
                        }
                        beats.Add(beat);
                    }
                }
            }
            return beats;
        }

        public async Task<List<AppJson>> SearchJsonAsync(string searchItem, List<AppJson> UserSearchedJson, List<string> songUrls) //, CancellationToken cancellationToken
        {
            bool containsSearchItem = false;

            if (UserSearchedJson != null)
            {
                if (UserSearchedJson.Any(s => s.meta.current.title.ToLower() == searchItem.ToLower() || s.meta.current.artist.ToLower() == searchItem.ToLower()))
                {
                    containsSearchItem = true;
                }
            }

            if (!containsSearchItem)
            {
                if (UserSearchedJson == null)
                {
                    UserSearchedJson = new List<AppJson>();
                }

                AppJson Song = new AppJson();
                string songSourceHTML;

                for (int urlNum = 0; urlNum < songUrls.Count; urlNum++)
                {
                    if (songUrls[urlNum].Contains("chord"))
                        continue;

                    songSourceHTML = await HttpGetAsync($"https://www.songsterr.com{songUrls[urlNum]}"); //, cancellationToken
                    Song = GetJsonSongInfo(songSourceHTML);
                    UserSearchedJson.Add(Song);

                    // Replace Thread.Sleep with asynchronous delay
                    await Task.Delay(1000);
                }
            }

            return UserSearchedJson;
        }

    }

    
}
