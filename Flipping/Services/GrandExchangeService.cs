using Flipping.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flipping.Services
{
    public class GrandExchangeService : IGrandExchangeService
    {
        List<RunescapeItem> items = new List<RunescapeItem>();

        public async Task<string> GetAsync(string uri)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=365");

                    var content = await result.Content.ReadAsStringAsync();

                    return content;

                }
            }
            catch (Exception e)
            {
                return "Exception thrown" + e.ToString();
            }
        }

    }
}
