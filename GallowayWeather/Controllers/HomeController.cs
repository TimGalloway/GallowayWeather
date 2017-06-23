using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using static GallowayWeather.CurrentConditon;
using System.Collections.Generic;

namespace GallowayWeather.Controllers
{
    public class HomeController : Controller
    {
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

            //Populate the viewmodel, this needs to be a JSON call to the webservice 

            var url = "http://dataservice.accuweather.com/currentconditions/v1/" + lstResults + "?apikey=URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF";
            List<RootObject> rootObject = new List<RootObject>();
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);

                rootObject = JsonConvert.DeserializeObject<List<RootObject>>(json);
            }
            RootObject currConditions = rootObject[0];

            weatherViewModel.WeatherIcon = "/Images/Icons/" + currConditions.WeatherIcon.ToString("D2") + "-s.png";
            weatherViewModel.WeatherText = currConditions.WeatherText;
            weatherViewModel.WeatherTemp = currConditions.Temperature.Metric.Value.ToString() + currConditions.Temperature.Metric.Unit;

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