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
            WeatherViewModel weatherViewModel = new WeatherViewModel();
            weatherViewModel.WeatherResults = new List<WeatherHistory>();

            return View(weatherViewModel);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(String lstResults, string lstUnitType)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel();
            WeatherHistory weatherResult = new WeatherHistory();
            WeatherHistory weatherHistory = new WeatherHistory();

            weatherViewModel.WeatherResults = new List<WeatherHistory>();
            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderBy(a => a.DateCreated).ToList();

            SimpleLocation currLocation = await db.GetLocationAsync(lstResults);
            SimpleCondition currCondition = await db.GetCurrentAsync(lstResults);

            weatherResult.Location = currLocation.EnglishName + ", " + currLocation.Country.EnglishName;
            weatherResult.Icon = currCondition.WeatherIcon.ToString();
            weatherResult.Text = currCondition.WeatherText;
            if (lstUnitType == "Metric")
            {
                weatherResult.Temp = currCondition.Temperature.Metric.Value.ToString() + currCondition.Temperature.Metric.Unit;
                weatherHistory.Temp = currCondition.Temperature.Metric.Value.ToString() + currCondition.Temperature.Metric.Unit;
            }
            else
            {
                weatherResult.Temp = currCondition.Temperature.Imperial.Value.ToString() + currCondition.Temperature.Imperial.Unit;
                weatherHistory.Temp = currCondition.Temperature.Imperial.Value.ToString() + currCondition.Temperature.Imperial.Unit;
            }
            weatherViewModel.WeatherResults.Add(weatherResult);

            weatherHistory.DateCreated = DateTime.Now;
            weatherHistory.Icon = currCondition.WeatherIcon.ToString();
            weatherHistory.Location = lstResults;
            weatherHistory.Text = currCondition.WeatherText;
            weatherHistory.LocationText = currLocation.EnglishName + ", " + currLocation.Country.EnglishName;

            db.Add(weatherHistory);

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