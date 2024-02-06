using System.Text.Json;
using myapp.Models;

namespace myapp.Services
{
    public class weatherServ
    {
        public weatherServ(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "climate.json"); }
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        static readonly HttpClient client = new HttpClient();
        public async Task getWeather(){     }
        public async Task<IEnumerable<weatherMod>> showWeather()
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/weatherdata/forecast?locations=Hawaii&aggregateHours=24&unitGroup=us&shortColumnNames=false&contentType=json&key=YOURAPIKEY";
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(jsonContent);
                    // Navigate to the 'locations.Hawaii.values' property
                    var valuesProperty = jsonDocument.RootElement
                    .GetProperty("locations")
                    .GetProperty("Hawaii")
                    .GetProperty("values");
                    // Deserialize the array of Product objects
                    return JsonSerializer.Deserialize<weatherMod[]>(valuesProperty.GetRawText(),
                                new JsonSerializerOptions{PropertyNameCaseInsensitive = true})!;
                }
                else
                {
                    // Handle the case when the API request is not successful
                    throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
                }
            }
        }
    }
}

