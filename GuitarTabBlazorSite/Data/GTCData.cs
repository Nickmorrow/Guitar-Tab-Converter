using GuitarTabConverter;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json;

namespace GuitarTabBlazorSite.Data
{
    public class GTCData
    {
        //private List<SongObject> _songs = new();

        //public List<SongObject>SearchByTitle(string title)
        //{
        //    //check if htere
        //    //if not => get from api / return results
           
        //}


        private  string HttpGet(string url)
        {
            string content = null;
            var wc = new MyWebClient();
            content = wc.DownloadString(url);
            return content;
        }
        public List<string> GetSongUrls(string html)
        {
            List<string> resultList = new List<string>();
            try
            {
                Regex regexObj = new Regex(@"<a.*?href=\D(/a/wsa/.*?)\D\s");
                Match matchResult = regexObj.Match(html);
                while (matchResult.Success)
                {
                    resultList.Add(matchResult.Groups[1].Value);
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            //List<int> distinct = arr1.Distinct().ToList();
            resultList = resultList.Distinct().ToList();
            return resultList;
        }

        public  AppJson GetJsonSongInfo(string songUrl)
        {
            List<string> resultList = new List<string>();
            try
            {
                Regex regexObj = new Regex(@"<script id=\Dstate\D type=\Dapplication/json\D>(?<applicationjson>.*?)</script>");
                Match matchResult = regexObj.Match(songUrl);
                while (matchResult.Success)
                {
                    resultList.Add(matchResult.Groups[1].Value);
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            AppJson result = JsonConvert.DeserializeObject<AppJson>(resultList[0]);
            return result;
        }

        public List<AppJson> GetSearchedSongs(List<string> searchedSongs) //needs cache system
        {

            List<AppJson> SongJson = new List<AppJson>();
            AppJson Song = new AppJson();
            string songSourceHTML;
            int counter = 0;

            foreach (String s in searchedSongs)
            {
                if (s.Contains("chord"))
                    continue;
                //Console.WriteLine(s);
                songSourceHTML = HttpGet($"https://www.songsterr.com{s}");
                Song = GetJsonSongInfo(songSourceHTML);
                SongJson.Add(Song);
                //Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");
                //counter++;
                //Thread.Sleep(1000);
                //Console.Clear();
            }
            return SongJson;
        }
    }
}
