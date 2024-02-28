using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GuitarTabBlazorSite.Data
{
    public class UserSearchSongs
    {       
        private string _userSearch(string s)
        {
            string searchUrl = $"/?pattern={s}";
            return s;
        }




    }
    
}
