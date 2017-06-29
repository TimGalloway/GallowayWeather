using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using GallowayWeather.Infrastructure;
using GallowayWeather.Core.Models;
using static GallowayWeather.Core.Models.Condition;

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
        public async System.Threading.Tasks.Task<ActionResult> Index(String lstResults)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel();

            SimpleCondition currConditions = await db.GetCurrentAsync(lstResults);

            weatherViewModel.WeatherIcon = "/Images/Icons/" + currConditions.WeatherIcon.ToString("D2") + "-s.png";
            weatherViewModel.WeatherText = currConditions.WeatherText;
            weatherViewModel.WeatherTemp = currConditions.Temperature.Metric.Value.ToString() + currConditions.Temperature.Metric.Unit;


            var weatherHistory = new WeatherHistory();
            weatherHistory.DateCreated = DateTime.Now;
            weatherHistory.Icon = currConditions.WeatherIcon;
            weatherHistory.Location = lstResults;
            weatherHistory.Temp = currConditions.Temperature.Metric.Value.ToString() + currConditions.Temperature.Metric.Unit;
            weatherHistory.Text = currConditions.WeatherText;

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