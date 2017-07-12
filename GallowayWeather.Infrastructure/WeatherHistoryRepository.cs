using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallowayWeather.Core.Models;

namespace GallowayWeather.Infrastructure
{
    public class WeatherHistoryRepository : IWeatherHistoryRepository
    {
        WeatherContext context = new WeatherContext();

        public Boolean Add(WeatherHistory h)
        {
            context.WeatherHistorys.Add(h);
            context.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(WeatherHistory h)
        {
            throw new NotImplementedException();
        }

        public IList<WeatherHistory> FindAll()
        {
            return context.WeatherHistorys.ToList();
        }

        public WeatherHistory FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<WeatherHistory> GetWeatherHistory()
        {
            return context.WeatherHistorys.ToList();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
