using GallowayWeather.Core.Models;
using System;
using System.Collections.Generic;
using static GallowayWeather.Core.Models.AccuWeather.AutoComplete;
using System.Threading.Tasks;

namespace GallowayWeather.Core.Interfaces
{
    public interface IWeatherRepository : IDisposable
    {
        Task<CommonCondition> GetCurrentAsync(string locationId, string searchtext, string tempUnit);
        Task<CommonLocation> GetLocationAsync(string locationId, string searchtext);
        Task<IList<SimpleAutoComplete>> GetAutoCompleteAsync(string searchString);
    }
}
