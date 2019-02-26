namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreeItemmodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Order = c.Int(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TreeItems", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreeItems", "ParentId", "dbo.TreeItems");
            DropIndex("dbo.TreeItems", new[] { "ParentId" });
            DropTable("dbo.TreeItems");
        }
    }
}
