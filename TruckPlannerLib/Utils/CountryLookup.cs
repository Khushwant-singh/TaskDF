using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TruckPlannerLib.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class CountryLookup
    {
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static async Task<string> GetCountryFromCoordinates(double latitude, double longitude, string apiKey)
        {
            var query = $"https://api.opencagedata.com/geocode/v1/json?q={latitude}%2C{longitude}&key={apiKey}";
            
            var response = await httpClient.GetStringAsync(query);

            var json = JObject.Parse(response);
            var countryName = json["results"]?[0]?["components"]?["country"]?.ToString();

            return countryName ?? "Unknown";
        }
    }

}
