using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTabConverter
{
    public class InstObjects
    {
        public static List<StringInstrument> DefStrInstruments()
        {
            List<StringInstrument> instruments = new List<StringInstrument>();

            // Defining SixStringGuitar

            // Standard Tuning

            MusicString GString0 = new MusicString();
            GString0.Tuning = RootNotes.E4;
            GString0.MidiNum = 64; 
            MusicString GString1 = new MusicString();
            GString1.Tuning = RootNotes.B3;
            GString1.MidiNum = 59;
            MusicString GString2 = new MusicString();
            GString2.Tuning = RootNotes.G3;
            GString2.MidiNum = 55;
            MusicString GString3 = new MusicString();
            GString3.Tuning = RootNotes.D3;
            GString3.MidiNum = 50;
            MusicString GString4 = new MusicString();
            GString4.Tuning = RootNotes.A2;
            GString4.MidiNum = 45;
            MusicString GString5 = new MusicString();
            GString5.Tuning = RootNotes.E2;
            GString5.MidiNum = 40;

            List<MusicString> StandardGuitarTunings = new List<MusicString>(); //string list is reverse of normal to match json data
            StandardGuitarTunings.Add(GString0);
            StandardGuitarTunings.Add(GString1);
            StandardGuitarTunings.Add(GString2);
            StandardGuitarTunings.Add(GString3);
            StandardGuitarTunings.Add(GString4);
            StandardGuitarTunings.Add(GString5);

            // Guitar

            StringInstrument SixStringGuitar = new StringInstrument();

            SixStringGuitar.Name = "SixStringGuitar";
            SixStringGuitar.FretCount = 22;
            SixStringGuitar.MusicStrings = StandardGuitarTunings;

            instruments.Add(SixStringGuitar);

            // Defining BassGuitar

            // Standard Tuning

            MusicString BGString0 = new MusicString();
            BGString0.Tuning = RootNotes.G2;
            BGString0.MidiNum = 43;
            MusicString BGString1 = new MusicString();
            BGString1.Tuning = RootNotes.D2;
            BGString1.MidiNum = 38;
            MusicString BGString2 = new MusicString();
            BGString2.Tuning = RootNotes.A1;
            BGString2.MidiNum = 33;
            MusicString BGString3 = new MusicString();
            BGString3.Tuning = RootNotes.E1;
            BGString3.MidiNum = 28;

            List<MusicString> StandardBassGuitarTunings = new List<MusicString>();
            StandardBassGuitarTunings.Add(BGString0);
            StandardBassGuitarTunings.Add(BGString1);
            StandardBassGuitarTunings.Add(BGString2);
            StandardBassGuitarTunings.Add(BGString3);

            StringInstrument BassGuitar = new StringInstrument();

            BassGuitar.Name = "BassGuitar";
            BassGuitar.FretCount = 22;
            BassGuitar.MusicStrings = StandardBassGuitarTunings;

            instruments.Add(BassGuitar);

            // Defining Ukelele

            // Standard tuning

            MusicString UkString0 = new MusicString();
            UkString0.Tuning = RootNotes.A4;
            UkString0.MidiNum = 69;
            MusicString UkString1 = new MusicString();
            UkString1.Tuning = RootNotes.E4;
            UkString1.MidiNum = 64;
            MusicString UkString2 = new MusicString();
            UkString2.Tuning = RootNotes.C4;
            UkString2.MidiNum = 60;
            MusicString UkString3 = new MusicString();
            UkString3.Tuning = RootNotes.G4;
            UkString3.MidiNum = 67;

            List<MusicString> StandardUkeleleTunings = new List<MusicString>();
            StandardUkeleleTunings.Add(UkString0);
            StandardUkeleleTunings.Add(UkString1);
            StandardUkeleleTunings.Add(UkString2);
            StandardUkeleleTunings.Add(UkString3);

            StringInstrument Ukelele = new StringInstrument();

            Ukelele.Name = "Ukelele";
            Ukelele.FretCount = 12;
            Ukelele.MusicStrings = StandardUkeleleTunings;

            instruments.Add(Ukelele);           

            // Defining Banjo

            // Standard tuning

            MusicString BanjoString0 = new MusicString();
            BanjoString0.Tuning = RootNotes.D4;
            BanjoString0.MidiNum = 62;
            MusicString BanjoString1 = new MusicString();
            BanjoString1.Tuning = RootNotes.B3;
            BanjoString1.MidiNum = 59;
            MusicString BanjoString2 = new MusicString();
            BanjoString2.Tuning = RootNotes.G3;
            BanjoString2.MidiNum = 55;
            MusicString BanjoString3 = new MusicString();
            BanjoString3.Tuning = RootNotes.D3;
            BanjoString3.MidiNum = 50;

            List<MusicString> StandardBanjoTunings = new List<MusicString>();
            StandardBanjoTunings.Add(BanjoString0);
            StandardBanjoTunings.Add(BanjoString1);
            StandardBanjoTunings.Add(BanjoString2);
            StandardBanjoTunings.Add(BanjoString3);

            StringInstrument Banjo = new StringInstrument();

            Banjo.Name = "Banjo";
            Banjo.FretCount = 22;
            Banjo.MusicStrings = StandardBanjoTunings;

            instruments.Add(Banjo);

            return instruments;
        }
    }
}
