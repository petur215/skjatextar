namespace skjatextar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        DateLastEdited = c.DateTime(nullable: false),
                        VideoID = c.Int(nullable: false),
                        Name = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Translation");
        }
    }
}
