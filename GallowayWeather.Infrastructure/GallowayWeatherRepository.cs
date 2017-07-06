﻿using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GallowayWeather.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using static GallowayWeather.Core.Models.Condition;
using System.Threading.Tasks;
using static GallowayWeather.Core.Models.Location;
using System.Configuration;
using static GallowayWeather.Core.Models.AutoComplete;

namespace GallowayWeather.Infrastructure
{
    public class GallowayWeatherRepository: IWeatherHistoryRepository
    {
        WeatherContext context = new WeatherContext();

        public void Add(WeatherHistory h)
        {
            h.Icon = String.Format("d2", h.Icon);
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

        public async Task<IList<SimpleAutoComplete>> GetAutoCompleteAsync(string searchString)
        {
            var url = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + ConfigurationManager.AppSettings["apiKey"] + "&q=" + searchString;
            List<SimpleAutoComplete> rootObject = new List<SimpleAutoComplete>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                rootObject = JsonConvert.DeserializeObject<List<SimpleAutoComplete>>(json);
            }
            return rootObject;
        }

        public async Task<SimpleCondition> GetCurrentAsync(string locationId)
        {
            var url = "http://dataservice.accuweather.com/currentconditions/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["apiKey"]; 
            List<SimpleCondition> rootObject = new List<SimpleCondition>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<List<SimpleCondition>>(json);
            }
            SimpleCondition currConditions = rootObject[0];

            return currConditions;
        }

        public async Task<Location.SimpleLocation> GetLocationAsync(string locationId)
        {
            var url = "http://dataservice.accuweather.com/locations/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["apiKey"];
            SimpleLocation rootObject = new SimpleLocation();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<SimpleLocation>(json);
            }
            SimpleLocation currLocations = rootObject;

            return currLocations;
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