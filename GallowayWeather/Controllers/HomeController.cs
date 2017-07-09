using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using GallowayWeather.Infrastructure;
using GallowayWeather.Core.Models;
using static GallowayWeather.Core.Models.Condition;
using static GallowayWeather.Core.Models.Location;
using System.Collections.Generic;
using System.Linq;
using static GallowayWeather.Core.Models.AutoComplete;

namespace GallowayWeather.Controllers
{
    public class HomeController : Controller
    {
        private GallowayWeatherRepository db = new GallowayWeatherRepository();

        [HttpGet]
        public ActionResult Index()
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel()
            {
                WeatherResults = new List<WeatherHistory>()
            };

            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderBy(a => a.DateCreated).ToList();

            return View(weatherViewModel);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(String lstResults, string lstUnitType)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel() {
                WeatherResults = new List<WeatherHistory>()
            };

            ExtendedLocation currLocation = await db.GetLocationAsync(lstResults);
            ExtendedCondition currCondition = await db.GetCurrentAsync(lstResults);

            WeatherHistory weatherHistory = new WeatherHistory()
            {
                DateCreated = DateTime.Now,
                Icon = currCondition.WeatherIcon.ToString("00"),
                Location = lstResults,
                Text = currCondition.WeatherText,
                LocationText = currLocation.EnglishName + ", " + currLocation.Country.EnglishName,
                LocalObservationDateTime = currCondition.LocalObservationDateTime
            };

            if (lstUnitType == "Metric")
            {
                weatherHistory.Temp = currCondition.Temperature.Metric.Value.ToString() + currCondition.Temperature.Metric.Unit;
            }
            else
            {
                weatherHistory.Temp = currCondition.Temperature.Imperial.Value.ToString() + currCondition.Temperature.Imperial.Unit;
            }

            db.Add(weatherHistory);

            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderBy(a => a.DateCreated).ToList();

            return View(weatherViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "GallowayWeather";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Galloway Consulting";

            return View();
        }

        public async System.Threading.Tasks.Task<JsonResult> AutoCompleteAsync(String searchtext)
        {
            return Json(await db.GetAutoCompleteAsync(searchtext),JsonRequestBehavior.AllowGet);
        }
    }
}