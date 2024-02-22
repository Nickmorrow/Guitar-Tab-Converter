using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTabConverter
{
    public class Midi
    {
        public static List<RootNotes> DefineMidiNotes()
        {
            List<RootNotes> midiNotes = new List<RootNotes>();
            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);
            midiNotes.Add(RootNotes.GsAb);
            midiNotes.Add(RootNotes.A);
            midiNotes.Add(RootNotes.AsBb);
            midiNotes.Add(RootNotes.B);

            midiNotes.Add(RootNotes.C00);
            midiNotes.Add(RootNotes.CsDb00);
            midiNotes.Add(RootNotes.D00);
            midiNotes.Add(RootNotes.DsEb00);
            midiNotes.Add(RootNotes.E00);
            midiNotes.Add(RootNotes.F00);
            midiNotes.Add(RootNotes.FsGb00);
            midiNotes.Add(RootNotes.G00);
            midiNotes.Add(RootNotes.GsAb00);
            midiNotes.Add(RootNotes.A0);
            midiNotes.Add(RootNotes.AsBb0);
            midiNotes.Add(RootNotes.B0);

            midiNotes.Add(RootNotes.C1);
            midiNotes.Add(RootNotes.CsDb1);
            midiNotes.Add(RootNotes.D1);
            midiNotes.Add(RootNotes.DsEb1);
            midiNotes.Add(RootNotes.E1);
            midiNotes.Add(RootNotes.F1);
            midiNotes.Add(RootNotes.FsGb1);
            midiNotes.Add(RootNotes.G1);
            midiNotes.Add(RootNotes.GsAb1);
            midiNotes.Add(RootNotes.A1);
            midiNotes.Add(RootNotes.AsBb1);
            midiNotes.Add(RootNotes.B1);

            midiNotes.Add(RootNotes.C2);
            midiNotes.Add(RootNotes.CsDb2);
            midiNotes.Add(RootNotes.D2);
            midiNotes.Add(RootNotes.DsEb2);
            midiNotes.Add(RootNotes.E2);
            midiNotes.Add(RootNotes.F2);
            midiNotes.Add(RootNotes.FsGb2);
            midiNotes.Add(RootNotes.G2);
            midiNotes.Add(RootNotes.GsAb2);
            midiNotes.Add(RootNotes.A2);
            midiNotes.Add(RootNotes.AsBb2);
            midiNotes.Add(RootNotes.B2);

            midiNotes.Add(RootNotes.C3);
            midiNotes.Add(RootNotes.CsDb3);
            midiNotes.Add(RootNotes.D3);
            midiNotes.Add(RootNotes.DsEb3);
            midiNotes.Add(RootNotes.E3);
            midiNotes.Add(RootNotes.F3);
            midiNotes.Add(RootNotes.FsGb3);
            midiNotes.Add(RootNotes.G3);
            midiNotes.Add(RootNotes.GsAb3);
            midiNotes.Add(RootNotes.A3);
            midiNotes.Add(RootNotes.AsBb3);
            midiNotes.Add(RootNotes.B3);

            midiNotes.Add(RootNotes.C4);
            midiNotes.Add(RootNotes.CsDb4);
            midiNotes.Add(RootNotes.D4);
            midiNotes.Add(RootNotes.DsEb4);
            midiNotes.Add(RootNotes.E4);
            midiNotes.Add(RootNotes.F4);
            midiNotes.Add(RootNotes.FsGb4);
            midiNotes.Add(RootNotes.G4);
            midiNotes.Add(RootNotes.GsAb4);
            midiNotes.Add(RootNotes.A4);
            midiNotes.Add(RootNotes.AsBb4);
            midiNotes.Add(RootNotes.B4);

            midiNotes.Add(RootNotes.C5);
            midiNotes.Add(RootNotes.CsDb5);
            midiNotes.Add(RootNotes.D5);
            midiNotes.Add(RootNotes.DsEb5);
            midiNotes.Add(RootNotes.E5);
            midiNotes.Add(RootNotes.F5);
            midiNotes.Add(RootNotes.FsGb5);
            midiNotes.Add(RootNotes.G5);
            midiNotes.Add(RootNotes.GsAb5);
            midiNotes.Add(RootNotes.A5);
            midiNotes.Add(RootNotes.AsBb5);
            midiNotes.Add(RootNotes.B5);

            midiNotes.Add(RootNotes.C6);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D6);
            midiNotes.Add(RootNotes.DsEb6);
            midiNotes.Add(RootNotes.E6);
            midiNotes.Add(RootNotes.F6);
            midiNotes.Add(RootNotes.FsGb6);
            midiNotes.Add(RootNotes.G6);
            midiNotes.Add(RootNotes.GsAb6);
            midiNotes.Add(RootNotes.A6);
            midiNotes.Add(RootNotes.AsBb6);
            midiNotes.Add(RootNotes.B6);

            midiNotes.Add(RootNotes.C7);
            midiNotes.Add(RootNotes.CsDb7);
            midiNotes.Add(RootNotes.D7);
            midiNotes.Add(RootNotes.DsEb7);
            midiNotes.Add(RootNotes.E7);
            midiNotes.Add(RootNotes.F7);
            midiNotes.Add(RootNotes.FsGb7);
            midiNotes.Add(RootNotes.G7);
            midiNotes.Add(RootNotes.GsAb7);
            midiNotes.Add(RootNotes.A7);
            midiNotes.Add(RootNotes.AsBb7);
            midiNotes.Add(RootNotes.B7);

            midiNotes.Add(RootNotes.C8);
            midiNotes.Add(RootNotes.CsDb8);
            midiNotes.Add(RootNotes.D8);
            midiNotes.Add(RootNotes.DsEb8);
            midiNotes.Add(RootNotes.E8);
            midiNotes.Add(RootNotes.F8);
            midiNotes.Add(RootNotes.FsGb8);
            midiNotes.Add(RootNotes.G8);
            midiNotes.Add(RootNotes.GsAb8);
            midiNotes.Add(RootNotes.A8);
            midiNotes.Add(RootNotes.AsBb8);
            midiNotes.Add(RootNotes.B8);

            midiNotes.Add(RootNotes.C9);
            midiNotes.Add(RootNotes.CsDb9);
            midiNotes.Add(RootNotes.D9);
            midiNotes.Add(RootNotes.DsEb9);
            midiNotes.Add(RootNotes.E9);
            midiNotes.Add(RootNotes.F9);
            midiNotes.Add(RootNotes.FsGb9);
            midiNotes.Add(RootNotes.G9);

            return midiNotes;
        }
    

    }
}
