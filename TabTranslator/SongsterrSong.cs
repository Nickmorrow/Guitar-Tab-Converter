﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TabTranslator
{
    // is missing certain parameters, check json data for other songs
    public partial class SongsterrSong
    {
        [JsonProperty("strings")]
        public long Strings { get; set; }

        [JsonProperty("frets")]
        public long Frets { get; set; }

        [JsonProperty("tuning")]
        public long[] Tuning { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("instrumentId")]
        public long InstrumentId { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("measures")]
        public Measure[] Measures { get; set; }

        [JsonProperty("capo")]
        public long Capo { get; set; }

        [JsonProperty("voices")]
        public long Voices { get; set; }

        [JsonProperty("automations")]
        public Automations Automations { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("songId")]
        public long SongId { get; set; }

        [JsonProperty("partId")]
        public long PartId { get; set; }

        [JsonProperty("revisionId")]
        public long RevisionId { get; set; }
    }

    public partial class Automations
    {
        [JsonProperty("tempo")]
        public TempoElement[] Tempo { get; set; }
    }

    public partial class TempoElement
    {
        [JsonProperty("measure")]
        public long Measure { get; set; }

        [JsonProperty("linear")]
        public bool Linear { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("bpm")]
        public long Bpm { get; set; }
    }

    public partial class Measure
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Signature { get; set; }

        [JsonProperty("marker", NullValueHandling = NullValueHandling.Ignore)]
        public Marker Marker { get; set; }

        [JsonProperty("voices")]
        public Voice[] Voices { get; set; }

        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rest { get; set; }

        [JsonProperty("repeatStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RepeatStart { get; set; }

        [JsonProperty("alternateEnding", NullValueHandling = NullValueHandling.Ignore)]
        public long[] AlternateEnding { get; set; }

        [JsonProperty("repeat", NullValueHandling = NullValueHandling.Ignore)]
        public long? Repeat { get; set; }
    }

    public partial class Marker
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Voice
    {
        [JsonProperty("beats")]
        public Beat[] Beats { get; set; }
    }

    public partial class Beat
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rest { get; set; }

        [JsonProperty("notes")]
        public Note[] Notes { get; set; }

        [JsonProperty("tempo", NullValueHandling = NullValueHandling.Ignore)]
        public BeatTempo Tempo { get; set; }

        [JsonProperty("duration")]
        public long[] Duration { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public Marker Text { get; set; }

        [JsonProperty("harmonic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Harmonic { get; set; }

        [JsonProperty("velocity", NullValueHandling = NullValueHandling.Ignore)]
        public string Velocity { get; set; }

        [JsonProperty("beamStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BeamStart { get; set; }

        [JsonProperty("beamStop", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BeamStop { get; set; }

        [JsonProperty("vibrato", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vibrato { get; set; }
    }

    public partial class Note
    {
        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rest { get; set; }

        [JsonProperty("string", NullValueHandling = NullValueHandling.Ignore)]
        public long? String { get; set; }

        [JsonProperty("fret", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fret { get; set; }

        [JsonProperty("harmonic", NullValueHandling = NullValueHandling.Ignore)]
        public string Harmonic { get; set; }

        [JsonProperty("tie", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Tie { get; set; }

        [JsonProperty("bend", NullValueHandling = NullValueHandling.Ignore)]
        public Bend Bend { get; set; }

        [JsonProperty("vibrato", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vibrato { get; set; }

        [JsonProperty("dead", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Dead { get; set; }
    }

    public partial class Bend
    {
        [JsonProperty("points")]
        public Point[] Points { get; set; }

        [JsonProperty("tone")]
        public long Tone { get; set; }
    }

    public partial class Point
    {
        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("tone")]
        public long Tone { get; set; }

        [JsonProperty("vibrato")]
        public long Vibrato { get; set; }
    }

    public partial class BeatTempo
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("bpm")]
        public long Bpm { get; set; }
    }

    public partial class SongsterrSong
    {
        public static SongsterrSong FromJson(string json) => JsonConvert.DeserializeObject<SongsterrSong>(json, TabTranslator.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SongsterrSong self) => JsonConvert.SerializeObject(self, TabTranslator.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
