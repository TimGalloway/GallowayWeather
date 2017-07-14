using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GallowayWeather.Core.Models.OpenWeatherMap;
using GallowayWeather.Core.Models;
using GallowayWeather.Core.Models.AccuWeather;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace GallowayWeather.Infrastructure.Repositories
{
    class OpenWeather : IWeatherRepository
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IList<AutoComplete.SimpleAutoComplete>> GetAutoCompleteAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<CommonCondition> GetCurrentAsync(string locationId, string searchtext, string tempUnit)
        {
            var url = "http://api.openweathermap.org/data/2.5/weather?q=" + searchtext + "&appid=" + ConfigurationManager.AppSettings["OpenWeatherapiKey"] + "&units=" + tempUnit;
            CurrentWeather rootObject = new CurrentWeather();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<CurrentWeather>(json);
            }

            CommonCondition commonCondition = new CommonCondition();
            commonCondition.locationId = rootObject.id;
            commonCondition.Type = "OpenWeather";
            commonCondition.Icon = "http://openweathermap.org/img/w/" + rootObject.weather[0].icon + ".png";
            commonCondition.Temp = rootObject.main.temp.ToString();
            commonCondition.Text = rootObject.weather[0].description.ToString();
            commonCondition.LocalObservationDateTime = UnixTimeStampToDateTime(rootObject.dt).ToString() + " UTC";
            if (tempUnit == "Metric")
            {
                commonCondition.TempUnit = "C";
            }
            else
            {
                commonCondition.TempUnit = "F";
            }
            return commonCondition;
        }

        public async Task<CommonLocation> GetLocationAsync(string locationId, string searchtext)
        {
            CommonLocation commonLocation = new CommonLocation();
            commonLocation.EnglishName = searchtext;

            return commonLocation;
        }
    }
}
