namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIntroduced2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "Name");
        }
    }
}
