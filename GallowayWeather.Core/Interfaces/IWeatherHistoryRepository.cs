using GallowayWeather.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherHistoryRepository : IDisposable
    {
        IList<WeatherHistory> FindAll();
        Boolean Add(WeatherHistory h);
        void Edit(WeatherHistory h);
        void Remove(int Id);
        IList<WeatherHistory> GetWeatherHistory();
        WeatherHistory FindById(int Id);

    }
}
