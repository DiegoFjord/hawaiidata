using ConsoleApp2;
using System.Diagnostics;

namespace myapp.Services
{
    public class mlservice
    {
        public mlservice(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public string createprediction( float Temp,
                                        float Dew,
                                        float Humidity,
                                        float Precip,
                                        float Precipprob,
                                        float Precipcover,
                                        float Windgust,
                                        float Windspeed,
                                        float Cloudcover,
                                        float Visibility,
                                        float Solarradiation,
                                        float Uvindex,
                                        string Sunrise,
                                        string Sunset)
        {
            var sampleData = new MLModel1.ModelInput()
            {
                Temp=Temp,
                Dew=Dew,
                Humidity= Humidity,
                Precip= Precip,
                Precipprob= Precipprob,
                Precipcover= Precipcover,
                Windgust= Windgust,
                Windspeed= Windspeed,
                Cloudcover= Cloudcover,
                Visibility= Visibility,
                Solarradiation= Solarradiation,
                Uvindex= Uvindex,
                Sunrise= Sunrise,
                Sunset= Sunset
            };
            var result = MLModel1.Predict(sampleData);
            Debug.WriteLine(result.Score);
            string show = result.Score.ToString();
            return (show);

        }



    }
}
