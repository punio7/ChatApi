namespace ChatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Powiedzonkoes",
                c => new
                    {
                        Wartosc = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Wartosc);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Powiedzonkoes");
        }
    }
}
