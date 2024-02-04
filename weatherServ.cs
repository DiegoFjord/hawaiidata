using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.IO;
using redone.Models;
using System.Collections.Generic;



namespace redone.Services
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
        public async Task getWeather()
        {
            try
            {
                //client.DefaultRequestHeaders.Add("User-Agent", "My Application");
                //string responseBody = await client.GetStringAsync("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/weatherdata/forecast?locations=Herndon,VA,20170&aggregateHours=24&unitGroup=us&shortColumnNames=false&contentType=csv&key=YOURAPIKEY");
                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


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



                    // Navigate to the 'dog.locations.Hawaii.values' property
                    var valuesProperty = jsonDocument.RootElement
                    .GetProperty("locations")
                    .GetProperty("Hawaii")
                    .GetProperty("values");
                    
                    // Deserialize the array of Product objects
                    return JsonSerializer.Deserialize<weatherMod[]>(valuesProperty.GetRawText(),
                                new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        })!;

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

