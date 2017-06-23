using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallowayWeather.DAL
{
    public class WeatherInitilizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
        }
    }
}