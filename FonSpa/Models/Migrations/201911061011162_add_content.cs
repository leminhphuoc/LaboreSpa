namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_content : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Content",
             c => new
             {
                 id = c.Long(nullable: false, identity: true),
                 name = c.String(maxLength: 250),
                 metatitle = c.String(maxLength: 100),
                 description = c.String(maxLength: 500),
                 image = c.String(maxLength: 250),
                 categoryID = c.Long(),
                 detail = c.String(storeType: "ntext"),
                 createdDate = c.DateTime(storeType: "date"),
                 modifiedDate = c.DateTime(storeType: "date"),
                 topHot = c.DateTime(storeType: "date"),
                 viewCount = c.Int(),
                 status = c.Boolean(),
             })
             .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Content");
        }
    }
}
