using FluentMigrator;
using FluentMigrator.SqlServer;

namespace DevTest.Migrations.Migrations
{
    [Migration(20210901104400)]
    public class M003_AddSocialAccountTable : Migration
    {
        private const string tableName = "SocialAccounts";

        public override void Up()
        {
            Create.Table(tableName)
                .WithColumn("AccountId").AsInt32().PrimaryKey().Identity(1, 1)
                .WithColumn("Type").AsString(50).NotNullable()
                .WithColumn("Address").AsString(255).NotNullable()
                .WithColumn("PersonId").AsInt32().ForeignKey("Persons", "PersonId");
        }
        public override void Down()
        {
            Delete.Table(tableName);
        }
    }
}
