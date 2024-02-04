using ConsoleApp2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.Net;

namespace redone.Services
{
    public class mlservice
    {
        public mlservice(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public string Show()
        {
            var sampleData = new MLModel1.ModelInput()
            {
                Datetime = @"2021-02-26",
                Temp = 30F,
                Dew = 16.2F,
                Humidity = 58.6F,
                Precip = 0F,
                Precipprob = 0F,
                Precipcover = 0F,
                Windgust = 44F,
                Windspeed = 36.4F,
                Cloudcover = 45.6F,
                Visibility = 12F,
                Solarradiation = 231.8F,
                Uvindex = 9F,
                Sunrise = @"2021-02-26 6:53:52",
                Sunset = @"2021-02-26 18:34:50",
            };
            var result = MLModel1.Predict(sampleData);
            Debug.WriteLine(result.Score);
            string show = result.Score.ToString();
            return (show);
        }

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
