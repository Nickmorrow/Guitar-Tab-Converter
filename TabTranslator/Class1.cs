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
//        public RootObject[] measures { get; set; }
//        public int capo { get; set; }
//        public int voices { get; set; }
//        public Automations automations { get; set; }
//        public int version { get; set; }
//        public int songId { get; set; }
//        public int partId { get; set; }
//        public int revisionId { get; set; }
//    }

//    public class Automations
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

//    public class RootObject
//    {
//        public int index { get; set; }
//        public int[] signature { get; set; }
//        public Voice[] voices { get; set; }
//        public bool rest { get; set; }
//        public Marker marker { get; set; }
//    }

//    public class Marker
//    {
//        public string text { get; set; }
//        public int width { get; set; }
//    }

//    public class Voice
//    {
//        public Beat[] beats { get; set; }
//    }

//    public class Beat
//    {
//        public int type { get; set; }
//        public bool rest { get; set; }
//        public Note[] notes { get; set; }
//        public Tempo1 tempo { get; set; }
//        public int[] duration { get; set; }
//        public Text text { get; set; }
//        public bool beamStart { get; set; }
//        public string velocity { get; set; }
//        public bool beamStop { get; set; }
//        public int tuplet { get; set; }
//        public bool tupletStart { get; set; }
//        public bool tupletStop { get; set; }
//        public bool dotted { get; set; }
//        public bool vibrato { get; set; }
//        public Chord chord { get; set; }
//        public int upStroke { get; set; }
//        public bool letRing { get; set; }
//    }

//    public class Tempo1
//    {
//        public int type { get; set; }
//        public int bpm { get; set; }
//    }

//    public class Text
//    {
//        public string text { get; set; }
//        public int width { get; set; }
//    }

//    public class Chord
//    {
//        public string text { get; set; }
//        public int width { get; set; }
//    }

//    public class Note
//    {
//        public bool rest { get; set; }
//        public int _string { get; set; }
//        public int fret { get; set; }
//        public int accentuated { get; set; }
//        public string slide { get; set; }
//        public bool hp { get; set; }
//        public bool tie { get; set; }
//        public bool grace { get; set; }
//        public bool ghost { get; set; }
//        public bool vibrato { get; set; }
//        public Bend bend { get; set; }
//        public bool staccato { get; set; }
//        public bool dead { get; set; }
//    }

//    public class Bend
//    {
//        public Point[] points { get; set; }
//        public int tone { get; set; }
//    }

//    public class Point
//    {
//        public int position { get; set; }
//        public int tone { get; set; }
//        public int vibrato { get; set; }
//    }

//}
