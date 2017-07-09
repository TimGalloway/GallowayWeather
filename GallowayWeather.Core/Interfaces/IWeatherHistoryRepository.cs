using GallowayWeather.Core.Models;
using System;
using System.Collections.Generic;
using static GallowayWeather.Core.Models.Condition;
using static GallowayWeather.Core.Models.Location;
using static GallowayWeather.Core.Models.AutoComplete;
using System.Threading.Tasks;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherHistoryRepository : IDisposable
    {
        IList<WeatherHistory> FindAll();
        Boolean Add(WeatherHistory h);
        void Edit(WeatherHistory h);
        void Remove(int Id);
        IList <WeatherHistory> GetWeatherHistory();
        WeatherHistory FindById(int Id);
        Task<ExtendedCondition> GetCurrentAsync(string locationId);
        Task<ExtendedLocation> GetLocationAsync(string locationId);
        Task<IList<SimpleAutoComplete>> GetAutoCompleteAsync(string searchString);
    }
}
