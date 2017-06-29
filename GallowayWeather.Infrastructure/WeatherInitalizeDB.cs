using GallowayWeather.Core.Models;
using System.Data.Entity;

namespace GallowayWeather.Infrastructure
{
    public class GallowayWeatherInitalizeDB : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            context.WeatherHistorys.Add(new WeatherHistory { Location = "Perth", Icon = 1, Temp = "20", Text = "Sunny" });
        }
    }
}
