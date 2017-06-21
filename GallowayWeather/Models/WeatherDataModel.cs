namespace GallowayWeather.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WeatherDataModel : DbContext
    {
        // Your context has been configured to use a 'WeatherDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GallowayWeather.Models.WeatherDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WeatherDataModel' 
        // connection string in the application configuration file.
        public WeatherDataModel()
            : base("name=WeatherDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Location
    {
        public string LocationName { get; set; }
    }
}