namespace VanHackForumWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "Category_ID", c => c.Int());
            CreateIndex("dbo.Posts", "Category_ID");
            AddForeignKey("dbo.Posts", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_ID" });
            DropColumn("dbo.Posts", "Category_ID");
            DropTable("dbo.Categories");
        }
    }
}
