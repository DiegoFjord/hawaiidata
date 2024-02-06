using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using myapp.Models;
using myapp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MlController : ControllerBase
    {

        public MlController(mlservice Mlserve) {
            this.MLserv = Mlserve;
        }

        public mlservice MLserv { get; }
        [HttpGet]


        public ActionResult createprediction(
                                [FromQuery] float Temp,
                                [FromQuery] float Dew,
                                [FromQuery] float Humidity,
                                [FromQuery] float Precip,
                                [FromQuery] float Precipprob,
                                [FromQuery] float Precipcover,
                                [FromQuery] float Windgust,
                                [FromQuery] float Windspeed,
                                [FromQuery] float Cloudcover,
                                [FromQuery] float Visibility,
                                [FromQuery] float Solarradiation,
                                [FromQuery] float Uvindex,
                                [FromQuery] string Sunrise,
                                [FromQuery] string Sunset)
        {
            return Content(MLserv.createprediction(Temp,
Dew,
Humidity,
Precip,
Precipprob,
Precipcover,
Windgust,
Windspeed,
Cloudcover,
Visibility,
Solarradiation,
Uvindex,
Sunrise,
Sunset));
            //return Ok();
        }








    }
}
