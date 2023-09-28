using KeyedServicesExample.Configuration;
using KeyedServicesExample.Weather;
using Microsoft.AspNetCore.Mvc;

namespace KeyedServicesExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController(IServiceProvider serviceProvider) : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        [Route("GetWeatherByOpenWeatherMap")]
        [HttpGet]
        public async Task<IResult> GetWeatherByOpenWeatherMap(string city, [FromKeyedServices(WeatherProvider.OpenWeatherMap)]IWeatherService weatherService)
        {
            var weather = await weatherService.GetWeatherAsync(city);

            return weather is null ? Results.NotFound() : Results.Ok(weather);
        }

        [Route("GetWeatherByWeatherApi")]
        [HttpGet]
        public async Task<IResult> GetWeatherByWeatherApi(string city, [FromKeyedServices(WeatherProvider.WeatherApi)] IWeatherService weatherService)
        {
            var weather = await weatherService.GetWeatherAsync(city);

            return weather is null ? Results.NotFound() : Results.Ok(weather);
        }

        [Route("GetWeather")]
        [HttpGet]
        public async Task<IResult> GetWeather(WeatherProvider provider, string city)
        {
            var weatherService = _serviceProvider.GetRequiredKeyedService<IWeatherService>(provider);
            if(weatherService is null)
            {
                return Results.NotFound();
            }

            var weather = await weatherService.GetWeatherAsync(city);

            return weather is null ? Results.NotFound() : Results.Ok(weather);
        }
    }
}