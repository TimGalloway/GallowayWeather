using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallowayWeather.DAL
{
    public class WeatherInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherContext>
    {
    }
}