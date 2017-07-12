namespace GallowayWeather.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeatherHistoryType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherHistories", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherHistories", "Type");
        }
    }
}
