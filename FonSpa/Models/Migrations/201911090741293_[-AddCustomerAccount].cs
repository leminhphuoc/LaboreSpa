namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAccount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 100),
                        passWord = c.String(nullable: false, maxLength: 100),
                        type = c.Boolean(),
                        STATUS = c.Boolean(),
                        IdCustomer = c.Long(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerAccount");
        }
    }
}
