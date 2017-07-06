using GallowayWeather.Core.Models;
using System;
using System.Collections.Generic;
using static GallowayWeather.Core.Models.Condition;
using static GallowayWeather.Core.Models.Location;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherHistoryRepository : IDisposable
    {
        IList<WeatherHistory> FindAll();
        Boolean Add(WeatherHistory h);
        void Edit(WeatherHistory h);
        void Remove(int Id);
        IEnumerable <WeatherHistory> GetWeatherHistory();
        WeatherHistory FindById(int Id);
        System.Threading.Tasks.Task<SimpleCondition> GetCurrentAsync(string locationId);
        System.Threading.Tasks.Task<SimpleLocation> GetLocationAsync(string locationId);
    }
}
