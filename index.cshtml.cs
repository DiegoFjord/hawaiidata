using Microsoft.AspNetCore.Mvc.RazorPages;
using myapp.Models;
using myapp.Services;

namespace myapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly mlservice _mlService;
        private readonly weatherServ GiveWeather;
        public string Message { get; private set; }
        public IEnumerable<weatherMod> weathernow { get; private set; }
        public string send { get; private set; }
        public bool IsPost { get; set; }


        public IndexModel(ILogger<IndexModel> logger,
            mlservice mlService, weatherServ giveweather)
        {
            _mlService = mlService;
            GiveWeather = giveweather;
        }

        public async Task OnGet()
        {
            //Message = _mlService.Show();
            weathernow = await GiveWeather.showWeather();

        }
        public async Task OnPost()
        {
            IsPost = true;
            weathernow = await GiveWeather.showWeather();
        }

    }
}
