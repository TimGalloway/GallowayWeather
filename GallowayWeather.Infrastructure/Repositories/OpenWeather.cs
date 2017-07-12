using GallowayWeather.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallowayWeather.Core.Models.OpenWeatherMap;
using GallowayWeather.Core.Models.AccuWeather;

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

        public Task<Condition.ExtendedCondition> GetCurrentAsync(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<Location.ExtendedLocation> GetLocationAsync(string locationId)
        {
            throw new NotImplementedException();
        }
    }
}
