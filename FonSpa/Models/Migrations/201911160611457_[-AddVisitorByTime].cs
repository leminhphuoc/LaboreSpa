namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitorByTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorByTime",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Count = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitorByTime");
        }
    }
}
