using GallowayWeather.Core.Interfaces;
using GallowayWeather.Core.Models;
using GallowayWeather.Core.Models.AccuWeather;
using GallowayWeather.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GallowayWeather.Core.Models.AccuWeather.Condition;
using static GallowayWeather.Core.Models.AccuWeather.Location;

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
            //Condition.ExtendedCondition condition = new Condition.ExtendedCondition()
            //{
            //    ConditionID = "1",
            //        LocalObservationDateTime = DateTime.Now.ToString(),
            //        EpochTime = 333,
            //        WeatherText = "Testing Sunny",
            //        WeatherIcon = 22,
            //        IsDayTime = true,
            //        Temperature = new Condition.Temperature()
            //        {
            //            Metric = new Condition.Metric() { Value = 10 },
            //            Imperial = new Condition.Imperial() { Value = 4 }
            //        },
            //        MobileLink = "123",
            //        Link = "ABC"
            //};
            //Location.ExtendedLocation location = new Location.ExtendedLocation()
            //{
            //    LocationID = "100",
            //    Version = 1,
            //    Key = "1",
            //    Type = "A",
            //    Rank = 10,
            //    LocalizedName = "TestPlace",
            //    EnglishName = "Test Place",
            //    PrimaryPostalCode = "0000",
            //    Region = new Location.Region()
            //    {
            //        EnglishName = "Test Region",
            //        ID = "1",
            //        LocalizedName = "Test Region"
            //    },
            //    Country = new Location.Country()
            //    {
            //        EnglishName = "Test Country",
            //        LocalizedName = "Test Country",
            //        ID = "1"
            //    },
            //    AdministrativeArea = new Location.AdministrativeArea()
            //    {
            //        ID = "1",
            //        LocalizedName = "Test Area",
            //        EnglishName = "Test Area",
            //        Level = 1,
            //        LocalizedType = "Country",
            //        EnglishType = "Country",
            //        CountryID = "1"
            //    },
            //    TimeZone = new Location.TimeZone()
            //    {
            //        Code = "A",
            //        Name = "A",
            //        GmtOffset = 8,
            //        IsDaylightSaving = true
            //    },
            //    GeoPosition = new Location.GeoPosition()
            //    {
            //        Latitude = 10,
            //        Longitude = 30,
            //        Elevation = new Location.Elevation()
            //        {
            //            Metric = new Location.Metric()
            //            {
            //                Value = 10
            //            },
            //            Imperial = new Location.Imperial()
            //            {
            //                Value = 5
            //            }
            //        }
            //    },
            //    IsAlias = false,
            //    SupplementalAdminAreas = new List<Location.SupplementalAdminArea>()
            //    {
            //        new Location.SupplementalAdminArea(){Level = 1, EnglishName = "Test", LocalizedName = "Test"},
            //        new Location.SupplementalAdminArea(){Level = 2, EnglishName = "Test2", LocalizedName = "Test2"}
            //    }
            //};
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
            //mockHistoryRepository.Setup(mr => mr.GetCurrentAsync("1")).Returns(Task.FromResult(condition));
            //mockHistoryRepository.Setup(mr => mr.GetLocationAsync("100")).Returns(Task.FromResult(location));

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
        /// Can we return all products?
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
