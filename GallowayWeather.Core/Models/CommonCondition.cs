namespace GallowayWeather.Core.Models
{
    public class CommonCondition
    {
        public int locationId { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string LocationText { get; set; }
        public string TempUnit { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string LocalObservationDateTime { get; set; }
    }
}
