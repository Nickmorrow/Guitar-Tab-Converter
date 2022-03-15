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
            string path = "E:/Projects/Programming/CSharp/RaketeMentoring/Final project/TabTranslator/SongsterrFiles/SongJSON";
            //string json = File.ReadAllText(path);
            
            List<Measure> Measures = GetMeasure(path);
            Console.WriteLine(Measures);


        } 
        public static List<Measure> GetMeasure(string dPath)
        {
            List<Measure> Measures = new List<Measure>();
            DirectoryInfo dir = new DirectoryInfo(dPath);
            string[] fPaths = Directory.GetFiles(dPath);

            foreach (FileInfo flInfo in dir.GetFiles())
            {
                Measure measure = JsonConvert.DeserializeObject<Measure>(dPath);
                Measures.Add(measure);
            }
            
            return Measures;
        }
    }
}