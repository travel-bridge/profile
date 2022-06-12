using FluentMigrator;
using MigrationBase = Profile.Migrator.Migrations.MigrationBase;

namespace Excursions.Migrator.Migrations;

[TimestampedMigration(2022, 06, 12, 22, 31)]
public class AddProfile : MigrationBase
{
    public override void Up()
    {
        CreateTableIfNotExists(
            "profile",
            "Profile",
            table =>
            {
                table.WithColumn("Id").AsString(64).NotNullable().PrimaryKey("PK_Profile");
                table.WithColumn("Name").AsString(64).Nullable();
                table.WithColumn("Surname").AsString(64).Nullable();
                table.WithColumn("Description").AsString(512).Nullable();
                table.WithColumn("IsGuide").AsBoolean().NotNullable();
                table.WithColumn("IsTourist").AsBoolean().NotNullable();
                table.WithColumn("CreateDateTimeUtc").AsDateTime().NotNullable();
                table.WithColumn("UpdateDateTimeUtc").AsDateTime().Nullable();
            });
    }
}