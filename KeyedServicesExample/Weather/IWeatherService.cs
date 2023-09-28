using KeyedServicesExample.Models;

namespace KeyedServicesExample.Weather
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetWeatherAsync(string city);
    }
}
