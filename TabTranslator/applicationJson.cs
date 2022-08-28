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
    public partial class Welcome3
    {

        [JsonProperty("songs")]
        public Welcome3Songs Songs { get; set; }

        [JsonProperty("uploads")]
        public Uploads Uploads { get; set; }

        [JsonProperty("chords")]
        public Chord Chords { get; set; }

        [JsonProperty("chordpro")]
        public Chord Chordpro { get; set; }

        [JsonProperty("chordDiagram")]
        public object[] ChordDiagram { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("defaultInstrument")]
        public long DefaultInstrument { get; set; }

        [JsonProperty("songs")]
        public ArtistSongs Songs { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("loading")]
        public object Loading { get; set; }
    }

    public partial class Artists
    {
        [JsonProperty("14")]
        public string The14 { get; set; }
    }

    public partial class Filters
    {
        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
    }

    public partial class ArtistSongs
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("list")]
        public object[] List { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("defaultInstrument")]
        public long DefaultInstrument { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }
    }

    public partial class Chord
    {
        [JsonProperty("current")]
        public object Current { get; set; }

        [JsonProperty("songId")]
        public long SongId { get; set; }

        [JsonProperty("chordsRevisionId")]
        public long? ChordsRevisionId { get; set; }

        [JsonProperty("isFailed")]
        public bool IsFailed { get; set; }

        [JsonProperty("isNotFound")]
        public bool IsNotFound { get; set; }

        [JsonProperty("isNetworkFailed")]
        public bool IsNetworkFailed { get; set; }

        [JsonProperty("loading")]
        public object Loading { get; set; }
    }

    public partial class Current
    {
        [JsonProperty("songId")]
        public long SongId { get; set; }

        [JsonProperty("artistId")]
        public long ArtistId { get; set; }

        [JsonProperty("revisionId")]
        public long RevisionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("artist")]
        //public string Artist { get; set; }   //throwing exception

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("personId")]
        public long PersonId { get; set; }

        [JsonProperty("person")]
        public string Person { get; set; }

        [JsonProperty("restriction")]
        public string Restriction { get; set; }

        [JsonProperty("hasChords")]
        public bool HasChords { get; set; }

        [JsonProperty("editors")]
        public long[] Editors { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("hasTracks")]
        public bool HasTracks { get; set; }

        [JsonProperty("hasPlayer")]
        public bool HasPlayer { get; set; }

        [JsonProperty("defaultTrackBass")]
        public long DefaultTrackBass { get; set; }

        [JsonProperty("defaultTrackDrums")]
        public long DefaultTrackDrums { get; set; }

        [JsonProperty("defaultTrack")]
        public long DefaultTrack { get; set; }

        [JsonProperty("lyrics")]
        public bool Lyrics { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("defaultTrackGuitar")]
        public long DefaultTrackGuitar { get; set; }

        [JsonProperty("audioV4Midi")]
        public string AudioV4Midi { get; set; }

        [JsonProperty("audioV2Midi")]
        public string AudioV2Midi { get; set; }

        [JsonProperty("hasAudio")]
        public bool HasAudio { get; set; }

        [JsonProperty("audioV4")]
        public string AudioV4 { get; set; }

        [JsonProperty("audioV4Generated")]
        public long AudioV4Generated { get; set; }

        [JsonProperty("audioV2Generated")]
        public long AudioV2Generated { get; set; }

        [JsonProperty("audioV2")]
        public string AudioV2 { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        //[JsonProperty("tags")]
        //public string[] Tags { get; set; }    //throwing exception
    }

    public partial class Track
    {
        [JsonProperty("tuning", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Tuning { get; set; }

        [JsonProperty("instrumentId")]
        public long InstrumentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("partId")]
        public long PartId { get; set; }

        [JsonProperty("difficulty", NullValueHandling = NullValueHandling.Ignore)]
        public string Difficulty { get; set; }

        [JsonProperty("difficultyVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? DifficultyVersion { get; set; }

        [JsonProperty("isGuitar", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGuitar { get; set; }

        [JsonProperty("isBassGuitar", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBassGuitar { get; set; }

        [JsonProperty("isDrums", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDrums { get; set; }
    }

    public partial class Welcome3Songs
    {
        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("defaultInstrument")]
        public long DefaultInstrument { get; set; }

        [JsonProperty("songs")]
        public ArtistSongs Songs { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("loading")]
        public object Loading { get; set; }
    }

    public partial class Uploads
    {
        [JsonProperty("song")]
        public object Song { get; set; }

        [JsonProperty("songSubmitted")]
        public bool SongSubmitted { get; set; }

        [JsonProperty("songError")]
        public object SongError { get; set; }

        [JsonProperty("revision")]
        public object Revision { get; set; }

        [JsonProperty("revisionSubmitted")]
        public bool RevisionSubmitted { get; set; }

        [JsonProperty("revisionError")]
        public object RevisionError { get; set; }
    }

}
