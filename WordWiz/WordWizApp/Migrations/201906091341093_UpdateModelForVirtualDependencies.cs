namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelForVirtualDependencies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Sentences", "Word_Id", "dbo.Words");
            DropIndex("dbo.Sentences", new[] { "Word_Id" });
            DropIndex("dbo.Words", new[] { "Student_Id" });
            RenameColumn(table: "dbo.Words", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.Sentences", name: "Word_Id", newName: "WordId");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sentences", "WordId", c => c.Int(nullable: false));
            AlterColumn("dbo.Words", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sentences", "WordId");
            CreateIndex("dbo.Words", "StudentId");
            CreateIndex("dbo.Students", "UserId");
            AddForeignKey("dbo.Students", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Words", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sentences", "WordId", "dbo.Words", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sentences", "WordId", "dbo.Words");
            DropForeignKey("dbo.Words", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Words", new[] { "StudentId" });
            DropIndex("dbo.Sentences", new[] { "WordId" });
            AlterColumn("dbo.Words", "StudentId", c => c.Int());
            AlterColumn("dbo.Sentences", "WordId", c => c.Int());
            DropColumn("dbo.Students", "UserId");
            DropColumn("dbo.Students", "CreatedDate");
            DropTable("dbo.Users");
            RenameColumn(table: "dbo.Sentences", name: "WordId", newName: "Word_Id");
            RenameColumn(table: "dbo.Words", name: "StudentId", newName: "Student_Id");
            CreateIndex("dbo.Words", "Student_Id");
            CreateIndex("dbo.Sentences", "Word_Id");
            AddForeignKey("dbo.Sentences", "Word_Id", "dbo.Words", "Id");
            AddForeignKey("dbo.Words", "Student_Id", "dbo.Students", "Id");
        }
    }
}
