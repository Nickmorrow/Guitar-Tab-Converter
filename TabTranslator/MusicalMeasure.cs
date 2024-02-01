using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class MusicalMeasure
    {
        public List<MusicalVoice> Voices = new List<MusicalVoice>();
        public long[] Signature;
        public bool? Rest;
    }
}
