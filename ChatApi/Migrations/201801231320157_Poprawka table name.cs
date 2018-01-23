namespace ChatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawkatablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Powiedzonkoes", newName: "TvGryPowiedzonka");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TvGryPowiedzonka", newName: "Powiedzonkoes");
        }
    }
}
