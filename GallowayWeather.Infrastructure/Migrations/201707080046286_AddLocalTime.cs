namespace GallowayWeather.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocalTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherHistories", "LocalObservationDateTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherHistories", "LocalObservationDateTime");
        }
    }
}
