using FluentMigrator;
using FluentMigrator.SqlServer;

namespace DevTest.Migrations.Migrations
{
    [Migration(20210901104200)]
    public class M002_AddSocialSkillsTable : Migration
    {
        private const string tableName = "SocialSkills";

        public override void Up()
        {
            Create.Table(tableName)
                .WithColumn("SkillId").AsInt32().PrimaryKey().Identity(1,1)
                .WithColumn("Description").AsString(255).NotNullable()
                .WithColumn("PersonId").AsInt32().ForeignKey("Persons", "PersonId");
        }
        public override void Down()
        {
            Delete.Table(tableName);
        }
    }
}
