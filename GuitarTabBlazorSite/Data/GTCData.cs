using GuitarTabConverter;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json;
using System.Linq;
using System.Reflection;
using PdfSharp.Fonts;
using System.IO;


namespace GuitarTabBlazorSite.Data
{
    public class GTCData
    {
        //public bool isBackToSearch { get; set; }
        public string searchItem { get; set; }

        public bool searchClicked { get; set; }

        public bool isLoading = false;

        private string _userSearchedUrl { get; set; }

        private string _fullSearchedUrl { get; set; }

        private string _userSearchedHTML { get; set; }

        private List<string> _SongUrls { get; set; }

        public List<AppJson> searchResults = new();

        private Track[] _SongTracks { get; set; }

        public List<Track> guitarOnly { get; set; }

        public AppJson songJson { get; set; }

        public int? trackIndex { get; set; }

        public string trackUrl { get; set; }

        public string trackHTML { get; set; }

        public SongsterrSong selectedSong { get; set; }

        public Track selectedTrack { get; set; }

        public List<StringInstrument> InstrumentList = InstObjects.DefStrInstruments();

        private List<AppJson> _searchCache = new();


        public bool trackClicked { get; set; }

        public StringInstrument selectedInstrument { get; set; }

        public List<MusicalBeat> songBeats { get; set; }

        public Tab tab;

        public List<Tab> tabs;

        public bool? converted { get; set; }

        public int? instNum { get; set; }

        public bool isGuitar { get; set; }

        public bool isBassGuitar { get; set; }

        public bool isUkelele { get; set; }

        public bool isBanjo { get; set; }

        public void IsGuitar()
        {
            isGuitar = true;
            isBassGuitar = false;
            isUkelele = false;
            isBanjo = false;
            tab = tabs[0];
        }
        public void IsBassGuitar()
        {
            isGuitar = false;
            isBassGuitar = true;
            isUkelele = false;
            isBanjo = false;
            tab = tabs[1];
        }
        public void IsUkelele()
        {
            isGuitar = false;
            isBassGuitar = false;
            isUkelele = true;
            isBanjo = false;
            tab = tabs[2];
        }
        public void IsBanjo()
        {
            isGuitar = false;
            isBassGuitar = false;
            isUkelele = false;
            isBanjo = true;
            tab = tabs[3];

        }

        public void GoBackToSearch()
        {
            isGuitar = false;
            isBassGuitar = false;
            isUkelele = false;
            isBanjo = false;
            converted = null;
            instNum = null;
            selectedInstrument = null;
            songBeats = null;
            tabs = null;
        }

        private int? _GetTrackIndex(Track guitarTrack, int? trackIndex)
        {
            for (int i = 0; i < _SongTracks.Count(); i++)
            {
                if (guitarTrack == _SongTracks[i])
                {
                    trackIndex = i;
                    break;
                }
            }
            return trackIndex;
        }

        public async Task _SearchClickedAsync()
        {
            if (searchItem == "")
            {
                searchItem = null;
            }

            if (searchItem != null)
            {
                searchClicked = true;
                isLoading = true;
                searchItem = searchItem.ToLower().TrimEnd();
                _userSearchedUrl = $"/?pattern={searchItem}";
                _fullSearchedUrl = $"https://www.songsterr.com{_userSearchedUrl}";

                CancellationTokenSource cts = new CancellationTokenSource();

                _userSearchedHTML = await HttpGetAsync($"{_fullSearchedUrl}", cts.Token);
                _SongUrls = GetSongUrls(_userSearchedHTML);
                searchResults = await SearchJsonAsync(searchItem, _SongUrls, cts.Token);
                isLoading = false;
            }
        }

        public void GuitarOnly(AppJson Json)
        {
            _SongTracks = Json.meta.current.tracks;
            guitarOnly = _SongTracks.Where(x => x.isGuitar).ToList();
        }

        public void TrackClicked(AppJson Json, Track guitarTrack)
        {
            trackClicked = true;
            songJson = Json;
            trackIndex = _GetTrackIndex(guitarTrack, trackIndex);
            trackUrl = GetUrl(_userSearchedHTML, songJson, trackIndex);
            trackHTML = HttpGet(trackUrl);
            selectedSong = GetSong(trackHTML, selectedSong);
            selectedTrack = _SongTracks[(int)trackIndex];

            tabs = new();

            foreach (StringInstrument instrument in InstrumentList)
            {
                if (instrument == InstrumentList[0]) converted = false;
                else converted = true;

                songBeats = GetSongBeats(selectedSong, instrument, InstrumentList);
                tab = new Tab(selectedSong, instrument, songBeats, songJson, converted);
                tabs.Add(tab);
            }

            searchItem = null;
            searchClicked = false;
            searchResults.Clear();
            trackClicked = true;
            trackIndex = null;
            trackUrl = null;
            trackHTML = "";
            selectedTrack = null;

        }       

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

        public async Task<string> HttpGetAsync(string url, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url, cancellationToken);
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
            if (containsSearchItem == false)
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

        public string GetUrl(string url, AppJson appJson, int? trackIndex)
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
            selectedSong = JsonConvert.DeserializeObject<SongsterrSong>(trackHTML);
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

        public async Task<List<AppJson>> SearchJsonAsync(string _searchItem, List<string> songUrls, CancellationToken cancellationToken)
        {
            bool containsSearchItem = false;

            if (_searchCache != null)
            {
                if (_searchCache.Any(s => s.meta.current.title.ToLower().Contains(_searchItem) || s.meta.current.artist.ToLower().Contains(_searchItem)))
                {
                    containsSearchItem = true;

                    return _searchCache.Where(s => s.meta.current.title.ToLower().Contains(_searchItem) || s.meta.current.artist.ToLower().Contains(_searchItem)).ToList();
                }
            }

            if (!containsSearchItem)
            {
                //if (_searchCache == null)
                //{
                //    _searchCache = new List<AppJson>();
                //}

                AppJson Song = new AppJson();
                string songSourceHTML;

                for (int urlNum = 0; urlNum < songUrls.Count; urlNum++)
                {
                    if (songUrls[urlNum].Contains("chord"))
                        continue;

                    songSourceHTML = await HttpGetAsync($"https://www.songsterr.com{songUrls[urlNum]}", cancellationToken);
                    Song = GetJsonSongInfo(songSourceHTML);
                    _searchCache.Add(Song);

                    await Task.Delay(500);
                }
                _searchCache = _searchCache.Distinct().ToList();
            }
            return _searchCache.Where(s => s.meta.current.title.ToLower().Contains(_searchItem) || s.meta.current.artist.ToLower().Contains(_searchItem)).ToList();
        }

        


    }

    
}
