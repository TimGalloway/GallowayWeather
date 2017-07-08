using GallowayWeather.Core.Models;
using System.Collections.Generic;

namespace GallowayWeather.ViewModels
{
    public class WeatherViewModel
    {
        public IList<WeatherHistory> WeatherResults { get; set; }
    }
}