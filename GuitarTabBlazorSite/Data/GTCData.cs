using GuitarTabConverter;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json;

namespace GuitarTabBlazorSite.Data
{
    public class GTCData
    {
        
        public string searchItem { get; set; }

        public string userSearchedHTML;
        public string GetUserSearchedHTML(string searchItem)
        {
            string userSearchedHTML = $"/?pattern={searchItem}";
            this.userSearchedHTML = HttpGet($"https://www.songsterr.com{userSearchedHTML}");
            return this.userSearchedHTML;
        }

        public List<string> SongUrls;

        public List<AppJson> UserSearchedJson;

        public List<AppJson> FilteredListJson;
        

        private string HttpGet(string url)
        {
            //TODO just an example here
            //if(UserSearchedJson.FirstOrDefault(s => s.meta.current.title == "title") != null)
            //{

            //}
            //else
            //{
            //    //do api fetch
            //    //add to the list
            //}
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

        public AppJson GetJsonSongInfo(string songUrl)
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

        //private List<AppJson> _songs = new();

        public List<AppJson> SearchJson(string searchItem, List<AppJson> UserSearchedJson, List<string> songUrls)
        {
            bool containsSearchItem = false;

            if (UserSearchedJson != null)
            {
                for (int i = 0; i < UserSearchedJson.Count; i++)
                {
                    if (UserSearchedJson[i].meta.current.artist.Contains(searchItem) || UserSearchedJson[i].meta.current.title.Contains(searchItem))
                    {
                        containsSearchItem = true;
                        break;
                    }
                }
            }            
            if (containsSearchItem == false )
            {   
                if (UserSearchedJson == null)
                {
                    UserSearchedJson = new List<AppJson>();
                }
                AppJson Song = new AppJson();
                string songSourceHTML;

                for (int urlNum = 0; urlNum < songUrls.Count; urlNum++)
                {
                    if (songUrls[urlNum].Contains("chord")) //chord means that url is for chords - use later for diplaying chords
                        continue;

                    songSourceHTML = HttpGet($"https://www.songsterr.com{songUrls[urlNum]}");
                    Song = GetJsonSongInfo(songSourceHTML);
                    UserSearchedJson.Add(Song);
                    //Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");
                    Thread.Sleep(1000);
                }
            }
            return UserSearchedJson;
        }

        public List<AppJson> GetFilteredListJson(List<AppJson> UserSearchJson, List<AppJson> FilterListJson)
        {
            FilterListJson = UserSearchedJson.Where(u => u.meta.current.artist.Contains(searchItem) || u.meta.current.title.Contains(searchItem)).ToList();
            return FilterListJson;
        }

        //public List<AppJson> GetSearchedSongs(List<string> songUrls, List<AppJson> UserSearchedJson) // for name and title display / needs cache system
        //{

        //    //List<AppJson> SongJson = new List<AppJson>();
        //    AppJson Song = new AppJson();
        //    string songSourceHTML;

        //    for (int urlNum = 0; urlNum< songUrls.Count;urlNum++)
        //    {
        //        if (songUrls[urlNum].Contains("chord")) //chord means that url is for chords - use later for diplaying chords
        //            continue;

        //        songSourceHTML = HttpGet($"https://www.songsterr.com{songUrls[urlNum]}");
        //        Song = GetJsonSongInfo(songSourceHTML);
        //        UserSearchedJson.Add(Song);
        //        //Console.WriteLine($"{counter + 1}. {SongJson[counter].meta.current.artist}-{SongJson[counter].meta.current.title}");

        //        Thread.Sleep(1000);

        //    }
        //    return UserSearchedJson;
        //}
    }
}
