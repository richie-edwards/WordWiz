// <auto-generated />
namespace WordWizApp.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class UserIdInsteadOfStudentId : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UserIdInsteadOfStudentId));
        
        string IMigrationMetadata.Id
        {
            get { return "201906250252392_UserIdInsteadOfStudentId"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}