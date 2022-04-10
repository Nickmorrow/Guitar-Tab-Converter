using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class Tab
    {
        string TitleOfSong;
        string Artist;
        string Difficulty;
        string Description;
        string Lyrics;
        StringInstrument Instrument;
        List<MusicalNote> Notes;
        List<FingerPosition> FingerPositions;
    }
}
