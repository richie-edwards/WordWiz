namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableWordCreateDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Words", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Words", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
