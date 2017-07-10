namespace GallowayWeather.Core.Models
{
    public class Condition
    {

        public class Metric
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Temperature
        {
            public Metric Metric { get; set; }
            public Imperial Imperial { get; set; }
        }

        public class SimpleCondition
        {
            public string LocalObservationDateTime { get; set; }
            public int EpochTime { get; set; }
            public string WeatherText { get; set; }
            public int WeatherIcon { get; set; }
            public bool IsDayTime { get; set; }
            public Temperature Temperature { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }

        public class ExtendedCondition : SimpleCondition
        {
            public string ConditionID { get; set; }
        }
    }
}