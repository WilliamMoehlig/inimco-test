using FluentMigrator;
using FluentMigrator.SqlServer;

namespace DevTest.Migrations.Migrations
{
    [Migration(20210901104000)]
    public class M001_AddPersonTable : Migration
    {
        private const string tableName = "Persons";

        public override void Up()
        {
            Create.Table(tableName)
                .WithColumn("PersonId").AsInt32().PrimaryKey().Identity(1, 1)
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable();
        }
        public override void Down()
        {
            Delete.Table(tableName);
        }
    }
}
