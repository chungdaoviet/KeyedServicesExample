using KeyedServicesExample.Configuration;
using KeyedServicesExample.Models;
using Microsoft.Extensions.Options;

namespace KeyedServicesExample.Weather
{
    public class OpenWeatherMapService(IHttpClientFactory httpClientFactory, IOptions<WeathersOptions> options) : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly WeatherOptions? _weatherOptions = options.Value.Options.FirstOrDefault(x => x.Provider == WeatherProvider.OpenWeatherMap.ToString());

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            if(_weatherOptions is null)
            {
                return null;
            }

            var httpClient = _httpClientFactory.CreateClient();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_weatherOptions.ApiKey}&lang=vi&units=metric";

            var weatherResponse = await httpClient.GetAsync(url);
            if(weatherResponse.StatusCode == System.Net.HttpStatusCode.NotFound) {
                return null;
            }

            var weather = await weatherResponse.Content.ReadFromJsonAsync<OpenWeatherMapResponse>();


            return new WeatherResponse()
            {
                Temp = weather!.Main.Temp,
                Humidity = weather!.Main.Humidity,
            };
        }
    }
}
