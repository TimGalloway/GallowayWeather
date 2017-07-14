namespace GallowayWeather.Core.Models.AccuWeather
{
    public class CurrentConditionDetailed
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

        public class Metric2
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial2
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class RealFeelTemperature
        {
            public Metric2 Metric { get; set; }
            public Imperial2 Imperial { get; set; }
        }

        public class Metric3
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial3
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class RealFeelTemperatureShade
        {
            public Metric3 Metric { get; set; }
            public Imperial3 Imperial { get; set; }
        }

        public class Metric4
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial4
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class DewPoint
        {
            public Metric4 Metric { get; set; }
            public Imperial4 Imperial { get; set; }
        }

        public class Direction
        {
            public int Degrees { get; set; }
            public string Localized { get; set; }
            public string English { get; set; }
        }

        public class Metric5
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial5
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Speed
        {
            public Metric5 Metric { get; set; }
            public Imperial5 Imperial { get; set; }
        }

        public class Wind
        {
            public Direction Direction { get; set; }
            public Speed Speed { get; set; }
        }

        public class Metric6
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial6
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Speed2
        {
            public Metric6 Metric { get; set; }
            public Imperial6 Imperial { get; set; }
        }

        public class WindGust
        {
            public Speed2 Speed { get; set; }
        }

        public class Metric7
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial7
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Visibility
        {
            public Metric7 Metric { get; set; }
            public Imperial7 Imperial { get; set; }
        }

        public class Metric8
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial8
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Ceiling
        {
            public Metric8 Metric { get; set; }
            public Imperial8 Imperial { get; set; }
        }

        public class Metric9
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial9
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Pressure
        {
            public Metric9 Metric { get; set; }
            public Imperial9 Imperial { get; set; }
        }

        public class PressureTendency
        {
            public string LocalizedText { get; set; }
            public string Code { get; set; }
        }

        public class Metric10
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial10
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past24HourTemperatureDeparture
        {
            public Metric10 Metric { get; set; }
            public Imperial10 Imperial { get; set; }
        }

        public class Metric11
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial11
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class ApparentTemperature
        {
            public Metric11 Metric { get; set; }
            public Imperial11 Imperial { get; set; }
        }

        public class Metric12
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial12
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class WindChillTemperature
        {
            public Metric12 Metric { get; set; }
            public Imperial12 Imperial { get; set; }
        }

        public class Metric13
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial13
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class WetBulbTemperature
        {
            public Metric13 Metric { get; set; }
            public Imperial13 Imperial { get; set; }
        }

        public class Metric14
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial14
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Precip1hr
        {
            public Metric14 Metric { get; set; }
            public Imperial14 Imperial { get; set; }
        }

        public class Metric15
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial15
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Precipitation
        {
            public Metric15 Metric { get; set; }
            public Imperial15 Imperial { get; set; }
        }

        public class Metric16
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial16
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class PastHour
        {
            public Metric16 Metric { get; set; }
            public Imperial16 Imperial { get; set; }
        }

        public class Metric17
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial17
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past3Hours
        {
            public Metric17 Metric { get; set; }
            public Imperial17 Imperial { get; set; }
        }

        public class Metric18
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial18
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past6Hours
        {
            public Metric18 Metric { get; set; }
            public Imperial18 Imperial { get; set; }
        }

        public class Metric19
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial19
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past9Hours
        {
            public Metric19 Metric { get; set; }
            public Imperial19 Imperial { get; set; }
        }

        public class Metric20
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial20
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past12Hours
        {
            public Metric20 Metric { get; set; }
            public Imperial20 Imperial { get; set; }
        }

        public class Metric21
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial21
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past18Hours
        {
            public Metric21 Metric { get; set; }
            public Imperial21 Imperial { get; set; }
        }

        public class Metric22
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial22
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Past24Hours
        {
            public Metric22 Metric { get; set; }
            public Imperial22 Imperial { get; set; }
        }

        public class PrecipitationSummary
        {
            public Precipitation Precipitation { get; set; }
            public PastHour PastHour { get; set; }
            public Past3Hours Past3Hours { get; set; }
            public Past6Hours Past6Hours { get; set; }
            public Past9Hours Past9Hours { get; set; }
            public Past12Hours Past12Hours { get; set; }
            public Past18Hours Past18Hours { get; set; }
            public Past24Hours Past24Hours { get; set; }
        }

        public class Metric23
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial23
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Minimum
        {
            public Metric23 Metric { get; set; }
            public Imperial23 Imperial { get; set; }
        }

        public class Metric24
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial24
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Maximum
        {
            public Metric24 Metric { get; set; }
            public Imperial24 Imperial { get; set; }
        }

        public class Past6HourRange
        {
            public Minimum Minimum { get; set; }
            public Maximum Maximum { get; set; }
        }

        public class Metric25
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial25
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Minimum2
        {
            public Metric25 Metric { get; set; }
            public Imperial25 Imperial { get; set; }
        }

        public class Metric26
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial26
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Maximum2
        {
            public Metric26 Metric { get; set; }
            public Imperial26 Imperial { get; set; }
        }

        public class Past12HourRange
        {
            public Minimum2 Minimum { get; set; }
            public Maximum2 Maximum { get; set; }
        }

        public class Metric27
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial27
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Minimum3
        {
            public Metric27 Metric { get; set; }
            public Imperial27 Imperial { get; set; }
        }

        public class Metric28
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial28
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Maximum3
        {
            public Metric28 Metric { get; set; }
            public Imperial28 Imperial { get; set; }
        }

        public class Past24HourRange
        {
            public Minimum3 Minimum { get; set; }
            public Maximum3 Maximum { get; set; }
        }

        public class TemperatureSummary
        {
            public Past6HourRange Past6HourRange { get; set; }
            public Past12HourRange Past12HourRange { get; set; }
            public Past24HourRange Past24HourRange { get; set; }
        }

        public class CurrentConditionDetail
        {
            public string LocalObservationDateTime { get; set; }
            public int EpochTime { get; set; }
            public string WeatherText { get; set; }
            public int WeatherIcon { get; set; }
            public bool IsDayTime { get; set; }
            public Temperature Temperature { get; set; }
            public RealFeelTemperature RealFeelTemperature { get; set; }
            public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
            public int RelativeHumidity { get; set; }
            public DewPoint DewPoint { get; set; }
            public Wind Wind { get; set; }
            public WindGust WindGust { get; set; }
            public int UVIndex { get; set; }
            public string UVIndexText { get; set; }
            public Visibility Visibility { get; set; }
            public string ObstructionsToVisibility { get; set; }
            public int CloudCover { get; set; }
            public Ceiling Ceiling { get; set; }
            public Pressure Pressure { get; set; }
            public PressureTendency PressureTendency { get; set; }
            public Past24HourTemperatureDeparture Past24HourTemperatureDeparture { get; set; }
            public ApparentTemperature ApparentTemperature { get; set; }
            public WindChillTemperature WindChillTemperature { get; set; }
            public WetBulbTemperature WetBulbTemperature { get; set; }
            public Precip1hr Precip1hr { get; set; }
            public PrecipitationSummary PrecipitationSummary { get; set; }
            public TemperatureSummary TemperatureSummary { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }
    }
}