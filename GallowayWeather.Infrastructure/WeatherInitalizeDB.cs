using GallowayWeather.Core.Models;
using System.Data.Entity;
using System;

namespace GallowayWeather.Infrastructure
{
    public class GallowayWeatherInitalizeDB : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            context.WeatherHistorys.Add(new WeatherHistory
            {
                Location = "22889",
                LocationText = "Sydney",
                Icon = "01",
                Temp = "20C",
                Text = "Sunny",
                DateCreated = DateTime.Now,
                LocalObservationDateTime = "01/02/2017 12:00PM"
            });
        }
    }
}
