using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTranslator
{
    public class Tab
    {
        public string TitleOfSong;
        public string ArtistName;
        public string Difficulty;
        public StringInstrument Instrument;
        public string InstrumentString;
        public List<RootNotes> Tuning;
        public long Capo;
        public string Description;
        public string Lyrics;
        public List<List<string>> TabLines;




        public List<List<string>> GetTabLines(SongsterrSong Song, StringInstrument instrument)
        {

            int tSigNum = 0;
            string tuningString = "";

            List<List<string>> TabLines = new List<List<string>>(); //list of guitar strings measurelines

            for (int stringIndex = 0; stringIndex < instrument.MusicStrings.Count; stringIndex++)
            {
                List<string> Measures = new List<string>(); //Measures per guitar string                
                //tSigNum = Convert.ToInt32(Song.Measures[0].Signature[0]);
                tuningString = instrument.MusicStrings[stringIndex].Tuning.ToString();
                Measures.Add(tuningString);

                for (int measure = 0; measure < Song.Measures.Count(); measure++)
                {
                    List<int> tSigNums = new List<int>();
                    for (int tSig = 0; tSig < Song.Measures[measure].Signature.Count(); tSig++)
                    {
                        tSigNum = Convert.ToInt32(Song.Measures[measure].Signature[tSig]); // gets time sigs for each measure
                        tSigNums.Add(tSig);
                    }
                    string MeasureDashes = "";
                    MeasureDashes += "|";
                    for (int counts = 0; counts < tSigNums[0]; counts++) // top sig
                    {
                        for (int dashes = 0; dashes < tSigNums[1]; dashes++) // bottom sig
                        {
                            if (tSigNums[1] == 2)
                            {
                                for (int i = 0; i < 2; i++) // half note
                                {
                                    MeasureDashes += "- _ ";
                                }
                            }
                            if (tSigNums[1] == 4)
                            {
                                for (int i = 0; i < 4; i++) // quarter note
                                {
                                    MeasureDashes += "- _ ";
                                }
                            }
                            if (tSigNums[1] == 8)
                            {
                                for (int i = 0; i < 8; i++) // 8th note
                                {
                                    MeasureDashes += "-_";
                                }
                            }
                            if (tSigNums[1] == 16)
                            {
                                for (int i = 0; i < 16; i++) // 16th note
                                {
                                    MeasureDashes += "-_";
                                }
                            }
                        }
                        Measures.Add(MeasureDashes);
                    }
                    TabLines.Add(Measures);
                }
                
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
            public void FillTablines(List<List<string>> TabLines, List<MusicalBeat> Beats, SongsterrSong Song)
            {
                for (int idxTabLine = 0; idxTabLine < TabLines.Count; idxTabLine++)
                {
                    List<string> measures = TabLines[idxTabLine];
                    int beatCount = 0;
                    for (int measureIndex = 1; measureIndex < measures.Count; measureIndex++)  //for each (output) measure
                    {
                        int dashCount = 1;
                        while (dashCount < measures[measureIndex].Length)
                        {
                            // break if current noteCount exceeds actual count -> should not happen
                            var currentBeat = Beats[beatCount];
                            //if (beatCount >= Beats.Count - 1)
                            //{
                            //    break;
                            //}

                            // replace parts with current FretNr or skip if is rest
                            //var currentBeat = Beats[beatCount];

                            for (int noteCount = 0; noteCount < currentBeat.MusicalNotes.Count; noteCount++)
                            {
                                var currentNote = currentBeat.MusicalNotes[noteCount];
                                if (currentNote.FingerPosition.FretNr != null && currentNote.FingerPosition.StringNum == idxTabLine)
                                {
                                    if (currentNote.Dead == true)
                                    {
                                        measures[measureIndex] = measures[measureIndex].Remove(dashCount, 1);
                                        measures[measureIndex] = measures[measureIndex].Insert(dashCount, "X");
                                    }
                                    else
                                    {
                                        var fretNrLength = 1; // add condition where if fretnumber is over 10 fretnumberlength is 2
                                                              //if (currentNote.FingerPosition.FretNr > 9)
                                                              //{
                                                              //    fretNrLength = 2;
                                                              //}
                                        measures[measureIndex] = measures[measureIndex].Remove(dashCount, fretNrLength);
                                        measures[measureIndex] = measures[measureIndex].Insert(dashCount, currentNote.FingerPosition.FretNr.ToString());
                                    }
                                }
                            }
                            dashCount += Convert.ToInt32(currentBeat.Duration16ths);
                            beatCount++;
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
                TabLines = GetTabLines(Song, Instrument);
                FillTablines(TabLines, songBeats, Song);
            }
        }
    }

