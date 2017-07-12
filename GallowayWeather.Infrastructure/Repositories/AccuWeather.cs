using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using GallowayWeather.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using static GallowayWeather.Core.Models.AccuWeather.Condition;
using System.Threading.Tasks;
using static GallowayWeather.Core.Models.AccuWeather.Location;
using System.Configuration;
using static GallowayWeather.Core.Models.AccuWeather.AutoComplete;
using GallowayWeather.Core.Models.AccuWeather;

namespace GallowayWeather.Infrastructure.Repositories
{
    public class AccuWeather: IWeatherRepository
    {
        public void Dispose()
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

        public async Task<CommonCondition> GetCurrentAsync(string locationId)
        {
            var url = "http://dataservice.accuweather.com/currentconditions/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["apiKey"]; 
            List<ExtendedCondition> rootObject = new List<ExtendedCondition>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<List<ExtendedCondition>>(json);
            }
            ExtendedCondition currConditions = rootObject[0];
            currConditions.ConditionID = locationId;

            CommonCondition commonCondition = new CommonCondition();

            commonCondition.Type = "AccuWeather";
            commonCondition.Icon = currConditions.WeatherIcon.ToString();
            commonCondition.TempC = currConditions.Temperature.Metric.Value.ToString();
            commonCondition.TempF = currConditions.Temperature.Imperial.Value.ToString();
            commonCondition.Text = currConditions.WeatherText;
            commonCondition.TempUnitC = currConditions.Temperature.Metric.Unit;
            commonCondition.TempUnitF = currConditions.Temperature.Imperial.Unit;
            commonCondition.LocalObservationDateTime = currConditions.LocalObservationDateTime;
            return commonCondition;
        }

        public async Task<Location.ExtendedLocation> GetLocationAsync(string locationId)
        {
            var url = "http://dataservice.accuweather.com/locations/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["apiKey"];
            ExtendedLocation rootObject = new ExtendedLocation();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<ExtendedLocation>(json);
            }
            ExtendedLocation currLocations = rootObject;
            currLocations.LocationID = locationId;

            return currLocations;
        }

    }
}
