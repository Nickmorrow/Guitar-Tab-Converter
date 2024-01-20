using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class InstObjects
    {
        public static List<StringInstrument> DefStrInstruments()
        {
            List<StringInstrument> instruments = new List<StringInstrument>();

            // Defining SixStringGuitar

            // Standard Tuning

            MusicString GString0 = new MusicString();
            GString0.Tuning = RootNotes.E;
            MusicString GString1 = new MusicString();
            GString1.Tuning = RootNotes.B;
            MusicString GString2 = new MusicString();
            GString2.Tuning = RootNotes.G;
            MusicString GString3 = new MusicString();
            GString3.Tuning = RootNotes.D;
            MusicString GString4 = new MusicString();
            GString4.Tuning = RootNotes.A;
            MusicString GString5 = new MusicString();
            GString5.Tuning = RootNotes.E;

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
            SixStringGuitar.FretCount = 21;
            SixStringGuitar.MusicStrings = StandardGuitarTunings;

            instruments.Add(SixStringGuitar);

            // Defining BassGuitar

            // Standard Tuning

            MusicString BGString0 = new MusicString();
            BGString0.Tuning = RootNotes.G;
            MusicString BGString1 = new MusicString();
            BGString1.Tuning = RootNotes.D;
            MusicString BGString2 = new MusicString();
            BGString2.Tuning = RootNotes.A;
            MusicString BGString3 = new MusicString();
            BGString3.Tuning = RootNotes.E;

            List<MusicString> StandardBassGuitarTunings = new List<MusicString>();
            StandardBassGuitarTunings.Add(BGString0);
            StandardBassGuitarTunings.Add(BGString1);
            StandardBassGuitarTunings.Add(BGString2);
            StandardBassGuitarTunings.Add(BGString3);

            StringInstrument BassGuitar = new StringInstrument();

            BassGuitar.Name = "BassGuitar";
            BassGuitar.FretCount = 21;
            BassGuitar.MusicStrings = StandardBassGuitarTunings;

            instruments.Add(BassGuitar);

            // Defining Ukelele

            // Standard tuning

            MusicString UkString0 = new MusicString();
            UkString0.Tuning = RootNotes.D;
            MusicString UkString1 = new MusicString();
            UkString1.Tuning = RootNotes.B;
            MusicString UkString2 = new MusicString();
            UkString2.Tuning = RootNotes.C;
            MusicString UkString3 = new MusicString();
            UkString3.Tuning = RootNotes.D;

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

            return instruments;

            // Defining Banjo

            // Standard tuning

            MusicString BanjoString0 = new MusicString();
            BanjoString0.Tuning = RootNotes.A;
            MusicString BanjoString1 = new MusicString();
            BanjoString1.Tuning = RootNotes.E;
            MusicString BanjoString2 = new MusicString();
            BanjoString2.Tuning = RootNotes.C;
            MusicString BanjoString3 = new MusicString();
            BanjoString3.Tuning = RootNotes.G;

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
