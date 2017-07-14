using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using GallowayWeather.Infrastructure;
using GallowayWeather.Core.Models;
using System.Collections.Generic;
using System.Linq;
using GallowayWeather.Core.Interfaces;
using System.Reflection;

namespace GallowayWeather.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherHistoryRepository db = new WeatherHistoryRepository();

        [HttpGet]
        public ActionResult Index()
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel()
            {
                WeatherResults = new List<WeatherHistory>(),
                WeatherTypes = new List<WeatherType>()
            };

            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderByDescending(a => a.DateCreated).Take(12).ToList();
            weatherViewModel.WeatherTypes = CreateWeatherTypeList();

            return View(weatherViewModel);
        }

        private static List<WeatherType> CreateWeatherTypeList()
        {
            List<WeatherType> weatherTypes = new List<WeatherType>();

            Assembly infrastructreAssesmbly = Assembly.Load("GallowayWeather.Infrastructure");

            var types = infrastructreAssesmbly.GetTypes()
             .Where(m => m.IsClass && m.GetInterface("IWeatherRepository") != null)
             .Select(s => s.Name);

            foreach (var i in types)
            {
                WeatherType a = new WeatherType() { ID = i, Type = i };
                weatherTypes.Add(a);
            }

            return weatherTypes;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(String searchtext, String lstResults, string lstUnitType, string lstWeatherType)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel() {
                WeatherResults = new List<WeatherHistory>(),
                WeatherTypes = new List<WeatherType>()
            };

            Assembly ass = Assembly.Load("GallowayWeather.Infrastructure");
            Type t = ass.GetType("GallowayWeather.Infrastructure.Repositories." + lstWeatherType);
            IWeatherRepository wr = (IWeatherRepository)Activator.CreateInstance(t);

            CommonLocation currLocation = await wr.GetLocationAsync(lstResults, searchtext);
            CommonCondition currCondition = await wr.GetCurrentAsync(lstResults, searchtext, lstUnitType);

            WeatherHistory weatherHistory = new WeatherHistory()
            {
                DateCreated = DateTime.Now,
                Icon = currCondition.Icon,
                Location = lstResults,
                Text = currCondition.Text,
                LocationText = currLocation.EnglishName,
                LocalObservationDateTime = currCondition.LocalObservationDateTime,
                Type = currCondition.Type,
                Temp = currCondition.Temp + currCondition.TempUnit.ToString()
            };

            db.Add(weatherHistory);

            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderByDescending(a => a.DateCreated).Take(12).ToList();
            weatherViewModel.WeatherTypes = CreateWeatherTypeList();

            ModelState.Clear();

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

        public async System.Threading.Tasks.Task<JsonResult> AutoCompleteAsync(String searchtext, String weatherType)
        {
            Assembly ass = Assembly.Load("GallowayWeather.Infrastructure");
            Type t = ass.GetType("GallowayWeather.Infrastructure.Repositories." + weatherType);
            IWeatherRepository wr = (IWeatherRepository)Activator.CreateInstance(t);

            return Json(await wr.GetAutoCompleteAsync(searchtext),JsonRequestBehavior.AllowGet);
        }
    }
}