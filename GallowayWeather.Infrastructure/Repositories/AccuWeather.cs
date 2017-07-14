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
            var url = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + ConfigurationManager.AppSettings["AccuWeatherapiKey"] + "&q=" + searchString;
            List<SimpleAutoComplete> rootObject = new List<SimpleAutoComplete>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                rootObject = JsonConvert.DeserializeObject<List<SimpleAutoComplete>>(json);
            }
            return rootObject;
        }

        public async Task<CommonCondition> GetCurrentAsync(string locationId, string searchtext, string tempUnit)
        {
            var url = "http://dataservice.accuweather.com/currentconditions/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["AccuWeatherapiKey"]; 
            List<ExtendedCondition> rootObject = new List<ExtendedCondition>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<List<ExtendedCondition>>(json);
            }
            ExtendedCondition currConditions = rootObject[0];
            currConditions.ConditionID = locationId;

            CommonCondition commonCondition = new CommonCondition();
            commonCondition.locationId = Convert.ToInt32(currConditions.ConditionID);
            commonCondition.Type = "AccuWeather";
            commonCondition.Icon = "/Images/Icons/" + commonCondition.Type  + "/" + currConditions.WeatherIcon.ToString("D2") + "-s.png";
            if (tempUnit == "Metric")
            {
                commonCondition.Temp = currConditions.Temperature.Metric.Value.ToString();
                commonCondition.TempUnit = currConditions.Temperature.Metric.Unit;
            }
            else
            {
                commonCondition.Temp = currConditions.Temperature.Imperial.Value.ToString();
                commonCondition.TempUnit = currConditions.Temperature.Imperial.Unit;
            }
            commonCondition.Text = currConditions.WeatherText;
            commonCondition.LocalObservationDateTime = currConditions.LocalObservationDateTime;
            return commonCondition;
        }

        public async Task<CommonLocation> GetLocationAsync(string locationId, string searchtext)
        {
            var url = "http://dataservice.accuweather.com/locations/v1/" + locationId + "?apikey=" + ConfigurationManager.AppSettings["AccuWeatherapiKey"];
            ExtendedLocation rootObject = new ExtendedLocation();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<ExtendedLocation>(json);
            }
            ExtendedLocation currLocations = rootObject;
            currLocations.LocationID = locationId;

            CommonLocation commonLocation = new CommonLocation();
            commonLocation.EnglishName = currLocations.EnglishName + ", " + currLocations.Country.EnglishName;

            return commonLocation;
        }

    }
}
