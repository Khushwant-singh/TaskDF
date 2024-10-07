using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TruckPlannerLib.Utils
{

    public class CountryLookup
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> GetCountryFromCoordinates(double latitude, double longitude)
        {
            string username = "yourusername"; // Replace with your Geonames username
            var response = await httpClient.GetStringAsync($"http://api.geonames.org/findNearbyPlaceNameJSON?lat={latitude}&lng={longitude}&username={username}");

            var json = JObject.Parse(response);
            var countryName = json["geonames"]?[0]?["countryName"]?.ToString();

            return countryName ?? "Unknown";
        }
    }

}
