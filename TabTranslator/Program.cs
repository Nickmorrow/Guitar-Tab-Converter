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
            var path = "E:/Projects/Programming/CSharp/RaketeMentoring/Final project/TabTranslator/SongsterrFiles/SongJSON/AliceInChainsWouldJSON.txt";
            string json = System.IO.File.ReadAllText(path);
            Welcome2 AliceInChains = JsonConvert.DeserializeObject<Welcome2>(json);
             
            Console.WriteLine(AliceInChains.Instrument.ToString());

            var textPath = "E:/Projects/Programming/CSharp/RaketeMentoring/Final project/TabTranslator/SongsterrFiles/TextTabs/JeffBuckleyHallelujahTab.txt";
            string text = System.IO.File.ReadAllText(textPath);
            Console.WriteLine(text);



        }   
    }
}