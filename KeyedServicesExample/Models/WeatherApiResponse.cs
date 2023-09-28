using System.Text.Json.Serialization;

namespace KeyedServicesExample.Models
{
    public class WeatherApiCurrent
    {
        [JsonPropertyName("temp_c")]
        public double TempC { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
    }
    public class WeatherApiResponse
    {
        [JsonPropertyName("current")]
        public WeatherApiCurrent Current { get; set; }
    }
}
