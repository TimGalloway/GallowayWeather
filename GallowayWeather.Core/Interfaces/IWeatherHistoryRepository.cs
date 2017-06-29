using GallowayWeather.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using static GallowayWeather.Core.Models.Condition;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherHistoryRepository : IDisposable
    {
        void Add(WeatherHistory h);
        void Edit(WeatherHistory h);
        void Remove(int Id);
        IEnumerable <WeatherHistory> GetWeatherHistory();
        WeatherHistory FindById(int Id);
        //CurrentConditon GetCurrentAsync(string locationId);
        System.Threading.Tasks.Task<SimpleCondition> GetCurrentAsync(string locationId);
    }
}
