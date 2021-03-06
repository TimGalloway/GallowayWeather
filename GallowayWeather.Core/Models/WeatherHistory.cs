﻿using System.ComponentModel.DataAnnotations;

namespace GallowayWeather.Core.Models
{
    public class WeatherHistory : BaseModel
    {
        [Required]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string LocationText { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string LocalObservationDateTime { get; set; }
    }
}