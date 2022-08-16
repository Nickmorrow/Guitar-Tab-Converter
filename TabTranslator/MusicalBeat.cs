using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class MusicalBeat
    {
        public long Duration16ths;
        public long SongsterrDuration;
        public bool? NullableBool;
        public bool IsRest;
        public List<MusicalNote> MusicalNotes = new List<MusicalNote>();

        public bool GetRestBeat(bool? NullableBool)
        {
            bool actualBool = NullableBool.GetValueOrDefault();
            return actualBool;

        }
        /// <summary>
        /// Gets duration of note
        /// </summary>
        /// <param name="SongsterrDuration"></param>
        /// <returns>long Duration16ths</returns>
        public long Get16ths(long SongsterrDuration)
        {
            long Duration16ths = 16 / SongsterrDuration;
            return Duration16ths;
        }
    }
}
