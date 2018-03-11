using MediaListing.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediaListing.Core.Services
{
    public class DataService:IDataService
    {
        private const string DATA_URL = "https://pastebin.com/raw/8LiEHfwU";

        public DataService()
        {
        }

        public async Task<List<Category>> ReadJsonDataAsync(string url = null)
        {

            var dataUrl = url;
            if(string.IsNullOrEmpty(url))
            {
                dataUrl = DATA_URL;
            }
            var stringData = await GetJsonString(dataUrl);
            if(string.IsNullOrEmpty(stringData))
            {
                return null;
            }
            else
            {
                try
                {
                    var data = JsonConvert.DeserializeObject<List<Category>>(stringData);
                    return data;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }


        }

        /// <summary>
        /// Get Json string from Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetJsonString(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var data = await client.GetStringAsync(url);
                    return data;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return string.Empty;
                }
            }
        }

    }
}
