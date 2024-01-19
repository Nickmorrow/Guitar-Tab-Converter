using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class AppJson
    {
        public bool isTestMode { get; set; }
        //public Route route { get; set; }
        public Query query { get; set; }
        public Player player { get; set; }
        public Meta meta { get; set; }
        public Part part { get; set; }
        public User user { get; set; }
        public Screen screen { get; set; }
        public Consent consent { get; set; }
        public Artist artist { get; set; }
        public Favorites favorites { get; set; }
        public Layer layer { get; set; }
        public Revisions revisions { get; set; }
        public Payment payment { get; set; }
        public Songs1 songs { get; set; }
        public Uploads uploads { get; set; }
        public Demo demo { get; set; }
        public Promo promo { get; set; }
        public bool isDeleted { get; set; }
        public Editor editor { get; set; }
        public Ads ads { get; set; }
        public Setlists setlists { get; set; }
        public Screener screener { get; set; }
        public Textpage textpage { get; set; }
        public Faq faq { get; set; }
        public Ut ut { get; set; }
        public Chords chords { get; set; }
        public Chordpro chordpro { get; set; }
        public Tabeditor tabEditor { get; set; }
        public Cursor cursor { get; set; }
        public object[] chordDiagram { get; set; }
        public Tags tags { get; set; }
        public Curiosity curiosity { get; set; }
        //public Routecontent routeContent { get; set; }
        public Querycontent queryContent { get; set; }
        public Device device { get; set; }
        public Browser browser { get; set; }
        public Experiments experiments { get; set; }
    }

    //public class Route
    //{
    //    public object partInstrument { get; set; }
    //    public string page { get; set; }
    //    public int songId { get; set; }
    //    public int partId { get; set; }
    //    public object revisionId { get; set; }
    //    public bool isPanel { get; set; }
    //}

    public class Query
    {
    }

    public class Player
    {
        public object audio { get; set; }
        public bool shouldPlay { get; set; }
        public bool canPlay { get; set; }
        public bool isLoopChanging { get; set; }
        public bool isCountin { get; set; }
        public bool isMetronome { get; set; }
        public string metronomeType { get; set; }
        public bool voiceMetronomeAvailable { get; set; }
        public Position position { get; set; }
        public string type { get; set; }
        public int version { get; set; }
        public object forcedVersion { get; set; }
        public int pitchShift { get; set; }
        public int speed { get; set; }
        public Tempo tempo { get; set; }
        public string[] locks { get; set; }
        public bool playbackAvailable { get; set; }
        public bool webworkerOperational { get; set; }
        public bool isAudioFailed { get; set; }
        public bool isAudioNetworkFailed { get; set; }
    }

    public class Position
    {
        public int cursor { get; set; }
        public int loopStart { get; set; }
        public int loopEnd { get; set; }
    }

    public class Tempo
    {
        public int bpm { get; set; }
        public int type { get; set; }
        public int position { get; set; }
    }

    public class Meta
    {
        public Current current { get; set; }
        public bool allowedByLicense { get; set; }
        public int songId { get; set; }
        public int? partId { get; set; }
        public object revisionId { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
        public bool wasFavoriteOnServerRender { get; set; }
    }

    public class Current
    {
        public int songId { get; set; }
        public int artistId { get; set; }
        public int revisionId { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public DateTime created_at { get; set; }
        public int personId { get; set; }
        public string person { get; set; }
        public string restriction { get; set; }
        public bool hasChords { get; set; }
        public int[] editors { get; set; }
        public string image { get; set; }
        public bool hasTracks { get; set; }
        public bool hasPlayer { get; set; }
        public int defaultTrackBass { get; set; }
        public int defaultTrackDrums { get; set; }
        public int defaultTrack { get; set; }
        public bool lyrics { get; set; }
        public Track[] tracks { get; set; }
        public int defaultTrackGuitar { get; set; }
        public string audioV4Midi { get; set; }
        public string audioV2Midi { get; set; }
        public bool hasAudio { get; set; }
        public string audioV4 { get; set; }
        public long audioV4Generated { get; set; }
        public long audioV2Generated { get; set; }
        public string audioV2 { get; set; }
        public int views { get; set; }
        public string[] tags { get; set; }
    }

    public class Track
    {
        public int[] tuning { get; set; }
        public int instrumentId { get; set; }
        public string name { get; set; }
        public string instrument { get; set; }
        public int views { get; set; }
        public string title { get; set; }
        public int partId { get; set; }
        public string difficulty { get; set; }
        public int difficultyVersion { get; set; }
        public bool isGuitar { get; set; }
        public bool isBassGuitar { get; set; }
        public bool isDrums { get; set; }
    }

    public class Part
    {
        public object current { get; set; }
        public Lines lines { get; set; }
        public int songId { get; set; }
        public int partId { get; set; }
        public int revisionId { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
    }

    public class Lines
    {
        public object[] lines { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int scale { get; set; }
        public string hash { get; set; }
        public Slicingmode slicingMode { get; set; }
    }

    public class Slicingmode
    {
        public int width { get; set; }
    }

    public class User
    {
        public object profile { get; set; }
        public bool hasPlus { get; set; }
        public bool isAdmin { get; set; }
        public bool isModerator { get; set; }
        public bool isLoggedIn { get; set; }
    }

    public class Screen
    {
        public string screen { get; set; }
        public Viewport viewport { get; set; }
        public bool isSmall { get; set; }
        public bool isMedium { get; set; }
        public bool isLarge { get; set; }
        public bool isWide { get; set; }
        public bool fullscreen { get; set; }
    }

    public class Viewport
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Consent
    {
        public object suite { get; set; }
        public object view { get; set; }
        public object options { get; set; }
    }

    public class Artist
    {
        public int id { get; set; }
        public Artists artists { get; set; }
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Songs songs { get; set; }
        public Filters1 filters { get; set; }
        public object loading { get; set; }
    }

    public class Artists
    {

        [JsonProperty("14")]
        public string _14 { get; set; }
    }

    public class Songs
    {
        public int id { get; set; }
        public object[] list { get; set; }
        public bool hasMore { get; set; }
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Filters filters { get; set; }
    }

    public class Filters
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
        public Tunings tunings { get; set; }
    }

    public class Tunings
    {
    }

    public class Filters1
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
        public Tunings1 tunings { get; set; }
    }

    public class Tunings1
    {
    }

    public class Favorites
    {
        public bool loading { get; set; }
        public bool error { get; set; }
        public string pattern { get; set; }
        public object[] favorites { get; set; }
        public string actionId { get; set; }
        public Filters2 filters { get; set; }
    }

    public class Filters2
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
        public Tunings2 tunings { get; set; }
    }

    public class Tunings2
    {
    }

    public class Layer
    {
        public object layer { get; set; }
    }

    public class Revisions
    {
        public object revisions { get; set; }
        public bool isLoading { get; set; }
        public bool isError { get; set; }
    }

    public class Payment
    {
        public Dropin dropin { get; set; }
    }

    public class Dropin
    {
        public bool loading { get; set; }
        public bool ready { get; set; }
        public object error { get; set; }
        public object module { get; set; }
        public object token { get; set; }
    }

    public class Songs1
    {
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Songs2 songs { get; set; }
        public Filters4 filters { get; set; }
        public object loading { get; set; }
    }

    public class Songs2
    {
        public object[] list { get; set; }
        public bool hasMore { get; set; }
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Filters3 filters { get; set; }
    }

    public class Filters3
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
        public Tunings3 tunings { get; set; }
    }

    public class Tunings3
    {
    }

    public class Filters4
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
        public Tunings4 tunings { get; set; }
    }

    public class Tunings4
    {
    }

    public class Uploads
    {
        public object song { get; set; }
        public bool songSubmitted { get; set; }
        public object songError { get; set; }
        public object revision { get; set; }
        public bool revisionSubmitted { get; set; }
        public object revisionError { get; set; }
    }

    public class Demo
    {
        public bool active { get; set; }
        public bool enabled { get; set; }
    }

    public class Promo
    {
        public bool active { get; set; }
        public object[] playbackPositionEvents { get; set; }
        public object[] playbackTypeEvents { get; set; }
        public int halfPlayed { get; set; }
    }

    public class Editor
    {
        public bool processingDeletion { get; set; }
        public bool canDelete { get; set; }
    }

    public class Ads
    {
        public object notsyLoaded { get; set; }
        public object notsyFailed { get; set; }
    }

    public class Setlists
    {
        public bool loading { get; set; }
        public object[] setlists { get; set; }
        public object[] markedIds { get; set; }
    }

    public class Screener
    {
        public object[] candidates { get; set; }
    }

    public class Textpage
    {
        public string slug { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public bool isLoading { get; set; }
        public bool isError { get; set; }
    }

    public class Faq
    {
        public bool isLoading { get; set; }
        public bool isError { get; set; }
    }

    public class Ut
    {
        public string recorderState { get; set; }
        public string stage { get; set; }
        public Steps steps { get; set; }
        public bool isAdditional { get; set; }
        public bool isClosing { get; set; }
        public bool isHidden { get; set; }
    }

    public class Steps
    {
        public int questions { get; set; }
        public int instructions { get; set; }
        public int survey { get; set; }
    }

    public class Chords
    {
        public object current { get; set; }
        public int songId { get; set; }
        public object chordsRevisionId { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
    }

    public class Chordpro
    {
        public object current { get; set; }
        public int songId { get; set; }
        public int chordsRevisionId { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
    }

    public class Tabeditor
    {
        public bool positioned { get; set; }
        public int formX { get; set; }
        public int formY { get; set; }
        public int measureNum { get; set; }
        public int beatNum { get; set; }
        public int stringNum { get; set; }
        public int voice { get; set; }
        public string fret { get; set; }
        public string originalFret { get; set; }
        public string status { get; set; }
        public object[] adminData { get; set; }
        public bool adminPanelOpened { get; set; }
    }

    public class Cursor
    {
        public bool isFailed { get; set; }
    }

    public class Tags
    {
        public object route { get; set; }
        public object query { get; set; }
        public object content { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
    }

    public class Curiosity
    {
        public Conversion conversion { get; set; }
        public Referer referer { get; set; }
        public Vpt10props VPT10Props { get; set; }
    }

    public class Conversion
    {
    }

    public class Referer
    {
    }

    public class Vpt10props
    {
        public bool Usedmetronome { get; set; }
        public bool Usedcountin { get; set; }
        public bool Usedsolo { get; set; }
        public bool Usedmute { get; set; }
        public bool Usedplayback { get; set; }
        public bool Usedspeed { get; set; }
        public bool Usedloop { get; set; }
        public bool Usedmixer { get; set; }
        public bool Usedpitchshift { get; set; }
        public bool Usedfullscreen { get; set; }
    }

    //public class Routecontent
    //{
    //    public object partInstrument { get; set; }
    //    public string page { get; set; }
    //    public int songId { get; set; }
    //    public int partId { get; set; }
    //    public object revisionId { get; set; }
    //    public bool isPanel { get; set; }
    //}

    public class Querycontent
    {
    }

    public class Device
    {
        public Os os { get; set; }
        public string type { get; set; }
        public bool webview { get; set; }
        public object[] languages { get; set; }
        public string country { get; set; }
        public bool isPhone { get; set; }
        public bool isTablet { get; set; }
        public bool isDesktop { get; set; }
        public bool hasCCPA { get; set; }
        public bool hasGDPR { get; set; }
    }

    public class Os
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Browser
    {
        public string family { get; set; }
        public string version { get; set; }
        public string browsersListEnv { get; set; }
    }

    public class Experiments
    {
        public Emotions_On_Plus emotions_on_plus { get; set; }
    }

    public class Emotions_On_Plus
    {
        public string status { get; set; }
        public string segment { get; set; }
    }


}
