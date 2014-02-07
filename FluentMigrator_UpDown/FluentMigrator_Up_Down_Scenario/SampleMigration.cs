using FluentMigrator;

namespace FMDB
{
    [Migration(1)]
    public class SampleMigration_01 : Migration
    {
        public override void Up()
        {
            Create.Table("Table1").WithColumn("Id").AsInt32().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("Table1");
        }
    }

    [Migration(2)]
    public class SampleMigration_02 : Migration
    {
        public override void Up()
        {
            Create.Table("Table2").WithColumn("Id").AsInt32().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("Table2");
        }
    }
}
