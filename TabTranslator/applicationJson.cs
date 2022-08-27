using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TabTranslator
{

    public class Artist
    {
        public int id { get; set; }
        public Artists artists { get; set; }
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Songs songs { get; set; }
        public Filters filters { get; set; }
        public object loading { get; set; }
    }

    public class Artists
    {
        public string _14 { get; set; }
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
        public List<int> editors { get; set; }
        public string image { get; set; }
        public bool hasTracks { get; set; }
        public bool hasPlayer { get; set; }
        public int defaultTrackBass { get; set; }
        public int defaultTrackDrums { get; set; }
        public int defaultTrack { get; set; }
        public bool lyrics { get; set; }
        public List<Track> tracks { get; set; }  //use this to get .json number for url and also to choose which song part
        public int defaultTrackGuitar { get; set; }
        public string audioV4Midi { get; set; }
        public string audioV2Midi { get; set; }
        public bool hasAudio { get; set; }
        public string audioV4 { get; set; }
        public long audioV4Generated { get; set; }
        public long audioV2Generated { get; set; }
        public string audioV2 { get; set; }
        public int views { get; set; }
        public List<string> tags { get; set; }
    }

    public class Filters
    {
        public string instrument { get; set; }
        public string difficulty { get; set; }
    }

    public class Part
    {
        public object current { get; set; }
        public int songId { get; set; }
        public int partId { get; set; }
        public int revisionId { get; set; }
        public bool isFailed { get; set; }
        public bool isNotFound { get; set; }
        public bool isNetworkFailed { get; set; }
        public object loading { get; set; }
    }

    public class Revisions
    {
        public object revisions { get; set; }
        public bool isLoading { get; set; }
        public bool isError { get; set; }
    }

    public class Route
    {
        public object partInstrument { get; set; }
        public string page { get; set; }
        public int songId { get; set; }
        public int partId { get; set; }
        public object revisionId { get; set; }
        public bool isPanel { get; set; }
    }

    public class Songs
    {
        public int id { get; set; }
        public List<object> list { get; set; }
        public bool hasMore { get; set; }
        public string pattern { get; set; }
        public int defaultInstrument { get; set; }
        public Filters filters { get; set; }
        public Songs songs { get; set; }
        public object loading { get; set; }
    }

    public class Track
    {
        public List<int> tuning { get; set; }
        public int instrumentId { get; set; }
        public string name { get; set; }
        public string instrument { get; set; }
        public int views { get; set; }
        public string title { get; set; }
        public int partId { get; set; }
        public string difficulty { get; set; }
        public int? difficultyVersion { get; set; }
        public bool? isGuitar { get; set; }
        public bool? isBassGuitar { get; set; }
        public bool? isDrums { get; set; }
    }



}
