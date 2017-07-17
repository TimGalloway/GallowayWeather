using GallowayWeather.Core.Interfaces;
using GallowayWeather.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GallowayWeather.Tests
{
    [TestClass]
    public class WeatherRepositoryTest
    {
        public WeatherRepositoryTest()
        {
            CommonCondition commonConditionAccuWeather = new CommonCondition()
            {
                locationId = 1,
                Type = "AccuWeather",
                Icon = "33",
                Location = "99",
                LocationText = "TestLocation",
                Temp = "3",
                Text = "Sunny",
                LocalObservationDateTime = "10/02/2017 12:00pm",
                TempUnit ="C"
            };

            CommonCondition commonConditionOpenWeather = new CommonCondition()
            {
                locationId = 1,
                Type = "OpenWeather",
                Icon = "33",
                Location = "99",
                LocationText = "TestLocation",
                Temp = "3",
                Text = "Sunny",
                LocalObservationDateTime = "10/02/2017 12:00pm",
                TempUnit = "C"
            };

            CommonLocation commonLocation = new CommonLocation()
            {
                 EnglishName = "Test Place"
            };
            IList<WeatherHistory> weatherHistories = new List<WeatherHistory>()
            {
                new WeatherHistory{
                    Icon = "33",
                    Location = "99",
                    LocationText = "TestLocation",
                    Temp = "3",
                    Text = "Sunny",
                    DateCreated = new DateTime(),
                    LocalObservationDateTime="10/02/2017 12:00pm",
                    ID=10
                },
                new WeatherHistory{
                    Icon = "33",
                    Location = "99",
                    LocationText = "TestLocation",
                    Temp = "3",
                    Text = "Sunny",
                    DateCreated = new DateTime(),
                    LocalObservationDateTime="10/02/2017 12:00pm",
                    ID=11
                },
                new WeatherHistory{
                    Icon = "33",
                    Location = "99",
                    LocationText = "TestLocation",
                    Temp = "3",
                    Text = "Sunny",
                    DateCreated = new DateTime(),
                    LocalObservationDateTime="10/02/2017 12:00pm",
                    ID=12
                }
            };

            Mock<IWeatherHistoryRepository> mockHistoryRepository = new Mock<IWeatherHistoryRepository>();
            Mock<IWeatherRepository> mockRepository = new Mock<IWeatherRepository>();

            mockHistoryRepository.Setup(mr => mr.FindAll()).Returns(weatherHistories);

            mockRepository.Setup(mr => mr.GetCurrentAsync("1", "perth", "C")).Returns(Task.FromResult(commonConditionAccuWeather));
            mockRepository.Setup(mr => mr.GetLocationAsync("1", "perth")).Returns(Task.FromResult(commonLocation));

            this.MockWeatherRepository = mockHistoryRepository.Object;
            this.MockRepository = mockRepository.Object;
        }

        public TestContext TestContext { get; set; }
        public readonly IWeatherHistoryRepository MockWeatherRepository;
        public readonly IWeatherRepository MockRepository;

        [TestMethod]
        public async Task CanGetConditionsAsync()
        {
            CommonCondition testCondition = await MockRepository.GetCurrentAsync("1","perth","C");

            Assert.IsNotNull(testCondition);
            Assert.IsInstanceOfType(testCondition, typeof(CommonCondition));
            Assert.AreEqual("TestLocation", testCondition.LocationText);
        }

        [TestMethod]
        public async Task CanGetLocation()
        {
            CommonLocation testLocation = await MockRepository.GetLocationAsync("1","perth");

            Assert.IsNotNull(testLocation);
            Assert.IsInstanceOfType(testLocation, typeof(CommonLocation));
            Assert.AreEqual("Test Place", testLocation.EnglishName);
        }

        ///<summary>
        /// 
        ///</summary>
        [TestMethod]
        public void CanReturnAllWeatherHistorys()
        {
            // Try finding all Weather Histories
            IList<WeatherHistory> testHistories = MockWeatherRepository.FindAll();

           Assert.IsNotNull(testHistories); // Test if null
           Assert.AreEqual(3, testHistories.Count); // Verify the correct Number
        }

    }
}
