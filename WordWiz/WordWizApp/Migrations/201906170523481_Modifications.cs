namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "User_Id" });
            AddColumn("dbo.Students", "UserName", c => c.String());
            AlterColumn("dbo.Students", "UserId", c => c.String());
            DropColumn("dbo.Students", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "UserName");
            CreateIndex("dbo.Students", "User_Id");
            AddForeignKey("dbo.Students", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
