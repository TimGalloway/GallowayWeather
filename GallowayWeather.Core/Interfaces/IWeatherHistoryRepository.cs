using GallowayWeather.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherHistoryRepository : IDisposable
    {
        void Add(WeatherHistory h);
        void Edit(WeatherHistory h);
        void Remove(int Id);
        IEnumerable <WeatherHistory> GetWeatherHistory();
        WeatherHistory FindById(int Id);
    }
}
