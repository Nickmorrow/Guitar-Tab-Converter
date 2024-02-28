using GuitarTabConverter;
using System.Text.RegularExpressions;

namespace GuitarTabBlazorSite.Data
{
    public class GTCData
    {
        
       
        private static string HttpGet(string url)
        {
            string content = null;
            var wc = new MyWebClient();
            content = wc.DownloadString(url);
            return content;
        }

        public static List<string> GetSongUrls(string html)
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
    }
}
