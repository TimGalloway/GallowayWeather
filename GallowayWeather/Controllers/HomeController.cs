using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using GallowayWeather.Infrastructure;
using GallowayWeather.Core.Models;
using static GallowayWeather.Core.Models.Condition;
using static GallowayWeather.Core.Models.Location;

namespace GallowayWeather.Controllers
{
    public class HomeController : Controller
    {
        private GallowayWeatherRepository db = new GallowayWeatherRepository();

        [HttpGet]
        public ActionResult Index()
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel();

            return View(weatherViewModel);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(String lstResults, string lstUnitType)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel();
            WeatherHistory weatherHistory = new WeatherHistory();

            SimpleLocation currLocation = await db.GetLocationAsync(lstResults);
            SimpleCondition currCondition = await db.GetCurrentAsync(lstResults);

            weatherViewModel.WeatherLocation = currLocation.EnglishName + ", " + currLocation.Country.EnglishName;
            weatherViewModel.WeatherIcon = "/Images/Icons/" + currCondition.WeatherIcon.ToString("D2") + "-s.png";
            weatherViewModel.WeatherText = currCondition.WeatherText;
            if (lstUnitType == "Metric")
            {
                weatherViewModel.WeatherTemp = currCondition.Temperature.Metric.Value.ToString() + currCondition.Temperature.Metric.Unit;
                weatherHistory.Temp = currCondition.Temperature.Metric.Value.ToString() + currCondition.Temperature.Metric.Unit;
            }
            else
            {
                weatherViewModel.WeatherTemp = currCondition.Temperature.Imperial.Value.ToString() + currCondition.Temperature.Imperial.Unit;
                weatherHistory.Temp = currCondition.Temperature.Imperial.Value.ToString() + currCondition.Temperature.Imperial.Unit;
            }

            weatherHistory.DateCreated = DateTime.Now;
            weatherHistory.Icon = currCondition.WeatherIcon;
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
    }
}