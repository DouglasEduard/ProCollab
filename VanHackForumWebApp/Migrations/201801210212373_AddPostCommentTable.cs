namespace VanHackForumWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        UserNickName = c.String(maxLength: 30),
                        Comment = c.String(),
                        Post_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostComments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostComments", new[] { "User_Id" });
            DropIndex("dbo.PostComments", new[] { "Post_Id" });
            DropTable("dbo.PostComments");
        }
    }
}
