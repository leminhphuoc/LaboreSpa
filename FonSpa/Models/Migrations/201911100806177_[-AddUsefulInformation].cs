namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsefulInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsefulInformation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Visitor = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsefulInformation");
        }
    }
}
