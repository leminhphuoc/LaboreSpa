namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIPAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IPAddress",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IPAddress");
        }
    }
}
