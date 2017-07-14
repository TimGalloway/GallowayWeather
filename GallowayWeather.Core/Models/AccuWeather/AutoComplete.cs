namespace GallowayWeather.Core.Models.AccuWeather
{
    public class AutoComplete
    {
        public class Country
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
        }

        public class AdministrativeArea
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
        }

        public class SimpleAutoComplete
        {
            public int Version { get; set; }
            public string Key { get; set; }
            public string Type { get; set; }
            public int Rank { get; set; }
            public string LocalizedName { get; set; }
            public Country Country { get; set; }
            public AdministrativeArea AdministrativeArea { get; set; }
        }
    }
}
