namespace MyConverter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNumber = c.String(),
                        Header = c.String(),
                        MainOrder = c.String(),
                        Length = c.String(),
                        PseudoIPaddress = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Latitude = c.String(),
                        Lat = c.String(),
                        Lan = c.String(),
                        Longitude = c.String(),
                        Speed = c.String(),
                        Angle = c.String(),
                        GPSstatus = c.String(),
                        Detectionsettingstatus = c.String(),
                        Ignitionstatus = c.String(),
                        Oilresistance = c.String(),
                        Voltage = c.String(),
                        Mileage = c.String(),
                        Temperature = c.String(),
                        Calibration = c.String(),
                        Footer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceDatas");
        }
    }
}
