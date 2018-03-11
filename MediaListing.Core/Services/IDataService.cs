using MediaListing.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaListing.Core.Services
{
    public interface IDataService
    {
        /// <summary>
        /// Retrive data from json
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> ReadJsonDataAsync(string url = null);

        /// <summary>
        /// Get Json string by Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<string> GetJsonString(string url);
    }
}
