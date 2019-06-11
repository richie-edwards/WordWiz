namespace WordWizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRolesUsersStudents : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into [dbo].[Roles] (Name) Values('Admin'), ('Student'), ('Teacher')");

            Sql(@"Insert into [dbo].[Users] ([Username], [Password], [CreatedDate], [RoleId]) 
select 'John.Smith', 'password123', GETDATE(), r.Id
from dbo.Roles as r
where r.Name = 'Teacher'");

            Sql(@"Insert into [dbo].[Students] ([FirstName], [LastName], [CreatedDate], [UserId]) 
select 'Student', 'One', GETDATE(), u.Id
from dbo.Users as u
where Username = 'John.Smith'");

        }
        
        public override void Down()
        {
        }
    }
}
