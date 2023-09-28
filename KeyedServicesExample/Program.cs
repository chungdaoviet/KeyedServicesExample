using KeyedServicesExample.Configuration;
using KeyedServicesExample.Weather;

namespace KeyedServicesExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var config = builder.Configuration;
            builder.Services.AddOptions<WeathersOptions>()
                .Bind(config.GetSection(WeathersOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services.AddHttpClient();
            builder.Services.AddKeyedSingleton<IWeatherService, WeatherApiService>(WeatherProvider.WeatherApi);
            builder.Services.AddKeyedSingleton<IWeatherService, OpenWeatherMapService>(WeatherProvider.OpenWeatherMap);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}