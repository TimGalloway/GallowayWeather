using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GallowayWeather.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using static GallowayWeather.Core.Models.Condition;

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

        public async System.Threading.Tasks.Task<SimpleCondition> GetCurrentAsync(string locationId)
        {
            var url = "http://dataservice.accuweather.com/currentconditions/v1/" + locationId + "?apikey=URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF";
            List<SimpleCondition> rootObject = new List<SimpleCondition>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<List<SimpleCondition>>(json);
            }
            SimpleCondition currConditions = rootObject[0];

            return currConditions;
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
