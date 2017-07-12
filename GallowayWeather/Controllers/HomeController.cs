﻿using System;
using System.Web.Mvc;
using GallowayWeather.ViewModels;
using GallowayWeather.Infrastructure;
using GallowayWeather.Core.Models;
using static GallowayWeather.Core.Models.AccuWeather.Condition;
using static GallowayWeather.Core.Models.AccuWeather.Location;
using System.Collections.Generic;
using System.Linq;
using static GallowayWeather.Core.Models.AccuWeather.AutoComplete;
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
            List<WeatherType> weatherTypes = new List<WeatherType>(){
                new WeatherType { ID = "AccuWeather", Type = "AccuWeather"},
                new WeatherType { ID = "OpenWeather", Type = "OpenWeather"}
            };
            return weatherTypes;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(String lstResults, string lstUnitType, string lstWeatherType)
        {
            WeatherViewModel weatherViewModel = new WeatherViewModel() {
                WeatherResults = new List<WeatherHistory>(),
                WeatherTypes = new List<WeatherType>()
            };

            Assembly ass = Assembly.Load("GallowayWeather.Infrastructure");
            Type t = ass.GetType("GallowayWeather.Infrastructure.Repositories." + lstWeatherType);
            IWeatherRepository wr = (IWeatherRepository)Activator.CreateInstance(t);

            ExtendedLocation currLocation = await wr.GetLocationAsync(lstResults);
            ExtendedCondition currCondition = await wr.GetCurrentAsync(lstResults);

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

            weatherViewModel.WeatherResults = db.GetWeatherHistory().OrderByDescending(a => a.DateCreated).Take(12).ToList();
            weatherViewModel.WeatherTypes = CreateWeatherTypeList();

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