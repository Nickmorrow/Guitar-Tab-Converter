using System;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TabTranslator 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:/Projects/Programming/CSharp/RaketeMentoring/FinalProject/TabTranslator/JSONFiles";            
            List<Measure> Measures = GetMeasure(path);            

        } 
        public static List<Measure> GetMeasure(string dPath) //getting this exception - Newtonsoft.Json.JsonSerializationException: 'Error converting value 1 to type 'TabTranslator.Voice[]'. Path 'voices', line 1, position 94848.': ArgumentException: Could not cast or convert from System.Int64 to TabTranslator.Voice[].
        {
            List<Measure> Measures = new List<Measure>();
            DirectoryInfo dir = new DirectoryInfo(dPath);
            string[] fPaths = Directory.GetFiles(dPath);
            string json = "";
            int fileNum = fPaths.Count();

            for (int i = 0; i < fileNum; i++)
            {
                json = File.ReadAllText(fPaths[i]);
                Measure measure = JsonConvert.DeserializeObject<Measure>(json);
                Measures.Add(measure);
            }

            return Measures;
        }

    }
}