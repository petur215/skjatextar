namespace skjatextar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TranslationID = c.Int(nullable: false),
                        CommentText = c.String(),
                        commentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TranslationID = c.Int(nullable: false),
                        RequestID = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        UserID = c.Int(),
                        LikeCount = c.Int(nullable: false),
                        NewRequest = c.String(),
                        RequestSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        LikeCount = c.Int(nullable: false),
                        Text = c.String(),
                        VideoID = c.Int(),
                        DeafCheck = c.String(),
                        DateLastEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Videos", t => t.VideoID)
                .Index(t => t.VideoID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(),
                        TranslationCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Translations", "VideoID", "dbo.Videos");
            DropForeignKey("dbo.Videos", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Requests", "UserID", "dbo.Users");
            DropIndex("dbo.Videos", new[] { "CategoryID" });
            DropIndex("dbo.Translations", new[] { "VideoID" });
            DropIndex("dbo.Requests", new[] { "UserID" });
            DropTable("dbo.Videos");
            DropTable("dbo.Translations");
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
