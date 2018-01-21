namespace VanHackForumWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('UI/UX Designer' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('DevOps/SysAdmin' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('Data Science/Big Data' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('Mobile' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('Quality Assurance' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('Gaming' , 0)");
            Sql("INSERT INTO Categories (Description, Amount) VALUES ('Fullstack and Backend' , 0)");           
        }
        
        public override void Down()
        {
        }
    }
}
