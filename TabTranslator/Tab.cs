using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTabConverter
{
    public class Tab
    {
        public string TitleOfSong;
        public string ArtistName;
        public string Difficulty;
        public List<long> TimeSigniture;
        public StringInstrument Instrument;
        public string InstrumentString;
        public List<RootNotes> Tuning;
        public long Capo;
        public string Description;
        public string Lyrics;
        public List<List<List<string>>> TabLines;

        public List<List<List<string>>> GetTabLines(SongsterrSong Song, StringInstrument instrument, bool converted)
        {
            long? tSigNum = 0;
            string tuningString = "";
            List<long?> tSigNums = new List<long?>();
            List<List<List<string>>> TabLines = new List<List<List<string>>>(); //list of guitar strings measurelines

            for (int stringIndex = 0; stringIndex < instrument.MusicStrings.Count; stringIndex++)
            {
                List<List<string>> Measures = new List<List<string>>(); //Measures per guitar string
                List<string> D16ths = new List<string>();
                if (converted)
                {
                    tuningString = instrument.MusicStrings[stringIndex].Tuning.ToString();
                }
                else
                {
                    tuningString = ConvertMidiNum(Song.Tuning[stringIndex]).ToString();
                }
                D16ths.Add(tuningString);
                Measures.Add(D16ths);

                for (int measure = 0; measure < Song.Measures.Count(); measure++)
                {
                    D16ths = new List<string>();
                    if (Song.Measures[measure].Signature != null)
                    {
                        tSigNums = new List<long?>();
                        for (long tSig = 0; tSig < Song.Measures[measure].Signature.Count(); tSig++)
                        {
                            tSigNum = Song.Measures[measure].Signature[tSig]; // gets time sigs for each measure
                            tSigNums.Add(tSigNum);
                        }
                    }
                    else
                    {
                        for (long tSig = 0; tSig < tSigNums.Count; tSig++)
                        {

                            tSigNums = tSigNums;
                        }
                    }
                    long? counts = tSigNums[0];
                    long? beats = tSigNums[1];
                    long? D16thsNum = counts * beats;
                    string D16th = "";
                    D16th += "|";
                    D16ths.Add(D16th);
                    for (long D = 0; D < D16thsNum; D++)
                    {
                        if (tSigNums[1] == 2 || tSigNums[1] == 4)
                        {
                            D16th = "-___";
                            D16ths.Add(D16th);
                        }
                        if (tSigNums[1] == 8 || tSigNums[1] == 16)
                        {
                            D16th = "-_";
                            D16ths.Add(D16th);
                        }
                    }
                    Measures.Add(D16ths);
                }
                TabLines.Add(Measures);
            }
            return TabLines;
        }
        public string GetFretNrString(MusicalNote Note)
        {
            string FretNr = Note.FingerPosition.FretNr.ToString();
            return FretNr;
        }
        /// <summary>
        /// inserts songnotes fretnumbers into tab structure
        /// </summary>
        /// <param name="TabLines"></param>
        /// <param name="Beats"></param>
        public void FillTablines(List<List<List<string>>> TabLines, List<MusicalBeat> Beats, SongsterrSong Song)
        {
            for (int stringNum = 0; stringNum < TabLines.Count; stringNum++)
            {
                List<List<string>> measures = TabLines[stringNum];
                int beatCount = 0;
                long beatDuration = 1;
                for (int measureIndex = 1; measureIndex < measures.Count; measureIndex++)  //for each (output) measure
                {

                    List<string> D16ths = measures[measureIndex];
                    for (int D = 1; D < D16ths.Count; D++)
                    {
                        string D16th = D16ths[D];
                        if (beatCount >= Beats.Count)
                        {
                            break;
                        }
                        var currentBeat = Beats[beatCount];
                        if (currentBeat.MeasureNum != measureIndex - 1)
                        {
                            break;
                        }
                        if (currentBeat.Duration16ths > 1 && beatDuration < currentBeat.Duration16ths)
                        {
                            beatDuration++;
                            continue;
                        }
                        else
                        {
                            for (int noteCount = 0; noteCount < currentBeat.MusicalNotes.Count; noteCount++) // writes in notes
                            {
                                var currentNote = currentBeat.MusicalNotes[noteCount];
                                if (currentNote.FingerPosition.FretNr != null && currentNote.FingerPosition.StringNum == stringNum)
                                {
                                    if (currentNote.Dead == true)
                                    {
                                        D16ths[D] = D16ths[D].Replace("-", "X");
                                    }

                                    else
                                    {
                                        if (currentNote.FingerPosition.FretNr > 9)
                                        {
                                            D16ths[D] = D16ths[D].Replace("-_", currentNote.FingerPosition.FretNr.ToString());
                                        }
                                        D16ths[D] = D16ths[D].Replace("-", currentNote.FingerPosition.FretNr.ToString());
                                    }
                                }
                            }
                            beatDuration = 1;
                            beatCount++;
                        }
                    }
                }
            }
        }

        public RootNotes ConvertMidiNum(long midiNum)
        {
            int convertedNum = Convert.ToInt32(midiNum);

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

            midiNotes.Add(RootNotes.C);
            midiNotes.Add(RootNotes.CsDb);
            midiNotes.Add(RootNotes.D);
            midiNotes.Add(RootNotes.DsEb);
            midiNotes.Add(RootNotes.E);
            midiNotes.Add(RootNotes.F);
            midiNotes.Add(RootNotes.FsGb);
            midiNotes.Add(RootNotes.G);

            RootNotes midiNote = RootNotes.C;

            for (int i = 0; i < midiNotes.Count; i++)
            {

                if (convertedNum == i)
                {
                    midiNote = midiNotes[i];
                }
            }

            return midiNote;
        }

        public Tab(SongsterrSong Song, StringInstrument Instrument, List<MusicalBeat> songBeats, AppJson appjson, bool converted)
        {
            ArtistName = appjson.meta.current.artist;
            TitleOfSong = appjson.meta.current.title;
            Instrument = Instrument;
            InstrumentString = Instrument.Name; //Song.Instrument;
            List<RootNotes> convertedTunings = new List<RootNotes>();

            if (!converted)
            {
                for (int i = 0; i < Song.Tuning.Count(); i++)
                {
                    RootNotes note = ConvertMidiNum(Song.Tuning[i]);
                    convertedTunings.Add(note);
                }
                Tuning = convertedTunings;
            }
            else
            {
                for (int i = 0; i < Instrument.MusicStrings.Count; i++)
                {
                    RootNotes note = Instrument.MusicStrings[i].Tuning;
                    convertedTunings.Add(note);
                }
                Tuning = convertedTunings;
            }

            Capo = Song.Capo;
            TabLines = GetTabLines(Song, Instrument, converted);
            FillTablines(TabLines, songBeats, Song);
        }

    }
}

