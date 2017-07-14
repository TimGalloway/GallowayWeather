using GallowayWeather.Core.Models;
using System.Collections.Generic;

namespace GallowayWeather.ViewModels
{
    public class WeatherViewModel
    {
        public IList<WeatherHistory> WeatherResults { get; set; }
        public IList<WeatherType> WeatherTypes { get; set; }
    }

    public class WeatherType
    {
        public string ID { get; set; }
        public string Type { get; set; }
    }
}