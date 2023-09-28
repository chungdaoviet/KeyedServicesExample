using System.ComponentModel.DataAnnotations;

namespace KeyedServicesExample.Configuration
{
    public enum WeatherProvider
    {
        OpenWeatherMap,
        WeatherApi
    }

    public class WeathersOptions
    {
        public const string SectionName = "Weathers";
        public List<WeatherOptions> Options { get; set; }
    }
    public class WeatherOptions
    {
        [EnumDataType(typeof(WeatherProvider))]
        public required string Provider { get; init; }

        [Required]
        [MinLength(1)]
        public required string ApiKey { get; init; }
    }
}
