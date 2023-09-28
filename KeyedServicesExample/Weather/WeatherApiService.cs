using KeyedServicesExample.Configuration;
using KeyedServicesExample.Models;
using Microsoft.Extensions.Options;

namespace KeyedServicesExample.Weather
{
    public class WeatherApiService(IHttpClientFactory httpClientFactory, IOptions<WeathersOptions> options) : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly WeatherOptions? _weatherOptions = options.Value.Options.FirstOrDefault(x => x.Provider == WeatherProvider.WeatherApi.ToString());

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            if(_weatherOptions is null)
            {
                return null;
            }

            var httpClient = _httpClientFactory.CreateClient();

            var url = $"https://api.weatherapi.com/v1/current.json?q={city}&key={_weatherOptions.ApiKey}&lang=vi";

            var weatherResponse = await httpClient.GetAsync(url);
            if (weatherResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            var weather = await weatherResponse.Content.ReadFromJsonAsync<WeatherApiResponse>();


            return new WeatherResponse()
            {
                Temp = weather!.Current.TempC,
                Humidity = weather!.Current.Humidity,
            };
        }
    }
}
