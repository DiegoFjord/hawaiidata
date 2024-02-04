using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using redone.Models;
using redone.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace redone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class WeatherController : ControllerBase
    {
        public WeatherController(weatherServ wServ) {
            this.Wserv = wServ;
        }
        public weatherServ Wserv { get; }
        [HttpGet]
        public async Task<IEnumerable<weatherMod>> Get()
        {
            return await Wserv.showWeather();
        }



        
    }
}
