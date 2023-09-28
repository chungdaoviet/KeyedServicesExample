namespace KeyedServicesExample.Models
{
    using System.Text.Json.Serialization;

    public class OpenWeatherMapCoord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
    public class OpenWeatherMapWeather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
    public class OpenWeatherMapMain
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public double SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public double GrndLevel { get; set; }
    }
    public class OpenWeatherMapWind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Deg { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
    public class OpenWeatherMapResponse
    {
        [JsonPropertyName("coord")]
        public OpenWeatherMapCoord Coord { get; set; }

        [JsonPropertyName("weather")]
        public OpenWeatherMapWeather[] Weather { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public OpenWeatherMapMain Main { get; set; }

        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }

        [JsonPropertyName("wind")]
        public OpenWeatherMapWind Wind { get; set; }

        [JsonPropertyName("dt")]
        public double Dt { get; set; }


    }
}
