using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallowayWeather.Core.Models;
using System.Collections;
using System.Data;

namespace GallowayWeather.Infrastructure
{
    public class GallowayWeatherRepository: IWeatherHistoryRepository
    {
        WeatherContext context = new WeatherContext();

        public void Add(WeatherHistory h)
        {
            context.WeatherHistorys.Add(h);
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(WeatherHistory h)
        {
            throw new NotImplementedException();
        }

        public WeatherHistory FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeatherHistory> GetWeatherHistory()
        {
            return context.WeatherHistorys.ToList();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
