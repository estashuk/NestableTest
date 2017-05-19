namespace Nestable_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuConfig = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuDatas");
        }
    }
}
