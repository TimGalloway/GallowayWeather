namespace GallowayWeather.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIconFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeatherHistories", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeatherHistories", "Icon", c => c.Int(nullable: false));
        }
    }
}
