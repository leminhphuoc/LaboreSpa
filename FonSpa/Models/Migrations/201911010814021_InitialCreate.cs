namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
         
            CreateTable(
                "dbo.About",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        description = c.String(maxLength: 250),
                        detail = c.String(storeType: "ntext"),
                        image = c.String(maxLength: 250),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AccountAdmin",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 100),
                        passWord = c.String(nullable: false, maxLength: 100),
                        type = c.Boolean(),
                        STATUS = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(storeType: "ntext"),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ContentCategory",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metatitle = c.String(maxLength: 250),
                        parentID = c.Int(),
                        displayOrder = c.Int(),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                        showOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 100),
                        passWord = c.String(nullable: false, maxLength: 200),
                        email = c.String(maxLength: 100),
                        phone = c.String(maxLength: 20, unicode: false),
                        address = c.String(maxLength: 100),
                        typeMember = c.Int(),
                        token = c.String(maxLength: 100),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FooterCategory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(maxLength: 50),
                        link = c.String(maxLength: 100),
                        displayOrder = c.Int(),
                        typeId = c.Int(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(maxLength: 50),
                        link = c.String(maxLength: 100),
                        displayOrder = c.Int(),
                        typeId = c.Int(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metatitle = c.String(maxLength: 250),
                        parentID = c.Int(),
                        displayOrder = c.Int(),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                        showOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        description = c.String(maxLength: 250),
                        image = c.String(maxLength: 100),
                        moreImages = c.String(storeType: "xml"),
                        price = c.Decimal(precision: 18, scale: 0),
                        promotionPrice = c.Decimal(precision: 18, scale: 0),
                        quantity = c.Int(nullable: false),
                        idCategory = c.Int(),
                        detail = c.String(storeType: "ntext"),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                        topHot = c.DateTime(storeType: "date"),
                        viewCount = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ServiceCategory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metatitle = c.String(maxLength: 250),
                        parentID = c.Int(),
                        displayOrder = c.Int(),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                        showOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        description = c.String(maxLength: 250),
                        image = c.String(maxLength: 100),
                        moreImages = c.String(storeType: "xml"),
                        price = c.Decimal(precision: 18, scale: 0),
                        promotionPrice = c.Decimal(precision: 18, scale: 0),
                        quantity = c.Int(nullable: false),
                        idCategory = c.Int(),
                        detail = c.String(storeType: "ntext"),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                        topHot = c.DateTime(storeType: "date"),
                        viewCount = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        image = c.String(maxLength: 250),
                        displayOrder = c.Int(),
                        link = c.String(maxLength: 250),
                        description = c.String(maxLength: 250),
                        createdDate = c.DateTime(storeType: "date"),
                        modifiedDate = c.DateTime(storeType: "date"),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Slide");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceCategory");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.FooterCategory");
            DropTable("dbo.Customer");
            DropTable("dbo.Content");
            DropTable("dbo.ContentCategory");
            DropTable("dbo.Contact");
            DropTable("dbo.AccountAdmin");
            DropTable("dbo.About");
        }
    }
}
