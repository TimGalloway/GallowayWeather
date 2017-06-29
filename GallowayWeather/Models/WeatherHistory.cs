﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallowayWeather.Models
{
    public class WeatherHistory : BaseModel
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }
        public int Icon { get; set; }
    }
}