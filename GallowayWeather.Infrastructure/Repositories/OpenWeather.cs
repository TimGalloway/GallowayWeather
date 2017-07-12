using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GallowayWeather.Core.Models.AccuWeather;
using GallowayWeather.Core.Models;

namespace GallowayWeather.Infrastructure.Repositories
{
    class OpenWeather : IWeatherRepository
    {
        WeatherContext context = new WeatherContext();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IList<AutoComplete.SimpleAutoComplete>> GetAutoCompleteAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public Task<CommonCondition> GetCurrentAsync(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<Location.ExtendedLocation> GetLocationAsync(string locationId)
        {
            throw new NotImplementedException();
        }
    }
}
