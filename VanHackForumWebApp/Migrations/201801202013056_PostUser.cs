namespace VanHackForumWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserNickName", c => c.String(maxLength: 30));
            AddColumn("dbo.Posts", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "NickName");
            DropColumn("dbo.Posts", "User_Id");
            DropColumn("dbo.Posts", "UserNickName");
        }
    }
}
