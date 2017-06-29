using GallowayWeather.Core.Models;
using System.Data.Entity;

namespace GallowayWeather.Infrastructure
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() 
            : base("WeatherContext")
        {
        }

        public DbSet<WeatherHistory> WeatherHistorys { get; set; }
    }
}