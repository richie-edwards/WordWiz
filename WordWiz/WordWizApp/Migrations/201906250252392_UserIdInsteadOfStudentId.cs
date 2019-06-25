namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdInsteadOfStudentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "StudentId", "dbo.Students");
            DropIndex("dbo.Words", new[] { "StudentId" });
            RenameColumn(table: "dbo.Words", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.Words", "UserId", c => c.String());
            AlterColumn("dbo.Words", "Student_Id", c => c.Int());
            CreateIndex("dbo.Words", "Student_Id");
            AddForeignKey("dbo.Words", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "Student_Id", "dbo.Students");
            DropIndex("dbo.Words", new[] { "Student_Id" });
            AlterColumn("dbo.Words", "Student_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Words", "UserId");
            RenameColumn(table: "dbo.Words", name: "Student_Id", newName: "StudentId");
            CreateIndex("dbo.Words", "StudentId");
            AddForeignKey("dbo.Words", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
