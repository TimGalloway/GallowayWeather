using GallowayWeather.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowayWeather.Tests
{
    [TestClass]
    public class WeatherRepositoryTest
    {
        GallowayWeatherRepository Repo;

        [TestInitialize]
        public void TestSetup()
        {
            GallowayWeatherInitalizeDB db = new GallowayWeatherInitalizeDB();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new GallowayWeatherRepository();
        }

        [TestMethod]
        public void IsRepositoryInitilizeWithValidNumberOfData()
        {
            var result = Repo.GetWeatherHistory();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(1, numberOfRecords);
        }
    }
}
