//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Globalization;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

//namespace TabTranslator
//{

//    public class Rootobject
//    {
//        public int strings { get; set; }
//        public int frets { get; set; }
//        public int[] tuning { get; set; }
//        public string name { get; set; }
//        public string instrument { get; set; }
//        public int instrumentId { get; set; }
//        public float volume { get; set; }
//        public int balance { get; set; }
//        public Measure[] measures { get; set; }
//        public int capo { get; set; }
//        public int voices { get; set; }
//        public Automations automations { get; set; }
//        public int version { get; set; }
//        public int songId { get; set; }
//        public int partId { get; set; }
//        public int revisionId { get; set; }
//    }

//    public partial class Automations
//    {
//        public Tempo[] tempo { get; set; }
//    }

//    public class Tempo
//    {
//        public int measure { get; set; }
//        public bool linear { get; set; }
//        public bool visible { get; set; }
//        public int position { get; set; }
//        public int type { get; set; }
//        public int bpm { get; set; }
//    }

//    public partial class Measure
//    {
//        public int index { get; set; }
//        public int[] signature { get; set; }
//        public Marker marker { get; set; }
//        public Voice[] voices { get; set; }
//        public bool rest { get; set; }
//        public bool repeatStart { get; set; }
//        public int[] alternateEnding { get; set; }
//        public int repeat { get; set; }
//    }

//    public partial class Marker
//    {
//        public string text { get; set; }
//        public int width { get; set; }
//    }

//    public partial class Voice
//    {
//        public Beat[] beats { get; set; }
//    }

//    public partial class Beat
//    {
//        public int type { get; set; }
//        public bool rest { get; set; }
//        public Note[] notes { get; set; }
//        public Tempo1 tempo { get; set; }
//        public int[] duration { get; set; }
//        public Text text { get; set; }
//        public bool harmonic { get; set; }
//        public string velocity { get; set; }
//        public bool beamStart { get; set; }
//        public bool beamStop { get; set; }
//        public bool vibrato { get; set; }
//    }

//    public partial class Tempo1
//    {
//        public int type { get; set; }
//        public int bpm { get; set; }
//    }

//    public partial class Text
//    {
//        public string text { get; set; }
//        public int width { get; set; }
//    }

//    public partial class Note
//    {
//        public bool rest { get; set; }
//        public int _string { get; set; }
//        public int fret { get; set; }
//        public string harmonic { get; set; }
//        public bool tie { get; set; }
//        public Bend bend { get; set; }
//        public bool vibrato { get; set; }
//    }

//    public partial class Bend
//    {
//        public Point[] points { get; set; }
//        public int tone { get; set; }
//    }

//    public partial class Point
//    {
//        public int position { get; set; }
//        public int tone { get; set; }
//        public int vibrato { get; set; }
//    }



//}
