namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into[dbo].[AspNetRoles] ([Id], [Name]) Values('1', 'Admin'), ('2', 'Student'), ('3', 'Teacher')");
        }
        
        public override void Down()
        {
        }
    }
}
