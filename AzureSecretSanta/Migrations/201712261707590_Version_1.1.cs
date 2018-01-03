namespace AzureSecretSanta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GiftDescription = c.String(),
                        SantaOf_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.SantaOf_UserId)
                .Index(t => t.SantaOf_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SantaOf_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "SantaOf_UserId" });
            DropTable("dbo.Users");
        }
    }
}
