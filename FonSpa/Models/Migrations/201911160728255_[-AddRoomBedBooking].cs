namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomBedBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bed",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                        IdRoom = c.Int(nullable: false),
                        IdBooking = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArrivalTime = c.DateTime(nullable: false),
                        IdCustomer = c.Long(nullable: false),
                        IdServices = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Room");
            DropTable("dbo.Booking");
            DropTable("dbo.Bed");
        }
    }
}
