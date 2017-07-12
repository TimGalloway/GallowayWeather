using GallowayWeather.Core.Models;
using System;
using System.Collections.Generic;
using static GallowayWeather.Core.Models.AccuWeather.Location;
using static GallowayWeather.Core.Models.AccuWeather.AutoComplete;
using System.Threading.Tasks;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherRepository : IDisposable
    {
        Task<CommonCondition> GetCurrentAsync(string locationId);
        Task<ExtendedLocation> GetLocationAsync(string locationId);
        Task<IList<SimpleAutoComplete>> GetAutoCompleteAsync(string searchString);
    }
}
