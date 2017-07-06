using GallowayWeather.Core.Interfaces;
using GallowayWeather.Core.Models;
using GallowayWeather.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        [TestMethod]
        public void CanGetConditions()
        {
            Condition.SimpleCondition condition = new Condition.SimpleCondition()
            {
                LocalObservationDateTime = DateTime.Now.ToString(),
                EpochTime = 333,
                WeatherText = "Testing Sunny",
                WeatherIcon = 22,
                IsDayTime = true,
                Temperature = new Condition.Temperature()
                {
                    Metric = new Condition.Metric() { Value = 10 },
                    Imperial = new Condition.Imperial() { Value = 4 }
                },
                MobileLink = "123",
                Link = "ABC"
            };

            Mock<IWeatherHistoryRepository> mockHistoryRepository = new Mock<IWeatherHistoryRepository>();


        }

        [TestMethod]
        public void CanGetLocation()
        { 
            Location.SimpleLocation location = new Location.SimpleLocation()
            {
                Version = 1,
                Key = "1",
                Type= "A",
                Rank = 10,
                LocalizedName = "TestPlace",
                EnglishName = "Test Place",
                PrimaryPostalCode = "0000",
                Region = new Location.Region() {
                    EnglishName = "Test Region",
                    ID = "1",
                    LocalizedName = "Test Region"
                },
                Country = new Location.Country()
                {
                     EnglishName="Test Country",
                     LocalizedName = "Test Country",
                     ID = "1"
                },
                AdministrativeArea = new Location.AdministrativeArea()
                {
                    ID = "1",
                    LocalizedName = "Test Area",
                    EnglishName = "Test Area",
                    Level = 1,
                    LocalizedType = "Country",
                    EnglishType = "Country",
                    CountryID = "1"
                },
                TimeZone = new Location.TimeZone()
                {
                    Code = "A",
                    Name = "A",
                    GmtOffset = 8,
                    IsDaylightSaving = true
                },
                GeoPosition = new Location.GeoPosition()
                {
                    Latitude = 10,
                    Longitude = 30,
                    Elevation = new Location.Elevation()
                    {
                        Metric = new Location.Metric()
                        {
                            Value = 10
                        },
                        Imperial = new Location.Imperial()
                        {
                            Value = 5
                        }
                    }
                },
                IsAlias = false,
                SupplementalAdminAreas = new List<Location.SupplementalAdminArea>()
                {
                    new Location.SupplementalAdminArea(){Level = 1, EnglishName = "Test", LocalizedName = "Test"},
                    new Location.SupplementalAdminArea(){Level = 2, EnglishName = "Test2", LocalizedName = "Test2"}
                }
            };
        }

        ///<summary>
        /// Can we return all products?
        ///</summary>
        [TestMethod]
        public void CanReturnAllProducts()
        {
            IList<WeatherHistory> weatherHistories = new List<WeatherHistory>()
            {
                new WeatherHistory{
                    Icon = 33,
                    Location = "99",
                    LocationText = "TestLocation",
                    Temp = "3",
                    Text = "Sunny",
                    DateCreated = new DateTime() }
            };

            // Mock the Products Repository using Moq
            Mock<IWeatherHistoryRepository> mockHistoryRepository = new Mock<IWeatherHistoryRepository>();

            // Return all the products
            mockHistoryRepository.Setup(mr => mr.FindAll()).Returns(weatherHistories);

            //List<WeatherHistory> testHistories = mockHistoryRepository.FindAll());

           //Assert.IsNotNull(testHistories); // Test if null
           // Assert.AreEqual(1, testHistories.Count); // Verify the correct Number
        }

    }
}
