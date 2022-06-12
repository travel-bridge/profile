using FluentMigrator;

namespace Profile.Migrator.Migrations;

[TimestampedMigration(2022, 06, 12, 22, 30)]
public class AddSchema : MigrationBase
{
    public override void Up()
    {
        Create.Schema("profile");
    }
}